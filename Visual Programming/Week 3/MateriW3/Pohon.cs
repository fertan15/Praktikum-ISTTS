using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriW3 
{
    public class Pohon : PictureBox
    {
        public string name;
        public int logsPerPohon;
        public int hargaJual;
        public int posX;
        public int posY;

        public void changeLoc(int posX, int posY)
        {
            this.Location = new Point(posX, posY);
            this.posX = posX;
            this.posY = posY;
        }

        public Pohon(int choice, int posX, int posY)
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;

            changeLoc(posX, posY);
            this.Size = new Size(64, 80);

            if (choice == 0)
                setOak();
            if(choice == 1)
                setMahogany();
            if(choice == 2)
                setMystic();
        } 

        Random rand = new Random();
        public void setOak()
        {
            name = "Oak";
            logsPerPohon = rand.Next(2,5);
            hargaJual = 50;
            this.Image = Image.FromFile("./assets/oak.png");


        }
        public void setMahogany()
        {
            name = "Mahogany";
            logsPerPohon = rand.Next(4, 8);
            hargaJual = 120;
            this.Image = Image.FromFile("./assets/pine.png");

        }
        public void setMystic()
        {
            name = "Mystic";
            logsPerPohon = rand.Next(6, 11);
            hargaJual = 250;
            this.Image = Image.FromFile("./assets/birch.png");

        }

        public Rectangle pohonRect
        {
            get { return new Rectangle(posX, posY, this.Width, this.Height); }
        }

    }
}
