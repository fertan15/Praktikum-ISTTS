const express = require("express");
const { Members, ClassBookings } = require("./src/models");
const { Op } = require("sequelize");
const Joi = require("joi");
const app = express();
const port = 3003;

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// JOI

const seventeenYearsAgo = new Date();
seventeenYearsAgo.setFullYear(seventeenYearsAgo.getFullYear() - 17);

const today = new Date();
today.setHours(23, 59, 59, 999);

// Register Member
const registerSchema = Joi.object({
  username: Joi.string().alphanum().min(5).max(15).required(),
  email: Joi.string().email().required(),
  password: Joi.string().min(8).required(),
  confirm_password: Joi.string()
    .valid(Joi.ref("password"))
    .required()
    .messages({
      "any.only": '"confirm_password" must be [ref:password]',
    }),
  nik: Joi.string()
    .pattern(/^[0-9]{16}$/)
    .required()
    .messages({
      "string.pattern.base":
        '"nik" with value "{#value}" fails to match the required pattern',
    }),
  birth_date: Joi.date().iso().max(seventeenYearsAgo).required().messages({
    "date.max":
      '"birth_date" must be less than or equal to [Tanggal 17 Tahun Lalu]',
  }),
  phone_number: Joi.string()
    .pattern(/^\+62[0-9]{7,11}$/)
    .required(),
  emergency_phone: Joi.string()
    .pattern(/^\+62[0-9]*$/)
    .invalid(Joi.ref("phone_number"))
    .required()
    .messages({
      "any.invalid": '"emergency_phone" contains an invalid value',
    }),
  city: Joi.string().required(),
  postal_code: Joi.string()
    .pattern(/^[0-9]{5}$/)
    .required(),
});

// Booking Class
const bookSchema = Joi.object({
  member_id: Joi.string()
    .pattern(/^FIT-[0-9]{4}$/)
    .required(),
  class_type: Joi.string().valid("YOGA", "ZUMBA", "LIFTING").required(),
  schedule_date: Joi.date().greater(today).required().messages({
    "date.greater": '"schedule_date" must be greater than [Hari Ini]',
  }),
  bring_guest: Joi.boolean().required(),
  guest_name: Joi.string().when("bring_guest", {
    is: true,
    then: Joi.required(),
    otherwise: Joi.forbidden(),
  }),
  promo_code: Joi.string().optional(),
  payment_method: Joi.string()
    .valid("CASH", "CASHLESS")
    .when("promo_code", {
      is: Joi.exist(),
      then: Joi.valid("CASHLESS").messages({
        "any.only": '"payment_method" must be [CASHLESS]',
      }),
    })
    .required(),
});

// ENDPOINTS

// 1. POST /api/v1/members/register
app.post("/api/v1/members/register", async (req, res) => {
  try {
    const input = await registerSchema.validateAsync(req.body, {
      abortEarly: false,
    });

    // Pengecekan Member sudah ada blom
    const existingMember = await Members.findOne({
      where: { [Op.or]: [{ nik: input.nik }, { email: input.email }] },
    });

    if (existingMember) {
      return res.status(400).json({
        status: "error",
        message: "NIK atau Email sudah terdaftar",
      });
    }

    // Generate id
    const maxMemberId = await Members.max("member_id");
    let nextIdNumber = 1;
    if (maxMemberId) {
      nextIdNumber = parseInt(maxMemberId.substring(4), 10) + 1;
    }
    const memberId = `FIT-${nextIdNumber.toString().padStart(4, "0")}`;

    // Insert
    await Members.create({
      ...input,
      member_id: memberId,
      status_member: "ACTIVE",
    });

    return res.status(201).json({
      status: "success",
      message: "Pendaftaran berhasil divalidasi",
    });
  } catch (error) {
    if (error.isJoi) {
      return res.status(400).json({
        status: "error",
        message: error.details[0].message,
      });
    }
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 2. POST /api/v1/classes/book
app.post("/api/v1/classes/book", async (req, res) => {
  try {
    const input = await bookSchema.validateAsync(req.body, {
      abortEarly: false,
    });

    // Pengecekan Member
    const memberRn = await Members.findOne({
      where: { member_id: input.member_id },
    });

    if (!memberRn) {
      return res.status(404).json({
        status: "error",
        message: "Member tidak ditemukan",
      });
    }

    // Insert ke Database
    await ClassBookings.create(input);

    return res.status(200).json({
      status: "success",
      message: "Booking valid",
    });
  } catch (error) {
    if (error.isJoi) {
      return res.status(400).json({
        status: "error",
        message: error.details[0].message,
      });
    }
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 3. GET /api/v1/members/:nik/profile
app.get("/api/v1/members/:nik/profile", async (req, res) => {
  try {
    const { nik } = req.params;

    // Validasi Manual
    if (!/^[0-9]{16}$/.test(nik)) {
      return res.status(400).json({
        status: "error",
        message: "Format NIK tidak valid. Harus 16 digit angka",
      });
    }

    // Cari Member berdasarkan NIK
    const memberRn = await Members.findByPk(nik);

    if (!memberRn) {
      return res.status(404).json({
        status: "error",
        message: "Data member tidak ditemukan di database",
      });
    }

    return res.status(200).json({
      status: "success",
      message: "Profil ditemukan",
      data: memberRn,
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 4. PUT /api/v1/members/pause
app.put("/api/v1/members/pause", async (req, res) => {
  try {
    const { member_id, months } = req.query;

    if (!member_id || !months) {
      return res.status(400).json({
        status: "error",
        message: "member_id dan months wajib diisi",
      });
    }

    const duration = parseInt(months, 10);
    if (isNaN(duration) || duration < 1 || duration > 6) {
      return res.status(400).json({
        status: "error",
        message: "Durasi cuti hanya boleh 1 - 6 bulan",
      });
    }

    // Pengecekan Member
    const memberRn = await Members.findOne({ where: { member_id } });
    if (!memberRn) {
      return res.status(404).json({
        status: "error",
        message: "Member tidak ditemukan",
      });
    }

    // Update Status
    await Members.update({ status_member: "PAUSED" }, { where: { member_id } });

    return res.status(200).json({
      status: "success",
      message: `Membership berhasil dipause selama ${duration} bulan`,
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

// 5. DELETE /api/v1/members/:memberId/cancel
app.delete("/api/v1/members/:memberId/cancel", async (req, res) => {
  try {
    const { memberId } = req.params;
    const { reason } = req.body;

    if (!reason) {
      return res.status(400).json({
        status: "error",
        message: "Alasan pembatalan (reason) wajib diisi",
      });
    }

    if (reason.length < 10) {
      return res.status(400).json({
        status: "error",
        message: "Alasan harus minimal 10 karakter",
      });
    }

    // Pengecekan Member
    const memberRn = await Members.findOne({ where: { member_id: memberId } });
    if (!memberRn) {
      return res.status(404).json({
        status: "error",
        message: "Member tidak ditemukan",
      });
    }

    // Delete Member
    await Members.destroy({ where: { member_id: memberId } });

    return res.status(200).json({
      status: "success",
      message: "Membership dibatalkan",
    });
  } catch (error) {
    return res.status(500).json({ status: "error", message: error.message });
  }
});

app.listen(port, () => console.log(`Example app listening on port ${port}!`));
