using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Storage
{
    public partial class StorageForm : Form
    {
        StorageContext context = new StorageContext();
        Client uClient;
        string connection = @"Data Source=DESKTOP-671K4J5\SQLEXPRESS; Initial Catalog = Storage; Integrated Security = True";
        public StorageForm(Client client)
        {
            InitializeComponent();
            uClient = client;
           
            if(client.ID_Client == 1)
            {
                buttonBack1.Visible = false;
                button1.Visible = false;
            }
            else if (client.ID_Client == 2)
            {
                buttonBack.Visible = false;
                button1.Visible = false;
            }
            else
            {
                buttonBack.Visible = false;
                buttonBack1.Visible = false;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminPanelForm form = new AdminPanelForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonStorage_Click(object sender, EventArgs e)
        {
            var tmp2 = context.Storage.Select(a => new { a.Name_Storage, a.Maker_Storage, a.Type_Storage, a.Price_Storage, a.Amount_Storage }).OrderBy(a => a.Name_Storage).Distinct().ToList();
            
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
                case "Maker":
                    SqlDataAdapter sdaM = new SqlDataAdapter("select Name_Storage, Maker_Storage, Type_Storage, Price_Storage, Amount_Storage from Storage order by Maker_Storage", connection);
                    DataTable dtM = new DataTable();
                    sdaM.Fill(dtM);
                    dataGridView1.DataSource = dtM;
                    break;
                case "Type":
                    SqlDataAdapter sdaT = new SqlDataAdapter("select Name_Storage, Maker_Storage, Type_Storage, Price_Storage, Amount_Storage from Storage order by Type_Storage", connection);
                    DataTable dtT = new DataTable();
                    sdaT.Fill(dtT);
                    dataGridView1.DataSource = dtT;
                    break;
                case "Price":
                    SqlDataAdapter sdaP = new SqlDataAdapter("select Name_Storage, Maker_Storage, Type_Storage, Price_Storage, Amount_Storage from Storage order by Price_Storage", connection);
                    DataTable dtP = new DataTable();
                    sdaP.Fill(dtP);
                    dataGridView1.DataSource = dtP;
                    break;
                case "Amount":
                    SqlDataAdapter sdaA = new SqlDataAdapter("select Name_Storage, Maker_Storage, Type_Storage, Price_Storage, Amount_Storage from Storage order by convert(int, Amount_Storage)", connection);
                    DataTable dtA = new DataTable();
                    sdaA.Fill(dtA);
                    dataGridView1.DataSource = dtA;
                    break;
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu form = new Menu(uClient);
            this.Hide();
            form.Show();
        }
    }
}
