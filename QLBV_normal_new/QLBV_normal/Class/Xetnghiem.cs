using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_normal.Class
{
    class Xetnghiem
    {
        private int _Id;
        public int Id
        {
            set { this._Id = value; }
            get { return this._Id; }
        }

        private string _Ten;
        public string Ten
        {
            set { this._Ten = value; }
            get { return this._Ten; }
        }

        private string _Thongsobinhthuong;
        public string Thongsobinhthuong
        {
            set { this._Thongsobinhthuong = value; }
            get { return this._Thongsobinhthuong; }
        }

        private string _Thongsoxetnghiem;
        public string Thongsoxetnghiem
        {
            set { this._Thongsoxetnghiem = value; }
            get { return this._Thongsoxetnghiem; }
        }

        private string _Loaixetnghiem;
        public string Loaixetnghiem
        {
            set { this._Loaixetnghiem = value; }
            get { return this._Loaixetnghiem; }
        }

        private int _Macdinh;
        public int Macdinh
        {
            set { this._Macdinh = value; }
            get { return this._Macdinh; }
        }
        
        private string _Donvi;
        public string Donvi
        {
            set { this._Donvi = value; }
            get { return this._Donvi; }
        }

        public  Xetnghiem ()
        {
            _Id = 0;
            _Ten = "";
            Thongsobinhthuong = "";
            _Loaixetnghiem = "";
            _Macdinh = 0;
            _Donvi = "";

        }
    }
}
