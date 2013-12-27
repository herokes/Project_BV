-- phpMyAdmin SQL Dump
-- version 3.5.2.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 23, 2013 at 11:24 AM
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
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TenBacsi` varchar(45) DEFAULT NULL,
  `Trinhdo` varchar(45) DEFAULT NULL,
  `Dienthoai` varchar(45) DEFAULT NULL,
  `Diachi` varchar(45) DEFAULT NULL,
  `Namsinh` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `bacsi`
--

INSERT INTO `bacsi` (`id`, `TenBacsi`, `Trinhdo`, `Dienthoai`, `Diachi`, `Namsinh`) VALUES
(1, 'NGUYỄN THỊ KIM PHƯỢNG', NULL, NULL, NULL, NULL),
(2, 'DƯƠNG MINH CƯỜNG', NULL, NULL, NULL, NULL),
(3, 'TRẦN LÝ MỸ CHÂU', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `bacsi_hoichuan`
--

CREATE TABLE IF NOT EXISTS `bacsi_hoichuan` (
  `Hoichuan_id` int(11) NOT NULL,
  `Bacsi_id` int(11) NOT NULL,
  `NgaygioHoichuan` datetime DEFAULT NULL,
  PRIMARY KEY (`Hoichuan_id`,`Bacsi_id`),
  KEY `fk_Bacsi_Hoichuan_Bacsi1` (`Bacsi_id`),
  KEY `fk_Bacsi_Hoichuan_Hoichuan1` (`Hoichuan_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `bacsi_hoichuan`
--

INSERT INTO `bacsi_hoichuan` (`Hoichuan_id`, `Bacsi_id`, `NgaygioHoichuan`) VALUES
(1, 1, '2013-12-23 11:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `benhnhan`
--

CREATE TABLE IF NOT EXISTS `benhnhan` (
  `id` int(11) NOT NULL,
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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `benhnhan`
--

INSERT INTO `benhnhan` (`id`, `Ten`, `Ngaysinh`, `Gioitinh`, `Nghenghiep`, `Dantoc`, `CMND`, `Ngoaikieu`, `Sonha`, `Duong`, `Phuong`, `Quan`, `Thanhpho`, `Noilamviec`) VALUES
(0, 'HUỲNH CÔNG HINH', '1953-07-17 00:00:00', 1, 'Công nhân', 'Kinh', '025177881', NULL, '183/23a', 'Tân Hòa Đông', '14', '6', 'Hồ Chí Minh', 'Quận 6'),
(1301, 'QUANG', '1989-11-11 00:00:00', 1, 'Công nhân', 'KINH', '025177881', '', '11', ' LTK', 'P9', 'TB', 'HCM', 'COOPMARK'),
(1302, 'HÀ', '1960-11-02 00:00:00', 0, 'Học sinh', 'KINH', '025177882', '', '55', 'MAC DINH CHI', '11', '6', 'HO CHI MINH', ' TRUNG HOC'),
(13004582, 'HUỲNH CÔNG HINH', '1953-07-17 00:00:00', 1, 'Công nhân', 'Kinh', '025177881', NULL, '183/23a', 'Tân Hòa Đông', '14', '6', 'Hồ Chí Minh', 'Quận 6');

-- --------------------------------------------------------

--
-- Table structure for table `benhvien`
--

CREATE TABLE IF NOT EXISTS `benhvien` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Tenbenhvien` varchar(45) DEFAULT NULL,
  `Ghichu` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `hoichuan`
--

CREATE TABLE IF NOT EXISTS `hoichuan` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Thoigianhoichuan` datetime DEFAULT NULL,
  `Ketluanhoichuan` varchar(200) DEFAULT NULL,
  `Phieuxetnghiem_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Hoichuan_Phieuxetnghiem1` (`Phieuxetnghiem_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `hoichuan`
--

INSERT INTO `hoichuan` (`id`, `Thoigianhoichuan`, `Ketluanhoichuan`, `Phieuxetnghiem_id`) VALUES
(1, '2013-12-16 11:00:00', 'Dùng thuốc tạo máu :(Pronivel 2000ui, Mirafo 4000ui, Epocassa 2000ui) liều 12,000ui/tuần. Truyền đạm (Kidmin 7,2%, Celemin Nepro 7%): 2 lần/ tuần)', 1);

-- --------------------------------------------------------

--
-- Table structure for table `hosophimanh`
--

CREATE TABLE IF NOT EXISTS `hosophimanh` (
  `id` int(11) NOT NULL,
  `loai` varchar(100) DEFAULT NULL,
  `soluong` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `hosophimanh_phieukhambenh`
--

CREATE TABLE IF NOT EXISTS `hosophimanh_phieukhambenh` (
  `Hosophimanh_id` int(11) NOT NULL,
  `Phieukhambenh_id` int(11) NOT NULL,
  PRIMARY KEY (`Hosophimanh_id`,`Phieukhambenh_id`),
  KEY `fk_Hosophimanh_has_Phieukhambenh_Phieukhambenh1` (`Phieukhambenh_id`),
  KEY `fk_Hosophimanh_has_Phieukhambenh_Hosophimanh1` (`Hosophimanh_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

-- --------------------------------------------------------

--
-- Table structure for table `idc_phieukhambenh`
--

CREATE TABLE IF NOT EXISTS `idc_phieukhambenh` (
  `IDC_id` varchar(10) NOT NULL,
  `Phieukhambenh_id` int(11) NOT NULL,
  PRIMARY KEY (`IDC_id`,`Phieukhambenh_id`),
  KEY `fk_IDC_has_Phieukhambenh_Phieukhambenh1` (`Phieukhambenh_id`),
  KEY `fk_IDC_has_Phieukhambenh_IDC1` (`IDC_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `ngoaitru`
--

CREATE TABLE IF NOT EXISTS `ngoaitru` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
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
  `Phieukhambenh_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Ngoaitru_Phieukhambenh1` (`Phieukhambenh_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `ngoaitru`
--

INSERT INTO `ngoaitru` (`id`, `Ngaygiovaovien`, `Benhchinh`, `Benhkemtheo`, `Dieutritu`, `Dieutriden`, `Tinhtrangravien`, `Huongdieutri`, `Bacsikhambenh`, `Bacsidieutri`, `chaythan`, `Phieukhambenh_id`) VALUES
(1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 3),
(2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 4),
(3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 5),
(4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 6),
(5, '2013-12-23 00:00:00', 'Suy thận mạn giai đoạn cuối', 'tăng huyết ap- đái tháo đường type2', '2013-12-23 00:00:00', NULL, 'ổn', 'Đổi hồ sơ tiếp tục điều trị', 'BS. Nguyễn Thị Kim Phượng', 'BS. Nguyễn Thị Kim Phượng', 1, 9);

-- --------------------------------------------------------

--
-- Table structure for table `noitru`
--

CREATE TABLE IF NOT EXISTS `noitru` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
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
  `Phieukhambenh_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Noitru_Phieukhambenh1` (`Phieukhambenh_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `noitru`
--

INSERT INTO `noitru` (`id`, `Thoigianvaovien`, `Tructiepvao`, `Vaolanthu`, `Ngaygiovaokhoa`, `Chuyenkhoa`, `Ngaygiochuyenkhoa`, `Chuyenvien`, `Chuyenden`, `Ngaygioravien`, `Loairavien`, `Noichuyenden`, `KKBCapcuu`, `Khivaokhoadieutri`, `Thuthuat`, `Phauthuat`, `Benhchinh`, `Benhkemtheo`, `Taibien`, `Bienchung`, `Ketquadieutri`, `Giaiphaubenh`, `Thoigiantuvong`, `Lydotuvong`, `Nguyennhanchinhtuvong`, `Khamnghiemtuthi`, `Chuandoangiaiphaututhi`, `Diung`, `Matuy`, `Ruoubia`, `Thuocla`, `Thuoclao`, `Khac`, `Tuanhoan`, `Hohap`, `Tieuhoa`, `Thantietnieusinhduc`, `Thankinh`, `Coxuongkhop`, `Taimuihong`, `Ranghammat`, `Mat`, `Noitietdinhduong`, `Tomtatbenhan`, `Tienluong`, `Huongdieutri`, `Phuongphapdieutri`, `BStruongkhoa`, `Bslambenhan`, `BSdieutri`, `Phieukhambenh_id`) VALUES
(1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6),
(2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7);

-- --------------------------------------------------------

--
-- Table structure for table `phieukhambenh`
--

CREATE TABLE IF NOT EXISTS `phieukhambenh` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Doituong` varchar(45) DEFAULT NULL,
  `DKKCBBD` varchar(45) DEFAULT NULL,
  `Bhytgiatritu` datetime DEFAULT NULL,
  `Bhytgiatriden` datetime DEFAULT NULL,
  `Sobhyt` varchar(45) DEFAULT NULL,
  `Nguoithan` varchar(45) DEFAULT NULL,
  `Diachinguoithan` varchar(100) DEFAULT NULL,
  `Dienthoai` varchar(45) DEFAULT NULL,
  `Thoigiandenkham` datetime DEFAULT NULL,
  `Noigioithieu` varchar(45) DEFAULT NULL,
  `Lydovaovien` varchar(200) DEFAULT NULL,
  `Quatrinhbenhly` varchar(200) DEFAULT NULL,
  `Tiensubenhbanthan` varchar(200) DEFAULT NULL,
  `Tiensubenhgiadinh` varchar(200) DEFAULT NULL,
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
  `Benhnhan_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Phieukhambenh_Benhnhan1` (`Benhnhan_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

--
-- Dumping data for table `phieukhambenh`
--

INSERT INTO `phieukhambenh` (`id`, `Doituong`, `DKKCBBD`, `Bhytgiatritu`, `Bhytgiatriden`, `Sobhyt`, `Nguoithan`, `Diachinguoithan`, `Dienthoai`, `Thoigiandenkham`, `Noigioithieu`, `Lydovaovien`, `Quatrinhbenhly`, `Tiensubenhbanthan`, `Tiensubenhgiadinh`, `Mach`, `Nhietdo`, `Huyetap`, `Nhiptho`, `Trongluong`, `Toanthan`, `Cacbophan`, `Tomtatketqualamsan`, `Chuandoanvaovien`, `Xuli`, `Dieutritaikhoa`, `Chuy`, `Benhnhan_id`) VALUES
(1, 'BHYT', 'QUẬN 6', '2013-12-23 00:00:00', '2013-12-31 00:00:00', 'CN679000244378879017', 'CON: TRẦN LÊ VĨNH SINH', '11 HOÀNG HOA THÁM QUẬN 11', '01234507576', '2013-12-23 02:06:40', 'COMBO', 'CHẠY THẬN ĐỊNH KỲ', 'SUY THẬN MẠN GIAI ĐOẠN CUỐI, - TĂNG HUYẾT ÁP- LAO HẠCH- VIÊM DẠ DÀY', 'SUY THẬN MẠN, LIỆT 2 CHI DƯỚI', 'CHƯA CÓ GHI NHẬN', '80', '37', '100/60', '16', '16', 'TIỂU RẤT ÍT\nPHÙ TOÀN THÂN\nTỈNH', 'TIM ĐỀU\nPHỔI KHÔNG RAN\nBỤNG MỀM\n', 'CHƯA CÓ KẾT QUẢ LÂM SÀNG', 'SUY THẬN MẠN GIAI ĐOẠN CUỐI, - TĂNG HUYẾT ÁP- LAO HẠCH- VIÊM DẠ DÀY', 'CHẠY THẬN NHÂN TẠO 3 LẦN / TUẦN\n', 'THẬN', '', 1302),
(2, 'BHYT', 'GDFF', '2013-12-23 00:00:00', '2013-12-23 00:00:00', 'GFDGFD', 'HGH', 'GHFG', '', '2013-12-23 02:23:06', 'FGH', 'FGH', 'FGH', 'FGHG', 'FGJKIYT', '5', '65', '456', '56', '54', 'GDFG', 'GDFG', 'FDGDF', 'lay ma IDC va ten IDC', 'DFGD', 'THẬN', '', 1302),
(3, 'BHYT', 'HGDFG', '2013-12-23 00:00:00', '2013-12-23 00:00:00', 'DSFGDFG', 'DFGDFGDF', 'DFGDG', 'G435TRSRER', '2013-12-23 02:28:15', 'FGDF', 'DFGD', 'DFGD', 'HFGHGF', 'FGHFG', 'GFH', 'HFG', 'FGHFFG', 'GHFG', 'FGH', 'FGH', 'FGHFGH', 'FGHFG', 'FGHFGHF', 'GFHFGHF', 'THẬN', '3', 1302),
(4, 'BHYT', 'HGDFG', '2013-12-23 00:00:00', '2013-12-23 00:00:00', 'DSFGDFG', 'DFGDFGDF', 'DFGDG', 'G435TRSRER', '2013-12-23 02:28:15', 'FGDF', 'DFGD', 'DFGD', 'HFGHGF', 'FGHFG', 'GFH', 'HFG', 'FGHFFG', 'GHFG', 'FGH', 'FGH', 'FGHFGH', 'FGHFG', 'FGHFGHF', 'GFHFGHF', 'THẬN', '3', 1302),
(5, 'BHYT', 'HGDFG', '2013-12-23 00:00:00', '2013-12-23 00:00:00', 'DSFGDFG', 'DFGDFGDF', 'DFGDG', 'G435TRSRER', '2013-12-23 02:28:15', 'FGDF', 'DFGD', 'DFGD', 'HFGHGF', 'FGHFG', 'GFH', 'HFG', 'FGHFFG', 'GHFG', 'FGH', 'FGH', 'FGHFGH', 'FGHFG', 'FGHFGHF', 'GFHFGHF', 'THẬN', '3', 1302),
(6, 'BHYT', 'HGDFG', '2013-12-23 00:00:00', '2013-12-23 00:00:00', 'DSFGDFG', 'DFGDFGDF', 'DFGDG', 'G435TRSRER', '2013-12-23 02:28:15', 'FGDF', 'DFGD', 'DFGD', 'HFGHGF', 'FGHFG', 'GFH', 'HFG', 'FGHFFG', 'GHFG', 'FGH', 'FGH', 'FGHFGH', 'FGHFG', 'FGHFGHF', 'GFHFGHF', 'THẬN', '3', 1302),
(7, 'BHYT', 'cfgff', '2013-12-23 00:00:00', '2013-12-23 00:00:00', 'gd', 'dfg', 'fdg', '', '2013-12-23 02:40:13', 'dfg', 'gdf', 'dfg', 'dfg', 'fg', 'dfg', 'df', 'dfg', 'dfg', 'dfg', 'dfg', 'dfg', 'dfg', 'lay ma IDC va ten IDC', 'dfg', 'THẬN', 'df', 1302),
(8, 'BHYT', NULL, '2013-12-23 00:00:00', '2013-12-31 00:00:00', 'GD779000060160179017', NULL, NULL, NULL, '2013-01-01 00:00:00', 'TỰ ĐẾN', 'CHẠY THẬN NHÂN TẠO ĐỊNH KỲ', 'Bệnh nhân được chuẩn đoán suy thân mạn giai đoạn cuối', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0),
(9, 'BHYT', NULL, '2013-12-23 00:00:00', '2013-12-31 00:00:00', 'GD779000060160179017', NULL, NULL, NULL, '2013-01-01 00:00:00', 'TỰ ĐẾN', 'CHẠY THẬN NHÂN TẠO ĐỊNH KỲ', 'Bệnh nhân được chuẩn đoán suy thân mạn giai đoạn cuối. Tăng huyết áp. Đái tháo đường type2. Được chạy thận 3 lần / tuần. Nay đổi hồ sơ tiếp tục điều trị', 'Trên 10 năm: Tăng huyết áp, Đái tháo đường type 2, 2009 suy thân giai đoạn cuối', 'Cha mẹ: Tăng huyết áp đã mất', '80', '37', '140/90', '16', '72', 'Tỉnh, niêm nhạt. Phù toàn thân. Tiểu rất ít', 'Tim đều, T1 T2 rõ. Bụng Không rang. Bụng mềm', NULL, 'suy thận man giai đoạn cuối, tăng huyết áp. bệnh tim thiếu máu cục bộ', 'Chạy thận nhân tạo định kỳ 3 lần/ tuần. Hạ áp. Epoetin.', 'Thận', NULL, 13004582);

-- --------------------------------------------------------

--
-- Table structure for table `phieukhambenh_bacsi`
--

CREATE TABLE IF NOT EXISTS `phieukhambenh_bacsi` (
  `Bacsi_id` int(11) NOT NULL,
  `Phieukhambenh_id` int(11) NOT NULL,
  PRIMARY KEY (`Bacsi_id`,`Phieukhambenh_id`),
  KEY `fk_Phieukhambenh_Bacsi_Bacsi1` (`Bacsi_id`),
  KEY `fk_Phieukhambenh_Bacsi_Phieukhambenh1` (`Phieukhambenh_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `phieukhambenh_xutri`
--

CREATE TABLE IF NOT EXISTS `phieukhambenh_xutri` (
  `Phieukhambenh_id` int(11) NOT NULL,
  `Xutri_id` int(11) NOT NULL,
  `Ngaygioxutri` datetime DEFAULT NULL,
  PRIMARY KEY (`Phieukhambenh_id`,`Xutri_id`),
  KEY `fk_Phieukhambenh_has_Xutri_Xutri1_idx` (`Xutri_id`),
  KEY `fk_Phieukhambenh_has_Xutri_Phieukhambenh1_idx` (`Phieukhambenh_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `phieuxetnghiem`
--

CREATE TABLE IF NOT EXISTS `phieuxetnghiem` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Ngayxetnghiemm` datetime DEFAULT NULL,
  `Phieukhambenh_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Xetnghiem_has_Phieukhambenh_Xetnghiem1` (`id`),
  KEY `fk_Phieuxetnghiem_Phieukhambenh1` (`Phieukhambenh_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `phieuxetnghiem`
--

INSERT INTO `phieuxetnghiem` (`id`, `Ngayxetnghiemm`, `Phieukhambenh_id`) VALUES
(1, '2013-12-11 00:00:00', 9);

-- --------------------------------------------------------

--
-- Table structure for table `thuoc`
--

CREATE TABLE IF NOT EXISTS `thuoc` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Tenthuoc` varchar(45) DEFAULT NULL,
  `Taduoc` varchar(45) DEFAULT NULL,
  `Hamluong` varchar(45) DEFAULT NULL,
  `Duongdung` varchar(45) DEFAULT NULL,
  `Dang` varchar(45) DEFAULT NULL,
  `Soluong` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `thuoc`
--

INSERT INTO `thuoc` (`id`, `Tenthuoc`, `Taduoc`, `Hamluong`, `Duongdung`, `Dang`, `Soluong`) VALUES
(1, 'Adalat LA', NULL, '30mg', NULL, 'Viên', NULL),
(2, 'Adalat LA', NULL, '30mg', 'Uống', 'Viên', NULL),
(3, 'Aprovel', NULL, '150mg', 'Uống', 'viên', NULL),
(4, 'Coversyl', NULL, '10mg', 'Uống', 'viên', NULL),
(5, 'Concor tab', NULL, '5mg', 'Uống', 'viên', NULL),
(6, 'Omazolta', NULL, '20mg', 'Uống', 'viên', NULL),
(7, 'Austriol', NULL, '0.5ug', 'Uống', 'viên', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `toathuoc`
--

CREATE TABLE IF NOT EXISTS `toathuoc` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Tungay` datetime DEFAULT NULL,
  `Denngay` datetime DEFAULT NULL,
  `Loidan` varchar(100) DEFAULT NULL,
  `Bacsi` varchar(45) DEFAULT NULL,
  `Phieukhambenh_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Toathuoc_Phieukhambenh1` (`Phieukhambenh_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `toathuoc`
--

INSERT INTO `toathuoc` (`id`, `Tungay`, `Denngay`, `Loidan`, `Bacsi`, `Phieukhambenh_id`) VALUES
(1, '2013-12-04 00:00:00', '2013-12-16 00:00:00', 'Ăn lạt, hạn chế trái cây, Đo HA hằng ngày', 'BS: Nguyễn Kim Phượng', 9);

-- --------------------------------------------------------

--
-- Table structure for table `toathuoc_thuoc`
--

CREATE TABLE IF NOT EXISTS `toathuoc_thuoc` (
  `Toathuoc_id` int(11) NOT NULL,
  `Thuoc_id` int(11) NOT NULL,
  `sang` varchar(45) DEFAULT NULL,
  `trua` varchar(45) DEFAULT NULL,
  `toi` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Toathuoc_id`,`Thuoc_id`),
  KEY `fk_Toathuoc_has_Thuoc_Thuoc1` (`Thuoc_id`),
  KEY `fk_Toathuoc_has_Thuoc_Toathuoc1` (`Toathuoc_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `toathuoc_thuoc`
--

INSERT INTO `toathuoc_thuoc` (`Toathuoc_id`, `Thuoc_id`, `sang`, `trua`, `toi`) VALUES
(1, 1, '2', '1', '1'),
(1, 2, '1', '0', '1'),
(1, 3, '1', '0', '1'),
(1, 4, '1/2', '0', '0'),
(1, 5, '1', '0', '0');

-- --------------------------------------------------------

--
-- Table structure for table `todieutri`
--

CREATE TABLE IF NOT EXISTS `todieutri` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Phieukhambenh_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Todieutri_Phieukhambenh1` (`Phieukhambenh_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `todieutri_bosung`
--

CREATE TABLE IF NOT EXISTS `todieutri_noidung` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Dientienbenh` text,
  `Ylenh` text,
  `Ngaygio` datetime DEFAULT NULL,
  `Todieutri_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Todieutri_noidung_Todieutri1` (`Todieutri_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `xetnghiem`
--

CREATE TABLE IF NOT EXISTS `xetnghiem` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TenXetnghiem` varchar(45) DEFAULT NULL,
  `Thongsobinhthuong` varchar(45) DEFAULT NULL,
  `Loaixetnghiem` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=25 ;

--
-- Dumping data for table `xetnghiem`
--

INSERT INTO `xetnghiem` (`id`, `TenXetnghiem`, `Thongsobinhthuong`, `Loaixetnghiem`) VALUES
(1, 'Glucose', '70 - 110 mg/dL', 'Sinh Hóa'),
(2, 'HbA1c', '4,6 - 6,5 %', 'Sinh Hóa'),
(3, 'Urea', '10 - 50 mg/dL', 'Sinh Hóa'),
(4, 'Creatinin', '0,6 - 1,3 mg/dL', 'Sinh Hóa'),
(5, 'SGPT', '15 - 45 U/L', 'Sinh Hóa'),
(6, 'GGT', '10 - 45 U/L', 'Sinh Hóa'),
(7, 'Triglycerides', '35 - 160 mg/dL', 'Sinh Hóa'),
(8, 'HDL - C', '>= 35mg/dL', 'Sinh Hóa'),
(9, 'LDL - C', '<130 mg/dL', 'Sinh Hóa'),
(10, 'K+/ISE', '3,5 - 5,2 mmol/L', 'Sinh Hóa'),
(11, 'Ca++/ISE', '2,15 - 2,55 mmol/L', 'Sinh Hóa'),
(12, 'SGOT', '15 45 U/L', 'Sinh Hóa'),
(13, 'CRP', '< 5 mg/L', 'Sinh Hóa'),
(14, 'Albumin', '35 -50 g/L', 'Sinh Hóa'),
(15, 'TC (Platelet)', NULL, 'Huyết Đồ'),
(16, 'Hct', NULL, 'Huyết Đồ'),
(17, 'Hb', NULL, 'Huyết Đồ'),
(18, 'Hệ ABO', NULL, 'Nhóm Máu'),
(19, 'Hệ Rh', NULL, 'Nhóm Máu'),
(20, 'HBsAg', 'Neg :<1,0 s/Co', 'Miễn Dịch'),
(21, 'Anti HCV', 'Neg :<1 s/Co', 'Miễn Dịch'),
(22, 'HIV', 'Negative', 'Miễn Dịch'),
(23, 'TPTNT', NULL, 'Nước Tiểu'),
(24, 'Phản ứng chéo', NULL, 'Khác');

-- --------------------------------------------------------

--
-- Table structure for table `xetnghiem_phieuxetnghiem`
--

CREATE TABLE IF NOT EXISTS `xetnghiem_phieuxetnghiem` (
  `Xetnghiem_id` int(11) NOT NULL,
  `Phieuxetnghiem_id` int(11) NOT NULL,
  `Thongsoxetnghiem` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Xetnghiem_id`,`Phieuxetnghiem_id`),
  KEY `fk_Xetnghiem_has_Phieuxetnghiem_Phieuxetnghiem1` (`Phieuxetnghiem_id`),
  KEY `fk_Xetnghiem_has_Phieuxetnghiem_Xetnghiem1` (`Xetnghiem_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `xetnghiem_phieuxetnghiem`
--

INSERT INTO `xetnghiem_phieuxetnghiem` (`Xetnghiem_id`, `Phieuxetnghiem_id`, `Thongsoxetnghiem`) VALUES
(16, 1, '32.4%'),
(17, 1, '9.66 g/dl');

-- --------------------------------------------------------

--
-- Table structure for table `xutri`
--

CREATE TABLE IF NOT EXISTS `xutri` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Tenxutri` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bacsi_hoichuan`
--
ALTER TABLE `bacsi_hoichuan`
  ADD CONSTRAINT `fk_Bacsi_Hoichuan_Bacsi1` FOREIGN KEY (`Bacsi_id`) REFERENCES `bacsi` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Bacsi_Hoichuan_Hoichuan1` FOREIGN KEY (`Hoichuan_id`) REFERENCES `hoichuan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `hoichuan`
--
ALTER TABLE `hoichuan`
  ADD CONSTRAINT `fk_Hoichuan_Phieuxetnghiem1` FOREIGN KEY (`Phieuxetnghiem_id`) REFERENCES `phieuxetnghiem` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `hosophimanh_phieukhambenh`
--
ALTER TABLE `hosophimanh_phieukhambenh`
  ADD CONSTRAINT `fk_Hosophimanh_has_Phieukhambenh_Hosophimanh1` FOREIGN KEY (`Hosophimanh_id`) REFERENCES `hosophimanh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Hosophimanh_has_Phieukhambenh_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_id`) REFERENCES `phieukhambenh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `idc_phieukhambenh`
--
ALTER TABLE `idc_phieukhambenh`
  ADD CONSTRAINT `fk_IDC_has_Phieukhambenh_IDC1` FOREIGN KEY (`IDC_id`) REFERENCES `idc` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_IDC_has_Phieukhambenh_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_id`) REFERENCES `phieukhambenh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `ngoaitru`
--
ALTER TABLE `ngoaitru`
  ADD CONSTRAINT `fk_Ngoaitru_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_id`) REFERENCES `phieukhambenh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `noitru`
--
ALTER TABLE `noitru`
  ADD CONSTRAINT `fk_Noitru_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_id`) REFERENCES `phieukhambenh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `phieukhambenh`
--
ALTER TABLE `phieukhambenh`
  ADD CONSTRAINT `fk_Phieukhambenh_Benhnhan1` FOREIGN KEY (`Benhnhan_id`) REFERENCES `benhnhan` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `phieukhambenh_bacsi`
--
ALTER TABLE `phieukhambenh_bacsi`
  ADD CONSTRAINT `fk_Phieukhambenh_Bacsi_Bacsi1` FOREIGN KEY (`Bacsi_id`) REFERENCES `bacsi` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Phieukhambenh_Bacsi_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_id`) REFERENCES `phieukhambenh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `phieukhambenh_xutri`
--
ALTER TABLE `phieukhambenh_xutri`
  ADD CONSTRAINT `fk_Phieukhambenh_has_Xutri_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_id`) REFERENCES `phieukhambenh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Phieukhambenh_has_Xutri_Xutri1` FOREIGN KEY (`Xutri_id`) REFERENCES `xutri` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `phieuxetnghiem`
--
ALTER TABLE `phieuxetnghiem`
  ADD CONSTRAINT `fk_Phieuxetnghiem_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_id`) REFERENCES `phieukhambenh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `toathuoc`
--
ALTER TABLE `toathuoc`
  ADD CONSTRAINT `fk_Toathuoc_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_id`) REFERENCES `phieukhambenh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `toathuoc_thuoc`
--
ALTER TABLE `toathuoc_thuoc`
  ADD CONSTRAINT `fk_Toathuoc_has_Thuoc_Thuoc1` FOREIGN KEY (`Thuoc_id`) REFERENCES `thuoc` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Toathuoc_has_Thuoc_Toathuoc1` FOREIGN KEY (`Toathuoc_id`) REFERENCES `toathuoc` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `todieutri`
--
ALTER TABLE `todieutri`
  ADD CONSTRAINT `fk_Todieutri_Phieukhambenh1` FOREIGN KEY (`Phieukhambenh_id`) REFERENCES `phieukhambenh` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `todieutri_bosung`
--
ALTER TABLE `todieutri_noidung`
  ADD CONSTRAINT `fk_Todieutri_noidung_Todieutri1` FOREIGN KEY (`Todieutri_id`) REFERENCES `todieutri` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `xetnghiem_phieuxetnghiem`
--
ALTER TABLE `xetnghiem_phieuxetnghiem`
  ADD CONSTRAINT `fk_Xetnghiem_has_Phieuxetnghiem_Phieuxetnghiem1` FOREIGN KEY (`Phieuxetnghiem_id`) REFERENCES `phieuxetnghiem` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Xetnghiem_has_Phieuxetnghiem_Xetnghiem1` FOREIGN KEY (`Xetnghiem_id`) REFERENCES `xetnghiem` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
