CREATE DATABASE IF NOT EXISTS db_tugas_m5;
USE db_tugas_m5;

CREATE TABLE members (
    nik VARCHAR(16) PRIMARY KEY,
    member_id VARCHAR(20) UNIQUE NOT NULL, 
    username VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    birth_date DATE NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    emergency_phone VARCHAR(20) NOT NULL,
    city VARCHAR(100) NOT NULL,
    postal_code VARCHAR(5) NOT NULL,
    status_member ENUM('ACTIVE', 'PAUSED') DEFAULT 'ACTIVE'
);

CREATE TABLE class_bookings (
    id INT AUTO_INCREMENT PRIMARY KEY,
    member_id VARCHAR(20) NOT NULL,
    class_type ENUM('YOGA', 'ZUMBA', 'LIFTING') NOT NULL,
    schedule_date DATE NOT NULL,
    bring_guest BOOLEAN NOT NULL DEFAULT FALSE,
    guest_name VARCHAR(100) NULL,
    promo_code VARCHAR(50) NULL,
    payment_method ENUM('CASH', 'CASHLESS') NOT NULL,
    FOREIGN KEY (member_id) REFERENCES members(member_id) ON DELETE CASCADE
);

INSERT INTO members (nik, member_id, username, email, password, birth_date, phone_number, emergency_phone, city, postal_code, status_member) VALUES
('1234567890123456', 'FIT-0001', 'budi123', 'budi@mail.com', 'password123', '1995-01-01', '+628123456789', '+628987654321', 'Jakarta', '12345', 'ACTIVE'),
('9876543210987654', 'FIT-0002', 'andi_strong', 'andi@mail.com', 'password321', '1990-05-15', '+628111222333', '+628444555666', 'Surabaya', '60284', 'ACTIVE'),
('1111222233334444', 'FIT-0003', 'siti_gym', 'siti@mail.com', 'passsiti123', '1998-08-08', '+628999888777', '+628777666555', 'Bandung', '40111', 'PAUSED');

INSERT INTO class_bookings (member_id, class_type, schedule_date, bring_guest, guest_name, promo_code, payment_method) VALUES
('FIT-0001', 'YOGA', '2027-01-01', TRUE, 'Joko', NULL, 'CASH'),
('FIT-0002', 'ZUMBA', '2027-01-02', FALSE, NULL, 'DISKON50', 'CASHLESS');