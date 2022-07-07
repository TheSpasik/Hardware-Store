using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Storage
{
    public partial class SalesInfoForm : Form
    {
        StorageContext context = new StorageContext();
        Client uClient;
        string connection = @"Data Source=DESKTOP-671K4J5\SQLEXPRESS; Initial Catalog = Storage; Integrated Security = True";
        public SalesInfoForm(Client client)
        {
            InitializeComponent();
            uClient = client;
            if (client.ID_Client == 1)
            {
                buttonBack1.Visible = false;
            }
            else if (client.ID_Client == 2)
            {
                buttonBack.Visible = false;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminPanelForm form = new AdminPanelForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            var tmp2 = context.Sell.Select(a => new { a.ID_Sell, a.ID_Storage, a.ID_Client, a.Name_Sell, a.Maker_Sell, a.Type_Sell, a.Price_Sell, a.Amount_Sell, a.Data_Sell }).ToList();
            dataGridView1.DataSource = tmp2;
        }

        private void buttonBack1_Click(object sender, EventArgs e)
        {
            ModeratorPanelForm form = new ModeratorPanelForm(uClient);
            this.Hide();
            form.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Name":
                    SqlDataAdapter sdaN = new SqlDataAdapter("select * from Sell order by Name_Sell", connection);
                    DataTable dtN = new DataTable();
                    sdaN.Fill(dtN);
                    dataGridView1.DataSource = dtN;
                    break;
                case "Maker":
                    SqlDataAdapter sdaM = new SqlDataAdapter("select * from Sell order by Maker_Sell", connection);
                    DataTable dtM = new DataTable();
                    sdaM.Fill(dtM);
                    dataGridView1.DataSource = dtM;
                    break;
                case "Type":
                    SqlDataAdapter sdaT = new SqlDataAdapter("select * from Sell order by Type_Sell", connection);
                    DataTable dtT = new DataTable();
                    sdaT.Fill(dtT);
                    dataGridView1.DataSource = dtT;
                    break;
                case "Price":
                    SqlDataAdapter sdaP = new SqlDataAdapter("select * from Sell order by Price_Sell", connection);
                    DataTable dtP = new DataTable();
                    sdaP.Fill(dtP);
                    dataGridView1.DataSource = dtP;
                    break;
                case "Amount":
                    SqlDataAdapter sdaA = new SqlDataAdapter("select * from Sell order by convert(int, Amount_Sell)", connection);
                    DataTable dtA = new DataTable();
                    sdaA.Fill(dtA);
                    dataGridView1.DataSource = dtA;
                    break;
                case "Data":
                    SqlDataAdapter sdaD = new SqlDataAdapter("select * from Sell order by Data_Sell", connection);
                    DataTable dtD = new DataTable();
                    sdaD.Fill(dtD);
                    dataGridView1.DataSource = dtD;
                    break;
            }
        }
    }
}
