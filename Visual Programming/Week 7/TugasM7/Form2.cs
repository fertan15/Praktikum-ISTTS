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
    public partial class Form2 : Form
    {
        string connectionString = "Server=localhost;Database=db_goputplusbanget;UserID=root;Password=;";
        DataSet1 dataSet;
        string id;
        public Form2(string id)
        {
            InitializeComponent();

            this.id = id;

            dataSet = new DataSet1();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string sql = "select * from restaurants";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dataSet, "restaurants");

                string sql1 = "select * from orders";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                da1.Fill(dataSet, "orders");

                string sql2 = "select * from menuitems";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                da2.Fill(dataSet, "menuitems");

                string sql3 = "select * from htransorder";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                da3.Fill(dataSet, "htransorder");

                string sql4 = "select * from dtransorder";
                MySqlCommand cmd4 = new MySqlCommand(sql4, conn);
                MySqlDataAdapter da4 = new MySqlDataAdapter(cmd4);
                da4.Fill(dataSet, "dtransorder");








                CrystalReport1 report = new CrystalReport1(); // .rpt untuk 1 nota
                report.SetDataSource(dataSet);

                report.SetParameterValue("restaurant", id);
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
        }

        


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
