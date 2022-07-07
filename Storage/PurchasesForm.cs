using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Storage
{
    public partial class PurchasesForm : Form
    {
        StorageContext context = new StorageContext();
        Client uClient;
        public PurchasesForm(Client client)
        {
            InitializeComponent();
            uClient = client;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            var tmp2 = context.Sell.Where(a => a.ID_Client == uClient.ID_Client).Select(a => new { a.Name_Sell, a.Maker_Sell, a.Type_Sell, a.Price_Sell, a.Amount_Sell, a.Data_Sell }).ToList();
            dataGridView1.DataSource = tmp2;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Menu form = new Menu(uClient);
            this.Hide();
            form.Show();
        }
    }
}
