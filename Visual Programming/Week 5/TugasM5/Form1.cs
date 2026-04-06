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
    public partial class Form1 : Form
    {

        int logInUserId = -1;
        int logInUserSaldo = 0;
        public Form1()
        {
            InitializeComponent();
            Data.connectDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username.Length < 1 || password.Length < 1)
            {
                MessageBox.Show("isi semua ye");
                return;
            }

            if (username == "admin" && password == "admin")
            {
                this.Hide();
                Admin adminPage = new Admin(this);
                adminPage.Show();
                refresh();
                return;
            }


            string userName="";
            try
            {

                Data.openDatabase();
                string query = "SELECT * FROM user WHERE username=@username AND password=@password";
                MySqlCommand cmd = new MySqlCommand(query, Data.connection);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);


                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) // Only once
                {
                    userName = reader.GetString("username");
                    logInUserId = reader.GetInt32("user_id");
                    logInUserSaldo = reader.GetInt32("saldo");
                    MessageBox.Show("Login berhasil. User ID: " + logInUserId + " Saldo: " + logInUserSaldo);
                    refresh();

                }
                else
                {
                    MessageBox.Show("Akun ga ketemu.");
                    refresh();
                    Data.closeDatabase();
                    return;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Data.closeDatabase();
                return;

            }
                Data.closeDatabase();


                UserPage userPage = new UserPage(logInUserId, logInUserSaldo, userName, this);
                this.Hide();
                userPage.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
            register registerForm = new register(this);
            this.Hide();
            registerForm.Show();
        }

        public void refresh()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
