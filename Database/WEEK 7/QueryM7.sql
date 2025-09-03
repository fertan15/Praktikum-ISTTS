-- No.1
SELECT  CONCAT('|',LPAD(k.id,5,'0')) AS 'ID Karyawan', 
	CONCAT(RPAD(k.nama,21,' '), '|' , LPAD(k.gaji_pokok,16,' ')) AS 'Nama & Gaji Pokok',
	RPAD(k.jabatan,20,'.') AS Jabatan,
	CONCAT('Gaji : ', CASE 
			WHEN k.gaji_pokok > r.rata THEN 'Tinggi |'
			WHEN k.gaji_pokok < r.rata THEN 'Rendah |'
			END
	) AS 'Tingkat Gaji'
FROM karyawan k, (
	SELECT AVG(k.gaji_pokok) AS rata
	FROM karyawan k
	) r
	ORDER BY k.gaji_pokok;


-- No.2
SELECT CONCAT('ID-', LPAD(p.id,5,'0')) AS 'Product ID',
	CONCAT(RPAD(CONCAT('Produk: ', CASE
				WHEN LENGTH(p.nama) > 20 THEN CONCAT(SUBSTR(p.nama,1,20),'...')
				ELSE p.nama
				END), 34,' '),
				'| Merk: ', m.nama
				 )AS 'Product Name & Brand',
	CONCAT('Kategori:', LPAD(k.nama,14,' '), ' |     Total Terjual: ',COUNT(*), 
	CASE WHEN COUNT(*) > 1 THEN ' Units' ELSE ' Unit' END) AS 'Category & Production Info'
FROM produksi s
JOIN produk p ON p.id = s.id_produk
JOIN merk m ON m.id = p.id_merk
JOIN kategori k ON k.id = p.id_kategori
WHERE p.id NOT IN(
	SELECT DISTINCT id_produk
	FROM detail_penjualan
)
GROUP BY p.id
ORDER BY k.id, p.id;

-- No.3
SELECT CONCAT(LPAD(k.id,4,'0'),' - ',k.nama) AS 'Employee ID & Name',
	k.jabatan AS 'Position',
	CONCAT('Call: ', k.telepon) AS 'Contact Number',
CONCAT('Email:',LPAD(SUBSTR(temp.email, 1, LOCATE('@', temp.email) - 1), 16, ' '),SUBSTR(temp.email, LOCATE('@', temp.email))) AS Email
, CONCAT('Rp',FLOOR(k.gaji_pokok)) AS 'Monthly Salary'
FROM karyawan k
JOIN(
	SELECT id, CONCAT(
		SUBSTR(email,1,LOCATE('@', email)), CASE  
							WHEN email LIKE '%gmail%' THEN 'gemail.com'
							WHEN email LIKE '%ymail%' THEN 'yemail.com'
							WHEN email LIKE '%live%' THEN 'laif.com'
							WHEN email LIKE '%yahoo%' THEN 'yahu.com'
							WHEN email LIKE '%mail%' THEN 'mael.com'	
			END
		) AS email
	FROM karyawan
) temp ON temp.id = k.id
JOIN(
	SELECT jabatan ,MIN(gaji_pokok) AS rendah
	FROM karyawan
	GROUP BY jabatan
	
) r ON k.jabatan = r.jabatan
WHERE temp.email IS NOT NULL AND k.gaji_pokok>r.rendah
ORDER BY k.jabatan, k.gaji_pokok DESC, k.id;


-- No.4
SELECT CONCAT('[',p.kode,']') AS 'KODE PRODUK', 
	CONCAT('[',REPLACE(p.nama,' ','-'),']') AS 'NAMA BARANG',
	CONCAT(RPAD(SUBSTR(p.deskripsi,1,20),20,' '),'...') AS 'DESKRIPSI SINGKAT',
	CONCAT('Rp ', REPLACE(FORMAT(p.harga, 0, 'id_ID'), '.', ',')) AS 'HARGA (RUPIAH)' 
FROM produk p
JOIN (	
	SELECT id_produk,SUM(qty) AS banyak
	FROM detail_penjualan
	GROUP BY id_produk
) s ON s.id_produk = p.id
WHERE s.banyak > (SELECT AVG(s.banyak) FROM (	
	SELECT id_produk,SUM(qty) AS banyak
	FROM detail_penjualan
	GROUP BY id_produk
) s);

