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
    public partial class Form2 : Form
    {


        List<User> users;

        public Form2(List<User> users)
        {
            InitializeComponent();
            this.users = users;
        }
        public Form2()
        {
            InitializeComponent();
            users = new List<User>();
            User dummy = new User("admin", "admin", "admin", "00000");
            dummy.money = 1000000;
            users.Add(dummy);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                MessageBox.Show("username harus diisi");
                return;

            }

            if (password.Text == "")
            {
                MessageBox.Show("password harus diisi");
                return;
            }


            foreach (User user in users)
            {

                if (user.username == username.Text)
                {
                    if (user.password == password.Text)
                    {
                        MessageBox.Show("Login Berhasil");
                        Form1 form1 = new Form1(user, this);
                        form1.Show();
                        this.Hide();
                        username.Text = "";
                        password.Text = "";
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Password salah");
                        return;
                    }

                }
            }
            MessageBox.Show("Username tidak ditemukan");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(users);
            form.Show();
            this.Hide();
            username.Text = "";
            password.Text = "";
            return;

        }
    }
}
