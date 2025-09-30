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

    public partial class Form1 : Form
    {
        User user;
        Form2 master;
        int uangVendingMachine;
        public Form1(User user, Form2 master)
        {
            InitializeComponent();
            this.user = user;
            this.master = master;

            uangVendingMachine = user.Vendingmoney;

            this.Money.Text = user.money.ToString();
            this.referral.Text = user.refferal;

            uangVending.Text = uangVendingMachine.ToString();

            if (uangVendingMachine <= 0)
            {
                vendingMachine.Enabled = false;
            }

            stuff.Visible = false;

            uangVendingMachine = user.Vendingmoney;
            foreach(string t in user.inventory)
            {
                listBox1.Items.Add(t);
            }
        }


        public void addMoney(int amount)
        {
            if(user.money < amount)
            {
                MessageBox.Show("Uang di dompet tidak cukup");
                return;
            }
            user.money-= amount;
            uangVendingMachine += amount;
            user.Vendingmoney = uangVendingMachine;
            uangVending.Text = uangVendingMachine.ToString();
            Money.Text = user.money.ToString();
            if (uangVendingMachine > 0)
            {
                vendingMachine.Enabled = true;
            }
        }

        public void spendMoney(int amount, string name)
        {
            if (uangVendingMachine < amount)
            {
                MessageBox.Show("Uang tidak cukup");
                return;
            }

            MessageBox.Show("Berhasil Membeli " + name + " Seharga Rp " + amount + "." );
            listBox1.Items.Add(name);

            uangVendingMachine -= amount;
            uangVending.Text = uangVendingMachine.ToString();
            if (uangVendingMachine <= 0)
            {
                vendingMachine.Enabled = false;
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Money.Text = user.money.ToString();




        }

        private void button10_Click(object sender, EventArgs e)
        {
            //topup 5000
            addMoney(5000);
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            user.Vendingmoney = uangVendingMachine;
            user.inventory.Clear();
            foreach(String s in listBox1.Items)
            {
                user.inventory.Add(s);
            }


            this.Close();
            master.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            addMoney(10000);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            addMoney(20000);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            spendMoney(5000, "Burger");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            spendMoney(6500, "Pizza");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            spendMoney(10000, "Spaghetti");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            spendMoney(4000, "Croissant");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            spendMoney(5500, "Sandwich");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            spendMoney(13000, "Cake");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            spendMoney(9000, "Cheese");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            spendMoney(11000, "Onigiri");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            spendMoney(3000, "Strawberry");

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form4 b = new Form4(user);
            b.ShowDialog();
            Money.Text = user.money.ToString();

        }

        bool isClicking = false;
        int clickCount = 0;
        int clickThreshold;
        Random rand = new Random();
        private void button14_Click(object sender, EventArgs e)
        {
            if(button14.Text == "Press Button" && isClicking == false)
            {
                clickCount = 0;
                isClicking = true;
                clickThreshold = rand.Next(5, 21);
                button14.Text = "TEKAN (" + clickCount + "/"+clickThreshold+")";
                return;
            }

            if(isClicking == true)
            {
                clickCount++;
                button14.Text = "TEKAN (" + clickCount + "/" + clickThreshold + ")";
                if(clickCount >= clickThreshold)
                {
                    isClicking = false;
                    button14.Text = "Press Button";
                    MessageBox.Show("Berhasil mendapatkan Rp 10.000");
                    user.money += 10000;
                    Money.Text = user.money.ToString();
                }
            }
        }

        bool find = false;
        private void button15_Click(object sender, EventArgs e)
        {
            if (!find)
            {
                find = true;
                button15.Text = "FIND 👺";
                stuff.Visible = true;
            }
        }

        private void stuff_Click(object sender, EventArgs e)
        {
            find = false;
            MessageBox.Show("Berhasil menemukan stuff 👺 mendapatkan Rp 10.000");
            user.money += 10000;
            Money.Text = user.money.ToString();
            stuff.Visible = false;
            button15.Text = "Do Stuff!";

        }
    }
}
