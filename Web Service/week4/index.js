// nex -> shortcut express
const express = require("express");
const app = express();
const port = 3003;

// Import db object dari folder models
// Ini akan otomatis mengeksekusi file models/index.js dan memuat semua relasinya
const db = require("./models");
const { Kamar, TipeKamar, Penyewa, Penyewaan, sequelize } = db;

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// =========================================================
// 1. POST /penyewa (Registrasi Penyewa Baru)
// =========================================================
app.post("/penyewa", async (req, res) => {
  try {
    const { nama_lengkap, nik, saldo_dompet } = req.body;

    if (!nama_lengkap || !nik) {
      return res
        .status(400)
        .json({ error: "nama_lengkap dan nik tidak boleh kosong" });
    }
    if (nik.length !== 16) {
      return res.status(400).json({ error: "NIK harus tepat 16 karakter" });
    }

    const newPenyewa = await Penyewa.create({
      nama_lengkap,
      nik,
      saldo_dompet: saldo_dompet || 0,
    });

    res.status(201).json({
      msg: "Penyewa terdaftar",
      data: {
        id: newPenyewa.id,
        saldo_dompet: newPenyewa.saldo_dompet,
        nama_lengkap: newPenyewa.nama_lengkap,
      },
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// =========================================================
// 2. PUT /penyewa/topup/:penyewaId (Top-Up Saldo Dompet)
// =========================================================
app.put("/penyewa/topup/:penyewaId", async (req, res) => {
  try {
    const { nominal } = req.body;
    const penyewa = await Penyewa.findByPk(req.params.penyewaId);

    if (!penyewa) {
      return res
        .status(404)
        .json({ error: "Penyewa tidak ditemukan di sistem" });
    }
    if (!nominal || isNaN(nominal) || nominal <= 0) {
      return res
        .status(400)
        .json({ error: "Nominal top-up tidak boleh minus atau nol" });
    }

    penyewa.saldo_dompet += Number(nominal);
    await penyewa.save();

    res.status(200).json({
      msg: "Top-up berhasil",
      data: { saldo_dompet: penyewa.saldo_dompet },
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// =========================================================
// 3. POST /kamar (Tambah Data Kamar)
// =========================================================
app.post("/kamar", async (req, res) => {
  try {
    const { nomor_kamar, TipeKamarId } = req.body;

    if (!nomor_kamar || !TipeKamarId) {
      return res
        .status(400)
        .json({ error: "nomor_kamar dan TipeKamarId wajib diisi" });
    }

    const tipeKamar = await TipeKamar.findByPk(TipeKamarId);
    if (!tipeKamar) {
      return res
        .status(404)
        .json({ error: "Tipe Kamar tidak valid atau tidak ditemukan" });
    }

    const newKamar = await Kamar.create({
      nomor_kamar,
      TipeKamarId,
      status: "Tersedia",
    });

    res.status(201).json({
      msg: "Kamar ditambahkan",
      data: {
        nomor_kamar: newKamar.nomor_kamar,
        status: newKamar.status,
        TipeKamarId: newKamar.TipeKamarId,
      },
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// =========================================================
// 4. GET /kamar/filter (Cari Kamar via Query Params)
// =========================================================
app.get("/kamar/filter", async (req, res) => {
  try {
    const { status } = req.query;
    const validStatus = ["Tersedia", "Dihuni", "Renovasi"];

    if (!status || !validStatus.includes(status)) {
      return res.status(400).json({
        error: "Query status hanya menerima: Tersedia, Dihuni, Renovasi",
      });
    }

    const kamars = await Kamar.findAll({
      where: { status },
      attributes: ["nomor_kamar", "status"],
    });

    if (kamars.length === 0) {
      return res.status(200).json({
        msg: "Tidak ada data kamar dengan status tersebut",
        data: [],
      });
    }

    res.status(200).json({
      msg: "Sukses",
      data: kamars,
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// =========================================================
// 5. POST /penyewaan/transaksi (Sewa Kamar)
// =========================================================
app.post("/penyewaan/transaksi", async (req, res) => {
  try {
    const { PenyewaId, KamarId, durasi_bulan } = req.body;

    const kamar = await Kamar.findByPk(KamarId, { include: TipeKamar });
    const penyewa = await Penyewa.findByPk(PenyewaId);

    if (!kamar || !penyewa) {
      return res
        .status(404)
        .json({ error: "Kamar atau Penyewa tidak ditemukan" });
    }

    if (kamar.status !== "Tersedia") {
      return res
        .status(403)
        .json({ error: "Kamar tidak tersedia atau sedang dihuni" });
    }

    const total_harga = kamar.TipeKamar.harga_per_bulan * durasi_bulan;

    if (penyewa.saldo_dompet < total_harga) {
      return res.status(400).json({
        error: "Transaksi gagal. Saldo dompet penyewa tidak mencukupi",
      });
    }

    // Aksi Berantai Berurutan
    penyewa.saldo_dompet -= total_harga;
    await penyewa.save();

    kamar.status = "Dihuni";
    await kamar.save();

    const sewaBaru = await Penyewaan.create({
      durasi_bulan,
      total_harga,
      status_sewa: "Aktif",
      KamarId,
      PenyewaId,
    });

    res.status(201).json({
      msg: "Sewa berhasil, saldo terpotong",
      data: {
        total_harga: sewaBaru.total_harga,
        status_sewa: sewaBaru.status_sewa,
      },
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// =========================================================
// 6. PUT /penyewaan/checkout/:penyewaanId (Selesaikan Sewa)
// =========================================================
app.put("/penyewaan/checkout/:penyewaanId", async (req, res) => {
  try {
    const penyewaan = await Penyewaan.findByPk(req.params.penyewaanId);

    if (!penyewaan) {
      return res.status(404).json({ error: "Data penyewaan tidak ditemukan" });
    }

    if (penyewaan.status_sewa !== "Aktif") {
      return res.status(400).json({
        error: "Pesanan ini sudah diselesaikan sebelumnya atau batal",
      });
    }

    const kamar = await Kamar.findByPk(penyewaan.KamarId);

    // Aksi Berantai Berurutan
    penyewaan.status_sewa = "Selesai";
    await penyewaan.save();

    kamar.status = "Tersedia";
    await kamar.save();

    res.status(200).json({
      msg: "Checkout berhasil, kamar kembali tersedia",
      data: {
        status_sewa: penyewaan.status_sewa,
      },
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// =========================================================
// 7. GET /penyewaan/riwayat/:penyewaId (Riwayat Sewa)
// =========================================================
app.get("/penyewaan/riwayat/:penyewaId", async (req, res) => {
  try {
    const penyewa = await Penyewa.findByPk(req.params.penyewaId, {
      attributes: ["nama_lengkap"],
      include: [
        {
          model: Penyewaan,
          attributes: ["durasi_bulan"],
          include: [
            {
              model: Kamar,
              attributes: ["nomor_kamar"],
              include: [
                {
                  model: TipeKamar,
                  attributes: ["nama_tipe"],
                },
              ],
            },
          ],
        },
      ],
    });

    if (!penyewa) {
      return res.status(404).json({
        error: "Penyewa dengan ID tersebut tidak ditemukan di sistem",
      });
    }

    if (!penyewa.Penyewaans || penyewa.Penyewaans.length === 0) {
      return res.status(200).json({
        msg: "Penyewa ini belum memiliki riwayat sewa",
        data: {
          nama_lengkap: penyewa.nama_lengkap,
          Penyewaans: [],
        },
      });
    }

    res.status(200).json({
      msg: "Data ditemukan",
      data: penyewa,
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// =========================================================
// 8. DELETE /penyewaan/batal/:penyewaanId (Batal & Refund)
// =========================================================
app.delete("/penyewaan/batal/:penyewaanId", async (req, res) => {
  try {
    const penyewaan = await Penyewaan.findByPk(req.params.penyewaanId);

    if (!penyewaan) {
      return res
        .status(404)
        .json({ error: "Data transaksi sewa tidak ditemukan" });
    }

    if (penyewaan.status_sewa !== "Aktif") {
      return res.status(400).json({
        error:
          "Pesanan yang sudah selesai atau batal tidak dapat dibatalkan lagi",
      });
    }

    const kamar = await Kamar.findByPk(penyewaan.KamarId);
    const penyewa = await Penyewa.findByPk(penyewaan.PenyewaId);

    // Aksi Berantai Berurutan
    penyewaan.status_sewa = "Batal";
    await penyewaan.save();

    kamar.status = "Tersedia";
    await kamar.save();

    penyewa.saldo_dompet += penyewaan.total_harga; // Refund saldo
    await penyewa.save();

    res.status(200).json({
      msg: "Sewa dibatalkan. Saldo telah direfund dan kamar kembali tersedia",
      data: {
        status_sewa: penyewaan.status_sewa,
        refund: penyewaan.total_harga,
      },
    });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

// =========================================================
// contoh put
// =========================================================
app.put("/penyewa/topup/:penyewaId", async (req, res) => {
  const penyewa = await Penyewa.findByPk(req.params.penyewaId);
  penyewa.saldo_dompet += Number(nominal);
  await penyewa.save();

  res.status(200).json({
    msg: "Top-up berhasil",
    data: { saldo_dompet: penyewa.saldo_dompet },
  });
});

//===========================================================

app.listen(port, () => console.log(`Example app listening on port ${port}!`));
