using ISApteka.Services;
using Xunit;

namespace PharmacyWinForms.Tests;

public class ProductServiceTests
{
    [Fact]
    public async Task AddAsync_EmptyName_ThrowsException()
    {
        // Тестируем только валидацию, без реального репозитория
        // Для этого создадим сервис с null репозиторием — валидация сработает до обращения к нему
        var service = new ProductService(null!);
        
        await Assert.ThrowsAsync<ArgumentException>(() => service.AddAsync("", 100.00m));
    }

    [Fact]
    public async Task AddAsync_ZeroPrice_ThrowsException()
    {
        var service = new ProductService(null!);
        
        await Assert.ThrowsAsync<ArgumentException>(() => service.AddAsync("Аспирин", 0));
    }

    [Fact]
    public async Task AddAsync_NegativePrice_ThrowsException()
    {
        var service = new ProductService(null!);
        
        await Assert.ThrowsAsync<ArgumentException>(() => service.AddAsync("Аспирин", -50));
    }
}