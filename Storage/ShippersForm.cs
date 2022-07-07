using System;
using System.Windows.Forms;

namespace Storage
{
    public partial class ShippersForm : Form
    {
        StorageContext context = new StorageContext();
        Client uClient;

        public ShippersForm(Client client)
        {
            InitializeComponent();
            uClient = client;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminPanelForm form = new AdminPanelForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (textBox1.Text.Replace(" ", "") != "" && textBox2.Text.Replace(" ", "") != "" && textBox3.Text.Replace(" ", "") != "")
            {
                bool access = true;
                errorProvider1.Clear();
                if (!int.TryParse(textBox3.Text, out int i))
                {
                    access = false;
                    errorProvider1.SetError(textBox3, "Phone can't be a string");
                }
                else { errorProvider1.Clear(); }
                if (access == true)
                {
                    Shipper shipper = new Shipper { Name_Shipper = textBox1.Text, Address_Shipper = textBox2.Text, Phone_Shipper = textBox3.Text };
                    context.Shipper.Add(shipper);
                    context.SaveChanges();
                    MessageBox.Show("Shipper added!");
                    AdminPanelForm form = new AdminPanelForm(uClient);
                    this.Hide();
                    form.Show();
                }
            }
            else
            {
                errorProvider1.SetError(buttonAdd, "Fill all fields");
            }
            
        }
    }
}
