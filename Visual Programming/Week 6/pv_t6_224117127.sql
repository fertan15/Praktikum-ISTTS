/*
SQLyog Community v13.3.0 (64 bit)
MySQL - 10.4.32-MariaDB : Database - pv_t6_224117127
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pv_t6_224117127` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `pv_t6_224117127`;

/*Table structure for table `history` */

DROP TABLE IF EXISTS `history`;

CREATE TABLE `history` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Day` int(11) NOT NULL,
  `Item` varchar(50) NOT NULL,
  `Unit Price` int(11) NOT NULL,
  `Qty` int(11) NOT NULL,
  `Revenue` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `history` */

insert  into `history`(`Id`,`Day`,`Item`,`Unit Price`,`Qty`,`Revenue`) values 
(1,12,'Mahogany',1,1,1),
(2,12,'Oak',13,2,26),
(3,12,'Mystic',500,2,1000),
(4,16,'Mahogany',200,2,400),
(5,17,'Mahogany',200,1,200),
(6,17,'Oak',100,3,300),
(7,18,'Oak',100,1,100),
(8,18,'Mystic',500,8,4000),
(9,20,'Oak',100,1,100);

/*Table structure for table `progress` */

DROP TABLE IF EXISTS `progress`;

CREATE TABLE `progress` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `money` int(11) NOT NULL,
  `oak` int(11) NOT NULL,
  `mahogany` int(11) NOT NULL,
  `mystic` int(11) NOT NULL,
  `stoneAxe` tinyint(1) NOT NULL,
  `ironAxe` tinyint(1) NOT NULL,
  `diamondAxe` tinyint(1) NOT NULL,
  `equippedAxe` int(11) NOT NULL,
  `chopped` tinyint(1) NOT NULL,
  `day` int(11) NOT NULL,
  `jam` int(11) NOT NULL,
  `menit` int(11) NOT NULL,
  `levelWarung` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `progress` */

insert  into `progress`(`id`,`money`,`oak`,`mahogany`,`mystic`,`stoneAxe`,`ironAxe`,`diamondAxe`,`equippedAxe`,`chopped`,`day`,`jam`,`menit`,`levelWarung`) values 
(1,8978800,0,0,0,1,1,1,2,1,22,8,22,3);

/*Table structure for table `warung` */

DROP TABLE IF EXISTS `warung`;

CREATE TABLE `warung` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `item` varchar(50) NOT NULL,
  `harga` int(11) NOT NULL,
  `jumlah` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `warung` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
