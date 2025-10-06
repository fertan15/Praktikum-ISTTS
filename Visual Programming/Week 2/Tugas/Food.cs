using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas
{
    public class Food : Item
    {
        public int price { get; set; }
        public int stamina { get; set; }
        public int luck { get; set; }
        public int duration { get; set; }
        public int stock { get; set; }

       
        public Food(String name, int stock)
        {
            var found = ListItem.listFoods.FirstOrDefault(item => item.name == name);

            if (found != null)
            {
                this.name = name;
                this.price = price;
                this.stamina = stamina;
                this.luck = luck;
                this.duration = duration;
            }
            else
            {
                MessageBox.Show(name + " not founded");
            }


            this.stock = stock;
        }
        public Food(string name, int stamina, int luck, int duration, int price)
        {
            this.name = name;
            this.price = price;
            this.stamina = stamina;
            this.luck = luck;
            this.duration = duration;
            this.stock = 0;
        }

        public Food(string name, int stamina, int luck, int duration, int price, int stock)
        {
            this.name = name;
            this.price = price;
            this.stamina = stamina;
            this.luck = luck;
            this.duration = duration;
            this.stock = stock;
        }

        public override string ToString()
        {
            return name + " x" + stock + " (STA +" + stamina + ". Luck +" + luck + "%. " + duration + " cast. $"+ price + ")";
        }

    }
}
