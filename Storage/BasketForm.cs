using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Storage
{
    public partial class BasketForm : Form 
    {
        StorageContext context = new StorageContext();
        Client uClient;
        Storage uStorage;
       
        public BasketForm(Client client, Storage storage)
        {
            InitializeComponent();
            uClient = client;
            uStorage = storage;
            
            var item = context.Storage.Where(a => a.Name_Storage == uStorage.Name_Storage).Select(c => new { c.Name_Storage, c.Maker_Storage, c.Type_Storage, c.Price_Storage, c.Amount_Storage }).ToList();
            dataGridViewBasket.DataSource = item;
            foreach (var aa in item)
            {
                for (int i = 1; i <= int.Parse(aa.Amount_Storage); i++)
                {
                    comboBox1.Items.Add(i);
                }
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                errorProvider1.Clear();
                Sell sell = new Sell
                {
                    ID_Storage = uStorage.ID_Storage,
                    ID_Client = uClient.ID_Client,
                    Name_Sell = uStorage.Name_Storage,
                    Maker_Sell = uStorage.Maker_Storage,
                    Type_Sell = uStorage.Type_Storage,
                    Price_Sell = int.Parse(label3.Text.Replace("$", "")),
                    Amount_Sell = comboBox1.SelectedItem.ToString(),
                    Data_Sell = DateTime.Now
                };
                context.Sell.Add(sell);

                var item = context.Storage.FirstOrDefault(a => a.Name_Storage == uStorage.Name_Storage);
                errorProvider1.Clear();
                item.Amount_Storage = "" + ((int.Parse(uStorage.Amount_Storage) - int.Parse(comboBox1.SelectedItem.ToString())));
                context.SaveChanges();

                var sdsd = context.Storage.Where(a => a.Name_Storage == uStorage.Name_Storage).Select(c => new { c.Name_Storage, c.Maker_Storage, c.Type_Storage, c.Price_Storage, c.Amount_Storage }).ToList();
                dataGridViewBasket.DataSource = sdsd;
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                foreach (var aa in sdsd)
                {
                    for (int i = 1; i <= int.Parse(aa.Amount_Storage); i++)
                    {
                        comboBox1.Items.Add(i);
                    }
                }
                MessageBox.Show("Thank you for your purchase!\nTake your promocode '2022' for discount on next order");
                Menu form = new Menu(uClient);
                this.Hide();
                form.Show();
            }
            else {errorProvider1.SetError(buttonBuy, "You have not selected the quantity");
        }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Menu form = new Menu(uClient);
            this.Hide();
            form.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if (comboBox1.SelectedItem != null)
            {
                var price = context.Storage.FirstOrDefault(a => a.Name_Storage == uStorage.Name_Storage.ToString());
                double i = double.Parse(comboBox1.SelectedItem.ToString()) * (double)price.Price_Storage;                
                label3.Visible = true;              
                label3.Text = i + "$";
            }
        }

        private void buttonPromo_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            { errorProvider1.SetError(textBoxPromo, "Choose the amount"); }
            else
            {
                var price = context.Storage.FirstOrDefault(a => a.Name_Storage == uStorage.Name_Storage.ToString());
                double i = double.Parse(comboBox1.SelectedItem.ToString()) * (double)price.Price_Storage;
                label3.Visible = true;
                label3.Text = i + "$";
                if (textBoxPromo.Text == "2022")
                {
                    errorProvider1.Clear();
                    label3.Text = i - 20 + "$";
                    MessageBox.Show("Promocode activated");
                }
                else
                {
                    errorProvider1.SetError(textBoxPromo, "Wrong promocode");
                }
            }
            
        }
    }
}
