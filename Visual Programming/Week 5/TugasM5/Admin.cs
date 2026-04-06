using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TugasM5
{
    public partial class Admin : Form
    {
        public Form1 master;
        public Admin(Form1 master)
        {
            InitializeComponent();
            this.master = master;

            refreshDGV();
            refreshInput();

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Seats";
            btn.Name = "seats";
            btn.Text = "See Seats";
            btn.UseColumnTextForButtonValue = true; // show text in every button

            // Add button column to DataGridView
            dataGridView1.Columns.Add(btn);


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            master.Show();
            this.Close();
        }

        public void refreshDGV()
        {
            try
            {
                Data.openDatabase();
                string query = "SELECT m.movie_id, m.title, m.genre, m.duration, m.studio_id, s.studio_name, s.price FROM movie m JOIN studio s ON m.studio_id = s.studio_id";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;





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

        private void button3_Click(object sender, EventArgs e)
        {
            //duration
            if(numericUpDown1.Value < 60)
            {
                MessageBox.Show("durasi minimal 60");
                return;
            }

            //genre

            List<string> genres = new List<string>();
            if (checkBox1.Checked) genres.Add("Action");
            if(checkBox2.Checked) genres.Add("Comedy");
            if (checkBox3.Checked) genres.Add("Drama");
            if (checkBox4.Checked) genres.Add("Horror");
            if (checkBox5.Checked) genres.Add("Animation");
            if (checkBox6.Checked) genres.Add("Sci-Fi");

            if (genres.Count <= 0) {
                MessageBox.Show("Minimal 1 genre");
                return;
            }

            string genre = string.Join(",", genres);


            //cek title

            if (textBox1.Text.Length < 10)
            {
                MessageBox.Show("title minimal 10 huruf");
                return;
            }

            try
            {
                Data.openDatabase();

                string query = "select count(*) from movie where title = @title";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@title", textBox1.Text);

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
                return;
            }
            finally
            {
                Data.closeDatabase();
            }



            //bikin id movie dulu 
            string id_movie = "MOV";
            try
            {
                int idInt;
                Data.openDatabase();
                string query = "select max(movie_id) from movie";
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
                id_movie += idInt.ToString().PadLeft(3, '0');

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



            try
            {
                Data.openDatabase();

                string query = "INSERT INTO movie (movie_id, title, genre, duration, studio_id) VALUES (@id, @title, @genre, @duration, @studio)";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@id", id_movie);
                cmd.Parameters.AddWithValue("@title", textBox1.Text);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@duration", numericUpDown1.Value);  
                cmd.Parameters.AddWithValue("@studio", comboBox1.SelectedValue);  // nanti ganti jangan lupa

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


            refreshDGV();
            refreshInput();

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addStudio n = new addStudio(this);
            n.Show();
            this.Hide();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Data.openDatabase();
                string query;
                if (selectedId == ""){
                     query = "SELECT * FROM studio WHERE studio_id NOT IN (SELECT studio_id FROM movie)";
                }
                else
                {
                     query = "SELECT * FROM studio WHERE studio_id NOT IN (SELECT studio_id FROM movie) UNION SELECT * FROM studio WHERE studio_id = @studio";
                }
                    MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                    if (selectedId != "")
                    {
                        cmd.Parameters.AddWithValue("@studio", dataGridView1.Rows[selectedRow].Cells["studio_id"].Value);
                    }
                MySqlDataReader reader1 = cmd.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(reader1);

                comboBox1.DataSource = dt1;
                comboBox1.DisplayMember = "studio_name";
                comboBox1.ValueMember = "studio_id";

                comboBox1.SelectedIndex = -1;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Seats" && e.RowIndex >= 0)
            {
                // see seats button clicked
                seeSeatsAdmin seeSeats = new seeSeatsAdmin(dataGridView1.Rows[e.RowIndex].Cells["movie_id"].Value.ToString(), this);
                seeSeats.ShowDialog();
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            refreshInput();
        }

        public void refreshInput()
        {
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
   
            textBox1.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            numericUpDown1.Value= numericUpDown1.Minimum;
            comboBox1.SelectedIndex = -1;
            selectedRow = -1;
            selectedId = "";
        }

        int selectedRow = -1;
        string selectedId = "";

        private void button4_Click(object sender, EventArgs e)
        {
            //update
                //duration
                if (numericUpDown1.Value < 60)
                {
                    MessageBox.Show("durasi minimal 60");
                    return;
                }

                //genre

                List<string> genres = new List<string>();
                if (checkBox1.Checked) genres.Add("Action");
                if (checkBox2.Checked) genres.Add("Comedy");
                if (checkBox3.Checked) genres.Add("Drama");
                if (checkBox4.Checked) genres.Add("Horror");
                if (checkBox5.Checked) genres.Add("Animation");
                if (checkBox6.Checked) genres.Add("Sci-Fi");

                if (genres.Count <= 0)
                {
                    MessageBox.Show("Minimal 1 genre");
                    return;
                }

                string genre = string.Join(",", genres);


                //cek title

                if (textBox1.Text.Length < 10)
                {
                    MessageBox.Show("title minimal 10 huruf");
                    return;
                }

                try
                {
                    Data.openDatabase();

                    string query = "select count(*) from movie where title = @title and movie_id != @movie_id";
                    MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                    cmd.Parameters.AddWithValue("@title", textBox1.Text);
                    cmd.Parameters.AddWithValue("@movie_id", (dataGridView1.Rows[selectedRow].Cells["movie_id"].Value).ToString());

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
                    return;
                }
                finally
                {
                    Data.closeDatabase();
                }

                try
                {
                    Data.openDatabase();

                //update query


                    string query = "update movie set title = @title, genre = @genre, duration = @duration,studio_id = @studio where movie_id = @movie_id";
                    MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                    cmd.Parameters.AddWithValue("@title", textBox1.Text);
                    cmd.Parameters.AddWithValue("@genre", genre);
                    cmd.Parameters.AddWithValue("@duration", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@studio", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@movie_id", (dataGridView1.Rows[selectedRow].Cells["movie_id"].Value).ToString());
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Data updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update data");
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

            refreshDGV();
            refreshInput();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //delete
            try
            {
                Data.openDatabase();
                string query = "delete from movie where movie_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@id", (dataGridView1.Rows[selectedRow].Cells["movie_id"].Value).ToString());
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Data deleted");
                }
                else
                {
                    MessageBox.Show("Failed to delete data");
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


            refreshDGV();
            refreshInput();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;

            selectedId = dataGridView1.Rows[e.RowIndex].Cells["movie_id"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["title"].Value.ToString();

            //genre
            string genreStr = dataGridView1.Rows[e.RowIndex].Cells["genre"].Value.ToString();
            List<string> genres = genreStr.Split(',').ToList();
            checkBox1.Checked = genres.Contains("Action");
            checkBox2.Checked = genres.Contains("Comedy");
            checkBox3.Checked = genres.Contains("Drama");
            checkBox4.Checked = genres.Contains("Horror");
            checkBox5.Checked = genres.Contains("Animation");
            checkBox6.Checked = genres.Contains("Sci-Fi");
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["duration"].Value);


            //load combo box
            try
            {

                Data.openDatabase();
                string query = "SELECT * FROM studio WHERE studio_id NOT IN (SELECT studio_id FROM movie) UNION SELECT * FROM studio WHERE studio_id = @studio";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@studio", dataGridView1.Rows[e.RowIndex].Cells["studio_id"].Value.ToString());
                MySqlDataReader reader1 = cmd.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(reader1);

                comboBox1.DataSource = dt1;
                comboBox1.DisplayMember = "studio_name";
                comboBox1.ValueMember = "studio_id";

                comboBox1.SelectedValue = dataGridView1.Rows[selectedRow].Cells["studio_id"].Value ;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;


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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
