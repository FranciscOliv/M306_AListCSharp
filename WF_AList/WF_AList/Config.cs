using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_AList
{
    public class Config
    {
        const string server = "hibou.lab.ecinf.ch"; //Renseigner
        const string database = "dbalist"; //Renseigner
        const string uid = "alist"; //Renseigner
        const string password = "j*u(5GRp92";    //Renseigner        
        const string port = "3307";
        private static bool _isLogged = false;
        private const int img_width = 215;
        private const int img_height = 320;


        public static string Server => server;

        public static string Database => database;

        public static string Uid => uid;

        public static string Password => password;        

        public static bool IsLogged { get => _isLogged; set => _isLogged = value; }

        public static int Img_width => img_width;

        public static int Img_height => img_height;

        public static string Port => port;
    }
}
