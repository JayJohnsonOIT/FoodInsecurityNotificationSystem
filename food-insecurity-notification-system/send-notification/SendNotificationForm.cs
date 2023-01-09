using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendNotificationLibrary;
using UserAccounts;
using InputValidation;

namespace send_notification
{
    /*
     *  Skyler Drake, Maxwell Robinson
     *  11/14/22
     *
     *  A form that will allow a user to edit and send notificactions via email. Loading of premade messages from
     *  templates will also be possible. Currently unfinished.
     */
    public partial class SendNotificationForm : Form
    {
        //The account that logged into the application, used for logging which staff member sent a notification
        private Account account;

        /*
         * Creates the form with a fake testing account assigned to it, only use this method for testing
         */
        public SendNotificationForm()
        {
            InitializeComponent();
            account = Account.TestAccount();
        }

        public SendNotificationForm(Account account)
        {
            InitializeComponent();

            this.account = account;
        }

        /*
         * UI element setup on load.
         */
        private void SendNotificationForm_Load(object sender, EventArgs e)
        {
            sendNotificationErrorProvider.SetIconAlignment(subjectTextBox, ErrorIconAlignment.MiddleLeft);
            sendNotificationErrorProvider.SetIconAlignment(messageLabel, ErrorIconAlignment.MiddleRight);
            sendNotificationErrorProvider.SetIconAlignment(templateSelectionComboBox, ErrorIconAlignment.MiddleLeft);
        }

        /*
         * Setup tasks for after UI has finished loading.
         * Current purpose is to fetch a list of template names to populate the relevant ComboBox.
         */
        private void SendNotificationForm_Shown(object sender, EventArgs e)
        {
            // Refreshing here to let Load events complete before continuing.
            this.Refresh();

            List<string> templateNames = new List<string>();

            try
            {
                templateNames = Database.ManageTemplates.loadTemplateNames();

                foreach (string str in templateNames)
                {
                    templateSelectionComboBox.Items.Add(str);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         * Gathers a list of all subscriber role users from the database, then sends a notification email to each 
         * of those users. Appends a row to the notifications database for log purposes.
         */
        private void sendButton_Click(object sender, EventArgs e)
        {
            if (NotificationValidation.isValidNotification(subjectTextBox.Text, messageRichTextBox.Text))
            {
                sendNotificationErrorProvider.SetError(subjectTextBox, "");
                sendNotificationErrorProvider.SetError(messageLabel, "");

                List<string> emailList = new List<string>();
                SendEmail sendEmail = new SendEmail();
                int subscriberCount = 0;

                try
                {
                    emailList = Database.ManageUsers.loadSubscriberEmails();
                    subscriberCount = emailList.Count;

                    sendEmail.sendNotification(emailList, subjectTextBox.Text, messageRichTextBox.Text);

                    Database.ManageNotifications.appendLog(account.getId(), subjectTextBox.Text, messageRichTextBox.Text, subscriberCount);

                    MessageBox.Show("Sent notification to " + subscriberCount + " subscribers.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                sendNotificationErrorProvider.SetError(subjectTextBox, NotificationValidation.subjectError(subjectTextBox.Text));
                sendNotificationErrorProvider.SetError(messageLabel, NotificationValidation.messageError(messageRichTextBox.Text));
            }
        }

        /*
         * Clears the text in the subject and message boxes, returns the template combobox to a deselected state
         * and blanks any input text that might remain if it was on index -1 already. Also clears any ErrorProvider
         * indicators.
         */
        private void clearButton_Click(object sender, EventArgs e)
        {
            subjectTextBox.Clear();
            messageRichTextBox.Clear();
            templateSelectionComboBox.SelectedIndex = -1;
            templateSelectionComboBox.Text = "";
            sendNotificationErrorProvider.SetError(subjectTextBox, "");
            sendNotificationErrorProvider.SetError(messageLabel, "");
        }

        /*
         * When the button is clicked it attempts to load a matching subject and message into the form, based on 
         * the template name currently in the relevant combobox.
         */
        private void loadTemplateButton_Click(object sender, EventArgs e)
        {
            sendNotificationErrorProvider.SetError(templateSelectionComboBox, "");
            string templateSubject = "";
            string templateMessage = "";

            try
            {
                templateSubject = Database.ManageTemplates.fetchSubject(templateSelectionComboBox.Text);
                templateMessage = Database.ManageTemplates.fetchMessage(templateSelectionComboBox.Text);

                if (templateSubject == "" && templateMessage == "")
                {
                    sendNotificationErrorProvider.SetError(templateSelectionComboBox, "Template is empty or could not be found.");
                }
                else
                {
                    subjectTextBox.Text = templateSubject;
                    messageRichTextBox.Text = templateMessage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         * Closes the form
         */
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
