using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using UserAccounts;

namespace Database
{
    /* 
     *  Maxwell Robinson, Skyler Drake, Jay Johnson
     *  11/16/22
     * 
     *  Contains methods to manage and retrieve data from the users table
     */
    public static class ManageUsers
    {
        private static string CONNECTION_STRING = ConnectionString.connectionString;

        /*
         * Adds a new user to the database using the parameters passed to it
         */
        public static void addAccount(string username, string email, string password, string name)
        {
            //Encrypt the pasword
            string encryptedPassword = Hashing.Hashing.hash(password);

            //Open the connection to the database
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();

            try
            {
                string query = "INSERT INTO users (username, email, password, name, role) " +
                    "VALUES (@username, @email, @password, @name, 'subscriber')";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add(new SqlParameter("@username", username.ToLower()));
                command.Parameters.Add(new SqlParameter("@email", email.ToLower()));
                command.Parameters.Add(new SqlParameter("@password", Hashing.Hashing.hash(password)));
                command.Parameters.Add(new SqlParameter("@name", name));
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }

            con.Close();
        }

        /*
         * Checks the database for a matching username
         * Returns true if a match is found
         */
        public static bool matchUsername(string username)
        {
            bool match = false;
            SqlConnection con = new SqlConnection(CONNECTION_STRING);

            try
            {
                string query = "SELECT * FROM users WHERE username = @username";
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add(new SqlParameter("@username", username.ToLower()));
                var reader = command.ExecuteReader();

                //If it gets a result then a match was found
                if (reader.Read())
                {
                    match = true;
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }

            return match;
        }

        /*
         * Checks the database for a matching email address
         */
        public static bool matchEmail(string email)
        {
            bool match = false;
            SqlConnection con = new SqlConnection(CONNECTION_STRING);

            try
            {
                string query = "SELECT * FROM users WHERE email = @email";
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.Add(new SqlParameter("@email", email.ToLower()));
                var reader = command.ExecuteReader();

                //If it gets a result then a match was found
                if (reader.Read())
                {
                    match = true;
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }

            return match;
        }

        /*
         * Returns an Account object matching the data associated with the username or email and password pair
         * Returns null if account not found
         */
        public static Account loadAccount(string login, string password)
        {
            Account account;
            int accId;
            string accUsername, accEmail, accName, accRole;
            DateTime accCreationTime;

            SqlConnection con = new SqlConnection(CONNECTION_STRING);

            try
            {
                SqlDataReader reader;
                SqlCommand command;

                //Creates a query that searches for an account based on username
                if (matchUsername(login))
                {
                    string query = "SELECT user_id, username, email, name, role, account_created FROM users " +
                       "WHERE username = @username AND password = @password";
                    con.Open();
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@username", login.ToLower()));
                    command.Parameters.Add(new SqlParameter("@password", Hashing.Hashing.hash(password)));
                }
                //Creates a query that searches for an account based on email
                else if (matchEmail(login))
                {
                    string query = "SELECT user_id, username, email, name, role, account_created FROM users " +
                        "WHERE email = @email AND password = @password";
                    con.Open();
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@email", login.ToLower()));
                    command.Parameters.Add(new SqlParameter("@password", Hashing.Hashing.hash(password)));
                }
                else
                {
                    return null;
                }

                reader = command.ExecuteReader();

                //If there's a result then a match was found
                if (reader.Read())
                {
                    accId = Convert.ToInt32(reader["user_id"].ToString());
                    accUsername = reader["username"].ToString();
                    accEmail = reader["email"].ToString();
                    accName = reader["name"].ToString();
                    accRole = reader["role"].ToString();
                    accCreationTime = reader.GetDateTime(5);

                    account = new Account(accId, accUsername, accEmail, accName, accRole, accCreationTime);
                    con.Close();
                    return account;
                }
                else
                {
                    con.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                con.Close();
                throw ex;
            }
        }

        /*
         * Connects to the remote database to obtain a List containing all email addresses for subscriber role users.
         */
        public static List<string> loadSubscriberEmails()
        {
            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCommand = new SqlCommand();
            SqlDataReader dbDataReader;
            List<string> emailList = new List<string>();

            try
            {
                dbConnection.ConnectionString = CONNECTION_STRING;
                dbConnection.Open();
                dbCommand.Connection = dbConnection;

                dbCommand.CommandText =
                    "SELECT DISTINCT email FROM users " +
                    "WHERE role = 'subscriber' AND email IS NOT NULL";
                dbDataReader = dbCommand.ExecuteReader();

                while (dbDataReader.Read())
                {
                    emailList.Add(dbDataReader[0].ToString());
                }

                dbDataReader.Close();
                dbConnection.Close();

                return emailList;
            }
            catch (Exception ex)
            {
                dbConnection.Close();

                throw ex;
            }
        }

        /*
         *  Get the username from the users table using the fk_sender_id and returns it
         */
        public static Object getUsername(Object sender_id)
        {
            DataTable results = new DataTable();
            Object username;
            string searchQuery = "SELECT * " +
               "FROM users " +
               "WHERE user_id ='" + sender_id + "'";

            // Connect to the database and open the connection
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand(searchQuery, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    // Put read data into results datatable
                    results.Load(reader);
                    reader.Close();

                    // Set username to the value of the username column
                    username = results.Rows[0][1];
                }
                else
                {
                    username = "NOT FOUND";
                }

                conn.Close();

            }
            catch (Exception except)
            {
                conn.Close();
                throw except;
            }

            return username;
        }
    }
}
