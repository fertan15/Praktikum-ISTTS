using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriW3
{
    public class Player : PictureBox
    {
        public int posX, posY;

        public void move(int posX, int posY)
        {
            this.posX = posX ;
            this.posY = posY ;
            this.Location = new Point(posX, posY);
        }

        public Rectangle PlayerRect
        {
            get { return new Rectangle(posX, posY, this.Width, this.Height); }
        }


        public Player(int posX, int posY)
        {
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Location = new Point(posX, posY);
            this.posX = posX;
            this.posY = posY;

            this.Size = new Size(64, 80);
            this.Image = Image.FromFile("./assets/player.png");
        }
    }
}
