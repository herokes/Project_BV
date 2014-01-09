using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_normal.Class
{
    class Bienbanhoichuan
    {
        private string _Mabenhnhan;
        public string Mabenhnhan
        {
            set { _Mabenhnhan = value; }
            get { return _Mabenhnhan; }
        }
        private string _Tenbenhnhan;
        public string Tenbenhnhan
        {
            set { _Tenbenhnhan = value; }
            get { return _Tenbenhnhan; }
        }

        private DateTime _Ngaysinh;
        public DateTime Ngaysinh
        {
            set { _Ngaysinh = value; }
            get { return _Ngaysinh; }
        }
        private bool _Gioitinh;
        public bool Gioitinh
        {
            set { _Gioitinh = value; }
            get { return _Gioitinh; }
        }
        private string _Chuandoan;
        public string Chuandoan
        {
            set { _Chuandoan = value; }
            get { return _Chuandoan; }
        }
        private DateTime _Ngayhoichuan;
        public DateTime Ngayhoichuan
        {
            set { _Ngayhoichuan = value; }
            get { return _Ngayhoichuan; }
        }
        private string _Mucdothieumau;
        public string Mucdothieumau
        {
            set { _Mucdothieumau = value; }
            get { return _Mucdothieumau; }
        }
        private string _Ketquaxetnghiem;
        public string Ketquaxetnghiem
        {
            set { _Ketquaxetnghiem = value; }
            get { return _Ketquaxetnghiem; }
        }
        private string _Ketluanhoichuan;
        public string Ketluanhoichuan
        {
            set { _Ketluanhoichuan = value; }
            get { return _Ketluanhoichuan; }
        }
        private string _Bacsihoichuan;
        public string Bacsihoichuan
        {
            set { _Bacsihoichuan = value; }
            get { return _Bacsihoichuan; }
        }

        public Bienbanhoichuan()
        {
            _Tenbenhnhan = "";
            _Ngaysinh = DateTime.Today;
            _Gioitinh = true;
            _Chuandoan = "";
            _Ngayhoichuan = DateTime.Today;
            _Mucdothieumau = "";
            _Ketquaxetnghiem = "";
            _Ketluanhoichuan = "";
            _Bacsihoichuan = "";

        }
    }
}
