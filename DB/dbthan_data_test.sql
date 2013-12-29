
INSERT INTO `benhnhan` (`id`, `Ten`, `Ngaysinh`, `Gioitinh`, `Nghenghiep`, `Dantoc`, `CMND`, `Ngoaikieu`, `Sonha`, `Duong`, `Phuong`, `Quan`, `Thanhpho`, `Noilamviec`) VALUES
(0, 'HUỲNH CÔNG HINH', '1953-07-17 00:00:00', 1, 'Công nhân', 'Kinh', '025177881', NULL, '183/23a', 'Tân Hòa Đông', '14', '6', 'Hồ Chí Minh', 'Quận 6'),
(1301, 'QUANG', '1989-11-11 00:00:00', 1, 'Công nhân', 'KINH', '025177881', '', '11', ' LTK', 'P9', 'TB', 'HCM', 'COOPMARK'),
(1302, 'HÀ', '1960-11-02 00:00:00', 0, 'Học sinh', 'KINH', '025177882', '', '55', 'MAC DINH CHI', '11', '6', 'HO CHI MINH', ' TRUNG HOC'),
(13004582, 'HUỲNH CÔNG HINH', '1953-07-17 00:00:00', 1, 'Công nhân', 'Kinh', '025177881', NULL, '183/23a', 'Tân Hòa Đông', '14', '6', 'Hồ Chí Minh', 'Quận 6'),
(1307, 'TÈO', '1989-11-11 00:00:00', 1, 'Công chức', 'KINH', '025177881', '', '11', ' LTK', 'P9', 'TB', 'HCM', 'COOPMARK'),
(1308, 'TÍ', '1960-11-02 00:00:00', 0, 'Học sinh', 'KINH', '025177882', '', '55', 'MAC DINH CHI', '11', '6', 'HO CHI MINH', ' TRUNG HOC'),
(1309, 'LÊ THỊ THANH', '1953-07-17 00:00:00', 1, 'Nhân viên', 'Kinh', '025177881', NULL, '183/23a', 'Tân Hòa Đông', '14', '6', 'Hồ Chí Minh', 'Quận 6');

-- --------------------------------------------------------

INSERT INTO `thuoc` (`id`, `Tenthuoc`, `Taduoc`, `Hamluong`, `Duongdung`, `Dang`) VALUES
(1, 'Adalat LA', NULL, '30mg', NULL, 'Viên'),
(2, 'Adalat LA', NULL, '30mg', 'Uống', 'Viên'),
(3, 'Aprovel', NULL, '150mg', 'Uống', 'viên'),
(4, 'Coversyl', NULL, '10mg', 'Uống', 'viên'),
(5, 'Concor tab', NULL, '5mg', 'Uống', 'viên'),
(6, 'Omazolta', NULL, '20mg', 'Uống', 'viên'),
(7, 'Austriol', NULL, '0.5ug', 'Uống', 'viên');

-- --------------------------------------------------------

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

INSERT INTO `idc` (`id`, `TenIDC`, `Ghichu`) VALUES 
('N18.0', 'Suy thận mạn giai đoạn cuối', NULL), 
('I10', 'Cao huyết áp', NULL),
('E13', 'Đái tháo đường type 2', NULL),
('I02.0', 'Thiếu máu cơ tim', NULL),
('I44.0', 'Block nhĩ thất độ I', NULL),
('I25.2', 'Nhồi máu cơ tim cũ', NULL),
('I48', 'Rung nhĩ và cuồng nhĩ', NULL),
('I50', 'Suy tim', NULL),
('I73', 'Bệnh mạch máu ngoại biên', NULL),
('I84', 'Trĩ', NULL),
('I87.2', 'Suy tĩnh mạch mạn', NULL),
('B18', 'Viêm gan virus mạn', NULL),
('J05.2', 'Viêm phế quản', NULL),
('J20', 'Viêm phế quản cấp', NULL),
('N08.0', 'Nhiễm trùng tiểu', NULL),
('A04', 'Nhiễm trùng đường ruột', NULL),
('E11', 'Không phụ thuộc Insulin', NULL);

-- Table contain contraint ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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

INSERT INTO `ngoaitru` (`id`, `Ngaygiovaovien`, `Benhchinh`, `Benhkemtheo`, `Dieutritu`, `Dieutriden`, `Tinhtrangravien`, `Huongdieutri`, `Bacsikhambenh`, `Bacsidieutri`, `Phieukhambenh_id`) VALUES
(1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3),
(2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4),
(3, NULL, NULL, NULL, NULL, NULL, '0', NULL, NULL, NULL, 5),
(4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6),
(5, '2013-12-23 00:00:00', 'Suy thận mạn giai đoạn cuối', 'tăng huyết ap- đái tháo đường type2', '2013-12-23 00:00:00', NULL, '0', 'Đổi hồ sơ tiếp tục điều trị', 'BS. Nguyễn Thị Kim Phượng', 'BS. Nguyễn Thị Kim Phượng', 9);

-- --------------------------------------------------------

INSERT INTO `noitru` (`id`, `Thoigianvaovien`, `Tructiepvao`, `Vaolanthu`, `Ngaygiovaokhoa`, `Chuyenkhoa`, `Ngaygiochuyenkhoa`, `Chuyenvien`, `Chuyenden`, `Ngaygioravien`, `Loairavien`, `Noichuyenden`, `KKBCapcuu`, `Khivaokhoadieutri`, `Thuthuat`, `Phauthuat`, `Benhchinh`, `Benhkemtheo`, `Taibien`, `Bienchung`, `Ketquadieutri`, `Giaiphaubenh`, `Thoigiantuvong`, `Lydotuvong`, `Nguyennhanchinhtuvong`, `Khamnghiemtuthi`, `Chuandoangiaiphaututhi`, `Diung`, `Matuy`, `Ruoubia`, `Thuocla`, `Thuoclao`, `Khac`, `Tuanhoan`, `Hohap`, `Tieuhoa`, `Thantietnieusinhduc`, `Thankinh`, `Coxuongkhop`, `Taimuihong`, `Ranghammat`, `Mat`, `Noitietdinhduong`, `Tomtatbenhan`, `Tienluong`, `Huongdieutri`, `Phuongphapdieutri`, `BStruongkhoa`, `Bslambenhan`, `BSdieutri`, `Phieukhambenh_id`) VALUES
(1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 6),
(2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7);

-- --------------------------------------------------------

INSERT INTO `phieuxetnghiem` (`id`, `Ngayxetnghiemm`, `Phieukhambenh_id`) VALUES
(1, '2013-12-11 00:00:00', 9),
(2, '2013-12-28 11:15:20', 6);

-- --------------------------------------------------------

INSERT INTO `bacsi` (`id`, `TenBacsi`, `Trinhdo`, `Dienthoai`, `Diachi`, `Namsinh`) VALUES
(1, 'NGUYỄN THỊ KIM PHƯỢNG', NULL, NULL, NULL, NULL),
(2, 'DƯƠNG MINH CƯỜNG', NULL, NULL, NULL, NULL),
(3, 'TRẦN LÝ MỸ CHÂU', NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

INSERT INTO `hoichuan` (`id`, `Thoigianhoichuan`, `Ketluanhoichuan`, `Phieuxetnghiem_id`) VALUES
(1, '2013-12-16 11:00:00', 'Dùng thuốc tạo máu :(Pronivel 2000ui, Mirafo 4000ui, Epocassa 2000ui) liều 12,000ui/tuần. Truyền đạm (Kidmin 7,2%, Celemin Nepro 7%): 2 lần/ tuần)', 1);

-- --------------------------------------------------------

INSERT INTO `bacsi_hoichuan` (`Hoichuan_id`, `Bacsi_id`, `NgaygioHoichuan`) VALUES
(1, 1, '2013-12-23 11:00:00');

-- --------------------------------------------------------

INSERT INTO `toathuoc` (`id`, `Tungay`, `Denngay`, `Loidan`, `Bacsi`, `Phieukhambenh_id`) VALUES
(1, '2013-12-04 00:00:00', '2013-12-16 00:00:00', 'Ăn lạt, hạn chế trái cây, Đo HA hằng ngày', 'BS: Nguyễn Kim Phượng', 9);

-- --------------------------------------------------------

INSERT INTO `toathuoc_thuoc` (`Toathuoc_id`, `Thuoc_id`, `sang`, `trua`, `toi`) VALUES
(1, 1, '2', '1', '1'),
(1, 2, '1', '0', '1'),
(1, 3, '1', '0', '1'),
(1, 4, '1/2', '0', '0'),
(1, 5, '1', '0', '0');

-- --------------------------------------------------------

INSERT INTO `todieutri` (`id`, `Phieukhambenh_id`) VALUES
(2, 5),
(1, 9);

-- --------------------------------------------------------

INSERT INTO `xetnghiem_phieuxetnghiem` (`Xetnghiem_id`, `Phieuxetnghiem_id`, `Thongsoxetnghiem`) VALUES
(16, 1, '32.4%'),
(17, 1, '9.66 g/dl');

-- --------------------------------------------------------

INSERT INTO `ylenh` (`loai`, `id_loai`, `Phieukhambenh_id`, `Mota`) VALUES (1, 2, 9, 'asdasdasd');
























