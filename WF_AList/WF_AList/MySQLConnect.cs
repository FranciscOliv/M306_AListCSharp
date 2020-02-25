/// \ file MySqlConnect.cs
/// \ brief Classe MySQLConnect - Permet la connexion à la base de données
/// \ et d'effectuer des requetes
/// \ author FONSECA DE OLIVEIRA, Francisco Daniel , I.DA-P4B CFPTI
/// \ date 2019.11.28 , FOF , version 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;   //Ajouter la dll pour pouvoir l'utiliser
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace WF_AList
{
    class MySQLConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public object MemoryStream { get; private set; }


        //Constructor
        public MySQLConnect()
        {
            Initialize();
        }

        //PARAMETRES  DE CONNEXION
        private void Initialize()
        {
            server = Config.Server; //Renseigner
            database = Config.Database; //Renseigner
            uid = Config.Uid;	//Renseigner
            password = Config.Password;	//Renseigner
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public string insertAnime(string nameParam, DateTime addDateParam, Bitmap coverParam, string descriptionParam)
        {
            //  string query = "INSERT INTO `yugioh`.`card` (`NAME`, `ATTRIBUTE`, `LEVEL`, `MONSTER_TYPE`, `CARD_TYPE`, `ATK`, `DEF`, `TEXT`, `CARD_IMG`) VALUES (@name, @attribute, @level, @monsterType, @cardType, @atk, @def,@text, @cardImg);";
            string query = "INSERT INTO `dbalist`.`t_anime` (`name`,`addDate`, `cover`, `description` ) VALUES (@name, @addDate, @cover, @description);";
            string coverName = string.Empty;
            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Image params
                    coverName = GenerateRandomString() + ".png";

                    cmd.Parameters.AddWithValue("@name", nameParam);
                    cmd.Parameters.AddWithValue("@addDate", addDateParam);
                    cmd.Parameters.AddWithValue("@cover", coverName);
                    cmd.Parameters.AddWithValue("@description", descriptionParam);


                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
                string path = Config.ServerImgPath + coverName;
                coverParam.Save(@path, ImageFormat.Png);
                return "Votre anime a bien été ajouté";
            }
            catch (Exception ex)
            {
                return "Une erreur est survenue" + ex;
            }
        }
        //Select statement
        public bool userExist(string email)
        {

            try
            {
                string query = "SELECT email FROM dbalist.t_user WHERE email =@email AND activated = 1 AND idRole = 2;";
                string result = string.Empty;
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        result = dataReader["email"].ToString();
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                }

                if (result != string.Empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }


        }

        //Select statement
        public bool pwdVerify(string email, string pwd)
        {

            try
            {
                string query = "SELECT password FROM dbalist.t_user WHERE email =@email AND activated = 1 AND idRole = 2;";
                string result = string.Empty;
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);


                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        result = dataReader["password"].ToString();
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                }                

                if (result == sha1Hash(email + pwd))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private string GenerateRandomString()
        {
            int length = 7;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        private string sha1Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}







