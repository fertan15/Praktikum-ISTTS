const express = require("express");
const { db } = require("./config/sequelize");
const { QueryTypes } = require("sequelize");
const app = express();
const port = 3005;

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

//function2 dan teman2
const hitungHarga = (jamMulai, durasi) => {
  let jam = parseInt(jamMulai.split(":")[0]);
  let hargaTotal = 0;
  console.log(`Jam mulai: ${jam}, Durasi: ${durasi} jam`);

  for (let i = 0; i < durasi; i++) {
    let hargaPerJam = 0;
    if (jam >= 6 && jam < 12) hargaPerJam = 55000;
    else if (jam >= 12 && jam < 18) hargaPerJam = 65000;
    else if (jam >= 18 && jam <= 23) hargaPerJam = 75000;

    hargaTotal += hargaPerJam;
    jam++;

    console.log(
      `jam ke-${i + 1}, Jam: ${jam}, harga per-jam: ${hargaPerJam}, Harga Total Sementara: ${hargaTotal}`,
    );
  }

  return hargaTotal;
};

const cekKetersediaanDB = async (
  tanggal,
  id_lapangan,
  jam_mulai,
  durasi,
  excludeId = null,
) => {
  let query = `
        SELECT id_reservasi 
        FROM reservasi 
        WHERE tanggal = :tanggal 
          AND id_lapangan = :id_lapangan 
          AND is_deleted = 0 
          AND (
              :jam_mulai < ADDTIME(jam_mulai, CONCAT(:durasi, ':00:00')) 
              AND 
              ADDTIME(:jam_mulai, CONCAT(:durasi, ':00:00')) > jam_mulai
          )
    `;

  const replacements = { tanggal, id_lapangan, jam_mulai, durasi };

  if (excludeId) {
    query += " AND id_reservasi != :excludeId";
    replacements.excludeId = excludeId;
  }

  const rows = await db.query(query, {
    replacements: replacements,
    type: QueryTypes.SELECT,
  });

  return rows.length > 0; // true = bentrok
};

//endpoint2 dan teman2
app.get("/", async (req, res) => {
  try {
  } catch (error) {
    return res.status(500).json({ error: error.message });
  }
});

//1 regis pelanggan
app.post("/api/customers", async (req, res) => {
  try {
    const { nama_pelanggan, no_whatsapp } = req.body;

    if (!nama_pelanggan || !no_whatsapp) {
      return res.status(400).json({
        status: "error",
        message: "Validasi gagal: no_whatsapp dan nama_pelanggan wajib diisi!",
      });
    }

    // Cek Duplikat WA
    const existing = await db.query(
      "SELECT * FROM pelanggan WHERE no_whatsapp = :no_whatsapp",
      {
        replacements: { no_whatsapp },
        type: QueryTypes.SELECT,
      },
    );

    if (existing.length > 0) {
      return res.status(409).json({
        status: "error",
        message: "Nomor WhatsApp sudah terdaftar di sistem",
      });
    }

    // Insert
    const [insertId] = await db.query(
      "INSERT INTO pelanggan (nama_pelanggan, no_whatsapp) VALUES (:nama_pelanggan, :no_whatsapp)",
      {
        replacements: { nama_pelanggan, no_whatsapp },
        type: QueryTypes.INSERT,
      },
    );

    res.status(201).json({
      status: "success",
      message: "Pelanggan berhasil didaftarkan",
      data: { id_pelanggan: insertId, nama_pelanggan },
    });
  } catch (error) {
    res.status(500).json({ status: "error", message: error.message });
  }
});

// 2. Buat Reservasi Baru
app.post("/api/bookings", async (req, res) => {
  try {
    const { id_pelanggan, tanggal, jam_mulai, durasi, id_lapangan } = req.body;

    if (!id_pelanggan || !tanggal || !jam_mulai || !durasi) {
      return res.status(400).json({
        status: "error",
        message: "Validasi gagal: tanggal dan jam_mulai wajib diisi",
      });
    }

    // Cek Pelanggan
    const customer = await db.query(
      "SELECT * FROM pelanggan WHERE id_pelanggan = :id_pelanggan",
      {
        replacements: { id_pelanggan },
        type: QueryTypes.SELECT,
      },
    );

    if (customer.length === 0) {
      return res.status(404).json({
        status: "error",
        message: `Pelanggan dengan ID ${id_pelanggan} tidak terdaftar`,
      });
    }

    let lapanganDipilih = id_lapangan;
    const totalHarga = hitungHarga(jam_mulai, durasi);

    if (id_lapangan) {
      // Cek Bentrok Lapangan Spesifik
      const isBentrok = await cekKetersediaanDB(
        tanggal,
        id_lapangan,
        jam_mulai,
        durasi,
      );
      if (isBentrok) {
        return res.status(409).json({
          status: "error",
          message: "Maaf, Lapangan tersebut sudah dipesan di jam ini",
        });
      }
    } else {
      // Auto-Generate Lapangan
      let lapanganDitemukan = null;
      for (let i = 1; i <= 8; i++) {
        const isBentrok = await cekKetersediaanDB(
          tanggal,
          i,
          jam_mulai,
          durasi,
        );
        if (!isBentrok) {
          lapanganDitemukan = i;
          break;
        }
      }
      if (!lapanganDitemukan) {
        return res.status(409).json({
          status: "error",
          message: "Semua lapangan penuh pada jadwal tersebut",
        });
      }
      lapanganDipilih = lapanganDitemukan;
    }

    // Insert Reservasi
    const [insertId] = await db.query(
      `INSERT INTO reservasi (id_pelanggan, tanggal, jam_mulai, durasi, id_lapangan, total_harga, status_pembayaran, is_deleted) 
             VALUES (:id_pelanggan, :tanggal, :jam_mulai, :durasi, :id_lapangan, :total_harga, 'belum_bayar', 0)`,
      {
        replacements: {
          id_pelanggan,
          tanggal,
          jam_mulai,
          durasi,
          id_lapangan: lapanganDipilih,
          total_harga: totalHarga,
        },
        type: QueryTypes.INSERT,
      },
    );

    res.status(201).json({
      status: "success",
      message: id_lapangan
        ? "Reservasi berhasil"
        : "Lapangan otomatis dipilihkan",
      data: {
        id_reservasi: insertId,
        id_lapangan: lapanganDipilih,
        total_harga: totalHarga,
      },
    });
  } catch (error) {
    res.status(500).json({ status: "error", message: error.message });
  }
});

// 3. Lihat Semua Reservasi Aktif
app.get("/api/bookings", async (req, res) => {
  try {
    const { tanggal } = req.query;
    let query = `
            SELECT r.id_reservasi, p.nama_pelanggan, r.id_lapangan AS nomor_lapangan, DATE_FORMAT(r.jam_mulai, '%H:%i') as jam_mulai, r.total_harga 
            FROM reservasi r 
            JOIN pelanggan p ON r.id_pelanggan = p.id_pelanggan 
            WHERE r.is_deleted = 0
        `;

    const replacements = {};

    if (tanggal) {
      query += " AND r.tanggal = :tanggal";
      replacements.tanggal = tanggal;
    }

    const rows = await db.query(query, {
      replacements: replacements,
      type: QueryTypes.SELECT,
    });

    if (tanggal && rows.length === 0) {
      return res.status(404).json({
        status: "error",
        message: "Tidak ada data reservasi pada tanggal tersebut",
      });
    }

    res.status(200).json({ status: "success", data: rows });
  } catch (error) {
    res.status(500).json({ status: "error", message: error.message });
  }
});

// 4. Cari Reservasi by Nama Pemesan
app.get("/api/bookings/customer/:nama", async (req, res) => {
  try {
    const { nama } = req.params;

    const customers = await db.query(
      "SELECT id_pelanggan, nama_pelanggan FROM pelanggan WHERE LOWER(nama_pelanggan) LIKE LOWER(:nama)",
      {
        replacements: { nama: `%${nama}%` },
        type: QueryTypes.SELECT,
      },
    );

    if (customers.length === 0) {
      return res.status(404).json({
        status: "error",
        message: `Data pelanggan ${nama} tidak ditemukan`,
      });
    }

    const idPelanggan = customers[0].id_pelanggan;

    const riwayat = await db.query(
      'SELECT id_reservasi, DATE_FORMAT(tanggal, "%Y-%m-%d") as tanggal FROM reservasi WHERE id_pelanggan = :idPelanggan AND is_deleted = 0',
      {
        replacements: { idPelanggan },
        type: QueryTypes.SELECT,
      },
    );

    res.status(200).json({
      status: "success",
      data: {
        id_pelanggan: idPelanggan,
        nama_pelanggan: customers[0].nama_pelanggan,
        riwayat_reservasi: riwayat,
      },
    });
  } catch (error) {
    res.status(500).json({ status: "error", message: error.message });
  }
});

// 5. Lihat Detail (GET), Update Jadwal (PUT), dan Pembatalan (DELETE)
app.route("/api/bookings/:id").get(async (req, res) => {
  try {
    const rows = await db.query(
      `
                SELECT r.id_reservasi, p.nama_pelanggan, r.id_lapangan AS nomor_lapangan, DATE_FORMAT(r.jam_mulai, '%H:%i') as jam_mulai, r.total_harga 
                FROM reservasi r 
                JOIN pelanggan p ON r.id_pelanggan = p.id_pelanggan 
                WHERE r.id_reservasi = :id AND r.is_deleted = 0
            `,
      {
        replacements: { id: req.params.id },
        type: QueryTypes.SELECT,
      },
    );

    if (rows.length === 0) {
      return res.status(404).json({
        status: "error",
        message: `Data reservasi dengan ID ${req.params.id} tidak ditemukan`,
      });
    }

    return res.status(200).json({
      status: "success",
      data: {
        id_reservasi: rows[0].id_reservasi,
        nama_pelanggan: rows[0].nama_pelanggan,
        nomor_lapangan: rows[0].nomor_lapangan,
        jam_mulai: rows[0].jam_mulai,
        total_harga: rows[0].total_harga,
      },
    });
  } catch (error) {
    res.status(500).json({ status: "error", message: error.message });
  }
});

app.route("/api/bookings/:id").put(async (req, res) => {
  try {
    const { jam_mulai, id_lapangan } = req.body;
    const id_reservasi = req.params.id;

    const existing = await db.query(
      "SELECT * FROM reservasi WHERE id_reservasi = :id_reservasi AND is_deleted = 0",
      {
        replacements: { id_reservasi },
        type: QueryTypes.SELECT,
      },
    );

    if (existing.length === 0) {
      return res.status(404).json({
        status: "error",
        message: `ID Reservasi ${id_reservasi} tidak valid untuk diupdate`,
      });
    }

    const currentData = existing[0];
    const newJamMulai = jam_mulai || currentData.jam_mulai.substring(0, 5);
    const newLapangan = id_lapangan || currentData.id_lapangan;
    const newHarga = hitungHarga(newJamMulai, currentData.durasi);

    const isBentrok = await cekKetersediaanDB(
      currentData.tanggal,
      newLapangan,
      newJamMulai,
      currentData.durasi,
      id_reservasi,
    );

    if (isBentrok) {
      return res.status(409).json({
        status: "error",
        message: "Gagal update. Lapangan tersebut penuh di jam ini",
      });
    }

    await db.query(
      "UPDATE reservasi SET jam_mulai = :jam_mulai, id_lapangan = :id_lapangan, total_harga = :total_harga WHERE id_reservasi = :id_reservasi",
      {
        replacements: {
          jam_mulai: newJamMulai,
          id_lapangan: newLapangan,
          total_harga: newHarga,
          id_reservasi,
        },
        type: QueryTypes.UPDATE,
      },
    );

    res.status(200).json({
      status: "success",
      message: "Jadwal diupdate",
      data: {
        id_reservasi: parseInt(id_reservasi),
        jam_mulai: newJamMulai,
        total_harga: newHarga,
      },
    });
  } catch (error) {
    res.status(500).json({ status: "error", message: error.message });
  }
});

// 6. Update Status Pembayaran
app.put("/api/bookings/:id/payment", async (req, res) => {
  try {
    const { status_pembayaran } = req.body;
    if (status_pembayaran !== "belum_bayar" && status_pembayaran !== "lunas") {
      return res.status(400).json({
        status: "error",
        message: "Status hanya boleh: belum_bayar atau lunas",
      });
    }

    const existing = await db.query(
      "SELECT id_reservasi FROM reservasi WHERE id_reservasi = :id AND is_deleted = 0",
      {
        replacements: { id: req.params.id },
        type: QueryTypes.SELECT,
      },
    );

    if (existing.length === 0) {
      return res
        .status(404)
        .json({ status: "error", message: "Reservasi tidak ditemukan" });
    }

    await db.query(
      "UPDATE reservasi SET status_pembayaran = :status_pembayaran WHERE id_reservasi = :id",
      {
        replacements: { status_pembayaran, id: req.params.id },
        type: QueryTypes.UPDATE,
      },
    );

    res
      .status(200)
      .json({ status: "success", message: "Pembayaran berhasil diupdate" });
  } catch (error) {
    res.status(500).json({ status: "error", message: error.message });
  }
});

//7. Pembatalan (Soft Delete)
app.delete("/api/bookings/:id", async (req, res) => {
  try {
    const existing = await db.query(
      "SELECT is_deleted FROM reservasi WHERE id_reservasi = :id",
      {
        replacements: { id: req.params.id },
        type: QueryTypes.SELECT,
      },
    );

    if (existing.length === 0) {
      return res.status(404).json({
        status: "error",
        message: "Reservasi tidak ditemukan",
      });
    }

    if (existing[0].is_deleted === 1) {
      return res.status(400).json({
        status: "error",
        message: "Reservasi ini sudah dibatalkan sebelumnya",
      });
    }

    await db.query(
      "UPDATE reservasi SET is_deleted = 1 WHERE id_reservasi = :id",
      {
        replacements: { id: req.params.id },
        type: QueryTypes.UPDATE,
      },
    );

    res.status(200).json({
      status: "success",
      message: "Reservasi berhasil dibatalkan (Soft Delete)",
    });
  } catch (error) {
    res.status(500).json({ status: "error", message: error.message });
  }
});

// 8. Lihat Riwayat Pembatalan
app.get("/api/bookings/history/trash", async (req, res) => {
  try {
    const rows = await db.query(
      `
            SELECT r.id_reservasi, p.nama_pelanggan, r.is_deleted 
            FROM reservasi r 
            JOIN pelanggan p ON r.id_pelanggan = p.id_pelanggan 
            WHERE r.is_deleted = 1
        `,
      { type: QueryTypes.SELECT },
    );

    const formattedData = rows.map((row) => ({
      ...row,
      is_deleted: true,
    }));

    res.status(200).json({ status: "success", data: formattedData });
  } catch (error) {
    res.status(500).json({ status: "error", message: error.message });
  }
});

app.listen(port, () => console.log(`Example app listening on port ${port}!`));
