using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriW3
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            dgvHistory.AutoGenerateColumns = true; // Pastikan kolom dibuat otomatis
            dgvHistory.ReadOnly = true; // Agar user tidak bisa edit
            dgvHistory.AllowUserToAddRows = false; // Hindari baris kosong di akhir
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Pilih satu baris penuh
            MuatDanTampilkanHistory();

        }

        private void MuatDanTampilkanHistory()
        {
            DataTable dtHistory = new DataTable();
            long totalRevenue = 0; // Menggunakan long untuk total revenue agar aman dari overflow

            try
            {
                using (var connection = new MySqlConnection(PlayerInfo.connectionString))
                {
                    connection.Open();
                    // Pastikan nama kolom 'Unit Price' di query ini sesuai dengan nama kolom di DB
                    // Perhatikan backticks (`) untuk nama kolom dengan spasi
                    string query = "SELECT Day, Item, `Unit Price`, Qty, Revenue FROM history ORDER BY Day DESC, Id DESC"; // Urutkan terbaru dulu

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dtHistory);
                    }
                }

                // Bind DataTable ke DataGridView
                dgvHistory.DataSource = dtHistory;

                // Hitung Total Revenue dari DataTable
                if (dtHistory.Rows.Count > 0)
                {
                    // Pastikan nama kolom "Revenue" sesuai di DataTable
                    // Menggunakan LINQ untuk Sum
                    totalRevenue = dtHistory.AsEnumerable().Sum(row => row.Field<int>("Revenue"));
                }

                // Tampilkan Total Revenue
                label1.Text = $"Total Revenue: Rp {totalRevenue:N0}"; // :N0 untuk format ribuan

                // Opsional: Atur lebar kolom agar pas
                dgvHistory.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error memuat history: {ex.Message}", "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Kosongkan DGV jika ada error
                dgvHistory.DataSource = null;
                label1.Text = "Total Revenue: Rp 0";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Tutup form history

        }
    }
}
