using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriW4
{
    public partial class addStok : Form
    {
        public addStok()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.stockAdded = (int)numericUpDown1.Value;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data.stockAdded = 0;
            this.Close();

        }
    }
}
