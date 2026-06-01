namespace PharmacyWinForms
{
    partial class AdminForm
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
            this.tabControl1 = new TabControl();
            this.tabPageProducts = new TabPage();
            this.dataGridViewProducts = new DataGridView();
            this.btnAddProduct = new Button();
            this.btnEditProduct = new Button();
            this.btnDeleteProduct = new Button();
            this.btnRefreshProducts = new Button();
            this.tabPageEmployees = new TabPage();
            this.dataGridViewEmployees = new DataGridView();
            this.btnAssignPharmacist = new Button();
            this.btnRefreshEmployees = new Button();
            this.tabControl1.SuspendLayout();
            this.tabPageProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewProducts).BeginInit();
            this.tabPageEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewEmployees).BeginInit();
            this.SuspendLayout();

            // tabControl1
            this.tabControl1.Controls.Add(this.tabPageProducts);
            this.tabControl1.Controls.Add(this.tabPageEmployees);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new Size(900, 500);
            this.tabControl1.TabIndex = 0;

            // tabPageProducts
            this.tabPageProducts.Controls.Add(this.dataGridViewProducts);
            this.tabPageProducts.Controls.Add(this.btnAddProduct);
            this.tabPageProducts.Controls.Add(this.btnEditProduct);
            this.tabPageProducts.Controls.Add(this.btnDeleteProduct);
            this.tabPageProducts.Controls.Add(this.btnRefreshProducts);
            this.tabPageProducts.Location = new Point(4, 24);
            this.tabPageProducts.Name = "tabPageProducts";
            this.tabPageProducts.Padding = new Padding(3);
            this.tabPageProducts.Size = new Size(892, 472);
            this.tabPageProducts.TabIndex = 0;
            this.tabPageProducts.Text = "Товары";

            // dataGridViewProducts
            this.dataGridViewProducts.Location = new Point(6, 6);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.Size = new Size(880, 380);
            this.dataGridViewProducts.TabIndex = 0;
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.MultiSelect = false;

            // btnAddProduct
            this.btnAddProduct.Location = new Point(6, 392);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new Size(100, 40);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "Добавить";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new EventHandler(this.btnAddProduct_Click);

            // btnEditProduct
            this.btnEditProduct.Location = new Point(112, 392);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new Size(100, 40);
            this.btnEditProduct.TabIndex = 2;
            this.btnEditProduct.Text = "Редактировать";
            this.btnEditProduct.UseVisualStyleBackColor = true;
            this.btnEditProduct.Click += new EventHandler(this.btnEditProduct_Click);

            // btnDeleteProduct
            this.btnDeleteProduct.Location = new Point(218, 392);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new Size(100, 40);
            this.btnDeleteProduct.TabIndex = 3;
            this.btnDeleteProduct.Text = "Удалить";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new EventHandler(this.btnDeleteProduct_Click);

            // btnRefreshProducts
            this.btnRefreshProducts.Location = new Point(786, 392);
            this.btnRefreshProducts.Name = "btnRefreshProducts";
            this.btnRefreshProducts.Size = new Size(100, 40);
            this.btnRefreshProducts.TabIndex = 4;
            this.btnRefreshProducts.Text = "Обновить";
            this.btnRefreshProducts.UseVisualStyleBackColor = true;
            this.btnRefreshProducts.Click += new EventHandler(this.btnRefreshProducts_Click);

            // tabPageEmployees
            this.tabPageEmployees.Controls.Add(this.dataGridViewEmployees);
            this.tabPageEmployees.Controls.Add(this.btnAssignPharmacist);
            this.tabPageEmployees.Controls.Add(this.btnRefreshEmployees);
            this.tabPageEmployees.Location = new Point(4, 24);
            this.tabPageEmployees.Name = "tabPageEmployees";
            this.tabPageEmployees.Padding = new Padding(3);
            this.tabPageEmployees.Size = new Size(892, 472);
            this.tabPageEmployees.TabIndex = 1;
            this.tabPageEmployees.Text = "Сотрудники";

            // dataGridViewEmployees
            this.dataGridViewEmployees.Location = new Point(6, 6);
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.Size = new Size(880, 380);
            this.dataGridViewEmployees.TabIndex = 0;
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployees.MultiSelect = false;

            // btnAssignPharmacist
            this.btnAssignPharmacist.Location = new Point(6, 392);
            this.btnAssignPharmacist.Name = "btnAssignPharmacist";
            this.btnAssignPharmacist.Size = new Size(150, 40);
            this.btnAssignPharmacist.TabIndex = 1;
            this.btnAssignPharmacist.Text = "Назначить фармацевтом";
            this.btnAssignPharmacist.UseVisualStyleBackColor = true;
            this.btnAssignPharmacist.Click += new EventHandler(this.btnAssignPharmacist_Click);

            // btnRefreshEmployees
            this.btnRefreshEmployees.Location = new Point(786, 392);
            this.btnRefreshEmployees.Name = "btnRefreshEmployees";
            this.btnRefreshEmployees.Size = new Size(100, 40);
            this.btnRefreshEmployees.TabIndex = 2;
            this.btnRefreshEmployees.Text = "Обновить";
            this.btnRefreshEmployees.UseVisualStyleBackColor = true;
            this.btnRefreshEmployees.Click += new EventHandler(this.btnRefreshEmployees_Click);

            this.btnLogout = new Button();
            this.btnLogout.Location = new Point(560, 392);
            this.btnLogout.Size = new Size(120, 40);
            this.btnLogout.Text = "Сменить роль";
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.tabPageProducts.Controls.Add(this.btnLogout);

            // AdminForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 500);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdminForm";
            this.Text = "Панель администратора";
            this.tabControl1.ResumeLayout(false);
            this.tabPageProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewProducts).EndInit();
            this.tabPageEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewEmployees).EndInit();
            this.ResumeLayout(false);
        }

        private TabControl tabControl1;
        private TabPage tabPageProducts;
        private TabPage tabPageEmployees;
        private DataGridView dataGridViewProducts;
        private DataGridView dataGridViewEmployees;
        private Button btnAddProduct;
        private Button btnEditProduct;
        private Button btnDeleteProduct;
        private Button btnRefreshProducts;
        private Button btnAssignPharmacist;
        private Button btnRefreshEmployees;
        private Button btnLogout;
    }
}