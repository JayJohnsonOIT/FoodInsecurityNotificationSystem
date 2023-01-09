using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace UIHandler
{
    /*
     * Jay Johnson
     * 10/30/2022
     * 
     * This class will handle displays for errors and the alerts display
     */
    public class Error
    {
        static ErrorProvider errorProvider = new ErrorProvider();

        /*
         * Check to see if the dates were entered correctly
         * Update the error provider appropriately
         */
        public static bool validateDateTime(DateTimePicker from, DateTimePicker to)
        {
            if (to.Value < from.Value)
            {
                errorProvider.SetError(to, "Enter a 'to' date later than a 'from' date.");
                return false;
            }
            else
            {
                errorProvider.SetError(to, "");
                return true;
            }
        }

        /*
         * Alert the user if there was no results found in their search
         */
        public static void noSearchResults(Button searchButton, bool error)
        {
            if(error)
            {
                errorProvider.SetError(searchButton, "No results found!");
            } else
            {
                errorProvider.SetError(searchButton, "");
            }
        }

        /*
         * Search the datatable for rows with duplicate messages
         * update the duplicate richTextBox appropriately
         */
        public static void alertDuplicates(DataTable dataTable, RichTextBox duplicateBox, DataGridView dataGrid)
        {
            DataTable duplicates = new DataTable();
           
            
            // If dataTable is not null or empty
            if(dataTable != null && dataTable.Rows.Count > 0)
            {
                // Clone dataTable to avoid issues with column names and primary keys
                duplicates = dataTable.Clone();

                // Find duplicate rows in the dataTable by finding duplicate messages
                foreach (DataRow _dr in dataTable.AsEnumerable().GroupBy(r => new
                {
                    c2 = r.Field<string>("Message")
                }
                ).Where(grp => grp.Count() > 1).SelectMany(itm => itm))
                {
                    // Add duplicate rows to duplicates DataTable
                    duplicates.ImportRow(_dr);
                }
            }
            
            if (duplicates == null || duplicates.Rows.Count <= 0)
            {
                // No duplicates have been found
                duplicateBox.ForeColor = Color.DarkGreen;
                duplicateBox.Text = "No duplicate notifications have been detected!";

                return;
            } else
            {
                // Duplicates have been found
                string subjectShort;
                int maxLength = 20;
              
                duplicateBox.ForeColor = Color.DarkRed;
                duplicateBox.Text = "There are duplicate notifications!";

                // Add a formatted date and subject for each duplicate message to the duplicate RichTextBox
                foreach(DataRow row in duplicates.Rows)
                {
                    subjectShort = row.Field<string>("Subject");
                    if (subjectShort.Length >= maxLength)
                    {
                        subjectShort = subjectShort.Substring(0, maxLength) + "...";
                    }
                    duplicateBox.Text += System.Environment.NewLine + System.Environment.NewLine + "[" + row.Field<DateTime>("send_datetime") + "] " + System.Environment.NewLine + subjectShort;
                }


                /* A bunch of code that was meant to highlight duplicate entries on the dataGridView
                 * I couldn't get it to work, but I'm leaving it here in case I try to tackle this before presenting
                 * If I do, I will break it out into it's own function
                 * 
                //DataTable gridTable = dataGrid.DataSource as DataTable;
                foreach (DataRow row in duplicates.Rows)
                {
                    var k = (from r in duplicates.Rows.OfType<DataRow>() where r["notification_id"].ToString() == row["notification_id"].ToString() select r).FirstOrDefault();
                    if (k != null)
                    { 
                        dataTable.Rows[dataTable.Rows.IndexOf(row)].SetField<string>(1, "[DUPLICATE DETECTED] " + row.Field<string>("Subject")); 
                    }
                    
                    // BEGIN OLD CODE
                    if (dataTable.Rows.Contains(row))
                    {
                        dataTable.Rows[dataTable.Rows.IndexOf(row)].SetField<string>(1, "[DUPLICATE DETECTED] " + row.Field<string>("Subject"));
                    } // END OLD CODE
                }

                dataGrid.DataSource = dataTable;
                int indexTracker = 0;
                foreach(DataGridViewRow row in dataGrid.Rows)
                {
                    if(row.Cells[0].ToString().StartsWith("[DUPLICATE DETECTED]"))
                    {
                        dataGrid.Rows[indexTracker].DefaultCellStyle.BackColor = Color.Red;
                    }
                }

                // BEGIN OLD CODE
                foreach (DataRow row in dataGrid.Rows)
                {
                    indexTracker++;

                    if (row.Field<string>("Subject").StartsWith("[DUPLICATE DETECTED]"))
                    {
                        dataGrid.Rows[indexTracker].DefaultCellStyle.BackColor = Color.Red;
                    }
                } // END OLD CODE
                */
            }
        }

        /*
         * Search the notification table for all rows within the specified date range without filtering the results
         * Check for notification droughts (A week or more time between notifications)
         * Update the drought RichTextBox appropriately
         */
        public static void alertDrought(DateTime from, DateTime to, RichTextBox droughtBox)
        {
            DataRow rowOne;
            DataRow rowTwo;
            TimeSpan droughtTime = new TimeSpan(7,0,0,0);

            // Search the database using ONLY the date range
            DataTable dataTable = Database.ManageNotifications.searchNotifications(from, to);
            DataTable droughtTable = new DataTable();

            // Check if the search returned any results
            if (dataTable.Rows.Count > 0 && dataTable != null)
            {
                // Clone dataTable to avoid issus with column names and primary keys
                droughtTable = dataTable.Clone();

                // For each pair of rows (that are sorted by the send_datetime column)
                for (int i = 0; i < dataTable.Rows.Count - 1; i++)
                {
                    rowOne = dataTable.Rows[i];
                    rowTwo = dataTable.Rows[i+1];

                    // If their is a week or more time between the two rows, add them to the droughtTable
                    if((rowTwo.Field<DateTime>("send_datetime") - rowOne.Field<DateTime>("send_datetime")).TotalDays > droughtTime.TotalDays)
                    {
                        droughtTable.ImportRow(rowOne);
                        droughtTable.ImportRow(rowTwo);
                    }
                }

                // If the drought table has any data
                if(droughtTable.Rows.Count > 0 && droughtTable != null)
                {
                    // Inform the user that notifications have not been sent out regularly at specific date ranges
                    droughtBox.ForeColor = Color.DarkRed;
                   
                    droughtBox.Text = "Notifications have not been sent out regularly!" + System.Environment.NewLine;
                    for (int i = 0; i < droughtTable.Rows.Count - 1; i++)
                    {
                        droughtBox.Text += System.Environment.NewLine + "No notifications between" + 
                            System.Environment.NewLine + droughtTable.Rows[i].Field<DateTime>("send_datetime") + 
                            System.Environment.NewLine  + " and " + System.Environment.NewLine + 
                            droughtTable.Rows[i+1].Field<DateTime>("send_datetime") + "!" + System.Environment.NewLine;
                    }
                } else
                {
                    // Inform the user that Notifications have been sent out regularly withing their search's date range
                    droughtBox.ForeColor = Color.DarkGreen;
                    droughtBox.Text = "Notifications have been sent regularly!";
                }
            }

        }

        /*
         * Clear the duplicaes RichTextBox and the drought RichTextBox
         */
        public static void clearAlerts(RichTextBox duplicateBox, RichTextBox droughtBox)
        {
            duplicateBox.Text = "";
            droughtBox.Text = "";
        }
    }
}
