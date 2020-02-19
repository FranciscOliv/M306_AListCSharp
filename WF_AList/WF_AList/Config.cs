using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_AList
{
    public class Config
    {
        const string server = "localhost"; //Renseigner
        const string database = "dbalist"; //Renseigner
        const string uid = "admin"; //Renseigner
        const string password = "Super2012";    //Renseigner
        const string serverImgPath = "F:/ECOLE/CFC/4eme/M306/Exercices/M306_ApplicationCSharp/img/";

        public static string Server => server;

        public static string Database => database;

        public static string Uid => uid;

        public static string Password => password;

        public static string ServerImgPath => serverImgPath;
    }
}
