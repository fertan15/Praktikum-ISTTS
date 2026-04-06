using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MateriW4
{
    public partial class adminPage : Form
    {
        int selected = -1;
        bool isEditing = false;
        login master;
        public adminPage(login master)
        {
            InitializeComponent();
            this.master = master;
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
            dataGridView1.DataSource = Data.dataSet.Tables["Stok"];
            dataGridView2.DataSource = Data.dataSet.Tables["HistoryTransaksi"];
            listBox1.DataSource = Data.dataSet.Tables["Antrian"];


            TambahStok.Text = "Tambah Stok";  // text that appears on the button
            TambahStok.UseColumnTextForButtonValue = true; // <== this makes the text appear

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            master.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Aksi" && e.RowIndex >= 0)
            {
                addStok addStok = new addStok();
                addStok.ShowDialog();

                Data.Stok.Rows[e.RowIndex]["Stok"] = Convert.ToInt16(Data.Stok.Rows[e.RowIndex]["Stok"]) + Data.stockAdded;
            }

        }

        public void Refresh()
        {
            namaBox.Clear();
            hargaBox.Value = 0;
            tipeBox.Text = "";
            stokBox.Value = 1;
            dateBox.Value = DateTime.Now;
            cheeseBox.Checked = false;
            pepperoniBox.Checked = false;
            mushroomBox.Checked = false;
            beefBox.Checked = false;
            tunaBox.Checked = false;


            updateButton.Enabled = false;
            deleteButton.Enabled = false;
            addButton.Enabled = true;

        }


        private void clearButton_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            if (namaBox.Text.Length < 10)
            {
                MessageBox.Show("nama minimal 10 huruf");
                return;
            }
            // nama unique -> maasih ak skip

            for (int i = 0; i < Data.Stok.Rows.Count; i++)
            {
                if (Data.Stok.Rows[i]["Nama"].ToString() == namaBox.Text)
                {
                    MessageBox.Show("ada nama duplikat");
                    return;
                }
            }





            if (hargaBox.Value < 10000)
            {
                MessageBox.Show("harga minimal 10rb");
                return;
            }
            if (!cheeseBox.Checked && !pepperoniBox.Checked && !mushroomBox.Checked && !beefBox.Checked && !tunaBox.Checked )
            {
                MessageBox.Show("minimal 1 topping");
                return;
            }
            if (tipeBox.Text == "")
            {
                MessageBox.Show("Pilih Tipe");
                return;
            }

            string topping = "";
            if (cheeseBox.Checked)
            {
                topping += "Cheese ";
            }
            if (pepperoniBox.Checked)
            {
                topping += "Pepperoni ";
            }
            if (mushroomBox.Checked)
            {
                topping += "Mushroom ";
            }
            if (beefBox.Checked)
            {
                topping += "Beef ";
            }
            if (tunaBox.Checked)
            {
                topping += "Tuna ";
            }


            string id = "PZ" + Data.Stok.Rows.Count.ToString().PadLeft(4, '0');
            MessageBox.Show(id);
            Data.addStok(id, namaBox.Text, tipeBox.Text, dateBox.Value, Convert.ToInt32(hargaBox.Value), topping, Convert.ToInt32(stokBox.Value));
            Refresh();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Refresh();
                addButton.Enabled = false;
                updateButton.Enabled = true;
                deleteButton.Enabled = true;


                selected = e.RowIndex;

                namaBox.Text = Data.Stok.Rows[selected]["Nama"].ToString();
                tipeBox.Text = Data.Stok.Rows[selected]["Tipe"].ToString();
                hargaBox.Value = Convert.ToInt64( Data.Stok.Rows[selected]["Harga"]);
                stokBox.Value = Convert.ToInt64(Data.Stok.Rows[selected]["Stok"]);
                dateBox.Value = (DateTime) Data.Stok.Rows[selected]["ReleaseDate"];

                //topping 
                string toppings = Data.Stok.Rows[selected]["Toppings"].ToString();
                string[] topping = toppings.Split(' ');

                for (int i = 0; i < topping.Length; i++)
                {
                    if (topping[i] == "Cheese")
                        cheeseBox.Checked = true;
                    if (topping[i] == "Pepperoni")
                        pepperoniBox.Checked = true;
                    if (topping[i] == "Mushroom")
                        mushroomBox.Checked = true;
                    if (topping[i] == "Beef")
                        beefBox.Checked = true;
                    if (topping[i] == "Tuna")
                        tunaBox.Checked = true;

                }
            }

        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            if (namaBox.Text.Length < 10)
            {
                MessageBox.Show("nama minimal 10 huruf");
                return;
            }
            // nama unique -> maasih ak skip

            for (int i = 0; i < Data.Stok.Rows.Count; i++)
            {
                if (Data.Stok.Rows[i]["Nama"].ToString() == namaBox.Text && i != selected)
                {
                    MessageBox.Show("ada nama duplikat");
                    return;
                }
            }





            if (hargaBox.Value < 10000)
            {
                MessageBox.Show("harga minimal 10rb");
                return;
            }
            if (!cheeseBox.Checked && !pepperoniBox.Checked && !mushroomBox.Checked && !beefBox.Checked && !tunaBox.Checked)
            {
                MessageBox.Show("minimal 1 topping");
                return;
            }
            if (tipeBox.Text == "")
            {
                MessageBox.Show("Pilih Tipe");
                return;
            }




            string topping = "";
            if (cheeseBox.Checked)
            {
                topping += "Cheese ";
            }
            if (pepperoniBox.Checked)
            {
                topping += "Pepperoni ";
            }
            if (mushroomBox.Checked)
            {
                topping += "Mushroom ";
            }
            if (beefBox.Checked)
            {
                topping += "Beef ";
            }
            if (tunaBox.Checked)
            {
                topping += "Tuna ";
            }

            Data.Stok.Rows[selected]["Nama"] = namaBox.Text;
            Data.Stok.Rows[selected]["Tipe"] = tipeBox.Text;
            Data.Stok.Rows[selected]["Harga"] = hargaBox.Value;
            Data.Stok.Rows[selected]["Stok"] = stokBox.Value;
            Data.Stok.Rows[selected]["ReleaseDate"] = dateBox.Value;
            Data.Stok.Rows[selected]["Toppings"] = topping;

            Refresh();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selected != -1)
            {
                    Data.Stok.Rows.RemoveAt(selected);
                    Refresh();
                    selected = -1;

            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            string tipe = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            if(tipe == "Pan") dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Yellow;
            if(tipe == "Thin") dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Blue;
            if(tipe == "Stuffed") dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Magenta;
            

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                DataRowView rowView = (DataRowView)listBox1.SelectedItem;
                DataRow row = rowView.Row;

                string id = row["OrderId"].ToString();
                string username = row["Username"].ToString();
                int total = Convert.ToInt32(row["Total"]);
                DateTime tanggal = Convert.ToDateTime(row["Tanggal"]);
                string items = row["Items"].ToString();

                MessageBox.Show("Order Selesai.\nTotal: Rp " + total);


                Data.addHistoryTransaksi(id, username, tanggal, total, items);
                Data.Antrian.Rows.RemoveAt(listBox1.SelectedIndex);
                listBox1.SelectedItem = null;

            }

        }
    }
}
