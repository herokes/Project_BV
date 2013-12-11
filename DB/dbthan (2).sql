-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 11, 2013 at 10:32 AM
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
-- Table structure for table `bacsi`
--

CREATE TABLE IF NOT EXISTS `bacsi` (
  `idBacsi` int(11) NOT NULL AUTO_INCREMENT,
  `TenBacsi` varchar(45) DEFAULT NULL,
  `Trinhdo` varchar(45) DEFAULT NULL,
  `Dienthoai` varchar(45) DEFAULT NULL,
  `Diachi` varchar(45) DEFAULT NULL,
  `Namsinh` datetime DEFAULT NULL,
  PRIMARY KEY (`idBacsi`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `bacsi`
--

INSERT INTO `bacsi` (`idBacsi`, `TenBacsi`, `Trinhdo`, `Dienthoai`, `Diachi`, `Namsinh`) VALUES
(7, 'NGUY?N TH? KIM PH??NG', NULL, NULL, NULL, NULL),
(8, 'NGUY?N TH? KIM PH??NG', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `bacsi_hoichuan`
--

CREATE TABLE IF NOT EXISTS `bacsi_hoichuan` (
  `Bacsi_idBacsi` int(11) NOT NULL,
  `Hoichuan_idHoichuan` int(11) NOT NULL,
  `NgaygioHoichuan` datetime DEFAULT NULL,
  PRIMARY KEY (`Bacsi_idBacsi`,`Hoichuan_idHoichuan`),
  KEY `fk_Bacsi_has_Hoichuan_Hoichuan1` (`Hoichuan_idHoichuan`),
  KEY `fk_Bacsi_has_Hoichuan_Bacsi1` (`Bacsi_idBacsi`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `benhnhan`
--

CREATE TABLE IF NOT EXISTS `benhnhan` (
  `idBenhnhan` int(11) NOT NULL,
  `Ten` varchar(45) DEFAULT NULL,
  `Ngaysinh` datetime DEFAULT NULL,
  `Gioitinh` tinyint(1) DEFAULT NULL,
  `Nghenghiep` varchar(45) DEFAULT NULL,
  `Dantoc` varchar(45) DEFAULT NULL,
  `CMND` varchar(12) DEFAULT NULL,
  `Ngoaikieu` varchar(45) DEFAULT NULL,
  `Sonha` varchar(45) DEFAULT NULL,
  `Duong` varchar(45) DEFAULT NULL,
  `Phuong` varchar(45) DEFAULT NULL,
  `Quan` varchar(45) DEFAULT NULL,
  `Thanhpho` varchar(45) DEFAULT NULL,
  `Noilamviec` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idBenhnhan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `benhvien`
--

CREATE TABLE IF NOT EXISTS `benhvien` (
  `idBenhvien` int(11) NOT NULL AUTO_INCREMENT,
  `Tenbenhvien` varchar(45) DEFAULT NULL,
  `Ghichu` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idBenhvien`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `hoichuan`
--

CREATE TABLE IF NOT EXISTS `hoichuan` (
  `idHoichuan` int(11) NOT NULL,
  `ThoigianHoichuan` datetime DEFAULT NULL,
  `Ketluanhoichuan` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idHoichuan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `hosophimanh`
--

CREATE TABLE IF NOT EXISTS `hosophimanh` (
  `idHosophimanh` int(11) NOT NULL,
  `ECG` varchar(100) DEFAULT NULL,
  `CT Scanner` varchar(200) DEFAULT NULL,
  `Sieuam` varchar(45) DEFAULT NULL,
  `Xetnghiem` varchar(45) DEFAULT NULL,
  `Khac` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idHosophimanh`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `idc`
--

CREATE TABLE IF NOT EXISTS `idc` (
  `idIDC` varchar(10) NOT NULL,
  `TenIDC` varchar(100) DEFAULT NULL,
  `Ghichu` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`idIDC`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `idc_phieukhambenh`
--

CREATE TABLE IF NOT EXISTS `idc_phieukhambenh` (
  `IDC_idIDC` varchar(10) NOT NULL,
  `Phieukhambenh_idPhieukhambenh` int(11) NOT NULL,
  PRIMARY KEY (`IDC_idIDC`,`Phieukhambenh_idPhieukhambenh`),
  KEY `fk_IDC_has_Phieukhambenh_Phieukhambenh1` (`Phieukhambenh_idPhieukhambenh`),
  KEY `fk_IDC_has_Phieukhambenh_IDC1` (`IDC_idIDC`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `lanhthuoc`
--

CREATE TABLE IF NOT EXISTS `lanhthuoc` (
  `Phieukhambenh_idPhieukhambenh` int(11) NOT NULL,
  `Thuoc_idThuoc` int(11) NOT NULL,
  `Tungay` datetime DEFAULT NULL,
  `Denngay` datetime DEFAULT NULL,
  `Sang` varchar(45) DEFAULT NULL,
  `Trua` varchar(45) DEFAULT NULL,
  `Toi` varchar(45) DEFAULT NULL,
  `Loidan` varchar(100) DEFAULT NULL,
  `Bacsi` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Phieukhambenh_idPhieukhambenh`,`Thuoc_idThuoc`),
  KEY `fk_Phieukhambenh_has_Thuoc_Thuoc1` (`Thuoc_idThuoc`),
  KEY `fk_Phieukhambenh_has_Thuoc_Phieukhambenh` (`Phieukhambenh_idPhieukhambenh`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `ngoaitru`
--

CREATE TABLE IF NOT EXISTS `ngoaitru` (
  `idNgoaitru` int(11) NOT NULL,
  `Ngaygiovaovien` datetime DEFAULT NULL,
  `Benhchinh` varchar(200) DEFAULT NULL,
  `Benhkemtheo` varchar(45) DEFAULT NULL,
  `Dieutritu` datetime DEFAULT NULL,
  `Dieutriden` datetime DEFAULT NULL,
  `Tinhtrangravien` varchar(45) DEFAULT NULL,
  `Huongdieutri` varchar(45) DEFAULT NULL,
  `Bacsikhambenh` varchar(45) DEFAULT NULL,
  `Bacsidieutri` varchar(45) DEFAULT NULL,
  `chaythan` tinyint(1) DEFAULT NULL,
  `Phieukhambenh_idPhieukhambenh` int(11) NOT NULL,
  PRIMARY KEY (`idNgoaitru`),
  KEY `fk_Ngoaitru_Phieukhambenh1` (`Phieukhambenh_idPhieukhambenh`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `noitru`
--

CREATE TABLE IF NOT EXISTS `noitru` (
  `idNoitru` int(11) NOT NULL,
  `Thoigianvaovien` datetime DEFAULT NULL,
  `Tructiepvao` varchar(45) DEFAULT NULL,
  `Vaolanthu` varchar(45) DEFAULT NULL,
  `Ngaygiovaokhoa` datetime DEFAULT NULL,
  `Chuyenkhoa` varchar(45) DEFAULT NULL,
  `Ngaygiochuyenkhoa` datetime DEFAULT NULL,
  `Chuyenvien` varchar(45) DEFAULT NULL,
  `Chuyenden` varchar(45) DEFAULT NULL,
  `Ngaygioravien` datetime DEFAULT NULL,
  `Loairavien` varchar(45) DEFAULT NULL,
  `Noichuyenden` varchar(45) DEFAULT NULL,
  `KKBCapcuu` varchar(45) DEFAULT NULL,
  `Khivaokhoadieutri` varchar(45) DEFAULT NULL,
  `Thuthuat` tinyint(1) DEFAULT NULL,
  `Phauthuat` tinyint(1) DEFAULT NULL,
  `Benhchinh` varchar(45) DEFAULT NULL,
  `Benhkemtheo` varchar(45) DEFAULT NULL,
  `Taibien` tinyint(1) DEFAULT NULL,
  `Bienchung` tinyint(1) DEFAULT NULL,
  `Ketquadieutri` varchar(45) DEFAULT NULL,
  `Giaiphaubenh` varchar(45) DEFAULT NULL,
  `Thoigiantuvong` datetime DEFAULT NULL,
  `Lydotuvong` varchar(45) DEFAULT NULL,
  `Nguyennhanchinhtuvong` varchar(45) DEFAULT NULL,
  `Khamnghiemtuthi` tinyint(1) DEFAULT NULL,
  `Chuandoangiaiphaututhi` varchar(45) DEFAULT NULL,
  `Diung` varchar(45) DEFAULT NULL,
  `Matuy` varchar(45) DEFAULT NULL,
  `Ruoubia` varchar(45) DEFAULT NULL,
  `Thuocla` varchar(45) DEFAULT NULL,
  `Thuoclao` varchar(45) DEFAULT NULL,
  `Khac` varchar(45) DEFAULT NULL,
  `Tuanhoan` varchar(45) DEFAULT NULL,
  `Hohap` varchar(45) DEFAULT NULL,
  `Tieuhoa` varchar(45) DEFAULT NULL,
  `Thantietnieusinhduc` varchar(45) DEFAULT NULL,
  `Thankinh` varchar(45) DEFAULT NULL,
  `Coxuongkhop` varchar(45) DEFAULT NULL,
  `Taimuihong` varchar(45) DEFAULT NULL,
  `Ranghammat` varchar(45) DEFAULT NULL,
  `Mat` varchar(45) DEFAULT NULL,
  `Noitietdinhduong` varchar(45) DEFAULT NULL,
  `Tomtatbenhan` varchar(200) DEFAULT NULL,
  `Tienluong` varchar(45) DEFAULT NULL,
  `Huongdieutri` varchar(45) DEFAULT NULL,
  `Phuongphapdieutri` varchar(45) DEFAULT NULL,
  `BStruongkhoa` varchar(45) DEFAULT NULL,
  `Bslambenhan` varchar(45) DEFAULT NULL,
  `BSdieutri` varchar(45) DEFAULT NULL,
  `Phieukhambenh_idPhieukhambenh` int(11) NOT NULL,
  PRIMARY KEY (`idNoitru`),
  KEY `fk_Noitru_Phieukhambenh1` (`Phieukhambenh_idPhieukhambenh`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `phieukhambenh`
--

CREATE TABLE IF NOT EXISTS `phieukhambenh` (
  `idPhieukhambenh` int(11) NOT NULL,
  `Doituong` varchar(45) NOT NULL,
  `BHYTgiatriden` datetime NOT NULL,
  `SoBHYT` varchar(30) NOT NULL,
  `Nguoithan` varchar(45) NOT NULL,
  `Dienthoai` varchar(20) NOT NULL,
  `Thoigiandenkham` datetime DEFAULT NULL,
  `Noigioithieu` varchar(45) DEFAULT NULL,
  `Lydovaovien` varchar(200) DEFAULT NULL,
  `Quatrinhbenhly` varchar(200) DEFAULT NULL,
  `Tiensubenh` varchar(200) DEFAULT NULL,
  `Mach` varchar(45) DEFAULT NULL,
  `Nhietdo` varchar(45) DEFAULT NULL,
  `Huyetap` varchar(45) DEFAULT NULL,
  `Nhiptho` varchar(45) DEFAULT NULL,
  `Trongluong` varchar(45) DEFAULT NULL,
  `Toanthan` varchar(200) DEFAULT NULL,
  `Cacbophan` varchar(200) DEFAULT NULL,
  `Tomtatketqualamsan` varchar(200) DEFAULT NULL,
  `Chuandoanvaovien` varchar(200) DEFAULT NULL,
  `Xuli` varchar(200) DEFAULT NULL,
  `Dieutritaikhoa` varchar(45) DEFAULT NULL,
  `Chuy` varchar(200) DEFAULT NULL,
  `Benhnhan_idBenhnhan` int(11) NOT NULL,
  `Hosophimanh_idHosophimanh` int(11) NOT NULL,
  `Benhvien_idBenhvien` int(11) NOT NULL,
  PRIMARY KEY (`idPhieukhambenh`),
  KEY `fk_Phieukhambenh_Benhnhan1` (`Benhnhan_idBenhnhan`),
  KEY `fk_Phieukhambenh_Hosophimanh1` (`Hosophimanh_idHosophimanh`),
  KEY `fk_Phieukhambenh_Benhvien1` (`Benhvien_idBenhvien`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `phieukhambenh_bacsi`
--

CREATE TABLE IF NOT EXISTS `phieukhambenh_bacsi` (
  `Phieukhambenh_idPhieukhambenh` int(11) NOT NULL,
  `Bacsi_idBacsi` int(11) NOT NULL,
  PRIMARY KEY (`Phieukhambenh_idPhieukhambenh`,`Bacsi_idBacsi`),
  KEY `fk_Phieukhambenh_has_Bacsi_Bacsi1` (`Bacsi_idBacsi`),
  KEY `fk_Phieukhambenh_has_Bacsi_Phieukhambenh1` (`Phieukhambenh_idPhieukhambenh`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `phieukhambenh_xutri`
--

CREATE TABLE IF NOT EXISTS `phieukhambenh_xutri` (
  `Phieukhambenh_idPhieukhambenh` int(11) NOT NULL,
  `Xutri_idXutri` int(11) NOT NULL,
  `Ngaygioxutri` datetime DEFAULT NULL,
  PRIMARY KEY (`Phieukhambenh_idPhieukhambenh`,`Xutri_idXutri`),
  KEY `fk_Phieukhambenh_has_Xutri_Xutri1_idx` (`Xutri_idXutri`),
  KEY `fk_Phieukhambenh_has_Xutri_Phieukhambenh1_idx` (`Phieukhambenh_idPhieukhambenh`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `thuoc`
--

CREATE TABLE IF NOT EXISTS `thuoc` (
  `idThuoc` int(11) NOT NULL,
  `Tenthuoc` varchar(45) DEFAULT NULL,
  `Taduoc` varchar(45) DEFAULT NULL,
  `Hamluong` varchar(45) DEFAULT NULL,
  `Duongdung` varchar(45) DEFAULT NULL,
  `Dang` varchar(45) DEFAULT NULL,
  `Soluong` int(11) DEFAULT NULL,
  PRIMARY KEY (`idThuoc`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `xetnghiem`
--

CREATE TABLE IF NOT EXISTS `xetnghiem` (
  `idXetnghiem` int(11) NOT NULL,
  `Glucose` varchar(45) DEFAULT NULL,
  `HbA1C` varchar(45) DEFAULT NULL,
  `Urea` varchar(45) DEFAULT NULL,
  `Creatinin` varchar(45) DEFAULT NULL,
  `SGOT` varchar(45) DEFAULT NULL,
  `SGPT` varchar(45) DEFAULT NULL,
  `GGT` varchar(45) DEFAULT NULL,
  `Triglycerides` varchar(45) DEFAULT NULL,
  `HDL-C` varchar(45) DEFAULT NULL,
  `LDL-C` varchar(45) DEFAULT NULL,
  `K+/ISE` varchar(45) DEFAULT NULL,
  `Ca++/ISE` varchar(45) DEFAULT NULL,
  `CRP` varchar(45) DEFAULT NULL,
  `Albumin` varchar(45) DEFAULT NULL,
  `TC` varchar(45) DEFAULT NULL,
  `Hct` varchar(45) DEFAULT NULL,
  `Hb` varchar(45) DEFAULT NULL,
  `HeABO` varchar(45) DEFAULT NULL,
  `HeRh` varchar(45) DEFAULT NULL,
  `HBsAg` varchar(45) DEFAULT NULL,
  `AntiHCV` varchar(45) DEFAULT NULL,
  `HIV` varchar(45) DEFAULT NULL,
  `TPTNT` varchar(45) DEFAULT NULL,
  `Khac` varchar(200) DEFAULT NULL,
  `Phieukhambenh_idPhieukhambenh` int(11) NOT NULL,
  `Hoichuan_idHoichuan` int(11) NOT NULL,
  PRIMARY KEY (`idXetnghiem`),
  KEY `fk_Xetnghiem_Phieukhambenh1` (`Phieukhambenh_idPhieukhambenh`),
  KEY `fk_Xetnghiem_Hoichuan1` (`Hoichuan_idHoichuan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `xutri`
--

CREATE TABLE IF NOT EXISTS `xutri` (
  `idXutri` int(11) NOT NULL,
  `Tenxutri` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idXutri`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bacsi_hoichuan`
--
ALTER TABLE `bacsi_hoichuan`
  ADD CONSTRAINT `fk_Bacsi_has_Hoichuan_Bacsi1` FOREIGN KEY (`Bacsi_idBacsi`) REFERENCES `bacsi` (`idBacsi`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Bacsi_has_Hoichuan_Hoichuan1` FOREIGN KEY (`Hoichuan_idHoichuan`) REFERENCES `hoichuan` (`idHoichuan`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `idc_phieukhambenh`
--
ALTER TABLE `idc_phieukhambenh`
  ADD CONSTRAINT `fk_IDC_has_Phieukhambenh_IDC1` FOREIGN KEY (`IDC_idIDC`) REFERENCES `idc` (`idIDC`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_IDC_has_Phieukhambenh_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`) REFERENCES `phieukhambenh` (`idPhieukhambenh`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `lanhthuoc`
--
ALTER TABLE `lanhthuoc`
  ADD CONSTRAINT `fk_Phieukhambenh_has_Thuoc_Phieukhambenh` FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`) REFERENCES `phieukhambenh` (`idPhieukhambenh`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Phieukhambenh_has_Thuoc_Thuoc1` FOREIGN KEY (`Thuoc_idThuoc`) REFERENCES `thuoc` (`idThuoc`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `ngoaitru`
--
ALTER TABLE `ngoaitru`
  ADD CONSTRAINT `fk_Ngoaitru_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`) REFERENCES `phieukhambenh` (`idPhieukhambenh`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `noitru`
--
ALTER TABLE `noitru`
  ADD CONSTRAINT `fk_Noitru_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`) REFERENCES `phieukhambenh` (`idPhieukhambenh`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `phieukhambenh`
--
ALTER TABLE `phieukhambenh`
  ADD CONSTRAINT `fk_Phieukhambenh_Benhnhan1` FOREIGN KEY (`Benhnhan_idBenhnhan`) REFERENCES `benhnhan` (`idBenhnhan`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Phieukhambenh_Benhvien1` FOREIGN KEY (`Benhvien_idBenhvien`) REFERENCES `benhvien` (`idBenhvien`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Phieukhambenh_Hosophimanh1` FOREIGN KEY (`Hosophimanh_idHosophimanh`) REFERENCES `hosophimanh` (`idHosophimanh`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `phieukhambenh_ibfk_1` FOREIGN KEY (`idPhieukhambenh`) REFERENCES `bacsi` (`idBacsi`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `phieukhambenh_bacsi`
--
ALTER TABLE `phieukhambenh_bacsi`
  ADD CONSTRAINT `fk_Phieukhambenh_has_Bacsi_Bacsi1` FOREIGN KEY (`Bacsi_idBacsi`) REFERENCES `bacsi` (`idBacsi`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Phieukhambenh_has_Bacsi_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`) REFERENCES `phieukhambenh` (`idPhieukhambenh`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `phieukhambenh_xutri`
--
ALTER TABLE `phieukhambenh_xutri`
  ADD CONSTRAINT `fk_Phieukhambenh_has_Xutri_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`) REFERENCES `phieukhambenh` (`idPhieukhambenh`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Phieukhambenh_has_Xutri_Xutri1` FOREIGN KEY (`Xutri_idXutri`) REFERENCES `xutri` (`idXutri`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `xetnghiem`
--
ALTER TABLE `xetnghiem`
  ADD CONSTRAINT `fk_Xetnghiem_Hoichuan1` FOREIGN KEY (`Hoichuan_idHoichuan`) REFERENCES `hoichuan` (`idHoichuan`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Xetnghiem_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`) REFERENCES `phieukhambenh` (`idPhieukhambenh`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
