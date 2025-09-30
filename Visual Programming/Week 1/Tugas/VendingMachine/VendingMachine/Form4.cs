using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachine
{
    public partial class Form4 : Form
    {
        Random rand = new Random();
        int hasil;
        User user;
        public Form4(User user)
        {
            this.user = user;
            InitializeComponent();
            int n1 = rand.Next(1, 100);
            int n2 = rand.Next(1, 100);
            int op = rand.Next(0, 4);
            
            num1.Text= n1.ToString();
            num2.Text= n2.ToString();
            switch (op)
            {
                case 0:
                    operation.Text = "+";
                    hasil = n1 + n2;
                    break;
                case 1:
                    operation.Text = "-";
                    hasil = n1 - n2;
                    break;
                case 2:
                    operation.Text = "*";
                    hasil = n1 * n2;
                    break;
                case 3:
                    operation.Text = "/";
                    hasil = n1 / n2;
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int jwb = int.Parse(textBox1.Text);
            if (jwb == hasil)
            {
                MessageBox.Show("Jawaban Benar, Mendapatkan Rp 10.000");
                user.money += 10000;
            }
            else
            {
                MessageBox.Show("Jawaban Salah, Coba Lagi");
            }

            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
