using ISApteka.Models;
using ISApteka.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PharmacyWinForms
{
    public partial class AdminForm : Form
    {
        private EmployeeService _employeeService = null!;
        private ProductService _productService = null!;

        public AdminForm(EmployeeService employeeService)
        {
            _employeeService = employeeService;
            InitializeServices();
            InitializeComponent();
            LoadProducts();
            LoadEmployees();
            this.btnLogout.Click += btnLogout_Click;
        }

        private void InitializeServices()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ISApteka.Data.PharmacyContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PharmacyDB"));

            var context = new ISApteka.Data.PharmacyContext(optionsBuilder.Options);
            var productRepo = new ISApteka.Repositories.ProductRepository(context);
            _productService = new ProductService(productRepo);
        }

        private async void LoadProducts()
        {
            var products = await _productService.GetAllAsync();
            dataGridViewProducts.DataSource = products.Select(p => new
            {
                p.Id,
                p.Name,
                Price = $"{p.Price:F2} руб."
            }).ToList();
        }

        private async void LoadEmployees()
        {
            var employees = await _employeeService.GetAllAsync();
            dataGridViewEmployees.DataSource = employees.Select(e => new
            {
                e.Id,
                e.Login,
                Role = e.Role == UserRole.Admin ? "Администратор" : "Фармацевт"
            }).ToList();
        }

        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            var dialog = new ProductDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await _productService.AddAsync(dialog.ProductNameValue, dialog.ProductPriceValue);
                LoadProducts();
                MessageBox.Show("Товар добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells["Id"].Value);
            var product = await _productService.GetByIdAsync(id);

            var dialog = new ProductDialog(product.Name, product.Price);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await _productService.UpdateAsync(id, dialog.ProductNameValue, dialog.ProductPriceValue);
                LoadProducts();
                MessageBox.Show("Товар обновлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewProducts.SelectedRows[0].Cells["Id"].Value);

            if (MessageBox.Show("Удалить товар?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _productService.DeleteAsync(id);
                LoadProducts();
                MessageBox.Show("Товар удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnAssignPharmacist_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dataGridViewEmployees.SelectedRows[0].Cells["Id"].Value);

            try
            {
                await _employeeService.AssignPharmacistAsync(id);
                LoadEmployees();
                MessageBox.Show("Сотрудник назначен фармацевтом!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshProducts_Click(object sender, EventArgs e) => LoadProducts();
        private void btnRefreshEmployees_Click(object sender, EventArgs e) => LoadEmployees();
        private void btnLogout_Click(object sender, EventArgs e) => this.Close();
    }
}