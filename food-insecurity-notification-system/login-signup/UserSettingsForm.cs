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

namespace login_signup
{
    /*
     * Maxwell Robinson
     * 10/23/22
     * 
     * The form that a regular user will see upon signing in
     */
    public partial class UserSettingsForm : Form
    {
        public UserSettingsForm(Account account)
        {
            InitializeComponent();

            accountNameLabel.Text = account.getUsername();
        }

        /*
         * Returns the user to the sign in form
         */
        private void logoutButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }
    }
}
