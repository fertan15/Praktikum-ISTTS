using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MateriW3
{
    public static class PlayerInfo
    {
        public static string connectionString = "Server=localhost;Database=pv_t6_224117127;userID=root;password=;";

        public static int money = 0;
        public static int levelWarung = 0;
        public static int dayCount = 0;
        public static int oak = 0;
        public static int mahogany = 0;
        public static int mystic = 0;

        public static Boolean stoneAxe = true;
        public static Boolean ironAxe = false;
        public static Boolean diamondAxe = false;

        public static int equippedAxe = 0; //0 = stone, 1 = iron, 2 = steel

        public static bool chopped = false;

        public static int lastHour = 6;
        public static int lastMinute = 0;


        private static Random rand = new Random();

        /// <summary>
        /// Mensimulasikan penjualan harian untuk 3 slot item di warung.
        /// </summary>
        public static List<RingkasanPenjualan> SimulasikanPenjualanHarian(int hariKe)
        {
            List<RingkasanPenjualan> ringkasan = new List<RingkasanPenjualan>();

            // 1. Definisikan variabel untuk 3 slot item
            string item1 = null, item2 = null, item3 = null;
            int harga1 = 0, harga2 = 0, harga3 = 0;
            int jumlah1 = 0, jumlah2 = 0, jumlah3 = 0;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // 2. Ambil data item dari 'warung' untuk ID 1, 2, dan 3
                string queryLoad = "SELECT id, item, harga, jumlah FROM warung WHERE id IN (1, 2, 3) AND jumlah > 0";
                using (var cmdLoad = new MySqlCommand(queryLoad, connection))
                {
                    using (var reader = cmdLoad.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            if (id == 1)
                            {
                                item1 = reader.GetString("item");
                                harga1 = reader.GetInt32("harga");
                                jumlah1 = reader.GetInt32("jumlah");
                            }
                            else if (id == 2)
                            {
                                item2 = reader.GetString("item");
                                harga2 = reader.GetInt32("harga");
                                jumlah2 = reader.GetInt32("jumlah");
                            }
                            else if (id == 3)
                            {
                                item3 = reader.GetString("item");
                                harga3 = reader.GetInt32("harga");
                                jumlah3 = reader.GetInt32("jumlah");
                            }
                        }
                    }
                } // Reader dan cmdLoad ditutup

                // 3. Mulai Transaksi
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // --- Proses Item 1 (ID 1) ---
                        if (jumlah1 > 0) // Cek jika item1 ada dan punya stok
                        {
                            int qtyTerjual = rand.Next(0, jumlah1 + 1);
                            if (qtyTerjual > 0)
                            {
                                int revenue = qtyTerjual * harga1;
                                // --- MODIFIKASI ---
                                // Hitung sisa stok
                                int stokSisa = jumlah1 - qtyTerjual;

                                // Panggil fungsi helper untuk eksekusi query
                                // --- MODIFIKASI --- (tambahkan stokSisa di akhir)
                                ExecutePenjualan(connection, transaction, hariKe, 1, item1, harga1, qtyTerjual, revenue, stokSisa);
                                money += revenue;
                                ringkasan.Add(new RingkasanPenjualan { Item = item1, Terjual = qtyTerjual, Pendapatan = revenue });
                            }
                        }

                        // --- Proses Item 2 (ID 2) ---
                        if (jumlah2 > 0) // Cek jika item2 ada dan punya stok
                        {
                            int qtyTerjual = rand.Next(0, jumlah2 + 1);
                            if (qtyTerjual > 0)
                            {
                                int revenue = qtyTerjual * harga2;
                                // --- MODIFIKASI ---
                                int stokSisa = jumlah2 - qtyTerjual;

                                // --- MODIFIKASI --- (tambahkan stokSisa di akhir)
                                ExecutePenjualan(connection, transaction, hariKe, 2, item2, harga2, qtyTerjual, revenue, stokSisa);
                                money += revenue;
                                ringkasan.Add(new RingkasanPenjualan { Item = item2, Terjual = qtyTerjual, Pendapatan = revenue });
                            }
                        }

                        // --- Proses Item 3 (ID 3) ---
                        if (jumlah3 > 0) // Cek jika item3 ada dan punya stok
                        {
                            int qtyTerjual = rand.Next(0, jumlah3 + 1);
                            if (qtyTerjual > 0)
                            {
                                int revenue = qtyTerjual * harga3;
                                // --- MODIFIKASI ---
                                int stokSisa = jumlah3 - qtyTerjual;

                                // --- MODIFIKASI --- (tambahkan stokSisa di akhir)
                                ExecutePenjualan(connection, transaction, hariKe, 3, item3, harga3, qtyTerjual, revenue, stokSisa);
                                money += revenue;
                                ringkasan.Add(new RingkasanPenjualan { Item = item3, Terjual = qtyTerjual, Pendapatan = revenue });
                            }
                        }

                        // Jika semua berhasil, Commit
                        transaction.Commit();
                        Console.WriteLine("Penjualan harian berhasil diproses.");
                    }
                    catch (Exception ex)
                    {
                        // Jika gagal, batalkan semua
                        transaction.Rollback();
                        Console.WriteLine("Error saat transaksi penjualan: " + ex.Message);
                        ringkasan.Clear();
                    }
                } // Transaksi selesai
            } // Koneksi ditutup

            return ringkasan;
        }

        /// --- MODIFIKASI ---
        /// Helper function untuk menjalankan query INSERT (history) dan UPDATE/DELETE (warung)
        /// Perhatikan penambahan parameter "int stokSisa" di akhir
        private static void ExecutePenjualan(MySqlConnection connection, MySqlTransaction transaction, int hariKe, int itemId, string namaItem, int harga, int qtyTerjual, int revenue, int stokSisa)
        {
            // PERINTAH A: Masukkan ke tabel 'history' (Tidak berubah)
            string queryHistory = @"
                INSERT INTO history (Day, Item, `Unit Price`, Qty, Revenue)
                VALUES (@day, @item, @price, @qty, @revenue);
            ";
            using (var cmdHistory = new MySqlCommand(queryHistory, connection, transaction))
            {
                cmdHistory.Parameters.AddWithValue("@day", hariKe);
                cmdHistory.Parameters.AddWithValue("@item", namaItem);
                cmdHistory.Parameters.AddWithValue("@price", harga);
                cmdHistory.Parameters.AddWithValue("@qty", qtyTerjual);
                cmdHistory.Parameters.AddWithValue("@revenue", revenue);
                cmdHistory.ExecuteNonQuery();
            }

            // --- MODIFIKASI ---
            // PERINTAH B: Kurangi stok di tabel 'warung' (atau HAPUS jika 0)
            if (stokSisa == 0)
            {
                // Stok habis, HAPUS item dari warung
                string queryWarung = @"DELETE FROM warung WHERE id = @id;";
                using (var cmdWarung = new MySqlCommand(queryWarung, connection, transaction))
                {
                    cmdWarung.Parameters.AddWithValue("@id", itemId);
                    cmdWarung.ExecuteNonQuery();
                }
            }
            else
            {
                // Stok masih ada, UPDATE jumlah
                string queryWarung = @"
                    UPDATE warung SET jumlah = @stokSisa
                    WHERE id = @id;
                ";
                using (var cmdWarung = new MySqlCommand(queryWarung, connection, transaction))
                {
                    cmdWarung.Parameters.AddWithValue("@stokSisa", stokSisa);
                    cmdWarung.Parameters.AddWithValue("@id", itemId);
                    cmdWarung.ExecuteNonQuery();
                }
            }
        }


        public static void SaveProgress()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                  
                    string query = @" 
                        INSERT INTO progress (
                            id, money, oak, mahogany, mystic, 
                            stoneAxe, ironAxe, diamondAxe, equippedAxe, chopped, 
                            day, jam, menit, levelWarung
                        ) 
                        VALUES (
                            1, @money, @oak, @mahogany, @mystic, 
                            @stoneAxe, @ironAxe, @diamondAxe, @equippedAxe, @chopped, 
                            @day, @jam, @menit, @levelWarung
                        )
                        ON DUPLICATE KEY UPDATE
                            money = @money,
                            oak = @oak,
                            mahogany = @mahogany,
                            mystic = @mystic,
                            stoneAxe = @stoneAxe,
                            ironAxe = @ironAxe,
                            diamondAxe = @diamondAxe,
                            equippedAxe = @equippedAxe,
                            chopped = @chopped,
                            day = @day,
                            jam = @jam,
                            menit = @menit,
                            levelWarung = @levelWarung
                    ";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@money", PlayerInfo.money);
                        cmd.Parameters.AddWithValue("@oak", PlayerInfo.oak);
                        cmd.Parameters.AddWithValue("@mahogany", PlayerInfo.mahogany);
                        cmd.Parameters.AddWithValue("@mystic", PlayerInfo.mystic);
                        cmd.Parameters.AddWithValue("@stoneAxe", PlayerInfo.stoneAxe);
                        cmd.Parameters.AddWithValue("@ironAxe", PlayerInfo.ironAxe);
                        cmd.Parameters.AddWithValue("@diamondAxe", PlayerInfo.diamondAxe);
                        cmd.Parameters.AddWithValue("@equippedAxe", PlayerInfo.equippedAxe);
                        cmd.Parameters.AddWithValue("@chopped", PlayerInfo.chopped);
                        cmd.Parameters.AddWithValue("@day", PlayerInfo.dayCount);
                        cmd.Parameters.AddWithValue("@jam", PlayerInfo.lastHour);
                        cmd.Parameters.AddWithValue("@menit", PlayerInfo.lastMinute);
                        cmd.Parameters.AddWithValue("@levelWarung", PlayerInfo.levelWarung);
                                                   
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Progress saved successfully.");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving progress: " + ex.Message);

            }
        }

        public static bool LoadProgress()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Select the progress from the row with id = 1
                    string query = "SELECT * FROM progress WHERE id = 1";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the static PlayerInfo class
                                PlayerInfo.money = reader.GetInt32("money");
                                PlayerInfo.oak = reader.GetInt32("oak");
                                PlayerInfo.mahogany = reader.GetInt32("mahogany");
                                PlayerInfo.mystic = reader.GetInt32("mystic");
                                PlayerInfo.stoneAxe = reader.GetBoolean("stoneAxe");
                                PlayerInfo.ironAxe = reader.GetBoolean("ironAxe");
                                PlayerInfo.diamondAxe = reader.GetBoolean("diamondAxe");
                                PlayerInfo.equippedAxe = reader.GetInt32("equippedAxe");
                                PlayerInfo.chopped = reader.GetBoolean("chopped");
                                PlayerInfo.dayCount = reader.GetInt32("day");
                                PlayerInfo.lastHour = reader.GetInt32("jam");     
                                PlayerInfo.lastMinute = reader.GetInt32("menit");
                                PlayerInfo.levelWarung = reader.GetInt32("levelWarung");

                                Console.WriteLine("Progress loaded successfully.");
                                return true;
                            }
                            else
                            {
                                // No save file found
                                Console.WriteLine("No save data found");
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading progress: {ex.Message}");
                return false;
            }
        }
    }


}
