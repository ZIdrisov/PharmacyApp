using ISApteka.Data;
using ISApteka.Repositories;
using ISApteka.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PharmacyWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                var services = new ServiceCollection();

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

                services.AddDbContext<PharmacyContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PharmacyDB")));

                services.AddScoped<ProductRepository>();
                services.AddScoped<OrderRepository>();
                services.AddScoped<EmployeeRepository>();
                services.AddScoped<ProductService>();
                services.AddScoped<OrderService>();
                services.AddScoped<EmployeeService>();
                services.AddScoped<ClientForm>();

                var serviceProvider = services.BuildServiceProvider();

                var loginForm = new LoginForm(serviceProvider.GetRequiredService<EmployeeService>());
                loginForm.ShowDialog();

                if (loginForm.IsDisposed || loginForm.DialogResult == DialogResult.Cancel)
                {
                    break;
                }
            }
        }
    }
}