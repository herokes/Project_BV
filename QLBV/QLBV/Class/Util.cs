using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using MySql.Data.MySqlClient;

namespace QLBV.Class
{
    class Util
    {
        public MySqlConnection con;

        public bool connect(Server server)
        { 
            try
            {
                string strCon = "server=" + server.Hostname + ";User Id=" + server.Username + ";Persist Security Info=True;database=" +  server.Database;
                con = new MySqlConnection(strCon);
                con.Open();
                con.Close();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }
            
        public void saveList(ArrayList arrList, string To_filepath)
        {
            FileStream fs = new FileStream(To_filepath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, arrList);
            fs.Close();
        }

        public ArrayList openList(string filepath)
        {
            ArrayList arrList = new ArrayList();
            try
            {
                FileStream fs = new FileStream(filepath, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                arrList = (ArrayList)bf.Deserialize(fs);
                fs.Close();
            }
            catch (FileNotFoundException)
            {
                this.saveList(arrList, filepath);
            }
            return arrList;
        }
    }
}
