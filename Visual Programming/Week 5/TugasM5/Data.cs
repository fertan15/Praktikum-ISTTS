using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasM5
{
    public static class Data
    {
        public static int userId, saldo;
        public static string username;

        public static string connectionString = "Server=localhost;Database=pv_t5_224117127;UserID=root;Password=;";
        public static MySqlConnection connection;
        

        public static void connectDatabase()
        {
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open(); 
                connection.Close();
                MessageBox.Show("database connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void openDatabase()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

        }

        public static void closeDatabase()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }



    }
}
