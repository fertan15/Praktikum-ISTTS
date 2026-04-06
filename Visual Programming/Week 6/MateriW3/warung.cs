using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriW3
{
    public partial class warung : Form
    {
        int requiredToUpgrade;
        string item1;
        int harga1;
        int jumlah1;
        string text1 = "";
        string item2;
        int harga2;
        int jumlah2;
        string text2 = "";
        string item3;
        int harga3;
        int jumlah3;
        string text3 = "";

        public warung()
        {
            InitializeComponent();
            refresh();
        }

        public void refresh()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;

            label1.Text = "Saldo: Rp " + PlayerInfo.money + "  Level: " + PlayerInfo.levelWarung + "/3";

            if (PlayerInfo.levelWarung == 1)
            {
                //load shelf 1
                try
                {
                    using (var connection = new MySqlConnection(PlayerInfo.connectionString))
                    {
                        connection.Open();

                        // Select the progress from the row with id = 1
                        string query = "SELECT * FROM warung WHERE id = 1";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                     item1 = reader.GetString("item");
                                     harga1 = reader.GetInt32("harga");
                                     jumlah1 = reader.GetInt32("jumlah");

                                    text1 = "Item : " + item1 + "\nHarga: Rp " + harga1 + "\nStok: " + jumlah1 + " Unit";
                                }
                                else
                                {
                                    text1 = "Kosong";
                                }
                            }
                        }
                    }

                    
                }catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                label2.Text = text1;
                //rest
                groupBox2.Enabled = false;
                label3.Text = "Terkunci.\nUpgrade untuk\nmengaktifkan.";
                groupBox3.Enabled = false;
                label4.Text = "Terkunci.\nUpgrade untuk\nmengaktifkan.";
                requiredToUpgrade = 750;
                button5.Text = "Upgrade -> " + (PlayerInfo.levelWarung + 1) + " (Rp " + requiredToUpgrade + ")";
            }
            if (PlayerInfo.levelWarung == 2)
            {
                //load shelf 1
                try
                {
                    using (var connection = new MySqlConnection(PlayerInfo.connectionString))
                    {
                        connection.Open();

                        // Select the progress from the row with id = 1
                        string query = "SELECT * FROM warung WHERE id = 1";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    item1 = reader.GetString("item");
                                    harga1 = reader.GetInt32("harga");
                                    jumlah1 = reader.GetInt32("jumlah");

                                    text1 = "Item : " + item1 + "\nHarga: Rp " + harga1 + "\nStok: " + jumlah1 + " Unit";
                                }
                                else
                                {
                                    text1 = "Kosong";
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                label2.Text = text1;
                //load shelf 2
                try
                {
                    using (var connection = new MySqlConnection(PlayerInfo.connectionString))
                    {
                        connection.Open();

                        // Select the progress from the row with id = 1
                        string query = "SELECT * FROM warung WHERE id = 2";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    item2 = reader.GetString("item");
                                    harga2 = reader.GetInt32("harga");
                                    jumlah2 = reader.GetInt32("jumlah");

                                    text2 = "Item : " + item2 + "\nHarga: Rp " + harga2 + "\nStok: " + jumlah2 + " Unit";
                                }
                                else
                                {
                                    text2 = "Kosong";
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                label3.Text = text2;

                groupBox3.Enabled = false;
                label4.Text = "Terkunci.\nUpgrade untuk\nmengaktifkan.";
                requiredToUpgrade = 2000;
                button5.Text = "Upgrade -> " + (PlayerInfo.levelWarung + 1) + " (Rp " + requiredToUpgrade + ")";


            }
            if (PlayerInfo.levelWarung == 3)
            {
                //load shelf 1
                try
                {
                    using (var connection = new MySqlConnection(PlayerInfo.connectionString))
                    {
                        connection.Open();

                        // Select the progress from the row with id = 1
                        string query = "SELECT * FROM warung WHERE id = 1";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    item1 = reader.GetString("item");
                                    harga1 = reader.GetInt32("harga");
                                    jumlah1 = reader.GetInt32("jumlah");

                                    text1 = "Item : " + item1 + "\nHarga: Rp " + harga1 + "\nStok: " + jumlah1 + " Unit";
                                }
                                else
                                {
                                    text1 = "Kosong";
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                label2.Text = text1;
                //load shelf 2
                try
                {
                    using (var connection = new MySqlConnection(PlayerInfo.connectionString))
                    {
                        connection.Open();

                        // Select the progress from the row with id = 1
                        string query = "SELECT * FROM warung WHERE id = 2";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    item2 = reader.GetString("item");
                                    harga2 = reader.GetInt32("harga");
                                    jumlah2 = reader.GetInt32("jumlah");

                                    text2 = "Item : " + item2 + "\nHarga: Rp " + harga2 + "\nStok: " + jumlah2 + " Unit";
                                }
                                else
                                {
                                    text2 = "Kosong";
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                label3.Text = text2;
                //load shelf 3
                try
                {
                    using (var connection = new MySqlConnection(PlayerInfo.connectionString))
                    {
                        connection.Open();

                        // Select the progress from the row with id = 1
                        string query = "SELECT * FROM warung WHERE id = 3";

                        using (var cmd = new MySqlCommand(query, connection))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    item3 = reader.GetString("item");
                                    harga3 = reader.GetInt32("harga");
                                    jumlah3 = reader.GetInt32("jumlah");

                                    text3 = "Item : " + item3 + "\nHarga: Rp " + harga3 + "\nStok: " + jumlah3 + " Unit";
                                }
                                else
                                {
                                    text3 = "Kosong";
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                label4.Text = text3;
                button5.Text = "Max Level";
                button5.Enabled = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(requiredToUpgrade <= PlayerInfo.money)
            {
                PlayerInfo.money -= requiredToUpgrade;
                PlayerInfo.levelWarung += 1;
                refresh();
            }
            else
            {
                MessageBox.Show("Uang tidak cukup untuk upgrade warung!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Shelf shelf = new Shelf(1, label2.Text, item1, jumlah1, this);
            shelf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Shelf shelf = new Shelf(2, label3.Text, item2, jumlah2, this);
            shelf.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Shelf shelf = new Shelf(3, label4.Text, item3, jumlah3, this);
            shelf.ShowDialog();
        }

        private void warung_Load(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
