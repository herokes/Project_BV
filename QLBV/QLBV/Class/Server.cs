﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV
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
            this.hostname = "localhost";
            this.username = "root";
            this.password = "";
            this.database = "dbthan";
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
