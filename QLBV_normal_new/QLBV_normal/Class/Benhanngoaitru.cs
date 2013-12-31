using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_normal.Class
{
    public class Benhanngoaitru
    {
        private string _tenbenhnhan;
        private DateTime _ngaysinh;
        private int _tuoi;
        private int _gioitinh;
        private string _nghenghiep;
        private string _dantoc;
        private string _ngoaikieu;
        private string _sonha;
        private string _duong;
        private string _phuong;
        private string _quan;
        private string _thanhpho;
        private string _noilamviec;
        private int _doituong;
        private string _dkkcbbd;
        private string _bhytgiatritu;
        private string _bhytgiatriden;
        private string _sobhyt;
        private string _nguoithan;
        private string _diachinguoithan;
        private string _dienthoai;
        private string _thoigiandenkham;
        private string _noigioithieu;
        private string _lydovaovien;
        private string _quatrinhbenhly;
        private string _tiensubenhbanthan;
        private string _tiensubenhgiadinh;
        private string _mach;
        private string _nhietdo;
        private string _huyetap;
        private string _nhiptho;
        private string _trongluong;
        private string _toanthan;
        private string _cacbophan;
        private string _tomtatketqualamsan;
        private string _chuandoanvaovien;
        private string _xuli;
        private string _dieutritaikhoa;
        private string _chuy;
        private DateTime _Dieutritu;
        private DateTime _Dieutriden;
        private String _Bacsikham;

        public Benhanngoaitru()
        {
            _tenbenhnhan = "";
            _ngaysinh = DateTime.Today;
            _tuoi = 0;
            _gioitinh = 0;
            _nghenghiep = "";
            _dantoc = "";
            _ngoaikieu = "";
            _sonha = "";
            _duong = "";
            _phuong = "";
            _quan = "";
            _thanhpho = "";
            _noilamviec = "";
            _doituong = 0;
            _bhytgiatritu = "";
            _sobhyt = "";
            _nguoithan = "";
            _diachinguoithan = "";
            _dienthoai = "";
            _thoigiandenkham = "";
            _noigioithieu = "";
            _lydovaovien = "";
            _quatrinhbenhly = "";
            _tiensubenhbanthan = "";
            _tiensubenhgiadinh = "";
            _mach = "";
            _nhietdo = "";
            _huyetap = "";
            _nhiptho = "";
            _trongluong = "";
            _toanthan = "";
            _cacbophan = "";
            _tomtatketqualamsan = "";
            _chuandoanvaovien = "";
            _xuli = "";
            _dieutritaikhoa = "";
            _chuy = "";

        }
        private string _Ngay1;
        public string Ngay1
        {
            set { _Ngay1 = value; }
            get { return _Ngay1; }
        }
        private string _Ngay2;
        public string Ngay2
        {
            set { _Ngay2 = value; }
            get { return _Ngay2; }
        }
        private string _Thang1;
        public string Thang1
        {
            set { _Thang1 = value; }
            get { return _Thang1; }
        }private string _Thang2;
        public string Thang2
        {
            set { _Thang2 = value; }
            get { return _Thang2; }
        }
        private string _Nam1;
        public string Nam1
        {
            set { _Nam1 = value; }
            get { return _Nam1; }
        }
        private string _Nam2;
        public string Nam2
        {
            set { _Nam2 = value; }
            get { return _Nam2; }
        }
        private string _Nam3;
        public string Nam3
        {
            set { _Nam3 = value; }
            get { return _Nam3; }
        }
        private string _Nam4;
        public string Nam4
        {
            set { _Nam4 = value; }
            get { return _Nam4; }
        }

        public string Tenbenhnhan
        {
            get
            {
                return this._tenbenhnhan;
            }
            set
            {
                this._tenbenhnhan = value;
            }
        }
        public DateTime Ngaysinh
        {
            get
            {
                return this._ngaysinh;
            }
            set
            {
                this._ngaysinh = value;
            }
        }
        public int Tuoi
        {
            get
            {
                return this._tuoi;
            }
            set
            {
                this._tuoi = value;
            }
        }
        public int Gioitinh
        {
            get
            {
                return this._gioitinh;
            }
            set
            {
                this._gioitinh = value;
            }
        }
        public string Nghenghiep
        {
            get
            {
                return this._nghenghiep;
            }
            set
            {
                this._nghenghiep = value;
            }
        }
        public string Dantoc
        {
            get
            {
                return this._dantoc;
            }
            set
            {
                this._dantoc = value;
            }
        }
        public string Ngoaikieu
        {
            get
            {
                return this._ngoaikieu;
            }
            set
            {
                this._ngoaikieu = value;
            }
        }
        public string Sonha
        {
            get
            {
                return this._sonha;
            }
            set
            {
                this._sonha = value;
            }
        }
        public string Duong
        {
            get
            {
                return this._duong;
            }
            set
            {
                this._duong = value;
            }
        }
        public string Phuong
        {
            get
            {
                return this._phuong;
            }
            set
            {
                this._phuong = value;
            }
        }
        public string Quan
        {
            get
            {
                return this._quan;
            }
            set
            {
                this._quan = value;
            }
        }
        public string Thanhpho
        {
            get
            {
                return this._thanhpho;
            }
            set
            {
                this._thanhpho = value;
            }
        }
        public string Noilamviec
        {
            get
            {
                return this._noilamviec;
            }
            set
            {
                this._noilamviec = value;
            }
        }
        public int Doituong
        {
            get
            {
                return this._doituong;
            }
            set
            {
                this._doituong = value;
            }
        }
        public string Dkkcbbd
        {
            get
            {
                return this._dkkcbbd;
            }
            set
            {
                this._dkkcbbd = value;
            }
        }
        public string Bhytgiatritu
        {
            get
            {
                return this._bhytgiatritu;
            }
            set
            {
                this._bhytgiatritu = value;
            }
        }
        public string Bhytgiatriden
        {
            get
            {
                return this._bhytgiatriden;
            }
            set
            {
                this._bhytgiatriden = value;
            }
        }
        public string Sobhyt
        {
            get
            {
                return this._sobhyt;
            }
            set
            {
                this._sobhyt = value;
            }
        }
        public string Nguoithan
        {
            get
            {
                return this._nguoithan;
            }
            set
            {
                this._nguoithan = value;
            }
        }
        public string Diachinguoithan
        {
            get
            {
                return this._diachinguoithan;
            }
            set
            {
                this._diachinguoithan = value;
            }
        }
        public string Dienthoai
        {
            get
            {
                return this._dienthoai;
            }
            set
            {
                this._dienthoai = value;
            }
        }
        public string Thoigiandenkham
        {
            get
            {
                return this._thoigiandenkham;
            }
            set
            {
                this._thoigiandenkham = value;
            }
        }
        public string Noigioithieu
        {
            get
            {
                return this._noigioithieu;
            }
            set
            {
                this._noigioithieu = value;
            }
        }
        public string Lydovaovien
        {
            get
            {
                return this._lydovaovien;
            }
            set
            {
                this._lydovaovien = value;
            }
        }
        public string Quatrinhbenhly
        {
            get
            {
                return this._quatrinhbenhly;
            }
            set
            {
                this._quatrinhbenhly = value;
            }
        }
        public string Tiensubenhbanthan
        {
            get
            {
                return this._tiensubenhbanthan;
            }
            set
            {
                this._tiensubenhbanthan = value;
            }
        }
        public string Tiensubenhgiadinh
        {
            get
            {
                return this._tiensubenhgiadinh;
            }
            set
            {
                this._tiensubenhgiadinh = value;
            }
        }
        public string Mach
        {
            get
            {
                return this._mach;
            }
            set
            {
                this._mach = value;
            }
        }
        public string Nhietdo
        {
            get
            {
                return this._nhietdo;
            }
            set
            {
                this._nhietdo = value;
            }
        }
        public string Huyetap
        {
            get
            {
                return this._huyetap;
            }
            set
            {
                this._huyetap = value;
            }
        }
        public string Nhiptho
        {
            get
            {
                return this._nhiptho;
            }
            set
            {
                this._nhiptho = value;
            }
        }
        public string Trongluong
        {
            get
            {
                return this._trongluong;
            }
            set
            {
                this._trongluong = value;
            }
        }
        public string Toanthan
        {
            get
            {
                return this._toanthan;
            }
            set
            {
                this._toanthan = value;
            }
        }
        public string Cacbophan
        {
            get
            {
                return this._cacbophan;
            }
            set
            {
                this._cacbophan = value;
            }
        }
        public string Tomtatketqualamsan
        {
            get
            {
                return this._tomtatketqualamsan;
            }
            set
            {
                this._tomtatketqualamsan = value;
            }
        }
        public string Chuandoanvaovien
        {
            get
            {
                return this._chuandoanvaovien;
            }
            set
            {
                this._chuandoanvaovien = value;
            }
        }
        public string Xuli
        {
            get
            {
                return this._xuli;
            }
            set
            {
                this._xuli = value;
            }
        }
        public string Dieutritaikhoa
        {
            get
            {
                return this._dieutritaikhoa;
            }
            set
            {
                this._dieutritaikhoa = value;
            }
        }
        public string Chuy
        {
            get
            {
                return this._chuy;
            }
            set
            {
                this._chuy = value;
            }
        }
        public DateTime Dieutritu
        {
            get
            {
                return this._Dieutritu;
            }
            set
            {
                this._Dieutritu = value;
            }
        }
        public DateTime Dieutriden
        {
            get
            {
                return this._Dieutriden;
            }
            set
            {
                this._Dieutriden = value;
            }
        }

        public string Bacsikham   
        {
            get
            {
                return this._Bacsikham;
            }
            set
            {
                this._Bacsikham = value;
            }
        }
        
    }
}
