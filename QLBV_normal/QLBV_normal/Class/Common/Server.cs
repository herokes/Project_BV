using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBV_normal
{
    [Serializable]
    public class Server
    {
        private string _hostname;
        private string _username;
        private string _password;
        private string _database;

        public Server() 
        {
            this._hostname = "";
            this._username = "";
            this._password = "";
            this._database = "";
        }

        public string Hostname
        {
            get
            {
                return this._hostname;
            }
            set
            {
                this._hostname = value;
            }
        }

        public string Username
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public string Database
        {
            get
            {
                return this._database;
            }
            set
            {
                this._database = value;
            }
        }


    }
}
