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
     * The form for creating a new account
     */
    public partial class SignupForm : Form
    {
        //Validation error messages
        private string usernameValidationMessage, emailValidationMessage, 
            nameValidationMessage, passwordValidationMessage;

        public SignupForm()
        {
            InitializeComponent();
            
            //Set messages for invalid input notifications
            usernameValidationMessage = "Username must be between " +
                Convert.ToString(InputValidation.AccountValidation.usernameMin) +
                " and " + Convert.ToString(InputValidation.AccountValidation.usernameMax) +
                " characters.";
            emailValidationMessage = "Email must be between " +
                Convert.ToString(InputValidation.AccountValidation.emailMin) +
                " and " + Convert.ToString(InputValidation.AccountValidation.emailMax) +
                " characters, and must be in the proper email format.";
            nameValidationMessage = "Name must be between " +
                Convert.ToString(InputValidation.AccountValidation.nameMin) +
                " and " + Convert.ToString(InputValidation.AccountValidation.nameMax) +
                " characters.";
            passwordValidationMessage = "Password must be between " +
                Convert.ToString(InputValidation.AccountValidation.passwordMin) +
                " and " + Convert.ToString(InputValidation.AccountValidation.passwordMax) +
                " characters and contain at least one uppercase character and number.";
        }

        /*
         * Redirects the user to the login form
         */
        private void signinButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        /*
         * Closes the form
         */
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
         * Validates the user input fields
         */
        private void signupButton_Click(object sender, EventArgs e)
        {
            //Keep track of validations, gets set to false if any fail
            bool valid = true;

            //Validate username, show error if invalid
            if(!InputValidation.AccountValidation.validateUsername(usernameTextBox.Text))
            {
                validationErrorProvider.SetError(usernameTextBox, usernameValidationMessage);
                valid = false;
            }
            else
            {
                validationErrorProvider.SetError(usernameTextBox, "");
            }

            //Validate email, show error if invalid
            if (!InputValidation.AccountValidation.validateEmail(emailTextBox.Text))
            {
                validationErrorProvider.SetError(emailTextBox, emailValidationMessage);
                valid = false;
            }
            else
            {
                validationErrorProvider.SetError(emailTextBox, "");
            }

            //Validate name, show error if invalid
            if (!InputValidation.AccountValidation.validateName(nameTextBox.Text))
            {
                validationErrorProvider.SetError(nameTextBox, nameValidationMessage);
                valid = false;
            }
            else
            {
                validationErrorProvider.SetError(nameTextBox, "");
            }

            //Validate password, show error if invalid
            if (!InputValidation.AccountValidation.validatePassword(passwordTextBox.Text))
            {
                validationErrorProvider.SetError(passwordTextBox, passwordValidationMessage);
                valid = false;
            }
            else
            {
                validationErrorProvider.SetError(passwordTextBox, "");
            }

            //Validate password re-entry, show error if invalid
            if (passwordTextBox.Text != reenterPasswordTextBox.Text)
            {
                validationErrorProvider.SetError(reenterPasswordTextBox, "Passwords must match");
                valid = false;
            }
            else
            {
                validationErrorProvider.SetError(reenterPasswordTextBox, "");
            }

            //Verify that username or email isn't already registered
            if(ManageUsers.matchUsername(usernameTextBox.Text) || ManageUsers.matchEmail(emailTextBox.Text))
            {
                valid = false;
                MessageBox.Show("Failed to create account", "Account creation failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //If all validations pass, begin adding new user
            if(valid)
            {
                try
                {
                    //Adds the account
                    ManageUsers.addAccount(usernameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, nameTextBox.Text);

                    //Inform the user that the account was created and clear input fields
                    MessageBox.Show("Account created successfully.", "Welcome!");
                    clearFields();
                }
                catch (Exception ex)
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
            clearFields();
        }

        /*
         * Clears all fields and resets validation error notifications
         */
        private void clearFields()
        {
            usernameTextBox.Clear();
            emailTextBox.Clear();
            nameTextBox.Clear();
            passwordTextBox.Clear();
            reenterPasswordTextBox.Clear();
            validationErrorProvider.SetError(usernameTextBox, "");
            validationErrorProvider.SetError(emailTextBox, "");
            validationErrorProvider.SetError(nameTextBox, "");
            validationErrorProvider.SetError(passwordTextBox, "");
            validationErrorProvider.SetError(reenterPasswordTextBox, "");
        }
    }
}
