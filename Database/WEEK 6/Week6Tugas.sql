-- no 1
SELECT CONCAT(
	'| NAMA PRODUK :  ', RPAD(p.nama,24,' '), 'NAMA MERK :  ', RPAD(m.nama,13,' ' ), 'NAMA KATEGORI :  ', RPAD(k.nama, 11, ' '), '|'
	) AS 'DETAIL PRODUK'
FROM produk p
JOIN merk m ON p.id_merk = m.id
JOIN kategori k ON p.id_kategori = k.id
WHERE p.stok > 35
ORDER BY m.nama, p.nama;

-- no 2
SELECT CONCAT(
		'Merk ', RPAD(m.nama,12,' '),' terjual sebanyak ',COUNT(p.id_merk),'x' 
	) AS 'FREKUENSI TERJUAL'
FROM merk m
JOIN produk p ON p.id_merk = m.id
JOIN detail_penjualan dp ON dp.id_produk = p.id 
GROUP BY p.id_merk
ORDER BY COUNT(p.id_merk) DESC, LENGTH(CONCAT('Merk ',m.nama)), m.nama;  -- kurang order

-- no 3
SELECT  
  CONCAT(
    RPAD(
      CONCAT(
        CASE
          WHEN s.nama LIKE 'PT%' THEN 'PERSEROAN TERBATAS '
          WHEN s.nama LIKE 'CV%' THEN 'COMMANDITAIRE VENNOOTSCHAP '
	  WHEN s.nama LIKE 'UD%' THEN 'USAHA DAGANG '
        END,
        UPPER(SUBSTRING(s.nama, LOCATE(' ', s.nama) + 1))), 44, ' '),'-> ', FLOOR(AVG(b.stok)), ' BUAH'
  ) AS 'RATA-RATA STOK SUPPLIER'
FROM bahan_baku b
JOIN supplier s ON b.id_supplier = s.id
GROUP BY s.nama
ORDER BY LENGTH(CONCAT(
        CASE
          WHEN s.nama LIKE 'PT%' THEN 'PERSEROAN TERBATAS '
          WHEN s.nama LIKE 'CV%' THEN 'COMMANDITAIRE VENNOOTSCHAP '
          WHEN s.nama LIKE 'UD%' THEN 'USAHA DAGANG '
        END,
        UPPER(SUBSTRING(s.nama, LOCATE(' ', s.nama) + 1)))) ,
	SUBSTRING(SUBSTRING(s.nama, LOCATE(' ', s.nama) + 1), 1, 1) DESC,
	FLOOR(AVG(b.stok)) DESC;


// NO 4
SELECT k.nama AS 'Nama Karyawan', 
  CONCAT('+62', SUBSTRING(k.telepon, 2)) AS Telepon, 
  k.email AS Email, 
  CONCAT(RPAD(SUBSTRING_INDEX(k.alamat, ' ', 2), 16, ' '), SUBSTRING_INDEX(k.alamat, ' ', -1)) AS 'Alamat', 
  k.Jabatan 
FROM karyawan k
LEFT JOIN penggajian p ON k.id = p.id_karyawan
GROUP BY k.id  
HAVING COUNT(p.id_karyawan) <= 0
ORDER BY LENGTH(k.nama);  
