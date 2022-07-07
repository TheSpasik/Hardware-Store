using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Storage
{
    public partial class EditForm : Form
    {
        StorageContext context = new StorageContext();
        Client uClient;
        public EditForm(Client client)
        {
            InitializeComponent();
            uClient = client;
       
            buttonDeleteShipper.Visible = false;
            buttonDeleteClient.Visible = false;
            if (client.ID_Client == 1)
            {
                buttonDeleteShipper.Visible = false;
                buttonDeleteClient.Visible = false;
                buttonModer.Visible = false;
            }
            else if (client.ID_Client == 2)
            {
                buttonBack.Visible = false;
                label1.Visible = false;
                buttonDeleteShipper.Visible = false;
                buttonDeleteClient.Visible = false;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminPanelForm form = new AdminPanelForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonShipper_Click(object sender, EventArgs e)
        {
           
            var tmp = context.Shipper.Select(a => new { a.Name_Shipper, a.Address_Shipper, a.Phone_Shipper }).Distinct().ToList();

            dataGridView1.DataSource = tmp;

            if (uClient.ID_Client == 1)
            {
                buttonDeleteShipper.Visible = true;
                buttonDeleteClient.Visible = false;
            }
            else if (uClient.ID_Client == 2)
            {
                buttonDeleteShipper.Visible = false; ;
                buttonDeleteClient.Visible = false;
            }
            
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            
            var tmp = context.Client.Where(a => a.Login != "admin").Select(a => new { a.Login, a.Password, a.Name_Client, a.Address_Client, a.Phone_Client }).OrderBy(a => a.Login).Distinct().ToList();

            dataGridView1.DataSource = tmp;


            if (uClient.ID_Client == 1)
            {
                buttonDeleteShipper.Visible = false;
                buttonDeleteClient.Visible = true;
            }
            else if (uClient.ID_Client == 2)
            {
                buttonDeleteShipper.Visible = false; ;
                buttonDeleteClient.Visible = false;
            }
            

        }


        private void buttonDeleteShipper_Click(object sender, EventArgs e)
        {
         
            int row = dataGridView1.CurrentRow.Index;
            var dlt = dataGridView1[0, row].Value.ToString();
            var find = context.Shipper.FirstOrDefault(a => a.Name_Shipper == dlt);
            context.Shipper.Remove(find);
            context.SaveChanges();
            var tmp = context.Shipper.Select(a => new { a.Name_Shipper, a.Address_Shipper, a.Phone_Shipper }).Distinct().ToList();

            dataGridView1.DataSource = tmp;
            MessageBox.Show("Shipper deleted");
        }

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            var dlt = dataGridView1[0, row].Value.ToString();
            var find = context.Client.FirstOrDefault(a => a.Login == dlt);
            context.Client.Remove(find);
            context.SaveChanges();
            var tmp = context.Client.Where(a => a.Login != "admin").Select(a => new { a.Login, a.Password, a.Name_Client, a.Address_Client, a.Phone_Client }).OrderBy(a => a.Login).Distinct().ToList();

            dataGridView1.DataSource = tmp;
            MessageBox.Show("Client deleted");

        }

        private void buttonModer_Click(object sender, EventArgs e)
        {
            ModeratorPanelForm form = new ModeratorPanelForm(uClient);
            this.Hide();
            form.Show();
        }
    }
}
