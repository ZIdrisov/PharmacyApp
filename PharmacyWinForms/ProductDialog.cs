using System;
using System.Windows.Forms;
using System.Xml.Linq;
using System;
using System.Windows.Forms;

namespace PharmacyWinForms
{
    public partial class ProductDialog : Form
    {
        public string ProductNameValue => txtName.Text;
        public decimal ProductPriceValue => decimal.Parse(txtPrice.Text);

        public ProductDialog(string name = "", decimal price = 0)
        {
            InitializeComponent();
            txtName.Text = name;
            txtPrice.Text = price > 0 ? price.ToString() : "";
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену (>0)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
        }
    }
}