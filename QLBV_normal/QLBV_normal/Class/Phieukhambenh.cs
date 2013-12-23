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
            set { _IdBenhnhan = value; }
            get { return IdBenhnhan; }
        }
        private String _Ten;
        public String Ten
        {
            set { _Ten = value; }
            get { return _Ten; }
        }
        private Boolean _Gioitinh;
        public Boolean Gioitinh
        {
            set { _Gioitinh = value; }
            get { return _Gioitinh; }
        }
        private String _Nghenghiep;
        public String ten
        {
            set { _Nghenghiep = value; }
            get { return _Nghenghiep; }
        }
        private String _Dantoc;
        public String Dantoc
        {
            set { _Dantoc = value; }
            get { return _Dantoc; }
        }
        private String _CMND;
        public String CMND
        {
            set { _CMND = value ; }
            get { return _CMND; }
        }
        private String _Ngoaikieu;
        public String Ngoaikieu
        {
            set { _Ngoaikieu = value; }
            get { return _Ngoaikieu; }
        }
        private String _Sonha;
        public String Sonha
        {
            set { _Sonha = value; }
            get { return _Sonha; }
        }
        private String _Duong;
        public String Duong
        {
            set { _Duong = value; }
            get { return _Duong; }
        }
        private String _Phuong;
        public String Phuong
        {
            set { _Phuong = value; }
            get { return _Phuong; }
        }
        private String _Quan;
        public String Quan
        {
            set { _Quan = value; }
            get { return _Quan; }
        }
        private String _Thanhpho;
        public String Thanhpho
        {
            set { _Thanhpho = value; }
            get { return _Thanhpho; }
        }
        private String _Noilamviec;
        public String Noilamviec
        {
            set { _Noilamviec = value; }
            get { return _Noilamviec; }
        }
        private String _Doituong;
        public String Doituong
        {
            set { _Doituong = value; }
            get { return _Doituong; }
        }
        private DateTime _BHYTgiatriden;
        public DateTime BYYTgiatriden
        {
            set { _BHYTgiatriden = value; }
            get { return _BHYTgiatriden; }
        }
        private String _SoBHYT;
        public String SoBHYT
        {
            set { _SoBHYT = value; }
            get { return _SoBHYT; }
        }
        private String _Nguoithan;
        public String Nguoithan
        {
            set { _Nguoithan = value; }
            get { return _Nguoithan; }
        }
        private int _Dienthoai;
        public int Dienthoai
        {
            set { _Dienthoai = value; }
            get { return _Dienthoai; }
        }

        public Phieukhambenh()
        { 
          
        }
        public Phieukhambenh(int idBenhnhan,String ten, Boolean gioitinh, String nghenghiep, String dantoc, String cmnd, String ngoaikieu, String sonha, String duong, String phuong, String quan,String thanhpho, String noilamviec, String doituong, DateTime bhytgiatriden,String sobhyt , String nguoithan, int dienthoai )
        {
            _IdBenhnhan = idBenhnhan;
            _Ten = ten;
            _Gioitinh = gioitinh;
            _Nghenghiep = nghenghiep;
            _Dantoc = dantoc;
            _CMND = cmnd;
            _Ngoaikieu = ngoaikieu;
            _Sonha = sonha;
            _Duong = duong;
            _Phuong = phuong;
            _Quan = quan;
            _Thanhpho = thanhpho;
            _Noilamviec = noilamviec;
            _Doituong = doituong;
            _BHYTgiatriden = bhytgiatriden;
            _SoBHYT = sobhyt;
            _Nguoithan = nguoithan;
            _Dienthoai = dienthoai;
        }
    }
}
