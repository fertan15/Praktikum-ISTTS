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

namespace TugasM7
{
    public partial class Form1 : Form
    {

        string connectionString = "Server=localhost;Database=db_goputplusbanget;UserID=root;Password=;";

        public Form1()
        {
            InitializeComponent();


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;


            loadDgv();

        }


        public void loadDgv()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    string query = "SELECT RestaurantID, Name, Address, Phone,Email, OpeningHours  FROM Restaurants";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                    catch (Exception ex)
                {
                    MessageBox.Show($"Error loading products: {ex.Message}");
                }
            }


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 form = new Form2(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDgv();
        }
    }
}
