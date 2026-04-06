using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasM5
{
    public partial class seatsBuy : Form
    {
        int price;

        string id;
        UserPage master;
        public seatsBuy(string movie_id, UserPage master)
        {
            InitializeComponent();
            this.id = movie_id;
            this.master = master;
            loadAll();
        }


        public void loadAll()
        {
            try
            {
                Data.openDatabase();

                string query = "SELECT m.movie_id, m.title, s.studio_name, s.price, m.seatA1, m.seatA2, m.seatA3, m.seatA4, m.seatA5 FROM movie m JOIN studio s ON m.studio_id = s.studio_id where movie_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // Only once
                {
                    string studioName = reader.GetString("studio_name");
                    price = reader.GetInt32("price");
                    string title = reader.GetString("title");
                    label1.Text = "Studio : " + studioName + " | Price : Rp " + price;
                    label2.Text = "Now Playing : " + title;

                    if (reader.GetBoolean("seatA1")) { button1.BackColor = Color.Red;  }
                    if (reader.GetBoolean("seatA2")) { button2.BackColor = Color.Red; }
                    if (reader.GetBoolean("seatA3")) { button3.BackColor = Color.Red; }
                    if (reader.GetBoolean("seatA4")) { button4.BackColor = Color.Red; }
                    if (reader.GetBoolean("seatA5")) { button5.BackColor = Color.Red; }



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                Data.closeDatabase();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(button1.BackColor == Color.Gainsboro)
            {
                button1.BackColor = Color.LightGreen;
            }
            else if (button1.BackColor == Color.LightGreen)
            {
                button1.BackColor = Color.Gainsboro;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Gainsboro)
            {
                button2.BackColor = Color.LightGreen;
            }
            else if(button2.BackColor == Color.LightGreen)
            {
                button2.BackColor = Color.Gainsboro;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Gainsboro)
            {
                button3.BackColor = Color.LightGreen;
            }
            else if(button3.BackColor == Color.LightGreen)
            {
                button3.BackColor = Color.Gainsboro;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Gainsboro)
            {
                button4.BackColor = Color.LightGreen;
            }
            else if(button4.BackColor == Color.LightGreen)
            {
                button4.BackColor = Color.Gainsboro;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Gainsboro)
            {
                button5.BackColor = Color.LightGreen;
            }
            else if(button5.BackColor == Color.LightGreen)
            {
                button5.BackColor = Color.Gainsboro;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selected = 0;
            bool selectA1 = false;
            bool selectA2 = false;
            bool selectA3 = false;
            bool selectA4 = false;
            bool selectA5 = false;

            if (button1.BackColor == Color.LightGreen)
            {
                selectA1 = true;
                selected++;
            }

            if (button2.BackColor == Color.LightGreen)
            {
                selectA2 = true;
                selected++;
            }

            if (button3.BackColor == Color.LightGreen)
            {
                selectA3 = true;
                selected++;
            }

            if (button4.BackColor == Color.LightGreen)
            {
                selectA4 = true;
                selected++;
            }

            if (button5.BackColor == Color.LightGreen)
            {
                selectA5 = true;
                selected++;
            }


            //cek miskin ga
            int total = selected * price;
            if(Data.saldo < total)
            {
                MessageBox.Show("Saldo tidak cukup. Total: Rp " + total);
                this.Close();
            }
            else
            {
                MessageBox.Show("Booking sukses! Dibayar: Rp " + total);
                Data.saldo -= total;
                master.refreshSaldo();

                if(selected == 0)
                {
                    return;
                }

                //update database yeah
                try
                {
                    Data.openDatabase();
                    //build query dulu 
                    //ini yang mau di set
                    List<string> set = new List<string>();
                    if (selectA1)
                        set.Add("seatA1 = true");
                    if (selectA2)
                        set.Add("seatA2 = true");
                    if (selectA3)
                        set.Add("seatA3 = true");
                    if (selectA4)
                        set.Add("seatA4 = true");
                    if (selectA5)
                        set.Add("seatA5 = true");

                    string setAll = string.Join(",", set);

                    string query = "update movie set " + setAll + " where movie_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    int result = cmd.ExecuteNonQuery();
                    if (result <= 0)
                    {
                        MessageBox.Show("gagal beli cobak lagi nanti");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Berhasil beli");
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    Data.closeDatabase();
                }
            }
        }
    }
}
