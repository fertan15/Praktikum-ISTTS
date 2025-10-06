/*
SQLyog Community
MySQL - 10.4.32-MariaDB : Database - bestmovie
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`bestmovie` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `bestmovie`;

/*Table structure for table `characters` */

DROP TABLE IF EXISTS `characters`;

CREATE TABLE `characters` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `house_id` int(11) DEFAULT NULL,
  `role` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `house_id` (`house_id`),
  CONSTRAINT `characters_ibfk_1` FOREIGN KEY (`house_id`) REFERENCES `houses` (`id`) ON DELETE SET NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `characters` */

insert  into `characters`(`id`,`name`,`house_id`,`role`) values 
(1,'Harry Potter',1,'Student'),
(2,'Hermione Granger',1,'Student'),
(3,'Draco Malfoy',2,'Student'),
(4,'Luna Lovegood',3,'Student'),
(5,'Cedric Diggory',4,'Student'),
(6,'Columbina',3,'Teacher');

/*Table structure for table `houses` */

DROP TABLE IF EXISTS `houses`;

CREATE TABLE `houses` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `founder` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `houses` */

insert  into `houses`(`id`,`name`,`founder`) values 
(1,'Gryffindor','Godric Gryffindor'),
(2,'Slytherin','Salazar Slytherin'),
(3,'Ravenclaw','Rowena Ravenclaw'),
(4,'Hufflepuff','Helga Hufflepuff');

/*Table structure for table `wands` */

DROP TABLE IF EXISTS `wands`;

CREATE TABLE `wands` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `character_id` int(11) NOT NULL,
  `wood` varchar(50) DEFAULT NULL,
  `core` varchar(50) DEFAULT NULL,
  `length` decimal(3,1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `character_id` (`character_id`),
  CONSTRAINT `wands_ibfk_1` FOREIGN KEY (`character_id`) REFERENCES `characters` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `wands` */

insert  into `wands`(`id`,`character_id`,`wood`,`core`,`length`) values 
(1,1,'Holly','Phoenix feather',11.0),
(2,2,'Vine','Dragon heartstring',10.8),
(3,3,'Hawthorn','Unicorn hair',10.0),
(4,4,'Cherry','Unknown',13.5),
(5,5,'Ash','Unicorn hair',12.3),
(6,6,'Yggdrasil','Phoenix Feather',12.0);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
