-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 22, 2013 at 04:01 PM
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
-- Table structure for table `benhnhan`
--

CREATE TABLE IF NOT EXISTS `benhnhan` (
  `id` int(11) NOT NULL,
  `ten` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `ngaysinh` datetime DEFAULT NULL,
  `gioitinh` tinyint(1) DEFAULT NULL,
  `nghenghiep` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Dantoc` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `CMND` varchar(12) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Ngoaikieu` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Sonha` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Duong` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Phuong` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Quan` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Thanhpho` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Noilamviec` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `benhnhan`
--

INSERT INTO `benhnhan` (`id`, `ten`, `ngaysinh`, `gioitinh`, `nghenghiep`, `Dantoc`, `CMND`, `Ngoaikieu`, `Sonha`, `Duong`, `Phuong`, `Quan`, `Thanhpho`, `Noilamviec`) VALUES
(1300003, 'QUANG2', '2013-12-02 00:00:00', 1, 'Học sinh', 'KINH', '025118871', 'k', '000000000', 'LTK2', 'P3', 'H4', 'TP5', 'ngiuyen minh hoa'),
(13000001, 'LÊ THỊ XUÂN TIẾN', '1952-11-22 00:00:00', 1, 'Học sinh', 'KINH', '025177881', '', '1166/12/1', 'QL1A', 'TÂN TẠO A', 'BÌNH TÂN', 'HỒ CHÍ MINH', 'khu cong nghiep tan tao'),
(13000002, 'THANH HOA', '2013-12-04 00:00:00', 0, 'Học sinh', 'KINH', '12312312', '', '123', 'TRAN QUAN KHAI', 'P9', 'TAN BINH', 'HO CHI MINH', 'UY BANH PHUONG 9'),
(13000003, 'tiep', '2013-12-11 00:00:00', 1, 'Học sinh', 'KINH', '025177881', '', '123', 'lang ha', 'p9', 'tan binh', 'ho chi minh', 'noi lam ');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
