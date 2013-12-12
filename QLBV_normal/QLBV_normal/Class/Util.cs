using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace QLBV_normal
{
    public class Util
    {
        public static MySqlConnection con;

        public static Hashtable connect(Server server)
        {
            Hashtable info = new Hashtable();
            try
            {
                string strCon = "server=" + server.Hostname + ";User Id=" + server.Username + ";Password=" + server.Password + ";Persist Security Info=True;database=" + server.Database + ";charset=utf8";
                con = new MySqlConnection(strCon);
                con.Open();
                con.Close();
                info.Add("info", server);
                return info;
            }
            catch (MySqlException)
            {
                return info;
            }
        }

        public static void saveList(ArrayList arrList, string To_filepath)
        {
            FileStream fs = new FileStream(To_filepath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, arrList);
            fs.Close();
        }

        public static ArrayList openList(string filepath)
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
                saveList(arrList, filepath);
            }
            return arrList;
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
