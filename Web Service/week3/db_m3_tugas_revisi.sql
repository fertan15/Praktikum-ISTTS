/*
SQLyog Community v13.3.0 (64 bit)
MySQL - 10.4.32-MariaDB : Database - db_m3_tugas
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_m3_tugas` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `db_m3_tugas`;

/*Table structure for table `products` */

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sku_code` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `category` varchar(50) NOT NULL,
  `base_price` int(11) NOT NULL,
  `stock` int(11) NOT NULL,
  `zone_code` varchar(255) NOT NULL,
  `deletedAt` datetime DEFAULT NULL,
  `createdAt` datetime NOT NULL DEFAULT current_timestamp(),
  `updatedAt` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `discount_percentage` int(11) NOT NULL DEFAULT 0,
  `final_price` int(11) NOT NULL,
  `is_flash_sale` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`),
  UNIQUE KEY `sku_code` (`sku_code`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `products` */

insert  into `products`(`id`,`sku_code`,`name`,`category`,`base_price`,`stock`,`zone_code`,`deletedAt`,`createdAt`,`updatedAt`,`discount_percentage`,`final_price`,`is_flash_sale`) values 
(1,'FAS-2026-00099','Sepatu Safety','fashion',250000,900,'ZON-B','2026-03-30 05:05:46','2026-03-30 10:49:46','2026-03-30 05:05:46',0,250000,0),
(2,'ELK-2026-00055','Kabel LAN 10m','elektronik',50000,0,'ZON-C',NULL,'2026-03-30 10:49:46','2026-03-30 11:02:16',0,50000,0),
(3,'MKN-2026-00088','Beras 1 Ton','makanan',15000,150,'ZON-D',NULL,'2026-03-30 10:49:46','2026-03-30 11:02:18',0,15000,0),
(4,'ELK-2026-00404','Monitor Rusak','elektronik',1000000,0,'ZON-B','2026-03-10 10:00:00','2026-03-30 10:49:46','2026-03-30 11:02:24',0,100000,0),
(5,'ELK-2026-00001','Laptop','elektronik',5000000,100,'ZON-A',NULL,'2026-03-30 04:59:31','2026-03-30 04:59:31',0,5000000,0);

/*Table structure for table `zones` */

DROP TABLE IF EXISTS `zones`;

CREATE TABLE `zones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `zone_code` varchar(255) NOT NULL,
  `max_capacity` int(11) NOT NULL,
  `current_load` int(11) NOT NULL DEFAULT 0,
  `createdAt` datetime NOT NULL DEFAULT current_timestamp(),
  `updatedAt` datetime NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `deletedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `zone_code` (`zone_code`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `zones` */

insert  into `zones`(`id`,`zone_code`,`max_capacity`,`current_load`,`createdAt`,`updatedAt`,`deletedAt`) values 
(1,'ZON-B',1000,0,'2026-03-30 10:49:46','2026-03-30 05:05:46',NULL),
(2,'ZON-C',300,0,'2026-03-30 10:49:46','2026-03-30 10:49:46',NULL),
(3,'ZON-D',150,150,'2026-03-30 10:49:46','2026-03-30 10:49:46',NULL),
(4,'ZON-A',500,100,'2026-03-30 04:56:20','2026-03-30 04:59:31',NULL);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
