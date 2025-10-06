using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas
{
    public class Fish : Item
    {
        public Fish(string name, string rarity, int difficulty, int baseValue, int minWeight, int maxWeight, int rarityMultiplier)
        {
            this.name = name;
            this.rarity = rarity;
            this.difficulty = difficulty;
            this.baseValue = baseValue;
            this.minWeight = minWeight;
            this.maxWeight = maxWeight;
            stock = 0;
            this.rarityMultiplier = rarityMultiplier;
        }

        public Fish(String name, int weight, int price)
        {
            var found = ListItem.listFish.FirstOrDefault(item => item.name == name);

            if (found != null)
            {
                this.name = found.name;
                this.rarity = found.rarity;
                this.difficulty = found.difficulty;
                this.baseValue = found.baseValue;
                this.minWeight = found.minWeight;
                this.maxWeight = found.maxWeight;
                this.rarityMultiplier = found.rarityMultiplier;
                this.weight = weight;
                this.price = price;
            }
            else
            {
                MessageBox.Show(name + " not founded");
            }


        }
        public Fish(Fish found)
        {
            this.name = found.name;
            this.rarity = found.rarity;
            this.difficulty = found.difficulty;
            this.baseValue = found.baseValue;
            this.minWeight = found.minWeight;
            this.maxWeight = found.maxWeight;
            this.rarityMultiplier = found.rarityMultiplier;


        }

        public Fish(Fish found, int weight, int price)
        {
            this.name = found.name;
            this.rarity = found.rarity;
            this.difficulty = found.difficulty;
            this.baseValue = found.baseValue;
            this.minWeight = found.minWeight;
            this.maxWeight = found.maxWeight;
            this.weight = weight;
            this.price = price;
            this.rarityMultiplier =found.rarityMultiplier;



        }




        public string rarity { get; set; }
        public int difficulty { get; set; }
        public int price { get; set; }
        public int baseValue { get; set; }
        public int minWeight { get; set; }
        public int maxWeight { get; set; }
        public int stock { get; set; }
        public int weight { get; set; }
        public int rarityMultiplier { get; set; }

        public override string ToString()
        {
            return name + " (" + weight + " kg) - " + rarity + " - $" + price;
        }
    }
}
