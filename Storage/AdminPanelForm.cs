using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Storage
{
    public partial class AdminPanelForm : Form
    {
        StorageContext context = new StorageContext();
        Client uClient;
        
        public AdminPanelForm(Client client)
        {
            InitializeComponent();
            uClient = client;
            var shippers = context.Shipper.Select(a => new { a.Name_Shipper }).ToList();
            foreach(var b in shippers)
            {
                comboBoxShipper.Items.Add(b.Name_Shipper);
            }                      
        }

       

        private void buttonStorage_Click(object sender, EventArgs e)
        {           
            StorageForm form = new StorageForm(uClient);
            this.Hide();
            form.Show();
        }

       

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Start form = new Start();
            this.Hide();
            form.Show();
        }

        private void buttonSaleInfo_Click(object sender, EventArgs e)
        {

            SalesInfoForm form = new SalesInfoForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonAddStorage_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxAmount.Text, out int i)) { errorProvider1.SetError(textBoxAmount, "Enter a number"); }
            else
            {
                if (!int.TryParse(textBoxPrice.Text, out int j)) { errorProvider1.SetError(textBoxPrice, "Enter a number"); }
                else
                {
                    errorProvider1.Clear();
                    if (comboBoxShipper.Text != ""
                        && comboBoxType.Text != ""
                        && comboBoxMaker.Text != ""
                        && textBoxName.Text != ""
                        && textBoxPrice.Text != ""
                        && textBoxAmount.Text != "")
                    {
                        errorProvider1.Clear();
                        if (int.Parse(textBoxPrice.Text) >= 0)
                        {
                            errorProvider1.Clear();
                            if (comboBoxShipper.SelectedItem == null)
                            {
                                errorProvider1.SetError(comboBoxShipper, "Nothing to add");
                            }
                            else
                            {
                                errorProvider1.Clear();

                                var shipper = context.Shipper.FirstOrDefault(a => a.Name_Shipper == comboBoxShipper.SelectedItem.ToString());
                                var storage = context.Storage.FirstOrDefault(a => a.Name_Storage == textBoxName.Text);

                                if (storage == null)
                                {
                                    Storage stor = new Storage { Name_Storage = textBoxName.Text, Maker_Storage = comboBoxMaker.SelectedItem.ToString(), Type_Storage = comboBoxType.SelectedItem.ToString(), Price_Storage = (decimal)(int.Parse(textBoxPrice.Text) * 1.2), Amount_Storage = "0" };
                                    context.Storage.Add(stor);
                                    context.SaveChanges();
                                    Buy buy = new Buy { ID_Storage = stor.ID_Storage, ID_Shipper = shipper.ID_Shipper, Name_Buy = textBoxName.Text, Maker_Buy = comboBoxMaker.SelectedItem.ToString(), Type_Buy = comboBoxType.SelectedItem.ToString(), Price_Buy = int.Parse(textBoxPrice.Text), Amount_Buy = textBoxAmount.Text, Data_Buy = DateTime.Now };
                                    context.Buy.Add(buy);

                                    stor.Amount_Storage = "" + (int.Parse(stor.Amount_Storage) + int.Parse(textBoxAmount.Text));
                                    context.SaveChanges();
                                    MessageBox.Show("Goods added to the storage!");
                                    comboBoxShipper.Items.Clear();
                                    comboBoxShipper.Text = "";
                                    comboBoxType.Items.Clear();
                                    comboBoxType.Text = "";
                                    comboBoxMaker.Items.Clear();
                                    comboBoxMaker.Text = "";
                                    textBoxName.Clear();
                                    textBoxPrice.Clear();
                                    textBoxAmount.Clear();
                                }
                                else
                                {
                                    if ((decimal)(int.Parse(textBoxPrice.Text) * 1.2) <= storage.Price_Storage)
                                    {
                                        Buy buy = new Buy { ID_Storage = storage.ID_Storage, ID_Shipper = shipper.ID_Shipper, Name_Buy = textBoxName.Text, Maker_Buy = comboBoxMaker.SelectedItem.ToString(), Type_Buy = comboBoxType.SelectedItem.ToString(), Price_Buy = int.Parse(textBoxPrice.Text), Amount_Buy = textBoxAmount.Text, Data_Buy = DateTime.Now };
                                        context.Buy.Add(buy);

                                        storage.Amount_Storage = "" + (int.Parse(storage.Amount_Storage) + int.Parse(textBoxAmount.Text));
                                        context.SaveChanges();
                                        MessageBox.Show("Goods added to the storage!");
                                        comboBoxShipper.Items.Clear();
                                        comboBoxType.Items.Clear();
                                        comboBoxMaker.Items.Clear();
                                        textBoxName.Clear();
                                        textBoxPrice.Clear();
                                        textBoxAmount.Clear();
                                    }
                                    else { errorProvider1.SetError(buttonAddStorage, "Buy price can't be more than storage price"); }
                                }
                            }
                        }
                        else { errorProvider1.SetError(buttonAddStorage, "Price can't be negative"); }
                    }

                    else { errorProvider1.SetError(buttonAddStorage, "Fill all fields"); }
                }
            }
        }

        private void buttonShipper_Click(object sender, EventArgs e)
        {
            ShippersForm form = new ShippersForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonDiagrams_Click(object sender, EventArgs e)
        {
            ChartForm form = new ChartForm(uClient);
            this.Hide();
            form.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditForm form = new EditForm(uClient);
            this.Hide();
            form.Show();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBoxType.Text)
            {
                case "Camera":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[]{ "Canon", "Nikon", "Sony" });
                    break;
                case "Charger":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "Apple", "Asus", "Canon", "Huawei", "Lenovo", "Nikon", "Samsung", "Sony", "Xiaomi"});
                    break;
                case "Game Console":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "XBOX", "PlayStation" });
                    break;
                case "Headphones":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "Apple", "Huawei", "Lenovo", "Samsung", "Sony", "Xiaomi", "Sven", "Razer", "Logitech" });
                    break;
                case "Keyboard":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "Apple", "Huawei", "Lenovo", "Samsung", "Xiaomi", "Sven", "Razer", "Logitech" });
                    break;
                case "Loudspeakers":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "Huawei", "Lenovo", "Samsung", "Sony", "Xiaomi", "Sven", "Razer" });
                    break;
                case "Monitor":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "Apple", "Huawei", "Lenovo", "Samsung", "Asus", "Xiaomi", "LG" });
                    break;
                case "Mouse":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "Apple", "Huawei", "Lenovo", "Samsung", "Xiaomi", "Sven", "Razer", "Logitech" });
                    break;
                case "Phone":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "Apple", "Huawei", "Lenovo", "Samsung", "Xiaomi" });
                    break;
                case "TV":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "Asus", "LG", "Samsung", "Xiaomi", "Lenovo" });
                    break;
                case "Tablet":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "Apple", "Huawei", "Lenovo", "Samsung", "Xiaomi" });
                    break;
                case "Watches":
                    comboBoxMaker.Items.Clear();
                    comboBoxMaker.Items.AddRange(new string[] { "Apple", "Huawei", "Samsung", "Xiaomi" });
                    break;


            }    
        }
    }
}
