using System;
using System.Data;
using System.Windows.Forms;
using UserAccounts;

namespace notification_log
{
    /*
     * Jay Johnson, Maxwell Robinson
     * 12/4/2022
     * 
     * A form that allows the user to view a table of previously sent notifications
     */
    public partial class NotificationLogForm : Form
    {
        private BindingSource bindingSource = new BindingSource();

        //The account associated with the staff that signed in
        Account account;

        /*
         * Creates the form with a fake testing account. Only use this method for testing purposes
         */
        public NotificationLogForm()
        {
            InitializeComponent();

            // Sets the last date in the date range to the current date and time
            toDateTimePicker.Value = DateTime.Today;

            account = Account.TestAccount();

            // Increases font sizes for presentation purposes
            float fontSize = 10.8F;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            fromDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", fontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        public NotificationLogForm(Account account)
        {
            InitializeComponent();

            // Sets the last date in the date range to the current date and time
            toDateTimePicker.Value = DateTime.Today;

            this.account = account;

            // Increases font sizes for presentation purposes
            //this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //fromDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        /*
         *  When any cell in the DataGridView is clicked, display the subject and message
         */
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string subject = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            string message = dataGridView.SelectedRows[0].Cells[2].Value.ToString();

            subjectTextBox.Text = subject;
            messageRichTextBox.Text = message;
        }

        /*
         * When the search Button is clicked, search the database for results and update the DataGridView
         */
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            // Clears all fields except the DateTimePickers and search TextBoxes
            dataGridView.DataSource = "";
            subjectTextBox.Clear();
            messageRichTextBox.Clear();
            duplicateRichTextBox.Clear();
            droughtRichTextBox.Clear();

            // If the input is valid then proceed with the search, otherwise warn user
            if (UIHandler.Error.validateDateTime(fromDateTimePicker, toDateTimePicker))
            {
                try
                {
                    // Put all search TextBox values in an array to pass into the Database search method
                    string[] searchText = { usernameTextBox.Text, subjectSearchTextBox.Text, messageSearchTextBox.Text};
                    
                    // Search the notifications table for notifications within the specified date range and parameters
                    dataTable = Database.ManageNotifications.searchNotifications(fromDateTimePicker.Value, toDateTimePicker.Value, searchText);

                    // If the search results are not empty
                    if (dataTable != null && dataTable.Rows.Count > 0)
                    {
                        // Clear the error provider
                        UIHandler.Error.noSearchResults(searchButton, false);

                        // Update dataGridView
                        UIHandler.UpdateDataGridView.displayTable(dataTable, dataGridView);

                        // Check for duplicate notifications within the search results and inform the user
                        UIHandler.Error.alertDuplicates(dataTable, duplicateRichTextBox, dataGridView);

                        // Check for notificaion drought based on only the date range of the search and inform the user
                        UIHandler.Error.alertDrought(fromDateTimePicker.Value, toDateTimePicker.Value, droughtRichTextBox);
                    }
                    else
                    {
                        // Inform the user that their search returned no results
                        UIHandler.Error.noSearchResults(searchButton, true);
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                // Do nothing and return
                return;
            }
        }

        /*
         * When the clear button is clicked, clear all fields
         */
        private void buttonClear_Click(object sender, EventArgs e)
        {
            // Clear controls and displays
            dataGridView.DataSource = "";
            subjectTextBox.Clear();
            messageRichTextBox.Clear();
            duplicateRichTextBox.Clear();
            droughtRichTextBox.Clear();
            usernameTextBox.Clear();
            subjectSearchTextBox.Clear();
            messageSearchTextBox.Clear();
            fromDateTimePicker.Value = new DateTime(2022, 10, 17);
            toDateTimePicker.ResetText();

            // Clear the error providers and alerts
            UIHandler.Error.noSearchResults(searchButton, false);
            UIHandler.Error.validateDateTime(fromDateTimePicker, toDateTimePicker);
            UIHandler.Error.clearAlerts(duplicateRichTextBox, droughtRichTextBox);
        }

        /*
         * When the exit button is clicked, exit the program
         * This should be used to return to the menu form once our projects are merged
         */
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
