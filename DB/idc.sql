-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 25, 2013 at 05:25 PM
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
-- Table structure for table `idc`
--

CREATE TABLE IF NOT EXISTS `idc` (
  `id` varchar(10) NOT NULL,
  `TenIDC` varchar(100) DEFAULT NULL,
  `Ghichu` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `idc`
--

INSERT INTO `idc` (`id`, `TenIDC`, `Ghichu`) VALUES
('A04', 'Nhiễm trùng đường ruột do vi khuẩn khác', NULL),
('B18', 'Viêm gan virus mạn', NULL),
('E13', 'Đái tháo đường type 2', NULL),
('I02.0', 'Thiếu máu cơ tim', NULL),
('I10', 'Cao Huyết áp', NULL),
('I25.2', 'Nhồi máu cơ tim cũ', NULL),
('I44.0', 'Block nhĩ thất độ I', NULL),
('I48', 'Rung nhĩ và cuồng nhĩ', NULL),
('I50', 'Suy tim', NULL),
('I73', 'Bệnh mạch máu ngoại biên', NULL),
('I84', 'Trĩ', NULL),
('I87.2', 'Suy tĩnh mạch (mạn) (ngoại biên)', NULL),
('J05.2', 'Viêm phế quản', NULL),
('J20', 'Viêm phế quản cấp', NULL),
('N18.0', 'Suy thận mạn giai đoạn cuối', NULL);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
