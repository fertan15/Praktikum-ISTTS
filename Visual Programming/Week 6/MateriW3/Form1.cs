using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MateriW3
{
    public partial class Form1 : Form
    {

        bool load = PlayerInfo.LoadProgress();
        Timer moveTimer = new Timer();

        int jam = PlayerInfo.lastHour, menit = PlayerInfo.lastMinute;
        Player player;
        PictureBox home, shop, warung;
        bool inLoading = true;
        Rectangle punyaShop, punyaHome, punyaWarung;
        List<Pohon> listPohon = new List<Pohon>();
        public Form1()
        {
            InitializeComponent();
            time.Text = string.Format("{0:00}:{1:00}", jam, menit);


            moveTimer.Interval = 16; 
            moveTimer.Tick += moveTimer_Tick;
            moveTimer.Start();


            //set Home
            home = new PictureBox();
            home.Image = Image.FromFile("./assets/home.png");
            home.SizeMode = PictureBoxSizeMode.Zoom;
            home.Location = new Point(650, 220);
            home.Size = new Size(128, 160);
                //rect home




            //set Home
            shop = new PictureBox();
            shop.Image = Image.FromFile("./assets/shop.png");
            shop.SizeMode = PictureBoxSizeMode.Zoom;
            shop.Location = new Point(30, 220);
            shop.Size = new Size(128, 160);

            //warung
            warung = new PictureBox();
            warung.Image = Image.FromFile("./assets/warung.png");
            warung.SizeMode = PictureBoxSizeMode.Zoom;
            warung.Location = new Point(300, 220);
            warung.Size = new Size(72,96);

            player = new Player(50, 100);
            
            panel.Controls.Add(home);
            panel.Controls.Add(shop);
            panel.Controls.Add(warung);
            panel.Controls.Add(player);


            punyaHome = new Rectangle(home.Location, home.Size);
            punyaShop = new Rectangle(shop.Location, shop.Size);
            punyaWarung = new Rectangle(warung.Location, new Size(72, 50));
            nextDay();
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            int nextDx = player.posX;
            int nextDy = player.posY;

            if (moveUp) nextDy -= 5;
            if (moveDown) nextDy += 5;
            if (moveLeft) nextDx -= 5;
            if (moveRight) nextDx += 5;

            Rectangle nextRect = new Rectangle(nextDx, nextDy, player.Width, player.Height);

            // ❌ Prevent leaving panel bounds
            if (nextDx < 0 || nextDx > panel.Width - player.Width ||
                nextDy < 0 || nextDy > panel.Height - player.Height)
                return;

            // 🏠 Collision: Home
            if (nextRect.IntersectsWith(punyaHome))
            {
                if (Fpressed)
                {
                    Fpressed = false;
                    DialogResult result = MessageBox.Show("Tidur untuk lanjut ke hari berikutnya?", "Rumah", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        waktu.Stop();
                        nextDay();
                    }
                    return;

                }
                return;
            }

            // 🏪 Collision: Shop
            if (nextRect.IntersectsWith(punyaShop))
            {
                if (Fpressed)
                {
                    Fpressed = false;
                    waktu.Stop();
                    Shop shop = new Shop();
                    shop.ShowDialog();
                    waktu.Start();
                }
                return;
            }

            if (nextRect.IntersectsWith(punyaWarung))
            {
                if (Epressed)
                {
                    Epressed = false;
                    waktu.Stop();
                    if (PlayerInfo.levelWarung==0)
                    {
                        DialogResult result = MessageBox.Show(
                        "Beli Warung Kayu seharga Rp 1.000 ?",  // Message
                        "Warung Kayu",                           // Title
                        MessageBoxButtons.YesNo,                 // Buttons
                        MessageBoxIcon.Question                  // Icon
                        );

                        if (result == DialogResult.Yes)
                        {
                            if (PlayerInfo.money < 1000)
                            {
                                MessageBox.Show("Uang tidak cukup untuk membeli Warung Kayu!");
                                waktu.Start();
                                return;
                            }
                            PlayerInfo.levelWarung = 1;
                            PlayerInfo.money -= 1000;
                            MessageBox.Show("Anda membeli Warung Kayu!");
                        }
                        else
                        {
                            MessageBox.Show("Pembelian dibatalkan.");
                            return;
                        }


                    }

                    warung warung = new warung();
                    warung.ShowDialog();
                    waktu.Start();
                }
                return;
            }


            // 🌳 Collision: Trees
            foreach (Pohon p in listPohon)
            {
                if (nextRect.IntersectsWith(p.pohonRect))
                {
                    if (Fpressed)
                    {
                        Fpressed = false;
                        waktu.Stop();
                        PlayerInfo.chopped = false;
                        Nebang nebang = new Nebang(p);
                        nebang.ShowDialog();

                        if (PlayerInfo.chopped)
                        {
                            if (p.name == "Oak") PlayerInfo.oak += p.logsPerPohon;
                            else if (p.name == "Mahogany") PlayerInfo.mahogany += p.logsPerPohon;
                            else PlayerInfo.mystic += p.logsPerPohon;

                            MessageBox.Show("Kamu mendapatkan " + p.logsPerPohon + " " + p.name + " Wood!");
                            panel.Controls.Remove(p);
                            listPohon.Remove(p);
                        }

                        waktu.Start();

                    }
                    return;
                }
            }

            player.move(nextDx, nextDy);
        }

        Boolean moveUp, moveDown, moveLeft, moveRight, Fpressed, Epressed;

        private void button1_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value == 2)
            {
                MessageBox.Show("Selamat, anda pintar sekali jadi gadapet hadiah!!!! karena gaada pun kayaknya ga masalah ygy");
            }
            else
            {
                MessageBox.Show("Masa Depan anda mencemaskan, jadi akan mendapatkan hadiah 100G yeyyyyy!");
                PlayerInfo.money += 100;
            }
            panel1.Enabled = false;
            panel1.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PlayerInfo.lastHour = jam;
            PlayerInfo.lastMinute = menit;

            PlayerInfo.SaveProgress();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                moveUp = false;
            if (e.KeyCode == Keys.S)
                moveDown = false;
            if (e.KeyCode == Keys.A)
                moveLeft = false;
            if (e.KeyCode == Keys.D)
                moveRight = false;
            if(e.KeyCode == Keys.F)
                Fpressed = false;
            if (e.KeyCode == Keys.E)
                Epressed = false;


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) moveUp = true;
            if (e.KeyCode == Keys.S) moveDown = true;
            if (e.KeyCode == Keys.A) moveLeft = true;
            if (e.KeyCode == Keys.D) moveRight = true;
            if(e.KeyCode == Keys.F) Fpressed = true;
            if(e.KeyCode == Keys.E) Epressed = true;

            // interactions only on keypress, not every frame
            if (e.KeyCode == Keys.I)
            {
                waktu.Stop();
                inventory inv = new inventory();
                inv.ShowDialog();
                waktu.Start();
            }
            if (e.KeyCode == Keys.H)
            {
                waktu.Stop();
                History h = new History();
                h.ShowDialog();
                waktu.Start();
            }



        }
        Random rand = new Random();
        public void nextDay()
        {
            waktu.Start();
            //ilangin pohon lama
            foreach(Pohon p in listPohon)
            {
                panel.Controls.Remove(p);
            }

            if(!inLoading)
                PlayerInfo.dayCount++;
            //reset waktu
            if (!inLoading)
                jam = 6; menit = 0;
            day.Text = "Day: " + PlayerInfo.dayCount;

            player.move(200, 250);

            //reset pohon
            listPohon = new List<Pohon>();
            //random jumlah pohon
            int jumlahPohon = rand.Next(8, 13);
            for(int i = 0; i < jumlahPohon; i++)
            {
                int jenisPohonrandom = rand.Next(0, 10);
                int jenis = 0;
                if (jenisPohonrandom < 6)
                {
                    jenis = 0; //oak
                }
                else if (jenisPohonrandom < 9)
                {
                    jenis = 1; //mahogany
                }
                else 
                {
                    jenis = 2; //mystic
                }

                int posX = rand.Next(0, panel.Width - 64);
                int posY = rand.Next(0, 220 - 80);
                //cek tabrakan
                Rectangle rectBaru = new Rectangle(posX, posY, 64, 80);
                Boolean tabrakan = false;
                foreach(Pohon p in listPohon)
                {
                    if(rectBaru.IntersectsWith(p.pohonRect))
                    {
                        tabrakan = true;
                        break;
                    }
                }
                if (tabrakan || rectBaru.IntersectsWith(punyaHome) || rectBaru.IntersectsWith(punyaShop) || rectBaru.IntersectsWith(punyaWarung))
                {
                    i--;
                    continue;
                }
                Pohon pohon = new Pohon(jenis, posX, posY);
                listPohon.Add(pohon);
                panel.Controls.Add(pohon);
            }

            if (!inLoading)
            {
                string ringkasanTeks;
                List<RingkasanPenjualan> ringkasan = PlayerInfo.SimulasikanPenjualanHarian(PlayerInfo.dayCount);
                if (ringkasan.Count == 0)
                {
                    ringkasanTeks = "Tidak ada barang yang terjual hari ini.";
                }
                else
                {
                    ringkasanTeks = string.Join("\n", ringkasan);
                }
                MessageBox.Show("Ringkasan Penjualan Hari ke-" + PlayerInfo.dayCount + ":\n\n" + ringkasanTeks,
                                "Laporan Penjualan");
            }

            inLoading = false;
        }

        private void waktu_Tick(object sender, EventArgs e)
        {
            menit++;
            if(menit == 60)
            {
                jam++;
                menit = 0;
            }


            time.Text = string.Format("{0:00}:{1:00}", jam, menit);
        
            if(jam == 24 )
            {
                waktu.Stop();
                int moneydicuri =(int)( PlayerInfo.money * 0.1);
                MessageBox.Show("Kamu Kelelahan dan Pingsan!\nUangmu dicuri Rp " + moneydicuri + " (-10%)");
                PlayerInfo.money -= moneydicuri;
                nextDay();
            }
        
        }
    }
}
