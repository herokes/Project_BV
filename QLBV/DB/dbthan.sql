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
  `idBenhnhan` INT NOT NULL AUTO_INCREMENT,
  `ten` VARCHAR(45) NULL,
  `gioitinh` TINYINT(1) NULL,
  `Nghenghiep` VARCHAR(45) NULL,
  `Dantoc` VARCHAR(45) NULL,
  `CMND` VARCHAR(12) NULL,
  `Ngoaikieu` VARCHAR(45) NULL,
  `Sonha` VARCHAR(45) NULL,
  `Duong` VARCHAR(45) NULL,
  `Phuong` VARCHAR(45) NULL,
  `Quan` VARCHAR(45) NULL,
  `Thanhpho` VARCHAR(45) NULL,
  `Noilamviec` VARCHAR(45) NULL,
  `Doituong` VARCHAR(45) NULL,
  `BHYTgiatriden` DATETIME NULL,
  `SoBHYT` VARCHAR(45) NULL,
  `Nguoithan` VARCHAR(45) NULL,
  `Dienthoai` INT NULL,
  PRIMARY KEY (`idBenhnhan`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Hosophimanh`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Hosophimanh` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Hosophimanh` (
  `idHosophimanh` INT NOT NULL,
  `ECG` VARCHAR(100) NULL,
  `CT Scanner` VARCHAR(200) NULL,
  `Sieuam` VARCHAR(45) NULL,
  `Xetnghiem` VARCHAR(45) NULL,
  `Khac` VARCHAR(200) NULL,
  PRIMARY KEY (`idHosophimanh`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Benhvien`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Benhvien` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Benhvien` (
  `idBenhvien` INT NOT NULL,
  `Tenbenhvien` VARCHAR(45) NULL,
  `Ghichu` VARCHAR(200) NULL,
  PRIMARY KEY (`idBenhvien`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Phieukhambenh`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Phieukhambenh` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Phieukhambenh` (
  `idPhieukhambenh` INT NOT NULL,
  `Thoigiandenkham` DATETIME NULL,
  `Noigioithieu` VARCHAR(45) NULL,
  `Lydovaovien` VARCHAR(200) NULL,
  `Quatrinhbenhly` VARCHAR(200) NULL,
  `Tiensubenh` VARCHAR(200) NULL,
  `Mach` VARCHAR(45) NULL,
  `Nhietdo` VARCHAR(45) NULL,
  `Huyetap` VARCHAR(45) NULL,
  `Nhiptho` VARCHAR(45) NULL,
  `Trongluong` VARCHAR(45) NULL,
  `Toanthan` VARCHAR(200) NULL,
  `Cacbophan` VARCHAR(200) NULL,
  `Tomtatketqualamsan` VARCHAR(200) NULL,
  `Chuandoanvaovien` VARCHAR(200) NULL,
  `Xuli` VARCHAR(200) NULL,
  `Dieutritaikhoa` VARCHAR(45) NULL,
  `Chuy` VARCHAR(200) NULL,
  `Benhnhan_idBenhnhan` INT NOT NULL,
  `Hosophimanh_idHosophimanh` INT NOT NULL,
  `Benhvien_idBenhvien` INT NOT NULL,
  PRIMARY KEY (`idPhieukhambenh`),
  INDEX `fk_Phieukhambenh_Benhnhan1` (`Benhnhan_idBenhnhan` ASC),
  INDEX `fk_Phieukhambenh_Hosophimanh1` (`Hosophimanh_idHosophimanh` ASC),
  INDEX `fk_Phieukhambenh_Benhvien1` (`Benhvien_idBenhvien` ASC),
  CONSTRAINT `fk_Phieukhambenh_Benhnhan1`
    FOREIGN KEY (`Benhnhan_idBenhnhan`)
    REFERENCES `dbthan`.`Benhnhan` (`idBenhnhan`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Phieukhambenh_Hosophimanh1`
    FOREIGN KEY (`Hosophimanh_idHosophimanh`)
    REFERENCES `dbthan`.`Hosophimanh` (`idHosophimanh`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Phieukhambenh_Benhvien1`
    FOREIGN KEY (`Benhvien_idBenhvien`)
    REFERENCES `dbthan`.`Benhvien` (`idBenhvien`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Ngoaitru`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Ngoaitru` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Ngoaitru` (
  `idNgoaitru` INT NOT NULL,
  `Ngaygiovaovien` DATETIME NULL,
  `Benhchinh` VARCHAR(200) NULL,
  `Benhkemtheo` VARCHAR(45) NULL,
  `Dieutritu` DATETIME NULL,
  `Dieutriden` DATETIME NULL,
  `Tinhtrangravien` VARCHAR(45) NULL,
  `Huongdieutri` VARCHAR(45) NULL,
  `Bacsikhambenh` VARCHAR(45) NULL,
  `Bacsidieutri` VARCHAR(45) NULL,
  `chaythan` TINYINT(1) NULL,
  `Phieukhambenh_idPhieukhambenh` INT NOT NULL,
  PRIMARY KEY (`idNgoaitru`),
  INDEX `fk_Ngoaitru_Phieukhambenh1` (`Phieukhambenh_idPhieukhambenh` ASC),
  CONSTRAINT `fk_Ngoaitru_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`)
    REFERENCES `dbthan`.`Phieukhambenh` (`idPhieukhambenh`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Bacsi`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Bacsi` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Bacsi` (
  `idBacsi` INT NOT NULL,
  `TenBacsi` VARCHAR(45) NULL,
  `Trinhdo` VARCHAR(45) NULL,
  `Dienthoai` VARCHAR(45) NULL,
  `Diachi` VARCHAR(45) NULL,
  `Namsinh` DATETIME NULL,
  PRIMARY KEY (`idBacsi`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Thuoc`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Thuoc` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Thuoc` (
  `idThuoc` INT NOT NULL,
  `Tenthuoc` VARCHAR(45) NULL,
  `Taduoc` VARCHAR(45) NULL,
  `Hamluong` VARCHAR(45) NULL,
  `Duongdung` VARCHAR(45) NULL,
  `Dang` VARCHAR(45) NULL,
  `Soluong` INT NULL,
  PRIMARY KEY (`idThuoc`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Hoichuan`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Hoichuan` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Hoichuan` (
  `idHoichuan` INT NOT NULL,
  `ThoigianHoichuan` DATETIME NULL,
  `Ketluanhoichuan` VARCHAR(200) NULL,
  PRIMARY KEY (`idHoichuan`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Xetnghiem`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Xetnghiem` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Xetnghiem` (
  `idXetnghiem` INT NOT NULL,
  `Glucose` VARCHAR(45) NULL,
  `HbA1C` VARCHAR(45) NULL,
  `Urea` VARCHAR(45) NULL,
  `Creatinin` VARCHAR(45) NULL,
  `SGOT` VARCHAR(45) NULL,
  `SGPT` VARCHAR(45) NULL,
  `GGT` VARCHAR(45) NULL,
  `Triglycerides` VARCHAR(45) NULL,
  `HDL-C` VARCHAR(45) NULL,
  `LDL-C` VARCHAR(45) NULL,
  `K+/ISE` VARCHAR(45) NULL,
  `Ca++/ISE` VARCHAR(45) NULL,
  `CRP` VARCHAR(45) NULL,
  `Albumin` VARCHAR(45) NULL,
  `TC` VARCHAR(45) NULL,
  `Hct` VARCHAR(45) NULL,
  `Hb` VARCHAR(45) NULL,
  `HeABO` VARCHAR(45) NULL,
  `HeRh` VARCHAR(45) NULL,
  `HBsAg` VARCHAR(45) NULL,
  `AntiHCV` VARCHAR(45) NULL,
  `HIV` VARCHAR(45) NULL,
  `TPTNT` VARCHAR(45) NULL,
  `Khac` VARCHAR(200) NULL,
  `Phieukhambenh_idPhieukhambenh` INT NOT NULL,
  `Hoichuan_idHoichuan` INT NOT NULL,
  PRIMARY KEY (`idXetnghiem`),
  INDEX `fk_Xetnghiem_Phieukhambenh1` (`Phieukhambenh_idPhieukhambenh` ASC),
  INDEX `fk_Xetnghiem_Hoichuan1` (`Hoichuan_idHoichuan` ASC),
  CONSTRAINT `fk_Xetnghiem_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`)
    REFERENCES `dbthan`.`Phieukhambenh` (`idPhieukhambenh`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Xetnghiem_Hoichuan1`
    FOREIGN KEY (`Hoichuan_idHoichuan`)
    REFERENCES `dbthan`.`Hoichuan` (`idHoichuan`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Xutri`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Xutri` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Xutri` (
  `idXutri` INT NOT NULL,
  `Tenxutri` VARCHAR(45) NULL,
  PRIMARY KEY (`idXutri`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Noitru`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Noitru` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Noitru` (
  `idNoitru` INT NOT NULL,
  `Thoigianvaovien` DATETIME NULL,
  `Tructiepvao` VARCHAR(45) NULL,
  `Vaolanthu` VARCHAR(45) NULL,
  `Ngaygiovaokhoa` DATETIME NULL,
  `Chuyenkhoa` VARCHAR(45) NULL,
  `Ngaygiochuyenkhoa` DATETIME NULL,
  `Chuyenvien` VARCHAR(45) NULL,
  `Chuyenden` VARCHAR(45) NULL,
  `Ngaygioravien` DATETIME NULL,
  `Loairavien` VARCHAR(45) NULL,
  `Noichuyenden` VARCHAR(45) NULL,
  `KKBCapcuu` VARCHAR(45) NULL,
  `Khivaokhoadieutri` VARCHAR(45) NULL,
  `Thuthuat` TINYINT(1) NULL,
  `Phauthuat` TINYINT(1) NULL,
  `Benhchinh` VARCHAR(45) NULL,
  `Benhkemtheo` VARCHAR(45) NULL,
  `Taibien` TINYINT(1) NULL,
  `Bienchung` TINYINT(1) NULL,
  `Ketquadieutri` VARCHAR(45) NULL,
  `Giaiphaubenh` VARCHAR(45) NULL,
  `Thoigiantuvong` DATETIME NULL,
  `Lydotuvong` VARCHAR(45) NULL,
  `Nguyennhanchinhtuvong` VARCHAR(45) NULL,
  `Khamnghiemtuthi` TINYINT(1) NULL,
  `Chuandoangiaiphaututhi` VARCHAR(45) NULL,
  `Diung` VARCHAR(45) NULL,
  `Matuy` VARCHAR(45) NULL,
  `Ruoubia` VARCHAR(45) NULL,
  `Thuocla` VARCHAR(45) NULL,
  `Thuoclao` VARCHAR(45) NULL,
  `Khac` VARCHAR(45) NULL,
  `Tuanhoan` VARCHAR(45) NULL,
  `Hohap` VARCHAR(45) NULL,
  `Tieuhoa` VARCHAR(45) NULL,
  `Thantietnieusinhduc` VARCHAR(45) NULL,
  `Thankinh` VARCHAR(45) NULL,
  `Coxuongkhop` VARCHAR(45) NULL,
  `Taimuihong` VARCHAR(45) NULL,
  `Ranghammat` VARCHAR(45) NULL,
  `Mat` VARCHAR(45) NULL,
  `Noitietdinhduong` VARCHAR(45) NULL,
  `Tomtatbenhan` VARCHAR(200) NULL,
  `Tienluong` VARCHAR(45) NULL,
  `Huongdieutri` VARCHAR(45) NULL,
  `Phuongphapdieutri` VARCHAR(45) NULL,
  `BStruongkhoa` VARCHAR(45) NULL,
  `Bslambenhan` VARCHAR(45) NULL,
  `BSdieutri` VARCHAR(45) NULL,
  `Phieukhambenh_idPhieukhambenh` INT NOT NULL,
  PRIMARY KEY (`idNoitru`),
  INDEX `fk_Noitru_Phieukhambenh1` (`Phieukhambenh_idPhieukhambenh` ASC),
  CONSTRAINT `fk_Noitru_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`)
    REFERENCES `dbthan`.`Phieukhambenh` (`idPhieukhambenh`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`IDC`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`IDC` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`IDC` (
  `idIDC` VARCHAR(10) NOT NULL,
  `TenIDC` VARCHAR(100) NULL,
  `Ghichu` VARCHAR(200) NULL,
  PRIMARY KEY (`idIDC`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Lanhthuoc`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Lanhthuoc` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Lanhthuoc` (
  `Phieukhambenh_idPhieukhambenh` INT NOT NULL,
  `Thuoc_idThuoc` INT NOT NULL,
  `Tungay` DATETIME NULL,
  `Denngay` DATETIME NULL,
  `Sang` VARCHAR(45) NULL,
  `Trua` VARCHAR(45) NULL,
  `Toi` VARCHAR(45) NULL,
  `Loidan` VARCHAR(100) NULL,
  `Bacsi` VARCHAR(45) NULL,
  PRIMARY KEY (`Phieukhambenh_idPhieukhambenh`, `Thuoc_idThuoc`),
  INDEX `fk_Phieukhambenh_has_Thuoc_Thuoc1` (`Thuoc_idThuoc` ASC),
  INDEX `fk_Phieukhambenh_has_Thuoc_Phieukhambenh` (`Phieukhambenh_idPhieukhambenh` ASC),
  CONSTRAINT `fk_Phieukhambenh_has_Thuoc_Phieukhambenh`
    FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`)
    REFERENCES `dbthan`.`Phieukhambenh` (`idPhieukhambenh`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Phieukhambenh_has_Thuoc_Thuoc1`
    FOREIGN KEY (`Thuoc_idThuoc`)
    REFERENCES `dbthan`.`Thuoc` (`idThuoc`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Phieukhambenh_Bacsi`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Phieukhambenh_Bacsi` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Phieukhambenh_Bacsi` (
  `Phieukhambenh_idPhieukhambenh` INT NOT NULL,
  `Bacsi_idBacsi` INT NOT NULL,
  PRIMARY KEY (`Phieukhambenh_idPhieukhambenh`, `Bacsi_idBacsi`),
  INDEX `fk_Phieukhambenh_has_Bacsi_Bacsi1` (`Bacsi_idBacsi` ASC),
  INDEX `fk_Phieukhambenh_has_Bacsi_Phieukhambenh1` (`Phieukhambenh_idPhieukhambenh` ASC),
  CONSTRAINT `fk_Phieukhambenh_has_Bacsi_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`)
    REFERENCES `dbthan`.`Phieukhambenh` (`idPhieukhambenh`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Phieukhambenh_has_Bacsi_Bacsi1`
    FOREIGN KEY (`Bacsi_idBacsi`)
    REFERENCES `dbthan`.`Bacsi` (`idBacsi`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Bacsi_Hoichuan`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Bacsi_Hoichuan` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Bacsi_Hoichuan` (
  `Bacsi_idBacsi` INT NOT NULL,
  `Hoichuan_idHoichuan` INT NOT NULL,
  `NgaygioHoichuan` DATETIME NULL,
  PRIMARY KEY (`Bacsi_idBacsi`, `Hoichuan_idHoichuan`),
  INDEX `fk_Bacsi_has_Hoichuan_Hoichuan1` (`Hoichuan_idHoichuan` ASC),
  INDEX `fk_Bacsi_has_Hoichuan_Bacsi1` (`Bacsi_idBacsi` ASC),
  CONSTRAINT `fk_Bacsi_has_Hoichuan_Bacsi1`
    FOREIGN KEY (`Bacsi_idBacsi`)
    REFERENCES `dbthan`.`Bacsi` (`idBacsi`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Bacsi_has_Hoichuan_Hoichuan1`
    FOREIGN KEY (`Hoichuan_idHoichuan`)
    REFERENCES `dbthan`.`Hoichuan` (`idHoichuan`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`Phieukhambenh_Xutri`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`Phieukhambenh_Xutri` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`Phieukhambenh_Xutri` (
  `Phieukhambenh_idPhieukhambenh` INT NOT NULL,
  `Xutri_idXutri` INT NOT NULL,
  `Ngaygioxutri` DATETIME NULL,
  PRIMARY KEY (`Phieukhambenh_idPhieukhambenh`, `Xutri_idXutri`),
  INDEX `fk_Phieukhambenh_has_Xutri_Xutri1_idx` (`Xutri_idXutri` ASC),
  INDEX `fk_Phieukhambenh_has_Xutri_Phieukhambenh1_idx` (`Phieukhambenh_idPhieukhambenh` ASC),
  CONSTRAINT `fk_Phieukhambenh_has_Xutri_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`)
    REFERENCES `dbthan`.`Phieukhambenh` (`idPhieukhambenh`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Phieukhambenh_has_Xutri_Xutri1`
    FOREIGN KEY (`Xutri_idXutri`)
    REFERENCES `dbthan`.`Xutri` (`idXutri`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `dbthan`.`IDC_Phieukhambenh`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `dbthan`.`IDC_Phieukhambenh` ;

CREATE TABLE IF NOT EXISTS `dbthan`.`IDC_Phieukhambenh` (
  `IDC_idIDC` VARCHAR(10) NOT NULL,
  `Phieukhambenh_idPhieukhambenh` INT NOT NULL,
  PRIMARY KEY (`IDC_idIDC`, `Phieukhambenh_idPhieukhambenh`),
  INDEX `fk_IDC_has_Phieukhambenh_Phieukhambenh1` (`Phieukhambenh_idPhieukhambenh` ASC),
  INDEX `fk_IDC_has_Phieukhambenh_IDC1` (`IDC_idIDC` ASC),
  CONSTRAINT `fk_IDC_has_Phieukhambenh_IDC1`
    FOREIGN KEY (`IDC_idIDC`)
    REFERENCES `dbthan`.`IDC` (`idIDC`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_IDC_has_Phieukhambenh_Phieukhambenh1`
    FOREIGN KEY (`Phieukhambenh_idPhieukhambenh`)
    REFERENCES `dbthan`.`Phieukhambenh` (`idPhieukhambenh`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
