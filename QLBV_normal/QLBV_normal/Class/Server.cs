using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_normal
{
    [Serializable]
    public class Server
    {
        private string hostname;
        private string username;
        private string password;
        private string database;

        public Server() 
        {
            this.hostname = "";
            this.username = "";
            this.password = "";
            this.database = "";
        }

        public string Hostname
        {
            get
            {
                return this.hostname;
            }
            set
            {
                this.hostname = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string Database
        {
            get
            {
                return this.database;
            }
            set
            {
                this.database = value;
            }
        }


    }
}
