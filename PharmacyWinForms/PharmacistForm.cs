using ISApteka.Models;
using ISApteka.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PharmacyWinForms
{
    public partial class PharmacistForm : Form
    {
        private OrderService _orderService;

        public PharmacistForm()
        {
            InitializeServices();
            InitializeComponent();
            LoadOrders();
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
            var orderRepo = new ISApteka.Repositories.OrderRepository(context);
            _orderService = new OrderService(orderRepo, productRepo);
        }

        private async void LoadOrders()
        {
            try
            {
                var orders = await _orderService.GetAllAsync();

                var data = orders.Select(o => new
                {
                    Id = o.Id,
                    CreatedAt = o.CreatedAt.ToString("dd.MM.yyyy HH:mm"),
                    Status = o.Status switch
                    {
                        OrderStatus.New => "Новый",
                        OrderStatus.Ready => "Готов к выдаче",
                        OrderStatus.Issued => "Выдан",
                        _ => "Неизвестно"
                    },
                    ItemsCount = o.Items.Sum(i => i.Quantity),
                    TotalSum = o.Items.Sum(i => i.Price * i.Quantity)
                }).ToList();

                dgvOrders.DataSource = data;

                if (dgvOrders.Columns.Contains("Id"))
                    dgvOrders.Columns["Id"].HeaderText = "№ заказа";
                if (dgvOrders.Columns.Contains("CreatedAt"))
                    dgvOrders.Columns["CreatedAt"].HeaderText = "Дата создания";
                if (dgvOrders.Columns.Contains("Status"))
                    dgvOrders.Columns["Status"].HeaderText = "Статус";
                if (dgvOrders.Columns.Contains("ItemsCount"))
                    dgvOrders.Columns["ItemsCount"].HeaderText = "Кол-во товаров";
                if (dgvOrders.Columns.Contains("TotalSum"))
                    dgvOrders.Columns["TotalSum"].HeaderText = "Сумма, руб";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAccept_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);
            string status = dgvOrders.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "";

            if (status != "Новый")
            {
                MessageBox.Show("Только заказы со статусом 'Новый' можно принять к сборке",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnAccept.Enabled = false;
                await _orderService.AcceptForPreparationAsync(id);
                await LoadOrdersAsync();
                MessageBox.Show("Заказ принят к сборке!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string fullError = ex.Message;
                if (ex.InnerException != null)
                    fullError += $"\n\n{ex.InnerException.Message}";
                MessageBox.Show($"Ошибка: {fullError}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAccept.Enabled = true;
            }
        }

        private async void BtnIssue_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);
            string status = dgvOrders.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "";

            if (status != "Готов к выдаче")
            {
                MessageBox.Show("Только заказы со статусом 'Готов к выдаче' можно выдавать",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnIssue.Enabled = false;
                await _orderService.IssueOrderAsync(id);
                await LoadOrdersAsync();
                MessageBox.Show("Заказ выдан клиенту!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string fullError = ex.Message;
                if (ex.InnerException != null)
                    fullError += $"\n\n{ex.InnerException.Message}";
                MessageBox.Show($"Ошибка: {fullError}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnIssue.Enabled = true;
            }
        }

        private async Task LoadOrdersAsync()
        {
            try
            {
                var orders = await _orderService.GetAllAsync();

                var data = orders.Select(o => new
                {
                    Id = o.Id,
                    CreatedAt = o.CreatedAt.ToString("dd.MM.yyyy HH:mm"),
                    Status = o.Status switch
                    {
                        OrderStatus.New => "Новый",
                        OrderStatus.Ready => "Готов к выдаче",
                        OrderStatus.Issued => "Выдан",
                        _ => "Неизвестно"
                    },
                    ItemsCount = o.Items.Sum(i => i.Quantity),
                    TotalSum = o.Items.Sum(i => i.Price * i.Quantity)
                }).ToList();

                dgvOrders.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            await LoadOrdersAsync();
            btnRefresh.Enabled = true;
        }

        private void btnLogout_Click(object sender, EventArgs e) => this.Close();
    }
}