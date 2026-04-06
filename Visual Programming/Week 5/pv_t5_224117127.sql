/*
SQLyog Community v13.3.0 (64 bit)
MySQL - 10.4.32-MariaDB : Database - pv_t5_224117127
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pv_t5_224117127` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `pv_t5_224117127`;

/*Table structure for table `movie` */

DROP TABLE IF EXISTS `movie`;

CREATE TABLE `movie` (
  `movie_id` varchar(6) NOT NULL,
  `title` varchar(50) NOT NULL,
  `genre` text NOT NULL,
  `duration` int(11) NOT NULL,
  `studio_id` varchar(6) NOT NULL,
  `seatA1` tinyint(1) DEFAULT 0,
  `seatA2` tinyint(1) DEFAULT 0,
  `seatA3` tinyint(1) DEFAULT 0,
  `seatA4` tinyint(1) DEFAULT 0,
  `seatA5` tinyint(1) DEFAULT 0,
  PRIMARY KEY (`movie_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `movie` */

/*Table structure for table `studio` */

DROP TABLE IF EXISTS `studio`;

CREATE TABLE `studio` (
  `studio_id` varchar(6) NOT NULL,
  `studio_name` varchar(50) NOT NULL,
  `price` int(11) NOT NULL,
  PRIMARY KEY (`studio_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `studio` */

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `saldo` int(11) DEFAULT 0,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `user` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


 


/*
SQLyog Community v13.3.0 (64 bit)
MySQL - 8.0.30 : Database - pv_t5_224117127
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`pv_t5_224117127` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `pv_t5_224117127`;

/*Data for the table `movie` */

insert  into `movie`(`movie_id`,`title`,`genre`,`duration`,`studio_id`,`seatA1`,`seatA2`,`seatA3`,`seatA4`,`seatA5`) values 
('MOV000','transformer','Action,Animation,Sci-Fi',120,'STD004',0,1,0,0,1),
('MOV002','Money Heist','Action,Drama,Sci-Fi',150,'STD000',0,0,0,0,0),
('MOV003','Alice in Wonderland','Action,Drama,Horror,Sci-Fi',60,'STD003',0,0,0,0,0);

/*Data for the table `studio` */

insert  into `studio`(`studio_id`,`studio_name`,`price`) values 
('STD000','studio Fedrian',20000),
('STD001','studio Beni',55000),
('STD002','studio punyaku anjay',500000),
('STD003','studio klerin',20000),
('STD004','studio joni',20000);

/*Data for the table `user` */

insert  into `user`(`user_id`,`username`,`password`,`saldo`,`name`) values 
(1,'ferfer','123456',35000,'fer'),
(2,'dada','123456',500000,'ferlinda'),
(3,'halo','halohalo',35000,'haloBandung');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
