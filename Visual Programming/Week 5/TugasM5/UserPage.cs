using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasM5
{
    public partial class UserPage : Form
    {

        Form1 master;
        public UserPage(int logInUserId, int logInUserSaldo,string username ,Form1 master)
        {
            InitializeComponent();
            Data.userId = logInUserId;
            Data.saldo = logInUserSaldo;
            this.master = master;
            Data.username = username;
            refreshDGV("");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Seats";
            btn.Name = "seats";
            btn.Text = "See Seats";
            btn.UseColumnTextForButtonValue = true; // show text in every button

            // Add button column to DataGridView
            dataGridView1.Columns.Add(btn);

            label1.Text = "Hello, " + username;
            refreshSaldo();
        }


        public void refreshSaldo()
        {
            label2.Text = "Balance: Rp " + Data.saldo;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //simpan saldo ke database
            try
            {
                Data.openDatabase();
                string query = "UPDATE user SET saldo=@saldo WHERE user_id=@userId";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@saldo", Data.saldo);
                cmd.Parameters.AddWithValue("@userId", Data.userId);
                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    MessageBox.Show("Failed to update saldo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Data.closeDatabase();
            }


            //matiin
            this.Close();
            master.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            refreshDGV(textBox1.Text);   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int amount = (int)numericUpDown1.Value;

            Data.saldo += amount;
            refreshSaldo();
            numericUpDown1.Value = numericUpDown1.Minimum;
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = numericUpDown1.Minimum;
            panel1.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Seats" && e.RowIndex >= 0)
            {
                // see seats button clicked
                seatsBuy seeSeats = new seatsBuy(dataGridView1.Rows[e.RowIndex].Cells["movie_id"].Value.ToString(), this);
                seeSeats.ShowDialog();
            }

        }

        public void refreshDGV(string like)
        {
            try
            {
                Data.openDatabase();
                string query = "SELECT m.movie_id, s.studio_name, s.price, m.title, m.genre, m.duration FROM movie m JOIN studio s ON m.studio_id = s.studio_id where m.title like @search";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@search", "%" + like + "%");
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

                if (dataGridView1.Columns["movie_id"] != null)
                {
                    dataGridView1.Columns["movie_id"].Visible = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Data.closeDatabase();

            }
        }

        private void UserPage_Load(object sender, EventArgs e)
        {
            refreshSaldo();
        }
    }
}
