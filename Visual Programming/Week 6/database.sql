/*
SQLyog Community v13.3.0 (64 bit)
MySQL - 10.4.32-MariaDB : Database - cozy_corner_db
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`cozy_corner_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `cozy_corner_db`;

/*Table structure for table `announcements` */

DROP TABLE IF EXISTS `announcements`;

CREATE TABLE `announcements` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) DEFAULT NULL,
  `content` text DEFAULT NULL,
  `created_at` datetime DEFAULT current_timestamp(),
  `is_active` tinyint(1) DEFAULT 1,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `announcements` */

insert  into `announcements`(`id`,`title`,`content`,`created_at`,`is_active`) values 
(1,'tes','mantap','2025-12-20 19:42:31',1);

/*Table structure for table `complaints` */

DROP TABLE IF EXISTS `complaints`;

CREATE TABLE `complaints` (
  `complaint_id` int(11) NOT NULL AUTO_INCREMENT,
  `tenant_id` int(11) NOT NULL,
  `category` varchar(50) DEFAULT NULL,
  `description` text NOT NULL,
  `admin_reply` text DEFAULT NULL,
  `status` enum('Menunggu','Proses','Selesai') DEFAULT 'Menunggu',
  `created_at` datetime DEFAULT current_timestamp(),
  `reply_at` datetime DEFAULT NULL,
  PRIMARY KEY (`complaint_id`),
  KEY `tenant_id` (`tenant_id`),
  CONSTRAINT `complaints_ibfk_1` FOREIGN KEY (`tenant_id`) REFERENCES `tenants` (`tenant_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `complaints` */

insert  into `complaints`(`complaint_id`,`tenant_id`,`category`,`description`,`admin_reply`,`status`,`created_at`,`reply_at`) values 
(1,2,'Pembayaran','tees ini aku','akan kami usahakan','Menunggu','2025-12-20 19:37:11','2025-12-23 20:16:55');

/*Table structure for table `guest_logs` */

DROP TABLE IF EXISTS `guest_logs`;

CREATE TABLE `guest_logs` (
  `guest_id` int(11) NOT NULL AUTO_INCREMENT,
  `tenant_id` int(11) NOT NULL,
  `guest_name` varchar(100) NOT NULL,
  `visit_date` date NOT NULL,
  `arrival_time` time NOT NULL,
  `purpose` varchar(255) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`guest_id`),
  KEY `tenant_id` (`tenant_id`),
  CONSTRAINT `guest_logs_ibfk_1` FOREIGN KEY (`tenant_id`) REFERENCES `tenants` (`tenant_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `guest_logs` */

insert  into `guest_logs`(`guest_id`,`tenant_id`,`guest_name`,`visit_date`,`arrival_time`,`purpose`,`created_at`) values 
(1,2,'fer','2025-12-21','16:00:00','ferfer','2025-12-20 20:03:50');

/*Table structure for table `leases` */

DROP TABLE IF EXISTS `leases`;

CREATE TABLE `leases` (
  `lease_id` int(11) NOT NULL AUTO_INCREMENT,
  `room_id` int(11) NOT NULL,
  `tenant_id` int(11) NOT NULL,
  `tenant_count` int(11) DEFAULT 1,
  `rent_price` decimal(10,2) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `duration_months` int(11) DEFAULT 1,
  `status` enum('Active','Expired','Cancelled') DEFAULT 'Active',
  `usingVoucher` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`lease_id`),
  KEY `room_id` (`room_id`),
  KEY `tenant_id` (`tenant_id`),
  CONSTRAINT `leases_ibfk_1` FOREIGN KEY (`room_id`) REFERENCES `rooms` (`room_id`),
  CONSTRAINT `leases_ibfk_2` FOREIGN KEY (`tenant_id`) REFERENCES `tenants` (`tenant_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `leases` */

insert  into `leases`(`lease_id`,`room_id`,`tenant_id`,`tenant_count`,`rent_price`,`start_date`,`end_date`,`duration_months`,`status`,`usingVoucher`) values 
(1,1,1,1,1500000.00,'2025-12-01','2026-01-01',1,'Active',0),
(2,2,2,2,2000000.00,'2025-12-01','2026-01-01',1,'Active',0);

/*Table structure for table `rooms` */

DROP TABLE IF EXISTS `rooms`;

CREATE TABLE `rooms` (
  `room_id` int(11) NOT NULL AUTO_INCREMENT,
  `room_number` varchar(10) NOT NULL,
  `type` enum('Standard Non-AC','Standard AC','VIP AC') NOT NULL,
  `base_price` decimal(10,2) NOT NULL,
  `status` enum('Tersedia','Terisi','Perbaikan') DEFAULT 'Tersedia',
  `facilities` text DEFAULT NULL,
  PRIMARY KEY (`room_id`),
  UNIQUE KEY `room_number` (`room_number`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `rooms` */

insert  into `rooms`(`room_id`,`room_number`,`type`,`base_price`,`status`,`facilities`) values 
(1,'101','Standard AC',1500000.00,'Terisi',NULL),
(2,'102','Standard AC',1500000.00,'Terisi',NULL);

/*Table structure for table `tenants` */

DROP TABLE IF EXISTS `tenants`;

CREATE TABLE `tenants` (
  `tenant_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) DEFAULT NULL,
  `full_name` varchar(100) NOT NULL,
  `ktp_number` varchar(20) DEFAULT NULL,
  `gender` enum('Laki-laki','Perempuan') DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `phone_number` varchar(15) DEFAULT NULL,
  `address` text DEFAULT NULL,
  PRIMARY KEY (`tenant_id`),
  UNIQUE KEY `ktp_number` (`ktp_number`),
  KEY `user_id` (`user_id`),
  CONSTRAINT `tenants_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tenants` */

insert  into `tenants`(`tenant_id`,`user_id`,`full_name`,`ktp_number`,`gender`,`date_of_birth`,`phone_number`,`address`) values 
(1,2,'Budi Santoso','1111',NULL,NULL,NULL,NULL),
(2,3,'Siti Aminah','2222',NULL,NULL,NULL,NULL);

/*Table structure for table `transactions` */

DROP TABLE IF EXISTS `transactions`;

CREATE TABLE `transactions` (
  `transaction_id` int(11) NOT NULL AUTO_INCREMENT,
  `lease_id` int(11) NOT NULL,
  `transaction_date` datetime DEFAULT current_timestamp(),
  `description` text NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  `payment_method` varchar(50) DEFAULT NULL,
  `status` enum('Pending','Paid','Failed') DEFAULT 'Pending',
  `category` varchar(50) NOT NULL DEFAULT 'other',
  PRIMARY KEY (`transaction_id`),
  KEY `lease_id` (`lease_id`),
  CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`lease_id`) REFERENCES `leases` (`lease_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `transactions` */

insert  into `transactions`(`transaction_id`,`lease_id`,`transaction_date`,`description`,`amount`,`payment_method`,`status`,`category`) values 
(1,1,'2025-12-20 19:21:35','Pembayaran Sewa Desember 2025',1500000.00,'Transfer','Paid','other'),
(2,1,'2025-12-20 19:21:35','Denda Kunci Patah',50000.00,'-','Pending','other'),
(3,2,'2025-12-20 19:21:35','Sewa Desember (2 Orang) + Laundry',2050000.00,'Cash','Paid','other'),
(4,2,'2025-12-20 20:30:08','ganti rugi vas pecah',23333.00,'Transfer Akun','Paid','other'),
(5,2,'2025-12-20 20:30:29','bayar uang listrik',222222.00,'Qris','Paid','other');

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` enum('admin','tenant') NOT NULL DEFAULT 'tenant',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `users` */

insert  into `users`(`user_id`,`username`,`password`,`role`,`created_at`) values 
(1,'Admin','123','admin','2025-12-20 19:21:35'),
(2,'Budi','123','tenant','2025-12-20 19:21:35'),
(3,'Siti','123','tenant','2025-12-20 19:21:35');

/*Table structure for table `view_user_dashboard` */

DROP TABLE IF EXISTS `view_user_dashboard`;

/*!50001 DROP VIEW IF EXISTS `view_user_dashboard` */;
/*!50001 DROP TABLE IF EXISTS `view_user_dashboard` */;

/*!50001 CREATE TABLE  `view_user_dashboard`(
 `user_id` int(11) ,
 `full_name` varchar(100) ,
 `room_number` varchar(10) ,
 `tenant_count` int(11) ,
 `rent_price` decimal(10,2) ,
 `lease_id` int(11) ,
 `jatuh_tempo` date ,
 `sisa_hari` int(7) ,
 `status_sewa` enum('Active','Expired','Cancelled') 
)*/;

/*Table structure for table `view_user_transactions` */

DROP TABLE IF EXISTS `view_user_transactions`;

/*!50001 DROP VIEW IF EXISTS `view_user_transactions` */;
/*!50001 DROP TABLE IF EXISTS `view_user_transactions` */;

/*!50001 CREATE TABLE  `view_user_transactions`(
 `user_id` int(11) ,
 `transaction_id` int(11) ,
 `transaction_date` datetime ,
 `description` text ,
 `amount` decimal(10,2) ,
 `payment_method` varchar(50) ,
 `status` enum('Pending','Paid','Failed') 
)*/;

/*View structure for view view_user_dashboard */

/*!50001 DROP TABLE IF EXISTS `view_user_dashboard` */;
/*!50001 DROP VIEW IF EXISTS `view_user_dashboard` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_user_dashboard` AS select `u`.`user_id` AS `user_id`,`t`.`full_name` AS `full_name`,`r`.`room_number` AS `room_number`,`l`.`tenant_count` AS `tenant_count`,`l`.`rent_price` AS `rent_price`,`l`.`lease_id` AS `lease_id`,`l`.`end_date` AS `jatuh_tempo`,to_days(`l`.`end_date`) - to_days(curdate()) AS `sisa_hari`,`l`.`status` AS `status_sewa` from (((`users` `u` join `tenants` `t` on(`u`.`user_id` = `t`.`user_id`)) join `leases` `l` on(`t`.`tenant_id` = `l`.`tenant_id`)) join `rooms` `r` on(`l`.`room_id` = `r`.`room_id`)) where `l`.`status` = 'Active' */;

/*View structure for view view_user_transactions */

/*!50001 DROP TABLE IF EXISTS `view_user_transactions` */;
/*!50001 DROP VIEW IF EXISTS `view_user_transactions` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_user_transactions` AS select `u`.`user_id` AS `user_id`,`tr`.`transaction_id` AS `transaction_id`,`tr`.`transaction_date` AS `transaction_date`,`tr`.`description` AS `description`,`tr`.`amount` AS `amount`,`tr`.`payment_method` AS `payment_method`,`tr`.`status` AS `status` from (((`transactions` `tr` join `leases` `l` on(`tr`.`lease_id` = `l`.`lease_id`)) join `tenants` `t` on(`l`.`tenant_id` = `t`.`tenant_id`)) join `users` `u` on(`t`.`user_id` = `u`.`user_id`)) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
