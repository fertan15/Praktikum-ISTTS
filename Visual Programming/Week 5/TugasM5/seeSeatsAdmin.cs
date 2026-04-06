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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TugasM5
{
    public partial class seeSeatsAdmin : Form
    {
        string id = "";
        int price = 0;
        int usedSeats = 0;
        Admin master;
        public seeSeatsAdmin(string id, Admin master)
        {
            InitializeComponent();
            this.master = master;
            this.id = id;
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

                    if(reader.GetBoolean("seatA1")) { button1.BackColor = Color.Red; usedSeats++; }
                    if(reader.GetBoolean("seatA2")) { button2.BackColor = Color.Red; usedSeats++; }
                    if(reader.GetBoolean("seatA3")) { button3.BackColor = Color.Red; usedSeats++; }
                    if(reader.GetBoolean("seatA4")) { button4.BackColor = Color.Red; usedSeats++; }
                    if(reader.GetBoolean("seatA5")) { button5.BackColor = Color.Red; usedSeats++; }
                    


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

        private void button7_Click(object sender, EventArgs e)
        {
            int total = usedSeats * price;
            MessageBox.Show("Movie Selesai.\nKursi terpakai: " + usedSeats + "\nTotal pendapatan: Rp " + total);

            try
            {
                Data.openDatabase();
                string query = "delete from movie where movie_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@id", id);
                int result = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Data.closeDatabase();
            }



            master.refreshDGV();
            this.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
