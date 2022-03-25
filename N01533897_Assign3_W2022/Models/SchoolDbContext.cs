using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace N01533897_Assign3_W2022.Models
{
    public class SchoolDbContext
    {

        private static string User { get { return "root"; } }
        private static string Password { get { return ""; } }
        private static string Database { get { return "blog"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //Connect to the database with the info gotten above
        protected static string ConnectionString
        {
            get 
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password
                    + "; convert zero datetime = True";
            }
        }

        //Get the connection to the blog database
        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}