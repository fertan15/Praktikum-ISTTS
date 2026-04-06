using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriW3
{
    public partial class Shop : Form
    {
        public Shop()
        {
            InitializeComponent();

            uang.Text = "Uang: Rp " + PlayerInfo.money;
            oak.Text = "Oak         : " + PlayerInfo.oak;
            mah.Text = "Mahogany    : " + PlayerInfo.mahogany;
            mys.Text = "Mystic      : " + PlayerInfo.mystic;


            switch (PlayerInfo.equippedAxe)
            {
                case 0:
                    label2.Text = "Equipped: Stone Axe";
                    break;
                case 1:
                    label2.Text = "Equipped: Iron Axe";
                    break;
                case 2:
                    label2.Text = "Equipped: Diamond Axe";
                    break;
            }

            if(PlayerInfo.ironAxe == true)
            {
                button5.Visible = false;
                label3.Text = "Owned : Iron";
            }

            if (PlayerInfo.diamondAxe == true)
            {
                button6.Visible = false;
                label4.Text = "Owned : Diamond";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(PlayerInfo.oak > 0)
            {
                PlayerInfo.oak--;
                PlayerInfo.money += 50;
                oak.Text = "Oak         : " + PlayerInfo.oak;
                uang.Text = "Uang: Rp " + PlayerInfo.money;
                MessageBox.Show("Kamu menjual 1 Oak Wood seharga Rp 50!");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (PlayerInfo.mahogany > 0)
            {
                PlayerInfo.mahogany--;
                PlayerInfo.money += 120;
                mah.Text = "Mahogany    : " + PlayerInfo.mahogany;
                uang.Text = "Uang: Rp " + PlayerInfo.money;
                MessageBox.Show("Kamu menjual 1 Mahogany Wood seharga Rp 120!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (PlayerInfo.mystic > 0)
            {
                PlayerInfo.mystic--;
                PlayerInfo.money += 250;
                mys.Text = "Mystic      : " + PlayerInfo.mystic;
                uang.Text = "Uang: Rp " + PlayerInfo.money;
                MessageBox.Show("Kamu menjual 1 Mystic Wood seharga Rp 250!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(PlayerInfo.money >= 1500 && PlayerInfo.ironAxe == false)
            {
                PlayerInfo.money -= 1500;
                PlayerInfo.ironAxe = true;
                uang.Text = "Uang: Rp " + PlayerInfo.money;
                button5.Visible = false;
                label3.Text = "Owned : Iron";
                MessageBox.Show("Kamu membeli Iron Axe!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(PlayerInfo.money >= 6000 && PlayerInfo.diamondAxe == false)
            {
                PlayerInfo.money -= 6000;
                PlayerInfo.diamondAxe = true;
                uang.Text = "Uang: Rp " + PlayerInfo.money;
                button6.Visible = false;
                label4.Text = "Owned : Diamond";
                MessageBox.Show("kamu membeli Diamond Axe!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(PlayerInfo.oak == 0 && PlayerInfo.mahogany == 0 && PlayerInfo.mystic == 0)
            {
                MessageBox.Show("Kamu tidak memiliki kayu untuk dijual!");
                return;
            }

            string message = "Kamu menjual\n";
            if (PlayerInfo.oak > 0)
            {
                PlayerInfo.money += 50 * PlayerInfo.oak;
                message += PlayerInfo.oak + " Oak Wood = Rp " + 50*PlayerInfo.oak + "\n";
                PlayerInfo.oak = 0;
                oak.Text = "Oak         : " + PlayerInfo.oak;
                uang.Text = "Uang: Rp " + PlayerInfo.money;

            }

            if(PlayerInfo.mahogany > 0)
            {
                PlayerInfo.money += 120 * PlayerInfo.mahogany;
                message += PlayerInfo.mahogany + " Mahogany Wood = Rp " + 120 * PlayerInfo.mahogany + "\n";
                PlayerInfo.mahogany = 0;
                mah.Text = "Mahogany    : " + PlayerInfo.mahogany;
                uang.Text = "Uang: Rp " + PlayerInfo.money;
            }

            if(PlayerInfo.mystic > 0)
            {
                PlayerInfo.money += 250 * PlayerInfo.mystic;
                message += PlayerInfo.mystic + " Mystic Wood = Rp " + 250 * PlayerInfo.mystic + "\n";
                PlayerInfo.mystic = 0;
                mys.Text = "Mystic      : " + PlayerInfo.mystic;
                uang.Text = "Uang: Rp " + PlayerInfo.money;
            }

            MessageBox.Show(message);

        }
    }
}
