using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_normal.Class
{
    public class Benhanngoaitru
    {
        private string _tenbenhnhan;

        public Benhanngoaitru() 
        {
            this._tenbenhnhan = "NGuyễn văn b";

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




    }
}
