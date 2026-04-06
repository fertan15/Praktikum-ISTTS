using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriW4
{
    public partial class userPage : Form
    {
        login master;
        int selected = -1;
        public userPage(login master)
        {
            InitializeComponent();
            this.master = master;

            dataGridView1.DataSource = Data.dataSet.Tables["Stok"];
            dataGridView2.DataSource = Data.dataSet.Tables["Cart"];

            button1.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {

            this.Close();
            master.Show();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            string tipe = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (tipe == "Pan") dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Yellow;
            if (tipe == "Thin") dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Blue;
            if (tipe == "Stuffed") dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Magenta;


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Data.addCart(Data.Stok.Rows[e.RowIndex]["PizzaID"].ToString(), Data.Stok.Rows[e.RowIndex]["Nama"].ToString(), Convert.ToInt32(Data.Stok.Rows[e.RowIndex]["Harga"]));
                button1.Enabled = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selected = e.RowIndex;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selected != -1)
            {
                Data.Cart.Rows.RemoveAt(selected);
                selected = -1;

                if(Data.Cart.Rows.Count < 1)
                {
                    button1.Enabled = false;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Data.Cart.Rows.Clear();
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime now = DateTime.Now;
            string id = "ORD" + now.Year + now.Day + now.Month + Data.orderNumber.ToString().PadLeft(4, '0');
            string items = "";
            int total = 0;
            for (int i = 0; i < Data.Cart.Rows.Count; i++) {
                items += Data.Cart.Rows[i]["Nama"] + "x" + Data.Cart.Rows[i]["Qty"] + ";";
                total += Convert.ToInt32(Data.Cart.Rows[i]["Harga"]) * Convert.ToInt32(Data.Cart.Rows[i]["Qty"]);
            }


            Data.addAntrian(id, Data.logInUser,now, total,items, Data.Cart.Rows.Count);

            MessageBox.Show("Order Dikirim ke Dapur!\nTotal: Rp " + total);
            Data.Cart.Rows.Clear();
            button1.Enabled = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selected = e.RowIndex;
            }

        }
    }
}
