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
            server = "localhost"; //Renseigner
            database = "dbalist"; //Renseigner
            uid = "admin";	//Renseigner
            password = "Super2012";	//Renseigner
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

        public string insertAnime(string nameParam,  DateTime addDateParam,  byte[] coverParam, string descriptionParam)
        {
          //  string query = "INSERT INTO `yugioh`.`card` (`NAME`, `ATTRIBUTE`, `LEVEL`, `MONSTER_TYPE`, `CARD_TYPE`, `ATK`, `DEF`, `TEXT`, `CARD_IMG`) VALUES (@name, @attribute, @level, @monsterType, @cardType, @atk, @def,@text, @cardImg);";
            string query = "INSERT INTO `dbalist`.`t_anime` (`name`,`addDate`, `cover`, `description` ) VALUES (@name, @addDate, @cover, @description);";

            try
            {
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                                       
                    cmd.Parameters.AddWithValue("@name", nameParam);
                    cmd.Parameters.AddWithValue("@addDate", addDateParam);                    
                    cmd.Parameters.AddWithValue("@cover", coverParam);
                    cmd.Parameters.AddWithValue("@description", descriptionParam);


                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }

                return "Votre anime a bien été ajouté";
            }
            catch (Exception ex)
            {
                return  "Une erreur est survenue" + ex ;
            }
        }


    }


}

