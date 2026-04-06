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

namespace TugasM5
{
    public partial class addStudio : Form
    {
        Admin master;
        public addStudio(Admin master)
        {
            InitializeComponent();
            this.master = master;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cek harga
            if(numericUpDown1.Value<20000 || numericUpDown1.Value % 5000 != 0)
            {
                MessageBox.Show("Harga min 20.000 dan kelipatan 5000");
                return;
            }


            //cek nama
            if (textBox1.Text.Length < 0)
            {
                MessageBox.Show("Isi nama Studio");
                return;

            }
            try
            {
                Data.openDatabase();
                string query = "select count(*) from studio where studio_name = @name";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);

                int result = Convert.ToInt32(cmd.ExecuteScalar());

                if (result > 0)
                {
                    MessageBox.Show("Title Sudah dipake");
                    return;
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


            //generate id
            string id = "STD";

            try
            {
                int idInt;

                Data.openDatabase();
                string query = "select max(studio_id) from studio";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                try
                {
                    string currentId = cmd.ExecuteScalar().ToString();
                    idInt = Convert.ToInt32(currentId.Substring(3)) + 1;


                }
                catch
                {
                     idInt = 0;
                }


                id += idInt.ToString().PadLeft(3, '0');


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Data.closeDatabase();
            }




            //insert
            try
            {
                Data.openDatabase();
                string query = "INSERT INTO studio (studio_id, studio_name, price) VALUES (@id, @name, @price)";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@price", numericUpDown1.Value);  // nanti ganti jangan lupa

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data inserted successfully");
                }
                else
                {
                    MessageBox.Show("Failed to insert data");
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


                    
            master.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            master.Show();
            this.Close();
        }
    }
}
