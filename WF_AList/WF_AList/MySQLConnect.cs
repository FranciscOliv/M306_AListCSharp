﻿/// \ file MySqlConnect.cs
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
    }
}







