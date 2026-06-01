namespace PharmacyWinForms
{
    partial class LoginForm
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
            this.txtLogin = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.lblTitle = new Label();
            this.lblLogin = new Label();
            this.lblPassword = new Label();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.Location = new Point(80, 20);
            this.lblTitle.Size = new Size(240, 32);
            this.lblTitle.Text = "ИС Аптеки";
            this.lblTitle.Name = "lblTitle";

            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new Point(50, 80);
            this.lblLogin.Size = new Size(47, 15);
            this.lblLogin.Text = "Логин:";
            this.lblLogin.Name = "lblLogin";

            this.txtLogin.Location = new Point(120, 77);
            this.txtLogin.Size = new Size(200, 23);
            this.txtLogin.Name = "txtLogin";

            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(50, 120);
            this.lblPassword.Size = new Size(52, 15);
            this.lblPassword.Text = "Пароль:";
            this.lblPassword.Name = "lblPassword";

            this.txtPassword.Location = new Point(120, 117);
            this.txtPassword.Size = new Size(200, 23);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Name = "txtPassword";

            this.btnLogin.Location = new Point(120, 160);
            this.btnLogin.Size = new Size(200, 40);
            this.btnLogin.Text = "Вход";
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Click += new EventHandler(this.BtnLogin_Click);

            this.ClientSize = new Size(400, 240);
            this.Controls.AddRange(new Control[] {
                this.lblTitle,
                this.lblLogin,
                this.txtLogin,
                this.lblPassword,
                this.txtPassword,
                this.btnLogin
            });
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "Авторизация";
            this.Name = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblTitle;
        private Label lblLogin;
        private Label lblPassword;
    }
}