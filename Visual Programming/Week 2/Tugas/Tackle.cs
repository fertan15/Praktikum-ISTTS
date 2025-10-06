using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas
{
    public class Tackle : Item
    {
        public int power { get; set; }
        public int price { get; set; }

        public Tackle(String name, int power, int price)
        {
            this.name = name;
            this.power = power;
            this.price = price;
        }

        public Tackle(String name)
        {
            var found = ListItem.listTackle.FirstOrDefault(item => item.name == name);

            if (found != null)
            {
                this.name = found.name;
                this.power = found.power;
                this.price = found.price;
            }
            else
            {
                MessageBox.Show(name + " not founded");
            }

        }


        public override string ToString()
        {
            return name + " (Pow " + power + ". $" +price + ")" ;
        }
    }
}
