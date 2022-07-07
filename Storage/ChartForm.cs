using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Storage
{
    public partial class ChartForm : Form
    {
        StorageContext context = new StorageContext();
        Client uClient;
       
        public ChartForm(Client client)
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


        private void button1_Click(object sender, EventArgs e)
        {
            var eachitem = context.Sell.Select(a => a.Name_Sell).Distinct().ToList();
            chart1.Series.Add("How many times has each item been sold");
            foreach (var nameitem in eachitem)
            {
                chart1.Series["How many times has each item been sold"].Points.AddXY(nameitem, context.Sell.Where(c => c.Name_Sell == nameitem).Count());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var eachitem = context.Buy.Select(a => a.Name_Buy).Distinct().ToList();
            chart2.Series.Add("How many times has each item been bought");
            foreach (var nameitem in eachitem)
            {
                chart2.Series["How many times has each item been bought"].Points.AddXY(nameitem, context.Buy.Where(c => c.Name_Buy == nameitem).Count());
            }
        }

        private void buttonMore_Click(object sender, EventArgs e)
        {
            MoreDiagForm form = new MoreDiagForm(uClient);
            this.Hide();
            form.Show();
        }
    }
}
