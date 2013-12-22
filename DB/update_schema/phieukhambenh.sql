-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 22, 2013 at 09:36 AM
-- Server version: 5.5.27
-- PHP Version: 5.4.7

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `dbthan`
--

-- --------------------------------------------------------

--
-- Table structure for table `phieukhambenh`
--

CREATE TABLE IF NOT EXISTS `phieukhambenh` (
  `id` int(11) NOT NULL,
  `doituong` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `bhytgiatritu` date NOT NULL,
  `bhytgiatriden` date NOT NULL,
  `sobhyt` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `nguoithan` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `diachinguoithan` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `dienthoai` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `Thoigiandenkham` datetime DEFAULT NULL,
  `Noigioithieu` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Lydovaovien` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Quatrinhbenhly` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Tiensubenh` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Mach` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Nhietdo` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Huyetap` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Nhiptho` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Trongluong` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Toanthan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Cacbophan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Tomtatketqualamsan` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Chuandoanvaovien` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Xuli` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Dieutritaikhoa` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Chuy` varchar(200) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Benhvien_id` int(11) NOT NULL,
  `Benhnhan_id` int(11) NOT NULL,
  `Hosophimanh_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Phieukhambenh_Benhvien1` (`Benhvien_id`),
  KEY `fk_Phieukhambenh_Benhnhan1` (`Benhnhan_id`),
  KEY `fk_Phieukhambenh_Hosophimanh1` (`Hosophimanh_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `phieukhambenh`
--
ALTER TABLE `phieukhambenh`
  ADD CONSTRAINT `fk_Phieukhambenh_Benhnhan1` FOREIGN KEY (`Benhnhan_id`) REFERENCES `benhnhan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Phieukhambenh_Benhvien1` FOREIGN KEY (`Benhvien_id`) REFERENCES `benhvien` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Phieukhambenh_Hosophimanh1` FOREIGN KEY (`Hosophimanh_id`) REFERENCES `hosophimanh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
