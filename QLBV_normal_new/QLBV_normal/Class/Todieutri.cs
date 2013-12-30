using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_normal.Class
{
    public class Todieutri
    {
        private string _tenbenhnhan;
        private DateTime _ngaysinh;
        private string _sogiuong;
        private string _buong;
        private string _chandoan;
        private DateTime _ngaygio;
        private string _dientienbenh;
        private string _ylenh;
        private string _bacsi;

        public Todieutri()
        {
            _tenbenhnhan = "";
            _ngaysinh = DateTime.Now;
            _sogiuong = "";
            _buong = "";
            _chandoan = "";
            _ngaygio = DateTime.Now;
            _dientienbenh = "";
            _ylenh = "";
            _bacsi = "";
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
        public string Sogiuong
        {
            get
            {
                return this._sogiuong;
            }
            set
            {
                this._sogiuong = value;
            }
        }
        public string Buong
        {
            get
            {
                return this._buong;
            }
            set
            {
                this._buong = value;
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
        public DateTime Ngaygio
        {
            get
            {
                return this._ngaygio;
            }
            set
            {
                this._ngaygio = value;
            }
        }
        public string Dientienbenh
        {
            get
            {
                return this._dientienbenh;
            }
            set
            {
                this._dientienbenh = value;
            }
        }
        public string Ylenh
        {
            get
            {
                return this._ylenh;
            }
            set
            {
                this._ylenh = value;
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
    }
}
