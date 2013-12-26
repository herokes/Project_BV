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
        private int _sogiuong;
        private int _buong;
        private string _chandoan;
        private DateTime _ngaygio;
        private string _dientienbenh;
        private string _ylenh;

        public Todieutri()
        {
            _tenbenhnhan = "GOOD";
            _ngaysinh = DateTime.Now;
            _sogiuong = 0;
            _buong = 0;
            _chandoan = "";
            _ngaygio = DateTime.Now;
            _dientienbenh = "asfdasdsadasdnasdasdasdasdasdnas dasdasdasdasdasdnasdasdas dasdasdasdasdasd";
            _ylenh = "";
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
        public int Sogiuong
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
        public int Buong
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
    }
}
