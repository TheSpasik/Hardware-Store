using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Storage
{
    public partial class MoreDiagForm : Form
    {
        StorageContext context = new StorageContext();
        Client uClient;
        public MoreDiagForm(Client client)
        {
            InitializeComponent();
            uClient = client;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ChartForm form = new ChartForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {           
            var buy = context.Buy.ToList();
            var sell = context.Sell.ToList();
            decimal sum = 0;
            decimal sum1 = 0;
            foreach (var a in buy)
            {
                sum += a.Price_Buy * decimal.Parse(a.Amount_Buy);
            }
            foreach (var a in sell)
            {
                sum1 += a.Price_Sell * decimal.Parse(a.Amount_Sell);
            }
            
            chart1.Series["Price of each item"].Points.AddXY("Buy", sum);
            chart1.Series["Price of each item"].Points.AddXY("Sell", sum1);
            labelProfit.Text = (sum1 - sum).ToString() + "$";
            labelProfit.Visible = true;
            label3.Text = ((sum1/sum)*100).ToString().Substring(0,6) + "%";           
            label3.Visible = true;
            label6.Text = (sum / (sum1 + sum) * 100).ToString().Substring(0, 5) + "%";
            label6.Visible = true;
            label7.Text = (sum1 / (sum1 + sum) * 100).ToString().Substring(0, 5) + "%";
            label7.Visible = true;

        }
    }
}
