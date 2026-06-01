using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISApteka.Models;
using ISApteka.Repositories;

namespace ISApteka.Services
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Введите название товара");
            if (price <= 0)
                throw new ArgumentException("Цена должна быть положительным числом");

            var product = new Product { Name = name, Price = price };
            await _repository.AddAsync(product);
        }

        public async Task UpdateAsync(int id, string name, decimal price)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                throw new ArgumentException("Товар не найден");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название не может быть пустым");
            if (price <= 0)
                throw new ArgumentException("Цена должна быть положительной");

            product.Name = name;
            product.Price = price;
            await _repository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}