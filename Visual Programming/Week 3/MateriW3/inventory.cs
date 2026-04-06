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
    public partial class inventory : Form
    {
        public inventory()
        {
            InitializeComponent();

            uang.Text = "Uang: Rp " + PlayerInfo.money;
            oak.Text = "Oak         : " + PlayerInfo.oak;
            mah.Text = "Mahogany    : " + PlayerInfo.mahogany;
            mys.Text = "Mystic      : " + PlayerInfo.mystic;

            if(PlayerInfo.equippedAxe == 0)
            {
                stone.Checked = true;
            }
            else if(PlayerInfo.equippedAxe == 1)
            {
                iron.Checked = true;
            }
            else
            {
                diamond.Checked = true;
            }


            if(PlayerInfo.ironAxe == false)
            {
                iron.Enabled = false;
            }
            if (PlayerInfo.diamondAxe == false)
            {
                diamond.Enabled = false;
            }


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void stone_CheckedChanged(object sender, EventArgs e)
        {
            if(stone.Checked == true)
            {
                PlayerInfo.equippedAxe = 0;
            }
        }

        private void iron_CheckedChanged(object sender, EventArgs e)
        {
            if (iron.Checked == true)
            {
                PlayerInfo.equippedAxe = 1;
            }
        }

        private void diamond_CheckedChanged(object sender, EventArgs e)
        {
            if (diamond.Checked == true)
            {
                PlayerInfo.equippedAxe = 2;
            }
        }
    }
}
