SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `dbthan` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `dbthan` ;

-- -----------------------------------------------------
-- Table `dbthan`.`Benhnhan`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Benhnhan` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Benhnhan` (
  `id` INT NOT NULL,
  `Ten` VARCHAR(45) NULL DEFAULT NULL,
  `Ngaysinh` DATETIME NULL DEFAULT NULL,
  `Gioitinh` INT NULL,
  `Nghenghiep` VARCHAR(45) NULL DEFAULT NULL,
  `Dantoc` VARCHAR(45) NULL DEFAULT NULL,
  `CMND` VARCHAR(12) NULL DEFAULT NULL,
  `Ngoaikieu` VARCHAR(45) NULL DEFAULT NULL,
  `Sonha` VARCHAR(45) NULL DEFAULT NULL,
  `Duong` VARCHAR(45) NULL DEFAULT NULL,
  `Phuong` VARCHAR(45) NULL DEFAULT NULL,
  `Quan` VARCHAR(45) NULL DEFAULT NULL,
  `Thanhpho` VARCHAR(45) NULL DEFAULT NULL,
  `Noilamviec` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Hosophimanh`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Hosophimanh` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Hosophimanh` (
  `id` INT NOT NULL,
  `loai` VARCHAR(100) NULL DEFAULT NULL,
  `soluong` INT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Benhvien`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Benhvien` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Benhvien` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Tenbenhvien` VARCHAR(45) NULL DEFAULT NULL,
  `Ghichu` VARCHAR(200) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Phieukhambenh`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Phieukhambenh` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Phieukhambenh` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Doituong` INT NULL,
  `DKKCBBD` VARCHAR(45) NULL,
  `Bhytgiatritu` DATETIME NULL,
  `Bhytgiatriden` DATETIME NULL,
  `Sobhyt` VARCHAR(45) NULL,
  `Nguoithan` VARCHAR(45) NULL,
  `Diachinguoithan` VARCHAR(100) NULL,
  `Dienthoai` VARCHAR(45) NULL,
  `Thoigiandenkham` DATETIME NULL DEFAULT NULL,
  `Noigioithieu` VARCHAR(45) NULL DEFAULT NULL,
  `Lydovaovien` VARCHAR(200) NULL DEFAULT NULL,
  `Quatrinhbenhly` VARCHAR(200) NULL DEFAULT NULL,
  `Tiensubenhbanthan` VARCHAR(200) NULL DEFAULT NULL,
  `Tiensubenhgiadinh` VARCHAR(200) NULL,
  `Mach` VARCHAR(45) NULL DEFAULT NULL,
  `Nhietdo` VARCHAR(45) NULL DEFAULT NULL,
  `Huyetap` VARCHAR(45) NULL DEFAULT NULL,
  `Nhiptho` VARCHAR(45) NULL DEFAULT NULL,
  `Trongluong` VARCHAR(45) NULL DEFAULT NULL,
  `Toanthan` VARCHAR(200) NULL DEFAULT NULL,
  `Cacbophan` VARCHAR(200) NULL DEFAULT NULL,
  `Tomtatketqualamsan` VARCHAR(200) NULL DEFAULT NULL,
  `Chuandoanvaovien` VARCHAR(200) NULL DEFAULT NULL,
  `Xuli` VARCHAR(200) NULL DEFAULT NULL,
  `Dieutritaikhoa` VARCHAR(45) NULL DEFAULT NULL,
  `Chuy` VARCHAR(200) NULL DEFAULT NULL,
  `Benhnhan_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Phieukhambenh_Benhnhan1` (`Benhnhan_id` ASC),
  CONSTRAINT `fk_Phieukhambenh_Benhnhan1`
    FOREIGN KEY (`Benhnhan_id`)
    REFERENCES `dbthan`.`Benhnhan` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Ngoaitru`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Ngoaitru` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Ngoaitru` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Ngaygiovaovien` DATETIME NULL DEFAULT NULL,
  `Benhchinh` VARCHAR(200) NULL DEFAULT NULL,
  `Benhkemtheo` VARCHAR(45) NULL DEFAULT NULL,
  `Dieutritu` DATETIME NULL DEFAULT NULL,
  `Dieutriden` DATETIME NULL DEFAULT NULL,
  `Tinhtrangravien` INT NULL DEFAULT NULL,
  `Huongdieutri` VARCHAR(45) NULL DEFAULT NULL,
  `Bacsikhambenh` VARCHAR(45) NULL DEFAULT NULL,
  `Bacsidieutri` VARCHAR(45) NULL DEFAULT NULL,
  `Phieukhambenh_id` INT NOT NULL,
  `Soxquang` INT NULL,
  `Soctscanner` INT NULL,
  `Sosieuam` INT NULL,
  `Soxetnghiem` INT NULL,
  `Sokhac` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Ngoaitru_Phieukhambenh1` (`Phieukhambenh_id` ASC),
  CONSTRAINT `fk_Ngoaitru_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Bacsi`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Bacsi` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Bacsi` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `TenBacsi` VARCHAR(45) NULL DEFAULT NULL,
  `Trinhdo` VARCHAR(45) NULL DEFAULT NULL,
  `Dienthoai` VARCHAR(45) NULL DEFAULT NULL,
  `Diachi` VARCHAR(45) NULL DEFAULT NULL,
  `Namsinh` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Thuoc`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Thuoc` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Thuoc` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Tenthuoc` VARCHAR(45) NULL DEFAULT NULL,
  `Taduoc` VARCHAR(45) NULL DEFAULT NULL,
  `Hamluong` VARCHAR(45) NULL DEFAULT NULL,
  `Duongdung` VARCHAR(45) NULL DEFAULT NULL,
  `Dang` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Phieuxetnghiem`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Phieuxetnghiem` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Phieuxetnghiem` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Ngayxetnghiemm` DATETIME NULL DEFAULT NULL,
  `Phieukhambenh_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Xetnghiem_has_Phieukhambenh_Xetnghiem1` (`id` ASC),
  INDEX `fk_Phieuxetnghiem_Phieukhambenh1` (`Phieukhambenh_id` ASC),
  CONSTRAINT `fk_Phieuxetnghiem_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Hoichuan`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Hoichuan` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Hoichuan` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Thoigianhoichuan` DATETIME NULL DEFAULT NULL,
  `Ketluanhoichuan` VARCHAR(200) NULL DEFAULT NULL,
  `Phieuxetnghiem_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Hoichuan_Phieuxetnghiem1` (`Phieuxetnghiem_id` ASC),
  CONSTRAINT `fk_Hoichuan_Phieuxetnghiem1`
    FOREIGN KEY (`Phieuxetnghiem_id`)
    REFERENCES `dbthan`.`Phieuxetnghiem` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Xetnghiem`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Xetnghiem` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Xetnghiem` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `TenXetnghiem` VARCHAR(45) NULL DEFAULT NULL,
  `Thongsobinhthuong` VARCHAR(45) NULL DEFAULT NULL,
  `Loaixetnghiem` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Xutri`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Xutri` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Xutri` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Tenxutri` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Noitru`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Noitru` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Noitru` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Thoigianvaovien` DATETIME NULL DEFAULT NULL,
  `Tructiepvao` VARCHAR(45) NULL DEFAULT NULL,
  `Vaolanthu` VARCHAR(45) NULL DEFAULT NULL,
  `Ngaygiovaokhoa` DATETIME NULL DEFAULT NULL,
  `Chuyenkhoa` VARCHAR(45) NULL DEFAULT NULL,
  `Ngaygiochuyenkhoa` DATETIME NULL DEFAULT NULL,
  `Chuyenvien` VARCHAR(45) NULL DEFAULT NULL,
  `Chuyenden` VARCHAR(45) NULL DEFAULT NULL,
  `Ngaygioravien` DATETIME NULL DEFAULT NULL,
  `Loairavien` VARCHAR(45) NULL DEFAULT NULL,
  `Noichuyenden` VARCHAR(45) NULL DEFAULT NULL,
  `KKBCapcuu` VARCHAR(45) NULL DEFAULT NULL,
  `Khivaokhoadieutri` VARCHAR(45) NULL DEFAULT NULL,
  `Thuthuat` TINYINT(1) NULL DEFAULT NULL,
  `Phauthuat` TINYINT(1) NULL DEFAULT NULL,
  `Benhchinh` VARCHAR(45) NULL DEFAULT NULL,
  `Benhkemtheo` VARCHAR(45) NULL DEFAULT NULL,
  `Taibien` TINYINT(1) NULL DEFAULT NULL,
  `Bienchung` TINYINT(1) NULL DEFAULT NULL,
  `Ketquadieutri` INT NULL DEFAULT NULL,
  `Giaiphaubenh` VARCHAR(45) NULL DEFAULT NULL,
  `Thoigiantuvong` DATETIME NULL DEFAULT NULL,
  `Lydotuvong` VARCHAR(45) NULL DEFAULT NULL,
  `Nguyennhanchinhtuvong` VARCHAR(45) NULL DEFAULT NULL,
  `Khamnghiemtuthi` TINYINT(1) NULL DEFAULT NULL,
  `Chuandoangiaiphaututhi` VARCHAR(45) NULL DEFAULT NULL,
  `Diung` VARCHAR(45) NULL DEFAULT NULL,
  `Matuy` VARCHAR(45) NULL DEFAULT NULL,
  `Ruoubia` VARCHAR(45) NULL DEFAULT NULL,
  `Thuocla` VARCHAR(45) NULL DEFAULT NULL,
  `Thuoclao` VARCHAR(45) NULL DEFAULT NULL,
  `Khac` VARCHAR(45) NULL DEFAULT NULL,
  `Tuanhoan` VARCHAR(45) NULL DEFAULT NULL,
  `Hohap` VARCHAR(45) NULL DEFAULT NULL,
  `Tieuhoa` VARCHAR(45) NULL DEFAULT NULL,
  `Thantietnieusinhduc` VARCHAR(45) NULL DEFAULT NULL,
  `Thankinh` VARCHAR(45) NULL DEFAULT NULL,
  `Coxuongkhop` VARCHAR(45) NULL DEFAULT NULL,
  `Taimuihong` VARCHAR(45) NULL DEFAULT NULL,
  `Ranghammat` VARCHAR(45) NULL DEFAULT NULL,
  `Mat` VARCHAR(45) NULL DEFAULT NULL,
  `Noitietdinhduong` VARCHAR(45) NULL DEFAULT NULL,
  `Tomtatbenhan` VARCHAR(200) NULL DEFAULT NULL,
  `Tienluong` VARCHAR(45) NULL DEFAULT NULL,
  `Huongdieutri` VARCHAR(45) NULL DEFAULT NULL,
  `Phuongphapdieutri` VARCHAR(45) NULL DEFAULT NULL,
  `BStruongkhoa` VARCHAR(45) NULL DEFAULT NULL,
  `Bslambenhan` VARCHAR(45) NULL DEFAULT NULL,
  `BSdieutri` VARCHAR(45) NULL DEFAULT NULL,
  `Phieukhambenh_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Noitru_Phieukhambenh1` (`Phieukhambenh_id` ASC),
  CONSTRAINT `fk_Noitru_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`IDC`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`IDC` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`IDC` (
  `id` VARCHAR(10) NOT NULL,
  `TenIDC` VARCHAR(100) NULL DEFAULT NULL,
  `Ghichu` VARCHAR(200) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Toathuoc`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Toathuoc` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Toathuoc` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Tungay` DATETIME NULL DEFAULT NULL,
  `Denngay` DATETIME NULL DEFAULT NULL,
  `Loidan` VARCHAR(100) NULL DEFAULT NULL,
  `Bacsi` VARCHAR(45) NULL DEFAULT NULL,
  `Phieukhambenh_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Toathuoc_Phieukhambenh1` (`Phieukhambenh_id` ASC),
  CONSTRAINT `fk_Toathuoc_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Phieukhambenh_Bacsi`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Phieukhambenh_Bacsi` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Phieukhambenh_Bacsi` (
  `Bacsi_id` INT NOT NULL,
  `Phieukhambenh_id` INT NOT NULL,
  PRIMARY KEY (`Bacsi_id`, `Phieukhambenh_id`),
  INDEX `fk_Phieukhambenh_Bacsi_Bacsi1` (`Bacsi_id` ASC),
  INDEX `fk_Phieukhambenh_Bacsi_Phieukhambenh1` (`Phieukhambenh_id` ASC),
  CONSTRAINT `fk_Phieukhambenh_Bacsi_Bacsi1`
    FOREIGN KEY (`Bacsi_id`)
    REFERENCES `dbthan`.`Bacsi` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Phieukhambenh_Bacsi_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Bacsi_Hoichuan`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Bacsi_Hoichuan` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Bacsi_Hoichuan` (
  `Hoichuan_id` INT NOT NULL,
  `Bacsi_id` INT NOT NULL,
  `NgaygioHoichuan` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`Hoichuan_id`, `Bacsi_id`),
  INDEX `fk_Bacsi_Hoichuan_Bacsi1` (`Bacsi_id` ASC),
  INDEX `fk_Bacsi_Hoichuan_Hoichuan1` (`Hoichuan_id` ASC),
  CONSTRAINT `fk_Bacsi_Hoichuan_Bacsi1`
    FOREIGN KEY (`Bacsi_id`)
    REFERENCES `dbthan`.`Bacsi` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Bacsi_Hoichuan_Hoichuan1`
    FOREIGN KEY (`Hoichuan_id`)
    REFERENCES `dbthan`.`Hoichuan` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Phieukhambenh_Xutri`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Phieukhambenh_Xutri` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Phieukhambenh_Xutri` (
  `Phieukhambenh_id` INT NOT NULL,
  `Xutri_id` INT NOT NULL,
  `Ngaygioxutri` DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (`Phieukhambenh_id`, `Xutri_id`),
  INDEX `fk_Phieukhambenh_has_Xutri_Xutri1_idx` (`Xutri_id` ASC),
  INDEX `fk_Phieukhambenh_has_Xutri_Phieukhambenh1_idx` (`Phieukhambenh_id` ASC),
  CONSTRAINT `fk_Phieukhambenh_has_Xutri_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Phieukhambenh_has_Xutri_Xutri1`
    FOREIGN KEY (`Xutri_id`)
    REFERENCES `dbthan`.`Xutri` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Xetnghiem_Phieuxetnghiem`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Xetnghiem_Phieuxetnghiem` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Xetnghiem_Phieuxetnghiem` (
  `Xetnghiem_id` INT NOT NULL,
  `Phieuxetnghiem_id` INT NOT NULL,
  `Thongsoxetnghiem` VARCHAR(45) NULL,
  PRIMARY KEY (`Xetnghiem_id`, `Phieuxetnghiem_id`),
  INDEX `fk_Xetnghiem_has_Phieuxetnghiem_Phieuxetnghiem1` (`Phieuxetnghiem_id` ASC),
  INDEX `fk_Xetnghiem_has_Phieuxetnghiem_Xetnghiem1` (`Xetnghiem_id` ASC),
  CONSTRAINT `fk_Xetnghiem_has_Phieuxetnghiem_Xetnghiem1`
    FOREIGN KEY (`Xetnghiem_id`)
    REFERENCES `dbthan`.`Xetnghiem` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Xetnghiem_has_Phieuxetnghiem_Phieuxetnghiem1`
    FOREIGN KEY (`Phieuxetnghiem_id`)
    REFERENCES `dbthan`.`Phieuxetnghiem` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Toathuoc_Thuoc`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Toathuoc_Thuoc` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Toathuoc_Thuoc` (
  `Toathuoc_id` INT NOT NULL,
  `Thuoc_id` INT NOT NULL,
  `sang` VARCHAR(45) NULL,
  `trua` VARCHAR(45) NULL,
  `toi` VARCHAR(45) NULL,
  `soluong` INT NULL,
  PRIMARY KEY (`Toathuoc_id`, `Thuoc_id`),
  INDEX `fk_Toathuoc_has_Thuoc_Thuoc1` (`Thuoc_id` ASC),
  INDEX `fk_Toathuoc_has_Thuoc_Toathuoc1` (`Toathuoc_id` ASC),
  CONSTRAINT `fk_Toathuoc_has_Thuoc_Toathuoc1`
    FOREIGN KEY (`Toathuoc_id`)
    REFERENCES `dbthan`.`Toathuoc` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Toathuoc_has_Thuoc_Thuoc1`
    FOREIGN KEY (`Thuoc_id`)
    REFERENCES `dbthan`.`Thuoc` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`IDC_Phieukhambenh`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`IDC_Phieukhambenh` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`IDC_Phieukhambenh` (
  `IDC_id` VARCHAR(10) NOT NULL,
  `Phieukhambenh_id` INT NOT NULL,
  PRIMARY KEY (`IDC_id`, `Phieukhambenh_id`),
  INDEX `fk_IDC_has_Phieukhambenh_Phieukhambenh1` (`Phieukhambenh_id` ASC),
  INDEX `fk_IDC_has_Phieukhambenh_IDC1` (`IDC_id` ASC),
  CONSTRAINT `fk_IDC_has_Phieukhambenh_IDC1`
    FOREIGN KEY (`IDC_id`)
    REFERENCES `dbthan`.`IDC` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_IDC_has_Phieukhambenh_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Todieutri`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Todieutri` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Todieutri` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Phieukhambenh_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Todieutri_Phieukhambenh1` (`Phieukhambenh_id` ASC),
  CONSTRAINT `fk_Todieutri_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Ylenh`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Ylenh` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Ylenh` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `loai` INT NULL,
  `id_loai` INT NULL,
  `Phieukhambenh_id` INT NOT NULL,
  `status` INT NULL DEFAULT 1,
  `Mota` TEXT NULL,
  `Bacsi_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Ylenh_Phieukhambenh1_idx` (`Phieukhambenh_id` ASC),
  INDEX `fk_Ylenh_Bacsi1_idx` (`Bacsi_id` ASC),
  CONSTRAINT `fk_Ylenh_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Ylenh_Bacsi1`
    FOREIGN KEY (`Bacsi_id`)
    REFERENCES `dbthan`.`Bacsi` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Todieutri_noidung`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Todieutri_noidung` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Todieutri_noidung` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Dientienbenh` TEXT NULL,
  `Ngaygio` DATETIME NULL,
  `Todieutri_id` INT NOT NULL,
  `Ylenh_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Todieutri_bosung_Todieutri1` (`Todieutri_id` ASC),
  INDEX `fk_Todieutri_noidung_Ylenh1_idx` (`Ylenh_id` ASC),
  CONSTRAINT `fk_Todieutri_bosung_Todieutri1`
    FOREIGN KEY (`Todieutri_id`)
    REFERENCES `dbthan`.`Todieutri` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Todieutri_noidung_Ylenh1`
    FOREIGN KEY (`Ylenh_id`)
    REFERENCES `dbthan`.`Ylenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Hosophimanh_Phieukhambenh`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Hosophimanh_Phieukhambenh` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Hosophimanh_Phieukhambenh` (
  `Hosophimanh_id` INT NOT NULL,
  `Phieukhambenh_id` INT NOT NULL,
  PRIMARY KEY (`Hosophimanh_id`, `Phieukhambenh_id`),
  INDEX `fk_Hosophimanh_has_Phieukhambenh_Phieukhambenh1` (`Phieukhambenh_id` ASC),
  INDEX `fk_Hosophimanh_has_Phieukhambenh_Hosophimanh1` (`Hosophimanh_id` ASC),
  CONSTRAINT `fk_Hosophimanh_has_Phieukhambenh_Hosophimanh1`
    FOREIGN KEY (`Hosophimanh_id`)
    REFERENCES `dbthan`.`Hosophimanh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Hosophimanh_has_Phieukhambenh_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Chaythan`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Chaythan` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Chaythan` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Phieukhambenh_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Chaythan_Phieukhambenh1` (`Phieukhambenh_id` ASC),
  CONSTRAINT `fk_Chaythan_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_id`)
    REFERENCES `dbthan`.`Phieukhambenh` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Chaythan_Thuoc`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Chaythan_Thuoc` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Chaythan_Thuoc` (
  `Chaythan_id` INT NOT NULL,
  `Thuoc_id` INT NOT NULL,
  `Soluong` VARCHAR(45) NULL,
  PRIMARY KEY (`Chaythan_id`, `Thuoc_id`),
  INDEX `fk_Chaythan_has_Thuoc_Thuoc1` (`Thuoc_id` ASC),
  INDEX `fk_Chaythan_has_Thuoc_Chaythan1` (`Chaythan_id` ASC),
  CONSTRAINT `fk_Chaythan_has_Thuoc_Chaythan1`
    FOREIGN KEY (`Chaythan_id`)
    REFERENCES `dbthan`.`Chaythan` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Chaythan_has_Thuoc_Thuoc1`
    FOREIGN KEY (`Thuoc_id`)
    REFERENCES `dbthan`.`Thuoc` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
