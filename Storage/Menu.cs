using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Storage
{
    public partial class Menu : Form
    {
        StorageContext context = new StorageContext();
        Client uClient;
        Client GoBasketForm;
        public Menu(Client client)
        {
            
            InitializeComponent();
            uClient = client;
            GoBasketForm = client;
            comboBoxType.Items.Clear();
            var tmp = context.Storage.Select(a => new { a.Type_Storage }).Distinct().ToList();

            foreach (var b in tmp)
            {
                comboBoxType.Items.Add(b.Type_Storage);
            }
        }

        public void LoadData()
        {
            var db = context.Storage.Select(a => new { a.Name_Storage, a.Maker_Storage, a.Type_Storage, a.Price_Storage, a.Amount_Storage }).OrderBy(a => a.Name_Storage).ToList();
            dataGridView1.DataSource = db;
        }
       

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMaker.Items.Clear();
            comboBoxMaker.Text = "";
            comboBoxList.Items.Clear();
            comboBoxList.Text = "";
            var tmp1 = context.Storage.Where(b => b.Type_Storage == comboBoxType.SelectedItem.ToString()).Select(a => new { a.Maker_Storage }).Distinct().ToList();
            var tmp2 = context.Storage.Where(c => c.Type_Storage == comboBoxType.SelectedItem.ToString()).Select(a => new { a.Name_Storage, a.Maker_Storage, a.Type_Storage, a.Price_Storage, a.Amount_Storage }).Distinct().ToList();
            foreach (var c in tmp1)
            {
                comboBoxMaker.Items.Add(c.Maker_Storage);
            }
            dataGridView1.DataSource = tmp2;
        }

        private void comboBoxMaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxList.Items.Clear();
            comboBoxList.Text = "";
            var tmp3 = context.Storage.Where(c => c.Type_Storage == comboBoxType.SelectedItem.ToString() && c.Maker_Storage == comboBoxMaker.SelectedItem.ToString()).ToList();
            var tmp2 = context.Storage.Where(c => c.Type_Storage == comboBoxType.SelectedItem.ToString() && c.Maker_Storage == comboBoxMaker.SelectedItem.ToString()).Select(a => new { a.Name_Storage, a.Maker_Storage, a.Type_Storage, a.Price_Storage, a.Amount_Storage }).Distinct().ToList();
            dataGridView1.DataSource = tmp2;
            foreach(var a in tmp3)
            {
                comboBoxList.Items.Add(a.Name_Storage);
            }
        }
        private void back_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            this.Hide();
            form.Show();
        }
        private void basket_Click(object sender, EventArgs e)
        {
            
            if (comboBoxList.SelectedItem == null)
            { errorProvider1.SetError(basket, "Choose the product"); }
            else
            {
                var item = context.Storage.FirstOrDefault(a => a.Name_Storage == comboBoxList.SelectedItem.ToString());
                if (int.Parse(item.Amount_Storage) > 0)
                {
                    BasketForm form = new BasketForm(GoBasketForm, item);
                    this.Hide();
                    form.Show();
                }
                else { MessageBox.Show("The selected item is currently out of stock!\nPlease, choose another one."); }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StorageForm form = new StorageForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            PurchasesForm form = new PurchasesForm(uClient);
            this.Hide();
            form.Show();
        }

        private void comboBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tmp3 = context.Storage.Where(c => c.Type_Storage == comboBoxType.SelectedItem.ToString() && c.Maker_Storage == comboBoxMaker.SelectedItem.ToString()).ToList();
            var tmp2 = context.Storage.Where(c => c.Type_Storage == comboBoxType.SelectedItem.ToString() && c.Maker_Storage == comboBoxMaker.SelectedItem.ToString() && c.Name_Storage == comboBoxList.SelectedItem.ToString()).Select(a => new { a.Name_Storage, a.Maker_Storage, a.Type_Storage, a.Price_Storage, a.Amount_Storage }).Distinct().ToList();
            dataGridView1.DataSource = tmp2;
        }
    }
}
