using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MateriW3
{
    public partial class Shelf : Form
    {
        int id = -1;
        bool kosong = false;
        string item;
        int jumlah;
        warung master;
        public Shelf(int id, string shelf, string item, int jumlah, warung master)
        {
            InitializeComponent();
            this.master = master;
            this.id = id;
            this.item = item;
            this.jumlah = jumlah;
            if (shelf == "Kosong")
            {
                kosong = true;
            }
            updateAll();
            comboBox1.SelectedIndex = 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateAll();
        }

        public void updateAll()
        {
            if(comboBox1.SelectedItem == "Oak")
            {
                numericUpDown1.Maximum = 100;
                label5.Text = "Maks: Rp " + 100 + "(200% dari dasar)";
                label4.Text = "Inventory tersedia: " + PlayerInfo.oak;
                numericUpDown2.Maximum = PlayerInfo.oak;
            }

            if (comboBox1.SelectedItem == "Mahogany")
            {
                numericUpDown1.Maximum = 240;
                label5.Text = "Maks: Rp " + 240 + "(200% dari dasar)";
                label4.Text = "Inventory tersedia: " + PlayerInfo.mahogany;
                numericUpDown2.Maximum = PlayerInfo.mahogany;
            }
            if (comboBox1.SelectedItem == "Mystic")
            {
                numericUpDown1.Maximum = 500;
                label5.Text = "Maks: Rp " + 500 + "(200% dari dasar)";
                label4.Text = "Inventory tersedia: " + PlayerInfo.mystic;
                numericUpDown2.Maximum = PlayerInfo.mystic;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(numericUpDown2.Value == 0)
            {
                MessageBox.Show("Jumlah tidak boleh 0!");
                return;
            }


            //balikin item sebelum kalo ga kosong
            if (!kosong)
            {
                if(item == "Oak")
                {
                    PlayerInfo.oak += jumlah;
                }
                if(item == "Mahogany")
                {
                    PlayerInfo.mahogany += jumlah;
                }
                if(item == "Mystic")
                {
                    PlayerInfo.mystic += jumlah;
                }
            }

            //update item baru kalo ada kalo ga bikin baru
            try
            {
                using (var connection = new MySqlConnection(PlayerInfo.connectionString))
                {
                    connection.Open();

                    // Query ini melakukan "UPSERT"
                    // Dia mencoba INSERT, tapi jika ID-nya sudah ada, dia akan UPDATE.
                    string query = $@"
                        INSERT INTO warung (id, item, harga, jumlah)
                        VALUES (@id, @item, @harga, @jumlah)
                        ON DUPLICATE KEY UPDATE
                            item = @item,
                            harga = @harga,
                            jumlah = @jumlah;
                    ";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        // Tambahkan parameter untuk keamanan
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@item", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@harga", numericUpDown1.Value);
                        cmd.Parameters.AddWithValue("@jumlah", numericUpDown2.Value);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine($"Item (ID: "+id+" berhasil di-upsert.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat upsert item (ID: {id}): {ex.Message}");
            }

            //trus kurangin dari inventory sekarang
            if(comboBox1.SelectedItem == "Oak")
            {
                PlayerInfo.oak -= (int)numericUpDown2.Value;
            }
            if (comboBox1.SelectedItem == "Mahogany")
            {
                PlayerInfo.mahogany -= (int)numericUpDown2.Value;
            }
            if (comboBox1.SelectedItem == "Mystic")
            {
                PlayerInfo.mystic -= (int)numericUpDown2.Value;
            }
            master.refresh();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Shelf_Load(object sender, EventArgs e)
        {

        }
    }
}
