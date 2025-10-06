using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas
{
    public class ListItem
    {
        public static List<Tackle> listTackle = new List<Tackle>();
        public static List<Food> listFoods = new List<Food>();
        public static List<Fish> listFish = new List<Fish>();
        public static List<Item> inventory = new List<Item>();

        public ListItem()
        {
            listTackle.Add(new Tackle("Wood Rod", 5, 60));
            listTackle.Add(new Tackle("Fiberglass Rod", 8, 120));
            listTackle.Add(new Tackle("Steel Rod", 12, 220));
            listTackle.Add(new Tackle("Pro Angler Rod", 16, 380));

            listFoods.Add(new Food("Bread", 10, 5, 3, 12));
            listFoods.Add(new Food("Onigiri", 20, 10, 4, 25));
            listFoods.Add(new Food("Spicy Curry", 35, 15, 5, 60));
            listFoods.Add(new Food("Energy Drink", 50, 20, 2, 90));
            listFoods.Add(new Food("Fish Stew", 25, 12, 4, 48));

            listFish.Add(new Fish("Carp", "Common", 1, 8, 1, 4,1));
            listFish.Add(new Fish("Perch", "Common", 1, 9, 1, 3,1));
            listFish.Add(new Fish("Pike", "Uncommon", 2, 12, 2, 6,2));
            listFish.Add(new Fish("Catfish", "Uncommon", 2, 13, 3, 7,2));
            listFish.Add(new Fish("Salmon", "Rare", 3, 20, 3, 9,4));
            listFish.Add(new Fish("Trout", "Rare", 3, 18, 2, 8,4));
            listFish.Add(new Fish("Tuna", "Epic", 4, 28, 5, 15,7));
            listFish.Add(new Fish("Swordfish", "Epic", 4, 32, 6, 16,7));
            listFish.Add(new Fish("Golden Carp", "Legendary", 5, 50, 8, 20,12));
            listFish.Add(new Fish("Ancient Sturgeon", "Legendary", 5, 55, 9, 22,12));

        }
    }
}
