using System;
using System.Data.SqlClient;
using System.Data;

namespace Database
{
    /*
     *  Maxwell Robinson, Skyler Drake, Jay Johnson
     *  11/30/22
     *  
     *  Contains methods to manage and retrieve data from the notifications table
     */
    public static class ManageNotifications
    {
        private static string CONNECTION_STRING = ConnectionString.connectionString;

        /*
         * Adds a row the to notifications database, for logging purposes, including all relevant information
         * for a sent notification.
         */
        public static void appendLog(int senderId, string subject, string message, int recipients)
        {
            string timestamp = DateTime.Now.ToString("G");
            subject = subject.Replace("'", "''");
            message = message.Replace("'", "''");

            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCommand = new SqlCommand();

            try
            {
                dbConnection.ConnectionString = CONNECTION_STRING;
                dbConnection.Open();
                dbCommand.Connection = dbConnection;

                // subscribers_recieved as written on server side, with spelling error. (TODO: Fix with team.)
                dbCommand.CommandText =
                    "INSERT INTO notifications" +
                    "(fk_sender_id, subject, message, send_datetime, subscribers_recieved)" +
                    "VALUES" +
                    "(" + senderId + ", '" + subject + "', '" + message + "', '" + timestamp + "', " + recipients + ")";
                dbCommand.ExecuteNonQuery();

                dbConnection.Close();
            }
            catch (Exception ex)
            {
                dbConnection.Close();

                throw ex;
            }
        }

        /*
         * This method queries the notfications table for data rows between two dates
         * It filters results based on text entered into the search fields
         * It then returns those results
         */
        public static DataTable searchNotifications(DateTime from, DateTime to,  string[] searchText)
        {

            DataTable results = new DataTable();

            // If to's time of day is 12:00 AM
            if (to.TimeOfDay == TimeSpan.Zero)
            {
                // Set to's time of day to 11:59 PM
                TimeSpan toTime = new TimeSpan(0, 23, 59, 59);
                to = to.Add(toTime);
            }

            string searchQuery = "SELECT * " +
                "FROM notifications " +
                "WHERE send_datetime BETWEEN '" + from + "' AND '" + to + "'";

            //See if any of the search fields contain parameters, and if so update the searchQuery
            string[] splitText = searchText[0].Split(' ');
            if (searchText[0] != "") // Username field
            {
                searchQuery = "SELECT * " +
                "FROM notifications " +
                "INNER JOIN users ON notifications.fk_sender_id=users.user_id " +
                "WHERE send_datetime BETWEEN '" + from + "' AND '" + to + "'";
                foreach (string word in splitText)
                {
                    searchQuery += " AND CHARINDEX('" + word + "', lower(users.username)) > 0";
                }
            }
            if (searchText[1] != "") // Subject field
            {
                splitText = searchText[1].Split(' ');

                foreach(string word in splitText)
                {
                    searchQuery += " AND CHARINDEX('" + word + "', lower(subject)) > 0";
                }
            }
            if (searchText[2] != "") // Message field
            {
                splitText = searchText[2].Split(' ');

                foreach (string word in splitText)
                {
                    searchQuery += " AND CHARINDEX('" + word + "', lower(message)) > 0";
                }
            }

            // Connect to the database and open the connection
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand(searchQuery, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // Try to search the notifications table
            try
            {
                // If there was data found, update the datagridview, otherwise inform the user that nothing was found
                if (reader.HasRows)
                {
                    // Put read data into results datatable
                    results.Load(reader);
                    reader.Close();
                }

                conn.Close();

                // Set the default sort to the date/time
                if (results.Columns.Contains("send_datetime"))
                {
                    results.DefaultView.Sort = "send_datetime";
                }
                return results;

            } catch (Exception except)
            {
                conn.Close();
                throw except;
            }
        }

        /*
         * This method queries the notfications table for data rows between two dates
         * This method does NOT filter results based on search text
         * It then returns those results
         */
        public static DataTable searchNotifications(DateTime from, DateTime to)
        {

            DataTable results = new DataTable();

            // If to's time of day is 12:00 AM
            if (to.TimeOfDay == TimeSpan.Zero)
            {
                // Set to's time of day to 11:59 PM
                TimeSpan toTime = new TimeSpan(0, 23, 59, 59);
                to = to.Add(toTime);
            }

            string searchQuery = "SELECT * " +
                "FROM notifications " +
                "WHERE send_datetime BETWEEN '" + from + "' AND '" + to + "'";

            // Connect to the database and open the connection
            SqlConnection conn = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand(searchQuery, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // Try to search the notifications table
            try
            {
                // If there was data found, update the datagridview, otherwise inform the user that nothing was found
                if (reader.HasRows)
                {
                    // Put read data into results datatable
                    results.Load(reader);
                    reader.Close();
                }

                conn.Close();

                // Set the default sort to the date/time
                if(results.Columns.Contains("send_datetime")) {
                    results.DefaultView.Sort = "send_datetime";
                }
                return results;

            } catch (Exception except)
            {
                conn.Close();
                throw except;
            }
        }
    }
}
