using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Database
{
    /*
     *  Maxwell Robinson, Skyler Drake, Andrew J Marchese
     *  11/15/22
     * 
     *  Contains methods to manage and retrieve data from the templates table
     */
    public static class ManageTemplates
    {
        private static string CONNECTION_STRING = ConnectionString.connectionString;

        /*
        *  Saves the template name, subject, and body to the database
        */
        public static void saveTemplate(int id, string subject, string body, string name)
        {
            string insertQuery = "INSERT INTO notification_templates(fk_creator_id, subject, message, template_name) " +
                "values(@id, @subjectTextBox, @bodyRichTextBox, @nameTextBox)";
            SqlConnection cnn;
            cnn = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand(insertQuery, cnn);
            try
            {
                cnn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@subjectTextBox", subject);
                cmd.Parameters.AddWithValue("@bodyRichTextBox", body);
                cmd.Parameters.AddWithValue("@nameTextBox", name);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch(Exception ex)
            {
                cnn.Close();
                throw ex;
            }
            
        }

        /*
         *  Deleted the selected template
         */
        public static void deleteTemplate(String name)
        {
            string deleteQuery = "DELETE from notification_templates WHERE template_name = @template_name";
            SqlConnection cnn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cnn.ConnectionString = CONNECTION_STRING;
            try
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.Parameters.AddWithValue("@template_name", name);
                cmd.CommandText = deleteQuery;
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                cnn.Close();
                throw ex;
            }
        }

        /*
         * This method retrieves the subject of a given template name if a match is found. Returns an
         * empty string instead if result is null.
         */
        public static string fetchSubject(string templateName)
        {
            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCommand = new SqlCommand();
            templateName = templateName.Replace("'", "''");
            string result = "";

            try
            {
                dbConnection.ConnectionString = CONNECTION_STRING;
                dbConnection.Open();
                dbCommand.Connection = dbConnection;

                dbCommand.CommandText =
                    "SELECT subject FROM notification_templates " +
                    "WHERE template_name = @template_name";
                dbCommand.Parameters.AddWithValue("@template_name", templateName);
                result = dbCommand.ExecuteScalar()?.ToString() ?? "";

                dbConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                dbConnection.Close();

                throw ex;
            }
        }

        /*
        * This method retrieves the message from a given template name if a match is found. Returns an
        * empty string instead if result is null.
        */
        public static string fetchMessage(string templateName)
        {
            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCommand = new SqlCommand();
            templateName = templateName.Replace("'", "''");
            string result = "";

            try
            {
                dbConnection.ConnectionString = CONNECTION_STRING;
                dbConnection.Open();
                dbCommand.Connection = dbConnection;

                dbCommand.CommandText =
                    "SELECT message FROM notification_templates " +
                    "WHERE template_name = @template_name";
                dbCommand.Parameters.AddWithValue("@template_name", templateName);
                result = dbCommand.ExecuteScalar()?.ToString() ?? "";

                dbConnection.Close();

                return result;
            }
            catch (Exception ex)
            {
                dbConnection.Close();

                throw ex;
            }
        }

        /*
         * Connects to the remote database to obtain the names of all stored templates, returning them as a List.
         */
        public static List<string> loadTemplateNames()
        {
            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCommand = new SqlCommand();
            SqlDataReader dbDataReader;
            List<string> nameList = new List<string>();

            try
            {
                dbConnection.ConnectionString = CONNECTION_STRING;
                dbConnection.Open();
                dbCommand.Connection = dbConnection;

                dbCommand.CommandText =
                    "SELECT DISTINCT template_name FROM notification_templates " +
                    "WHERE template_id IS NOT NULL AND template_name IS NOT NULL " +
                    "GROUP BY template_name";
                dbDataReader = dbCommand.ExecuteReader();

                while (dbDataReader.Read())
                {
                    nameList.Add(dbDataReader[0].ToString());
                }

                dbDataReader.Close();
                dbConnection.Close();

                return nameList;
            }
            catch (Exception ex)
            {
                dbConnection.Close();

                throw ex;
            }
        }
    }
}
