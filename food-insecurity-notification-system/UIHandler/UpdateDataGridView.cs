using System.Data;
using System.Windows.Forms;

namespace UIHandler
{
    /*
     * Jay Johnson
     * 11/30/2022
     * 
     * This class formats and displays data in the DataGridView
     */
    public class UpdateDataGridView
    {
        /*
         * Updates dataGridView with data from dataTable
         */
        public static void displayTable(DataTable dataTable, DataGridView dataGridView)
        {
            DataTable displayTable = new DataTable();

            // Check for null or empty
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                // format dataTable to be user friendly and remove extra columns
                displayTable = formatTable(dataTable);
            }

            // update the dataGridView
            dataGridView.DataSource = displayTable;

            // Auto Resize all columns except the message column
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.AutoResizeColumn(0);
                dataGridView.AutoResizeColumn(1);
                dataGridView.AutoResizeColumn(3);
                dataGridView.AutoResizeColumn(4);
            }
            
        }

        /*
         * Returns a DataTable that has been formatted for display in the DataGridView
         */
        public static DataTable formatTable(DataTable dataTable)
        {
            DataTable formattedTable = new DataTable();

            // Check for null or empty
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                return formattedTable;
            }

            // Remove the notification_id column from the results
            if (dataTable.Columns.Contains("notification_id"))
            {
                dataTable.Columns.Remove("notification_id");
            }

            // Change datatable column 0 type to string by cloneing results to resultsDisplay
            formattedTable = dataTable.Clone();
            formattedTable.Columns[0].DataType = typeof(string);
            foreach (DataRow row in dataTable.Rows)
            {
                formattedTable.ImportRow(row);
            }

            // If the results include columns from the users table, cut them off
            int cutOff = 6;
            while (formattedTable.Columns.Count > cutOff)
            {
                formattedTable.Columns.RemoveAt(cutOff);
            }

            // Change column names to be user friendly
            if (dataTable.Columns.Contains("fk_sender_id"))
            {
                formattedTable.Columns["fk_sender_id"].ColumnName = "Sender";
            }
            if (dataTable.Columns.Contains("subject"))
            {
                formattedTable.Columns["subject"].ColumnName = "Subject";
            }
            if (dataTable.Columns.Contains("message"))
            {
                formattedTable.Columns["message"].ColumnName = "Message";
            }
            if (dataTable.Columns.Contains("send_datetime"))
            {
                formattedTable.Columns["send_datetime"].ColumnName = "Date/Time";
            }
            if (dataTable.Columns.Contains("subscribers_recieved"))
            {
                formattedTable.Columns["subscribers_recieved"].ColumnName = "Recipients";
            }
            if (dataTable.Columns.Contains("attachment"))
            {
                formattedTable.Columns["attachment"].ColumnName = "Attachments";
            }
            formattedTable.AcceptChanges();

            // Change value of column 0 from fk_user_id to username
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                formattedTable.Rows[i][0] = Database.ManageUsers.getUsername(dataTable.Rows[i][0]);
            }

            return formattedTable;
        }
    }
}
