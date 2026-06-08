using ISApteka.Services;
using Xunit;

namespace PharmacyWinForms.Tests;

public class OrderServiceTests
{
    [Fact]
    public async Task ConfirmOrderAsync_WithNullOrder_ThrowsNullReferenceException()
    {
        var service = new OrderService(null!, null!);
        
        await Assert.ThrowsAsync<NullReferenceException>(() => service.ConfirmOrderAsync(999));
    }

    [Fact]
    public async Task AcceptForPreparationAsync_WithNullOrder_ThrowsNullReferenceException()
    {
        var service = new OrderService(null!, null!);
        
        await Assert.ThrowsAsync<NullReferenceException>(() => service.AcceptForPreparationAsync(999));
    }

    [Fact]
    public async Task IssueOrderAsync_WithNullOrder_ThrowsNullReferenceException()
    {
        var service = new OrderService(null!, null!);
        
        await Assert.ThrowsAsync<NullReferenceException>(() => service.IssueOrderAsync(999));
    }

    // Этот тест уже должен работать
    [Fact]
    public async Task CreateCartAsync_WithNullOrder_ThrowsNullReferenceException()
    {
        var service = new OrderService(null!, null!);
        
        await Assert.ThrowsAsync<NullReferenceException>(() => service.CreateCartAsync());
    }
}