using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriW4
{
    public static class Data
    {
        public static DataSet1 dataSet = new DataSet1();
        public static DataTable Stok = dataSet.Tables["Stok"];
        public static DataTable HistoryTransaksi = dataSet.Tables["HistoryTransaksi"];
        public static DataTable Antrian = dataSet.Tables["Antrian"];
        public static DataTable User = dataSet.Tables["User"];
        public static DataTable Cart = dataSet.Tables["Cart"];

        public static int stockAdded = 0;
        public static int orderNumber = 0;

        public static string logInUser = "";
        
        public static void addStok(string id, string nama, string tipe, DateTime releaseDate, int harga, string toppings, int stok)
         {
            DataRow row = Stok.NewRow();
            row["PizzaId"] = id;
            row["Nama"] = nama;
            row["Tipe"] = tipe;
            row["ReleaseDate"] = releaseDate;
            row["Harga"] = harga;
            row["Toppings"] = toppings;
            row["Stok"] = stok;
            Stok.Rows.Add(row);

        }
        public static void addHistoryTransaksi(string id, string username, DateTime tanggal,int total, string Items)
        {
            DataRow row = HistoryTransaksi.NewRow();
            row["OrderId"] = id;
            row["Username"] = username;
            row["Tanggal"] = tanggal;
            row["Total"] = total;
            row["Items"] = Items;
            HistoryTransaksi.Rows.Add(row);

        }

        public static void addAntrian(string id, string username, DateTime tanggal, int total, string Items, int jumlahItem)
        {
            DataRow row = Antrian.NewRow();
            row["OrderId"] = id;
            row["Username"] = username;
            row["Tanggal"] = tanggal;
            row["Total"] = total;
            row["Items"] = Items;
            row["JumlahItem"] = jumlahItem;

            row["View"] = id + " | " + username + " | " + jumlahItem + " item | Rp " + total;
            Antrian.Rows.Add(row);

        }

        public static int addUser( string username, string password)
        {

            if (User.Rows.Count >= 1)
            {

                for(int i = 0; i < User.Rows.Count; i++)
                {
                    //kalo ada akunnya
                    if (User.Rows[i]["username"].ToString() == username)
                    {
                        //cek password benar ga
                        if (User.Rows[i]["Password"].ToString() == password)
                        {
                            //kalo iya return yeah
                            //oiya cek admin bukan
                            if (Convert.ToBoolean(User.Rows[i]["isAdmin"]) == true)
                            {
                                //kalo iya balekin 2-> admin
                                return 2;
                            }
                            else
                            {
                                //user
                                return 1;
                            }


                        }

                        //password salah
                        return -1;
                    }
                }
            }

            //kalo gaada bikin baru
            DataRow row = User.NewRow();
            row["Username"] = username;
            row["Password"] = password;
            row["isAdmin"] = false;
            User.Rows.Add(row);


            return 1; //kalo misal rakyat jelata -> bukan admin yeah
        }

        public static void addCart(string id, string nama, int harga)
        {
            for (int i = 0; i < Cart.Rows.Count; i++)
            {
                if (id == Cart.Rows[i]["PizzaId"].ToString())
                {
                    Cart.Rows[i]["Qty"] = Convert.ToInt16(Cart.Rows[i]["Qty"]) + 1;
                    Cart.Rows[i]["Subtotal"] = Convert.ToInt16( Cart.Rows[i]["Qty"]) * harga;
                    return;
                }
            }




            DataRow row = Cart.NewRow();
            row["PizzaId"] = id;
            row["Nama"] = nama;
            row["Harga"] = harga;
            row["Qty"] = 1;
            row["Subtotal"] = harga * 1;
            Cart.Rows.Add(row);

        }



    }

}
