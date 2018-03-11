using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elective3Server.Models;

namespace Elective3Server
{
    public class SignupPersistence
    {
        private MySql.Data.MySqlClient.MySqlConnection mySqlConnection;

        
        public SignupPersistence()
        {
            string strMyConnection = "server=localhost;port=3306;uid=root;pwd=abcd;database=elective3server";

            try
            {
                mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection();
                mySqlConnection.ConnectionString = strMyConnection;
                mySqlConnection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
            }



        }


        public long signupUser(Signup signup)
        {

            String insertQuery = "INSERT INTO elective3(email, username, pw) VALUES ('" + signup.email + "',  '" + signup.username + "', '" + signup.password + "');";

            MySql.Data.MySqlClient.MySqlCommand mySqlCommand = new MySql.Data.MySqlClient.MySqlCommand(insertQuery, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            long id = mySqlCommand.LastInsertedId;
            return id;
        }

    }
}