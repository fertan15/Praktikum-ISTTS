using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachine
{
    public class User
    {
        public string name { get; set; }
        public string password { get; set; }
        public string username  { get; set; }
        public string refferal  { get; set; }

        public int money { get; set; }
        public int Vendingmoney { get; set; }

        public List<String> inventory { get; set; }


        Random rand = new Random();

        public User(string name, string password, string username)
        {
            Vendingmoney = 0;
            inventory = new List<String>();
            this.name = name;
            this.password = password;
            this.username = username;
            
            //buat refferal code
            this.refferal = rand.Next(10000, 100000).ToString();

        }

        public User(string name, string password, string username, string referral)
        {
            Vendingmoney = 0;
            inventory = new List<String>();

            this.name = name;
            this.password = password;
            this.username = username;

            //buat refferal code
            this.refferal = referral;


        }

    }
}
