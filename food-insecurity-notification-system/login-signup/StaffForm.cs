using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAccounts;
using send_notification;
using template_aj;
using notification_log;

namespace login_signup
{
    /*
     * Maxwell Robinson
     * 11/14/22
     * 
     * The form that a staff member will see after logging in, contains buttons that allow
     * the staff member to access the tools for sending notifications
     */
    public partial class StaffForm : Form
    {
        private Account account;

        public StaffForm(Account account)
        {
            InitializeComponent();

            this.account = account;
            usernameLabel.Text = account.getUsername();
        }

        /*
         * Returns the user to the login form
         */
        private void backButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        /*
         * Will redirect the user to the staff portal if a child form closes
         */
        void childForm_FormClosed(object sender, EventArgs e)
        {
            this.Show();
            this.Refresh();
        }

        /*
         * Hides this form and shows the send notification form
         */
        private void sendNotificationButton_Click(object sender, EventArgs e)
        {
            SendNotificationForm sendNotificationForm = new SendNotificationForm(account);
            sendNotificationForm.FormClosed += childForm_FormClosed;
            sendNotificationForm.Show(this);
            this.Hide();
        }

        /*
         * Hides this form and shows the notification log form
         */
        private void notificationLogButton_Click(object sender, EventArgs e)
        {
            NotificationLogForm notificationLogForm = new NotificationLogForm(account);
            notificationLogForm.FormClosed += childForm_FormClosed;
            notificationLogForm.Show(this);
            this.Hide();
        }

        /*
         * Hides this form and shows the templates form
         */
        private void templateButton_Click(object sender, EventArgs e)
        {
            Templates templatesForm = new Templates(account);
            templatesForm.FormClosed += childForm_FormClosed;
            templatesForm.Show(this);
            this.Hide();
        }
    }
}
