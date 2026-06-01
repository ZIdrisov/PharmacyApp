using ISApteka.Models;
using ISApteka.Repositories;

namespace ISApteka.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly ProductRepository _productRepository;

        public OrderService(OrderRepository orderRepository, ProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<Order> CreateCartAsync()
        {
            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,  
                Status = OrderStatus.New,
                Items = new List<OrderItem>()
            };
            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task AddToCartAsync(int orderId, int productId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new ArgumentException("Корзина не найдена");

            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new ArgumentException("Товар не найден");

            var existingItem = order.Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                order.Items.Add(new OrderItem
                {
                    OrderId = orderId,
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }

            await _orderRepository.UpdateAsync(order);
        }

        public async Task<Order> ConfirmOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new ArgumentException("Заказ не найден");

            if (order.Status != OrderStatus.New)
                throw new InvalidOperationException("Заказ уже обработан");

            if (!order.Items.Any())
                throw new InvalidOperationException("Нельзя оформить пустой заказ");

            await _orderRepository.UpdateAsync(order);
            return order;
        }

        public async Task AcceptForPreparationAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new ArgumentException("Заказ не найден");

            if (order.Status != OrderStatus.New)
                throw new InvalidOperationException("Заказ не в статусе 'Новый'");

            order.Status = OrderStatus.Ready;
            await _orderRepository.UpdateAsync(order);
        }

        public async Task IssueOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new ArgumentException("Заказ не найден");

            if (order.Status != OrderStatus.Ready)
                throw new InvalidOperationException("Заказ не готов к выдаче");

            order.Status = OrderStatus.Issued;
            await _orderRepository.UpdateAsync(order);
        }

        public async Task<List<Order>> GetByStatusAsync(OrderStatus status)
        {
            var all = await _orderRepository.GetAllAsync();
            return all.Where(o => o.Status == status).ToList();
        }
    }
}