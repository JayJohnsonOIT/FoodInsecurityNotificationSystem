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
using Database;

namespace login_signup
{
    /*
     * Maxwell Robinson
     * 11/12/22
     * 
     * The form for signing in as a returning user
     */
    public partial class LoginForm : Form
    {
        //The form that will show when the user wants to create a new account
        private SignupForm signupForm;

        //The form that will show up when the user successfully logs in
        private UserSettingsForm userSettingsForm;

        //The form that will show when the user successfully logs in as a staff account
        private StaffForm staffForm;

        public LoginForm()
        {
            //Sets up the other forms
            signupForm = new SignupForm();
            signupForm.FormClosed += signupForm_FormClosed;

            InitializeComponent();
        }

        /*
         * Redirects the user to the signup form
         */
        private void signupButton_Click(object sender, EventArgs e)
        {
            signupForm.Show(this);
            this.Hide();
        }

        /*
         * Will close the program if the user presses the 'x' button in the signup form
         */
        void signupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            signupForm = null;
            Application.Exit();
        }

        /*
         * Will close the program if the user presses the 'x' button in the user settings form
         */
        void userSettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            userSettingsForm = null;
            Application.Exit();
        }

        /*
         * Will close the program if the user presses the 'x' button in the staff portal form
         */
        void staffForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            staffForm = null;
            Application.Exit();
        }

        /*
         * Validates the username and password and signs the user into the account
         */
        private void loginButton_Click(object sender, EventArgs e)
        {
            //Keeps track of validations, set to false if any fail
            bool valid = true;

            //Validate username, show error if invalid
            if (!InputValidation.AccountValidation.validateUsername(usernameTextBox.Text) && 
                !InputValidation.AccountValidation.validateEmail(usernameTextBox.Text))
            {
                validationErrorProvider.SetError(usernameTextBox, "Username Invalid");
                valid = false;
            }
            else
            {
                validationErrorProvider.SetError(usernameTextBox, "");
            }

            //Validate password, show error if invalid
            if(passwordTextBox.Text == "")
            {
                validationErrorProvider.SetError(passwordTextBox, "Password Invalid");
                valid = false;
            }
            else
            {
                validationErrorProvider.SetError(passwordTextBox, "");
            }

            //If all checks pass, attempt to log the user into the account
            if(valid)
            {
                try
                {
                    //Try to load an account using the username and password provided
                    Account account = ManageUsers.loadAccount(usernameTextBox.Text, passwordTextBox.Text);

                    //Check if account loaded successfully
                    if (account != null)
                    {
                        //If account is a staff member, redirect to staff portal
                        if(account.getRole() == "staff")
                        {
                            staffForm = null;
                            staffForm = new StaffForm(account);
                            staffForm.FormClosed += staffForm_FormClosed;
                            staffForm.Show(this);
                            clear();
                            this.Hide();
                        }
                        //Otherwise send to account settings page
                        else
                        {
                            userSettingsForm = null;
                            userSettingsForm = new UserSettingsForm(account);
                            userSettingsForm.FormClosed += userSettingsForm_FormClosed;
                            userSettingsForm.Show(this);
                            clear();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Unable to log into account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /*
         * Clears all fields and resets validation error notifications
         */
        private void clearButton_Click(object sender, EventArgs e)
        {
            clear();
        }

        /*
         * Clears all fields and resets validation error notifications
         */
        private void clear()
        {
            usernameTextBox.Clear();
            passwordTextBox.Clear();
            validationErrorProvider.SetError(usernameTextBox, "");
            validationErrorProvider.SetError(passwordTextBox, "");
        }

        /*
         * Clicks the sign in button if the user presses enter while selecting usernameTextBox
         */
        private void usernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                loginButton.PerformClick();
            }
        }

        /*
         * Clicks the sign in button if the user presses enter while selecting passwordTextBox
         */
        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                loginButton.PerformClick();
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
