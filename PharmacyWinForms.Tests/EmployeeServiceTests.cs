using ISApteka.Services;
using Xunit;

namespace PharmacyWinForms.Tests;

public class EmployeeServiceTests
{
    [Fact]
    public async Task AuthenticateAsync_WithNullRepo_ThrowsNullReferenceException()
    {
        var service = new EmployeeService(null!);
        
        await Assert.ThrowsAsync<NullReferenceException>(() => service.AuthenticateAsync("admin", "123"));
    }

    [Fact]
    public async Task AssignPharmacistAsync_WithNullRepo_ThrowsNullReferenceException()
    {
        var service = new EmployeeService(null!);
        
        await Assert.ThrowsAsync<NullReferenceException>(() => service.AssignPharmacistAsync(999));
    }
}