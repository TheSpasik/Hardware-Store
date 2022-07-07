using System;
using System.Linq;
using System.Windows.Forms;

namespace Storage
{
    public partial class Start : Form
    {
        StorageContext context = new StorageContext();
        
        public Start()
        {
            InitializeComponent();
        }
        private void login_Click(object sender, EventArgs e)
        {
            var client = context.Client.FirstOrDefault(a => a.Login == textBox1.Text && a.Password == textBox2.Text);
            if (client == null)
            {
                errorProvider1.SetError(login, "Wrong login or password");
            }
            else if(client.ID_Client == 1)
            {
                errorProvider1.Clear();
                AdminPanelForm form = new AdminPanelForm(client);
                this.Hide();
                form.Show();
            }
            else if (client.ID_Client == 2)
            {
                errorProvider1.Clear();
                ModeratorPanelForm form = new ModeratorPanelForm(client);
                this.Hide();
                form.Show();
            }
            else
            {
                errorProvider1.Clear();
                Menu form = new Menu(client);
                this.Hide();
                form.Show();
            }
        }
        private void registration_Click(object sender, EventArgs e)
        {
            Registration form = new Registration();
            this.Hide();
            form.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
            }
            else textBox2.PasswordChar = '*';
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            WelcomeForm form = new WelcomeForm();
            this.Hide();
            form.Show();
        }
    }
}
