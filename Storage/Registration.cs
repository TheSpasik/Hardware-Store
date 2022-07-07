using System;
using System.Windows.Forms;

namespace Storage
{
    public partial class Registration : Form
    {
        StorageContext context = new StorageContext();
        public Registration()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, EventArgs e)
        {
            errorProvider4.Clear();
            if (textBox1.Text.Replace(" ", "") != "" && textBox2.Text.Replace(" ", "") != "" && textBox3.Text.Replace(" ", "") != ""
                && textBox4.Text.Replace(" ", "") != "" && textBox5.Text.Replace(" ", "") != "" && textBox6.Text.Replace(" ", "") != "")
            {
                bool access = true;
                errorProvider1.Clear();                
                if (!int.TryParse(textBox6.Text, out int i))
                {
                    access = false;
                    errorProvider4.SetError(textBox6, "Phone can't be a string");
                }
                else { errorProvider4.Clear(); }
                if (access == true)
                {
                    Client client = new Client { Login = textBox1.Text, Password = textBox2.Text, Name_Client = textBox4.Text, Address_Client = textBox5.Text, Phone_Client = textBox6.Text };
                    context.Client.Add(client);
                    context.SaveChanges();
                    MessageBox.Show("You have successfully registered!");
                    Start st = new Start();
                    this.Hide();
                    st.Show();
                }
            }
            else { errorProvider1.SetError(reg, "Fill all fields"); }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Start st = new Start();
            this.Hide();
            st.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '*')
            {
                textBox3.PasswordChar = '\0';
            }
            else textBox3.PasswordChar = '*';
        }
    }
}
