namespace PharmacyWinForms
{
    partial class ProductDialog
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
            this.txtName = new TextBox();
            this.txtPrice = new TextBox();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.lblName = new Label();
            this.lblPrice = new Label();
            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(20, 25);
            this.lblName.Size = new Size(62, 15);
            this.lblName.Text = "Название:";

            // txtName
            this.txtName.Location = new Point(90, 22);
            this.txtName.Size = new Size(200, 23);
            this.txtName.Name = "txtName";

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new Point(20, 60);
            this.lblPrice.Size = new Size(38, 15);
            this.lblPrice.Text = "Цена:";

            // txtPrice
            this.txtPrice.Location = new Point(90, 57);
            this.txtPrice.Size = new Size(200, 23);
            this.txtPrice.Name = "txtPrice";

            // btnOk
            this.btnOk.Location = new Point(90, 100);
            this.btnOk.Size = new Size(90, 30);
            this.btnOk.Text = "OK";
            this.btnOk.DialogResult = DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.Click += new EventHandler(this.BtnOk_Click);

            // btnCancel
            this.btnCancel.Location = new Point(200, 100);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";

            // ProductDialog
            this.ClientSize = new Size(320, 160);
            this.Controls.AddRange(new Control[] { lblName, txtName, lblPrice, txtPrice, btnOk, btnCancel });
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "Товар";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private TextBox txtName;
        private TextBox txtPrice;
        private Button btnOk;
        private Button btnCancel;
        private Label lblName;
        private Label lblPrice;
    }
}