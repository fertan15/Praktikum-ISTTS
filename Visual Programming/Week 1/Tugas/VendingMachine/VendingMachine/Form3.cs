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
    public partial class Form3 : Form
    {
        List<User> users;
        public Form3(List<User> users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && nama.Text != "" && password.Text != "")
            {
                foreach (User user in users)
                {
                    if (user.username == username.Text)
                    {
                        MessageBox.Show("Username sudah digunakan");
                        return;

                    }
                }

                if (password.Text.Length < 3)
                {
                    MessageBox.Show("Panjang Password Min 3");
                    return;
                }


                
                if (referral.Text!="")
                {
                    bool found = false;
                    foreach(User user in users)
                    {
                        if(user.refferal == referral.Text)
                        {
                            found = true;
                            break;
                        }
                    }
                    if(!found && referral.Text != "MONEY")
                    {
                        MessageBox.Show("Kode referral tidak valid");
                        return;
                    }
                    else
                    {
                        User newUser = new User(nama.Text, password.Text, username.Text);

                        if(referral.Text == "MONEY")
                        {
                            MessageBox.Show("Menggunakan referral MONEY, mendapatkan Rp100.000 sebagai hadiah");
                            newUser.money += 100000;

                        }
                        else
                        {
                            MessageBox.Show("refferral ditemukan, mendapatkan Rp50.000 sebagai hadiah");
                            newUser.money += 50000;

                        }
                        MessageBox.Show("Akun berhasil dibuat");
                        users.Add(newUser);
                        this.Close();
                        
                    }
                }

                User newUser1 = new User(nama.Text, password.Text, username.Text);
                users.Add(newUser1);
                this.Close();
                Form2 form2 = new Form2(users);
                form2.Show();


            }
            else
            {
                MessageBox.Show("Semua field harus diisi");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 form2 = new Form2(users);
            form2.Show();
        }
    }
}
