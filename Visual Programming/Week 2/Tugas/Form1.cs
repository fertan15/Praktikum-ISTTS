using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas
{
    public partial class Form1 : Form
    {
        List<Food> invFoods = new List<Food>();
        List<Fish> invFish = new List<Fish>();
        List<Tackle> invTackle = new List<Tackle>();
        int gpc; //gauge per cast
        int currentLuck = 0;
        int luckTurnLeft = 0;

        int money = 300;

        string mode = "cast";

        public Form1()
        {
            InitializeComponent();
            ListItem b = new ListItem();
            moneyUpdate(0);

            invFoods.Add(new Food("Bread", 10, 5, 3, 12, 3));
            invFoods.Add(new Food("Onigiri", 20, 10, 4, 25, 2));
            invFoods.Add(new Food("Spicy Curry", 35, 15, 5, 60, 1));

            invTackle.Add(new Tackle("Wood Rod"));
            invTackle.Add(new Tackle("Fiberglass Rod"));

            listBox5.Items.Add(new Tackle("Steel Rod"));
            listBox5.Items.Add(new Tackle("Pro Angler Rod"));
            listBox4.Items.Add(new Food("Energy Drink", 50, 20, 2, 90, 1));
            listBox4.Items.Add(new Food("Fish Stew", 25, 12, 4, 48, 1));



            refreshTackle();
            refreshFood();
            refreshInventory();
            progressBar2.Value = 100;
            progressBar1.Visible = false;
            label8.Text = "None";
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;

        }

        void refreshTackle()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < invTackle.Count; i++)
            {
                listBox1.Items.Add(invTackle[i].ToString());
            }

        }

        void refreshInventory()
        {
            listBox3.Items.Clear();
            for (int i = 0; i < invFish.Count; i++)
            {
                listBox3.Items.Add(invFish[i]);
            }

        }


        void useLuck()
        {
            if (luckTurnLeft <= 0)
            {
                currentLuck = 0;
                return;
            }
            else
            {
                luckTurnLeft -= 1;

                if (luckTurnLeft <= 0)
                {
                    currentLuck = 0;
                    label8.Text = "None";
                }
                else
                {
                    label8.Text = "None";
                    label8.Text = "+" + currentLuck + "% (" + luckTurnLeft + " cast)";
                }
            }
        }

        void refreshFood()
        {
            listBox2.Items.Clear();
            for (int i = 0; i < invFoods.Count; i++)
            {
                listBox2.Items.Add(invFoods[i].ToString());
            }

        }

        public void moneyUpdate(int amount)
        {
            money += amount;
            label3.Text = "Money: $" + money;
            label9.Text = "Money: $" + money;
            label10.Text = "Money: $" + money;
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int randomWeight;
        Fish caught;

        private void button2_Click(object sender, EventArgs e)
        {
            if (mode == "cast")
            {

                if (listBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("pilih tackle dulu");
                    return;
                }
                if (progressBar2.Value < 5)
                {
                    MessageBox.Show("Stamina kurang. Makan Food dulu.");
                    return;
                }
                progressBar2.Value -= 5;
                useLuck();

                Tackle usedTackle = invTackle[listBox1.SelectedIndex];

                //random hasil ikan dulu
                Random rnd = new Random();
                int randomFish = rnd.Next(0, 100);
                int randomfishP2 = rnd.Next(0, 2);

                if (randomFish <= 49) //common
                {
                    caught = new Fish(ListItem.listFish[0 + randomfishP2]);
                }
                else if (randomFish <= 74) //uncommon
                {
                    caught = new Fish(ListItem.listFish[2 + randomfishP2]);
                }
                else if (randomFish <= 89) //rare
                {
                    caught = new Fish(ListItem.listFish[4 + randomfishP2]);
                }
                else if (randomFish <= 96) //epic
                {
                    caught = new Fish(ListItem.listFish[6 + randomfishP2]);
                }
                else //legendary
                {
                    caught = new Fish(ListItem.listFish[8 + randomfishP2]);
                }

                int hookChance = 50 + usedTackle.power - (5 * caught.difficulty) + (currentLuck / 5);
                randomWeight = rnd.Next(caught.minWeight, caught.maxWeight + 1);

                int randomChance = rnd.Next(0, 100);
                if (randomChance < hookChance)
                {
                    MessageBox.Show("Lepas! " + caught.name + "(" + caught.rarity + ")");
                    return;
                }
                else
                {
                    MessageBox.Show("Hooked " + caught.name + "(" + randomWeight + " kg, " + caught.rarity + ".\nHooked!");
                }

                //ganti nama button
                button2.Text = "Reel!";
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                gpc = 8 + (usedTackle.power) - (2 * caught.difficulty);
                mode = "reel";
                //kurangi stamina
                return;
            }

            if (mode == "reel")
            {
                if (progressBar2.Value < 2)
                {
                    MessageBox.Show("Stamina habis saat menarik! Ikan kabur.");
                    button2.Text = "Cast!";
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                    mode = "cast";

                    return;
                }
                progressBar2.Value -= 2;

                int value = progressBar1.Value + gpc;

                if (value >= 100)
                {
                    progressBar1.Value = 100;
                    int nilaijual = (caught.baseValue * randomWeight * caught.rarityMultiplier);
                    MessageBox.Show("Menangkap: " + caught.name + "\nRarity: " + caught.rarity + "\nBerat: " + randomWeight + "\nNilai: $" + nilaijual);
                    invFish.Add(new Fish(caught, randomWeight, nilaijual));
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                    button2.Text = "Cast!";
                    mode = "cast";
                    refreshInventory();
                }
                else
                {
                    progressBar1.Value = value;
                }
            }





        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih makanan dulu");
                return;
            }

            Food usedFood = invFoods[listBox2.SelectedIndex];

            currentLuck = usedFood.luck;
            luckTurnLeft = usedFood.duration;
            invFoods[listBox2.SelectedIndex].stock -= 1;
            if (invFoods[listBox2.SelectedIndex].stock <= 0)
            {
                invFoods.RemoveAt(listBox2.SelectedIndex);
            }
            refreshFood();
            currentLuck = usedFood.luck;
            luckTurnLeft = usedFood.duration;
            label8.Text = "+" + currentLuck + "% (" + luckTurnLeft + " cast)";
            int staminanow = progressBar2.Value + usedFood.stamina;
            if (staminanow > 100)
            {
                staminanow = 100;
            }

            progressBar2.Value = staminanow;


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void listBox5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //shop tackle buy
            if (listBox5.SelectedIndex >= 0)
            {
                Tackle selectedTackle = (Tackle)listBox5.SelectedItem;
                DialogResult result = MessageBox.Show("Yakin Beli Tackle: " + selectedTackle.name + " seharga $" + selectedTackle.price + "?", "Konfirmasi Beli", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (money >= selectedTackle.price)
                    {
                        invTackle.Add(new Tackle(selectedTackle.name, selectedTackle.power, selectedTackle.price));
                        moneyUpdate(-selectedTackle.price);
                        MessageBox.Show("Berhasil Membeli " + selectedTackle.name);
                        refreshTackle();
                    }
                    else
                    {
                        MessageBox.Show("Uang tidak cukup untuk membeli " + selectedTackle.name);
                    }
                }

            }
        }

        private void listBox4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //shop food buy
            if (listBox4.SelectedIndex >= 0)
            {
                Food selectedTackle = (Food)listBox4.SelectedItem;
                DialogResult result = MessageBox.Show("Yakin Beli Makanan: " + selectedTackle.name + " seharga $" + selectedTackle.price + "?", "Konfirmasi Beli", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (money >= selectedTackle.price)
                    {
                        moneyUpdate(-selectedTackle.price);
                        //food 
                        //cek dulu ada di inv atau belum
                        var foundFood = invFoods.FirstOrDefault(item => item.name == selectedTackle.name);
                        if (foundFood != null)
                        {
                            foundFood.stock += 1;
                        }
                        else
                        {
                            invFoods.Add(new Food(selectedTackle.name, selectedTackle.stamina, selectedTackle.luck, selectedTackle.duration, selectedTackle.price, 1));
                        }


                        MessageBox.Show("Berhasil Membeli " + selectedTackle.name);
                        refreshFood();
                    }
                    else
                    {
                        MessageBox.Show("Uang tidak cukup untuk membeli " + selectedTackle.name);
                    }
                }

            }

        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;

        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Fish selected = (Fish)listBox3.SelectedItem;
            DialogResult result = MessageBox.Show("Yakin Jual " + selected.name + "(" + selected.weight + " kg, " + selected.rarity + ") seharga $" + selected.price + "?", "Konfirmasi Jual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                invFish.RemoveAt(listBox3.SelectedIndex);
                moneyUpdate(selected.price);
                refreshInventory();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //save button
            SaveFileDialog sfd = new SaveFileDialog(); // Dialog untuk menyimpan diary
            sfd.Filter = "Rich Text Format|*.rtf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach(Fish x in invFish)
                    {
                        sw.WriteLine(x.name);
                        sw.WriteLine(x.weight);
                        sw.WriteLine(x.price);
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //load button
            OpenFileDialog ofd = new OpenFileDialog(); // Dialog untuk memilih file diary
            ofd.Filter = "Rich Text Format|*.rtf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(ofd.FileName);
                if(lines.Length % 3 != 0)
                {
                    MessageBox.Show("File tidak valid");
                    return;
                }
                if(lines.Length <= 0)
                {
                    MessageBox.Show("File kosong");
                    return;
                }
                
                for(int i = 0; i < lines.Length; i+=3)
                {
                    string name = lines[i];
                    int weight = int.Parse(lines[i + 1]);
                    int price = int.Parse(lines[i + 2]);
                    invFish.Add(new Fish(name, weight, price));
                }

                refreshInventory();
                MessageBox.Show("Berhasil memuat data");


            }

        }
    }
}
