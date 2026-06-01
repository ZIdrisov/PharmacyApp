using ISApteka.Services;
using ISApteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PharmacyWinForms
{
    public partial class LoginForm : Form
    {
        private EmployeeService _employeeService;

        public LoginForm(EmployeeService employeeService)
        {
            _employeeService = employeeService;
            InitializeComponent();
            this.FormClosing += LoginForm_FormClosing;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            btnLogin.Text = "Вход...";

            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                var user = await _employeeService.AuthenticateAsync(login, password);

                if (user != null)
                {
                    this.Hide();

                    if (user.Role == UserRole.Admin)
                    {
                        var adminForm = new AdminForm(_employeeService);
                        adminForm.ShowDialog();
                    }
                    else if (user.Role == UserRole.Pharmacist)
                    {
                        var pharmacistForm = new PharmacistForm();
                        pharmacistForm.ShowDialog();
                    }

                    this.Show();
                }
                else
                {
                    
                    this.Hide();

                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();

                    var optionsBuilder = new DbContextOptionsBuilder<ISApteka.Data.PharmacyContext>();
                    optionsBuilder.UseNpgsql(configuration.GetConnectionString("PharmacyDB"));

                    var context = new ISApteka.Data.PharmacyContext(optionsBuilder.Options);
                    var productRepo = new ISApteka.Repositories.ProductRepository(context);
                    var orderRepo = new ISApteka.Repositories.OrderRepository(context);
                    var productService = new ProductService(productRepo);
                    var orderService = new OrderService(orderRepo, productRepo);

                    var clientForm = new ClientForm(productService, orderService);
                    clientForm.ShowDialog();

                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка входа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Вход";
                txtPassword.Clear();
            }
        }
    }
}