using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QLBV_normal.Class
{
    public class Toathuoc
    {
        private DateTime _tungay;
        private DateTime _denngay;
        private string _tenbenhnhan;
        private DateTime _ngaysinh;
        private int _gioitinh;
        private string _diachi;
        private string _bhyt;
        private DateTime _bhytgiatriden;
        private string _dkkcbbd;
        private string _chandoan;
        private string _loidan;
        private string _bacsi;
        private string _tenthuoc;
        private string _duongdung;
        private string _sang;
        private string _trua;
        private string _toi;
        private double _tongcong;
        private string _dang;

        public Toathuoc()
        {
            _tenbenhnhan = _diachi = _bhyt = _dkkcbbd = _chandoan = _loidan = _bacsi = _tenthuoc = _duongdung = _dang = _sang = _trua = _toi = "";
            _gioitinh = 0;
            _tongcong = 0;
            _tungay = _denngay = _ngaysinh = _bhytgiatriden = DateTime.Now;
        }

        public DateTime Tungay
        {
            get
            {
                return this._tungay;
            }
            set
            {
                this._tungay = value;
            }
        }
        public DateTime Denngay
        {
            get
            {
                return this._denngay;
            }
            set
            {
                this._denngay = value;
            }
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
        public string Diachi
        {
            get
            {
                return this._diachi;
            }
            set
            {
                this._diachi = value;
            }
        }
        public string Bhyt
        {
            get
            {
                return this._bhyt;
            }
            set
            {
                this._bhyt = value;
            }
        }
        public DateTime Bhytgiatriden
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
        public string Chandoan
        {
            get
            {
                return this._chandoan;
            }
            set
            {
                this._chandoan = value;
            }
        }
        public string Loidan
        {
            get
            {
                return this._loidan;
            }
            set
            {
                this._loidan = value;
            }
        }
        public string Bacsi
        {
            get
            {
                return this._bacsi;
            }
            set
            {
                this._bacsi = value;
            }
        }
        public string Tenthuoc
        {
            get
            {
                return this._tenthuoc;
            }
            set
            {
                this._tenthuoc = value;
            }
        }
        public string Duongdung
        {
            get
            {
                return this._duongdung;
            }
            set
            {
                this._duongdung = value;
            }
        }
        public string Sang
        {
            get
            {
                return this._sang;
            }
            set
            {
                this._sang = value;
            }
        }
        public string Trua
        {
            get
            {
                return this._trua;
            }
            set
            {
                this._trua = value;
            }
        }
        public string Toi
        {
            get
            {
                return this._toi;
            }
            set
            {
                this._toi = value;
            }
        }
        public double Tongcong
        {
            get
            {
                return this._tongcong;
            }
            set
            {
                this._tongcong = value;
            }
        }
        public string Dang
        {
            get
            {
                return this._dang;
            }
            set
            {
                this._dang = value;
            }
        }
    }
}
