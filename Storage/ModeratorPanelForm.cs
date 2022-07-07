using System;
using System.Windows.Forms;

namespace Storage
{
    public partial class ModeratorPanelForm : Form
    {
        StorageContext context = new StorageContext();
        Client uClient;

        public ModeratorPanelForm(Client client)
        {
            InitializeComponent();
            uClient = client;
        }

        private void buttonStorage_Click(object sender, EventArgs e)
        {
            StorageForm form = new StorageForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonSaleInfo_Click(object sender, EventArgs e)
        {
            SalesInfoForm form = new SalesInfoForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            this.Hide();
            form.Show();
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            EditForm form = new EditForm(uClient);
            this.Hide();
            form.Show();
        }
    }
}
