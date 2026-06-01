using ISApteka.Services;
using ISApteka.Models;

namespace PharmacyWinForms
{
    public partial class ClientForm : Form
    {
        private ProductService _productService;
        private OrderService _orderService;
        private int _currentCartId;
        private bool _isLoading = true;

        public ClientForm(ProductService productService, OrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
            InitializeComponent();
            LoadDataAsync();
            this.btnLogout.Click += btnLogout_Click;
        }

        private async void LoadDataAsync()
        {
            try
            {
                btnAddToCart.Enabled = false;
                btnViewCart.Enabled = false;
                btnCheckout.Enabled = false;

                await LoadProductsAsync();
                await CreateNewCartAsync();

                btnAddToCart.Enabled = true;
                btnViewCart.Enabled = true;
                btnCheckout.Enabled = true;
            }
            catch (Exception ex)
            {
                string fullError = ex.Message;
                if (ex.InnerException != null)
                    fullError += $"\n\nВнутренняя ошибка:\n{ex.InnerException.Message}";
                MessageBox.Show($"Ошибка загрузки: {fullError}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private async Task LoadProductsAsync()
        {
            var products = await _productService.GetAllAsync();
            dataGridViewProducts.DataSource = products.Select(p => new
            {
                p.Id,
                p.Name,
                Price = $"{p.Price:F2} руб."
            }).ToList();
        }

        private async Task CreateNewCartAsync()
        {
            var cart = await _orderService.CreateCartAsync();
            _currentCartId = cart.Id;
        }

        private async void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (_isLoading)
            {
                MessageBox.Show("Подождите, данные загружаются...", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnAddToCart.Enabled = false;
                int productId = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells["Id"].Value);
                await _orderService.AddToCartAsync(_currentCartId, productId);
                MessageBox.Show("Товар добавлен в корзину!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAddToCart.Enabled = true;
            }
        }

        private async void btnViewCart_Click(object sender, EventArgs e)
        {
            if (_isLoading)
            {
                MessageBox.Show("Подождите, данные загружаются...", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                btnViewCart.Enabled = false;
                var cart = await _orderService.GetByIdAsync(_currentCartId);

                if (cart == null || !cart.Items.Any())
                {
                    MessageBox.Show("Корзина пуста", "Корзина",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string message = "Ваша корзина:\n\n";
                decimal total = 0;
                foreach (var item in cart.Items)
                {
                    decimal itemTotal = item.Price * item.Quantity;
                    total += itemTotal;
                    message += $"{item.ProductName} x{item.Quantity} = {itemTotal:F2} руб.\n";
                }
                message += $"\nИтого: {total:F2} руб.";

                MessageBox.Show(message, "Корзина",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnViewCart.Enabled = true;
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_isLoading)
            {
                MessageBox.Show("Подождите, данные загружаются...", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                btnCheckout.Enabled = false;

                var cart = await _orderService.GetByIdAsync(_currentCartId);
                if (cart == null || !cart.Items.Any())
                {
                    MessageBox.Show("Корзина пуста. Добавьте товары перед оформлением.", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Подтвердить заказ?", "Оформление заказа",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var order = await _orderService.ConfirmOrderAsync(_currentCartId);
                    MessageBox.Show($"Заказ №{order.Id} успешно оформлен!\nСтатус: Новый",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CreateNewCartAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка оформления заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCheckout.Enabled = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}