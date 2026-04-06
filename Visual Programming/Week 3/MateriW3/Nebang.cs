using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriW3
{
    public partial class Nebang : Form
    {
        Pohon p;
        int hit = 0, miss = 0, hitTarget;
        public Nebang(Pohon p)
        {
            InitializeComponent();
            this.p = p;
            timer1.Start();


            //set hit target based on axe
            switch (PlayerInfo.equippedAxe)
            {
                case 0:
                    switch (p.name)
                    {
                        case "Oak":
                            hitTarget = 3;
                            break;
                        case "Mahogany":
                            hitTarget = 5;
                            break;
                        case "Mystic":
                            hitTarget = 8;
                            break;
                    }
                    break;
                case 1:
                    switch (p.name)
                    {
                        case "Oak":
                            hitTarget = 2;
                            break;
                        case "Mahogany":
                            hitTarget = 3;
                            break;
                        case "Mystic":
                            hitTarget = 5;
                            break;
                    }

                    break;
                case 2:
                    switch (p.name)
                    {
                        case "Oak":
                            hitTarget = 1;
                            break;
                        case "Mahogany":
                            hitTarget = 2;
                            break;
                        case "Mystic":
                            hitTarget = 3;
                            break;
                    }

                    break;
            }
            label2.Text = "Target Hit: " + hitTarget;
        }
        int value = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(value >= 0)
            {
                progressBar1.Value += value;

                if(progressBar1.Value == 100)
                {
                    value = -5;
                }
            }
            else
            {
                progressBar1.Value += value;

                if (progressBar1.Value == 0)
                {
                    value = 5;
                }

            }

        }

        private void Nebang_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                if (progressBar1.Value >= 60 && progressBar1.Value <= 85)
                {
                    hit++;
                    refHM();
                    if (hit == hitTarget)
                    {
                        //chopped
                        PlayerInfo.chopped = true;
                        MessageBox.Show("Berhasil menebang pohon!");
                        this.Close();
                    }
                }
                else
                {
                    miss++;
                    refHM();
                    if (miss == 3)
                    {
                        MessageBox.Show("Gagal menebang pohon!");
                        this.Close();

                    }
                }


                progressBar1.Value = 0;
                value = 5;

            }
        }

        public void refHM()
        {
            label3.Text = "Hit: " + hit + " | Miss : " + miss + "/3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(progressBar1.Value >= 60 && progressBar1.Value <= 85)
            {
                hit++;
                refHM();
                if(hit == hitTarget)
                {
                    //chopped
                    MessageBox.Show("Berhasil menebang pohon!");
                    PlayerInfo.chopped = true;
                    this.Close();
                }
            }
            else
            {
                miss++;
                refHM();
                if(miss == 3)
                {
                    MessageBox.Show("Gagal menebang pohon!");
                    this.Close();

                }
            }

            progressBar1.Value = 0;
            value = 5;

        }
    }
}
