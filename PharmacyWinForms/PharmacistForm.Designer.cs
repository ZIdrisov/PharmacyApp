namespace PharmacyWinForms
{
    partial class PharmacistForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvOrders = new DataGridView();
            this.btnAccept = new Button();
            this.btnIssue = new Button();
            this.btnRefresh = new Button();
            this.btnLogout = new Button();
            this.lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)this.dgvOrders).BeginInit();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Location = new Point(10, 15);
            this.lblTitle.Size = new Size(200, 25);
            this.lblTitle.Text = "Работа с заказами";

            this.dgvOrders.Location = new Point(10, 50);
            this.dgvOrders.Size = new Size(780, 400);
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.Name = "dgvOrders";

            this.btnAccept.Location = new Point(10, 460);
            this.btnAccept.Size = new Size(150, 40);
            this.btnAccept.Text = "Принять к сборке";
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Click += new EventHandler(this.BtnAccept_Click);

            this.btnIssue.Location = new Point(170, 460);
            this.btnIssue.Size = new Size(150, 40);
            this.btnIssue.Text = "Выдать заказ";
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Click += new EventHandler(this.BtnIssue_Click);

            this.btnRefresh.Location = new Point(690, 460);
            this.btnRefresh.Size = new Size(100, 40);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new EventHandler(this.BtnRefresh_Click);

            this.btnLogout.Location = new Point(330, 460);
            this.btnLogout.Size = new Size(120, 40);
            this.btnLogout.Text = "Сменить роль";
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = true;

            this.ClientSize = new Size(800, 520);
            this.Controls.AddRange(new Control[] { lblTitle, dgvOrders, btnAccept, btnIssue, btnRefresh, btnLogout });
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Панель фармацевта";
            this.BackColor = Color.White;

            ((System.ComponentModel.ISupportInitialize)this.dgvOrders).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DataGridView dgvOrders;
        private Button btnAccept;
        private Button btnIssue;
        private Button btnRefresh;
        private Button btnLogout;
        private Label lblTitle;
    }
}