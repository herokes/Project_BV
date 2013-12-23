using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_normal.Class
{
    class Phieukhambenh
    {
        private int _IdBenhnhan;
        public int IdBenhnhan
        {
            set { this._IdBenhnhan = value; }
            get { return this._IdBenhnhan; }
        }
        private string _Ten;
        public string Ten
        {
            set { _Ten = value; }
            get { return _Ten; }
        }
        private DateTime _Ngaysinh;
        public DateTime Ngaysinh
        {
            set { _Ngaysinh = value; }
            get { return _Ngaysinh; }
        }
        private Boolean _Gioitinh;
        public Boolean Gioitinh
        {
            set { _Gioitinh = value; }
            get { return _Gioitinh; }
        }
        private string _Nghenghiep;
        public string Nghenghiep
        {
            set { _Nghenghiep = value; }
            get { return _Nghenghiep; }
        }
        private string _Dantoc;
        public string Dantoc
        {
            set { _Dantoc = value; }
            get { return _Dantoc; }
        }
        private string _CMND;
        public string CMND
        {
            set { _CMND = value ; }
            get { return _CMND; }
        }
        private string _Ngoaikieu;
        public string Ngoaikieu
        {
            set { _Ngoaikieu = value; }
            get { return _Ngoaikieu; }
        }
        private string _Sonha;
        public string Sonha
        {
            set { _Sonha = value; }
            get { return _Sonha; }
        }
        private string _Duong;
        public string Duong
        {
            set { _Duong = value; }
            get { return _Duong; }
        }
        private string _Phuong;
        public string Phuong
        {
            set { _Phuong = value; }
            get { return _Phuong; }
        }
        private string _Quan;
        public string Quan
        {
            set { _Quan = value; }
            get { return _Quan; }
        }
        private string _Thanhpho;
        public string Thanhpho
        {
            set { _Thanhpho = value; }
            get { return _Thanhpho; }
        }
        private string _Noilamviec;
        public string Noilamviec
        {
            set { _Noilamviec = value; }
            get { return _Noilamviec; }
        }
        /// <summary>
        /// phieu kham benh
        /// </summary>
        private int _Doituong;
        public int Doituong
        {
            set { _Doituong = value; }
            get { return _Doituong; }
        }
        private string _DKKCBBD;
        public string DKKCBBD
        {
            set { _DKKCBBD = value; }
            get { return _DKKCBBD; }
        }
        private DateTime _BHYTgiatritu;
        public DateTime BYYTgiatritu
        {
            set { _BHYTgiatritu = value; }
            get { return _BHYTgiatritu; }
        }
        private DateTime _BHYTgiatriden;
        public DateTime BYYTgiatriden
        {
            set { _BHYTgiatriden = value; }
            get { return _BHYTgiatriden; }
        }
        private string _Sobhyt;
        public string Sobhyt
        {
            set { _Sobhyt = value; }
            get { return _Sobhyt; }
        }
        private string _Nguoithan;
        public string Nguoithan
        {
            set { _Nguoithan = value; }
            get { return _Nguoithan; }
        }
        private string _Diachinguoithan;
        public string Diachinguoithan
        {
            set { _Diachinguoithan = value; }
            get { return _Diachinguoithan; }
        }
        private string _Dienthoai;
        public string Dienthoai
        {
            set { _Dienthoai = value; }
            get { return _Dienthoai; }
        }

        private DateTime _Thoigiandenkham;
        public DateTime Thoigiandenkham
        {
            set { _Thoigiandenkham = value; }
            get { return _Thoigiandenkham; }
        }
        private string _Noigioithieu;
        public string Noigioithieu
        {
            set { _Noigioithieu = value; }
            get { return _Noigioithieu; }
        }
        private string _Lydovaovien;
        public string Lydovaovien
        {
            set { _Lydovaovien = value; }
            get { return _Lydovaovien; }
        }
      
        private string _Quatrinhbenhly;
        public string Quatrinhbenhly
        {
            set { _Quatrinhbenhly = value; }
            get { return _Quatrinhbenhly; }
        }
        private string _Tiensubenhbanthan;
        public string Tiensubenhbanthan
        {
            set { _Tiensubenhbanthan = value; }
            get { return _Tiensubenhbanthan; }
        }
        private string _Tiensubenhgiadinh;
        public string Tiensubenhgiadinh
        {
            set { _Tiensubenhgiadinh = value; }
            get { return _Tiensubenhgiadinh; }
        }
        private string _Mach;
        public string Mach
        {
            set { _Mach = value; }
            get { return _Mach; }
        }
        private string _Nhietdo;
        public string Nhietdo
        {
            set { _Nhietdo = value; }
            get { return _Nhietdo; }
        }
        private string _Huyetap;
        public string Huyetap
        {
            set { _Huyetap = value; }
            get { return _Huyetap; }
        }
        private string _Nhiptho;
        public string Nhiptho
        {
            set { _Nhiptho = value; }
            get { return _Nhiptho; }
        }
        private string _Trongluong;
        public string Trongluong
        {
            set { _Trongluong = value; }
            get { return _Trongluong; }
        }
        private string _Toanthan;
        public string Toanthan
        {
            set { _Toanthan = value; }
            get { return _Toanthan; }
        }
        private string _Cacbophan;
        public string Cacbophan
        {
            set { _Cacbophan = value; }
            get { return _Cacbophan; }

        }
        private string _Tomtatketqualamsan;
        public string Tomtatketqualamsan
        {
            set { _Tomtatketqualamsan = value; }
            get { return _Tomtatketqualamsan; }
        }
        private string _Chuandoanvaovien;
        public string Chuandoanvaovien
        {
            set { _Chuandoanvaovien = value; }
            get { return _Chuandoanvaovien; }
        }
        private string _Xuli;
        public string Xuli
        {
            set { _Xuli = value; }
            get { return _Xuli; }
        }
        private string _Dieutritaikhoa;
        public string Dieutritaikhoa
        {
            set { _Dieutritaikhoa = value; }
            get { return _Dieutritaikhoa; }
        }
        private string _Chuy;
        public string Chuy
        {
            set { _Chuy = value; }
            get { return _Chuy; }
        }
        private string _Benhnhan_id;
        public string Benhnhan_id
        {
            set { _Benhnhan_id = value; }
            get { return _Benhnhan_id; }
        }


        public Phieukhambenh()
        { 
          
        }
        //public Phieukhambenh(int idBenhnhan,String ten, Boolean gioitinh, String nghenghiep, String dantoc, String cmnd, String ngoaikieu, String sonha, String duong, String phuong, String quan,String thanhpho, String noilamviec, String doituong, DateTime bhytgiatriden,String sobhyt , String nguoithan, int dienthoai )
        //{
        //    _IdBenhnhan = idBenhnhan;
        //    _Ten = ten;
        //    _Gioitinh = gioitinh;
        //    _Nghenghiep = nghenghiep;
        //    _Dantoc = dantoc;
        //    _CMND = cmnd;
        //    _Ngoaikieu = ngoaikieu;
        //    _Sonha = sonha;
        //    _Duong = duong;
        //    _Phuong = phuong;
        //    _Quan = quan;
        //    _Thanhpho = thanhpho;
        //    _Noilamviec = noilamviec;
        //    _Doituong = doituong;
        //    _BHYTgiatriden = bhytgiatriden;
        //    _SoBHYT = sobhyt;
        //    _Nguoithan = nguoithan;
        //    _Dienthoai = dienthoai;
        //}
    }
}
