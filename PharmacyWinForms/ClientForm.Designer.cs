namespace PharmacyWinForms
{
    partial class ClientForm
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
            this.dataGridViewProducts = new DataGridView();
            this.btnAddToCart = new Button();
            this.btnViewCart = new Button();
            this.btnCheckout = new Button();
            this.btnLogout = new Button();
            this.lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.Location = new Point(10, 15);
            this.lblTitle.Size = new Size(180, 30);
            this.lblTitle.Text = "Каталог товаров";
            this.lblTitle.Name = "lblTitle";

            this.dataGridViewProducts.Location = new Point(10, 60);
            this.dataGridViewProducts.Size = new Size(600, 350);
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.MultiSelect = false;
            this.dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.Name = "dataGridViewProducts";

            this.btnAddToCart.Location = new Point(10, 420);
            this.btnAddToCart.Size = new Size(150, 40);
            this.btnAddToCart.Text = "Добавить в корзину";
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new EventHandler(this.btnAddToCart_Click);

            this.btnViewCart.Location = new Point(170, 420);
            this.btnViewCart.Size = new Size(150, 40);
            this.btnViewCart.Text = "Корзина";
            this.btnViewCart.Name = "btnViewCart";
            this.btnViewCart.UseVisualStyleBackColor = true;
            this.btnViewCart.Click += new EventHandler(this.btnViewCart_Click);

            this.btnCheckout.Location = new Point(460, 420);
            this.btnCheckout.Size = new Size(150, 40);
            this.btnCheckout.Text = "Оформить заказ";
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new EventHandler(this.btnCheckout_Click);

            this.btnLogout.Location = new Point(330, 420);
            this.btnLogout.Size = new Size(120, 40);
            this.btnLogout.Text = "Сменить роль";
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.UseVisualStyleBackColor = true;

            this.ClientSize = new Size(620, 480);
            this.Text = "Аптека - Клиент";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.btnViewCart);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.btnLogout);
            this.Name = "ClientForm";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DataGridView dataGridViewProducts;
        private Button btnAddToCart;
        private Button btnViewCart;
        private Button btnCheckout;
        private Button btnLogout;
        private Label lblTitle;
    }
}