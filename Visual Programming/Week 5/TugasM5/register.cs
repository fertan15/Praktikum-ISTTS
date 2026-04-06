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
    public partial class register : Form
    {
        Form1 master;
        public register(Form1 master)
        {
            InitializeComponent();
            this.master = master;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1 || textBox3.Text.Length < 1)
                {
                    MessageBox.Show("isi semua ye");
                    return;
                }

                //username unik
                try
                {

                    Data.openDatabase();
                    string queryCheck = "SELECT COUNT(*) FROM user WHERE username=@username";
                    MySqlCommand cmdCheck = new MySqlCommand(queryCheck, Data.connection);
                    cmdCheck.Parameters.AddWithValue("@username", textBox2.Text);
                    int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Username sudah ada, coba cari yg lain.");
                        Data.closeDatabase();
                        return;
                    }


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Data.closeDatabase();

                }


                //password min 6
                if (textBox3.Text.Length < 6)
                {
                    MessageBox.Show("Password minimal 6 karakter.");
                    return;
                }




                try
                {

                    Data.openDatabase();

                    string query = "INSERT INTO user (name, username, password) VALUES (@name, @username, @password)";
                    MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@username", textBox2.Text);
                    cmd.Parameters.AddWithValue("@password", textBox3.Text);

                    int result = cmd.ExecuteNonQuery(); // pakai ExecuteNonQuery karena ini insert data

                    if (result > 0)
                    {
                        MessageBox.Show("register sukses");
                    }
                    else
                    {
                        MessageBox.Show("gagal");
                    }

                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                   Data.closeDatabase();

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            master.Show();
            this.Close();
        }
    }
}
