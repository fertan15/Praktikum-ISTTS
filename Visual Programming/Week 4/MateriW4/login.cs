using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MateriW4
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();

            //data admin
            DataRow row = Data.User.NewRow();
            row["Username"] = "admin";
            row["Password"] = "admin";
            row["isAdmin"] = true;
            Data.User.Rows.Add(row);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                return;
            if (textBox2.Text == "")
                return;

            int hasil = Data.addUser(textBox1.Text, textBox2.Text);

            if(hasil == -1)
            {
                MessageBox.Show("Salah Password");
            }

            if (hasil == 1)
            {
                MessageBox.Show("welcome user");
                Data.logInUser = textBox1.Text;
                userPage userPage = new userPage(this);
                userPage.Show();
                this.Hide();
            }

            if (hasil == 2)
            {
                MessageBox.Show("welcome admin");
                adminPage userPage = new adminPage(this);
                userPage.Show();
                this.Hide();
            }

            refresh();
        }

        public void refresh()
        {
            textBox1.Clear();
            textBox2.Clear();
             
        }
    }
}
