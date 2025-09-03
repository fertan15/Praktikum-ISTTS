

-- 1
SELECT p.nama AS PRODUK, CONCAT('[', RPAD(g.nama,23,' '),':', s.qty, ' pairs]') AS DISTRIBUSI_STOK 
FROM produk p
JOIN stok_produk s ON p.id = s.id_produk
JOIN gudang g ON g.id = s.id_gudang
ORDER BY p.nama;
 
-- 2
SELECT d.id AS ID_PRODUKSI, 
	CONCAT('Produk ',RPAD(
	CASE WHEN LENGTH(p.nama) > 20 THEN SUBSTR(p.nama, 1, 20)
	ELSE p.nama 
	END
	,21,' '), '| Jumlah Produksi =>   ', d.qty, ' pasang') AS DATA_PRODUKSI,
	CASE
		WHEN d.id_karyawan IS NOT NULL THEN CONCAT(RPAD(k.nama,14,' '), '=> ', k.jabatan) 
		ELSE d.id_karyawan
	END AS PENANGGUNGJAWAB_PRODUKSI
FROM produksi d
JOIN produk p ON p.id = d.id_produk
LEFT JOIN karyawan k ON d.id_karyawan = k.id
WHERE d.status = 'Dalam Proses'
ORDER BY d.id;

-- 3
SELECT 
	CASE WHEN COUNT(p.id) > 0 THEN CONCAT(
		RPAD(k.nama,16 ,' '), 'berhasil melakukan penjualan sebanyak ',
		RPAD(COUNT(p.id),2,' '), ', nominal total => Rp ', LPAD(FLOOR(SUM(p.total_harga)),10,' ')
		) 
	ELSE CONCAT(RPAD(k.nama,16 ,' '), 'belum melakukan penjualan') 
	END AS DESKRIPSI_TRANSAKSI
FROM karyawan k
LEFT JOIN penjualan p ON p.id_karyawan = k.id
GROUP BY k.nama
ORDER BY COUNT(p.id) DESC; -- kurang order by


-- 4
SELECT d.tanggal_mulai,CONCAT(
	RPAD(p.nama,20,' '), ' => ', RPAD(t.nama,15,' '), 
	CASE 
		WHEN d.status = 'Dalam Proses' THEN 'sedang dalam produksi   '
		WHEN d.status = 'Selesai' THEN 'diproduksi dalam        '
	END,
	CASE 
		WHEN d.status = 'Dalam Proses' THEN '~'
		WHEN d.status = 'Selesai' THEN DATEDIFF(d.tanggal_selesai, d.tanggal_mulai)
	END, ' hari [', d.qty,' pasang]' 
	) AS STATUS_PRODUKSI
FROM produksi d
JOIN produk p ON d.id_produk = p.id
JOIN kategori t ON t.id = p.id_kategori
ORDER BY d.tanggal_mulai DESC,d.tanggal_selesai DESC ,d.qty DESC;


-- no 5
SELECT 
	CONCAT(
		RPAD(l.nama, 15,' '), '[', MAX(DATE_FORMAT(j.tanggal, '%D %M %Y')) ,']'
	) AS LAST_TRANSACTION,
	CONCAT(COUNT(*),'x Transaksi') AS TOTAL_TRANSAKSI_PELANGGAN, 
	CONCAT('Rp ',SUM(j.total_harga)) AS TOTAL_BELANJA 
FROM penjualan j
JOIN pelanggan l ON l.id = j.id_pelanggan
GROUP BY l.nama
ORDER BY COUNT(*) DESC, l.nama ;
