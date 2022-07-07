using System;
using System.Windows.Forms;

namespace Storage
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            this.Hide();
            form.Show();
        }
    
    }
}
