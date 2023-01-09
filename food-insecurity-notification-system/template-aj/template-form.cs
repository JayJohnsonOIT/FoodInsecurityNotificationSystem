using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UserAccounts;

/*
 *  Andrew J Marchese, Maxwell Robinson
 *  11/14/22
 *  
 *  Handles a form and its methods for holding and creating notifcation templates
 */
namespace template_aj
{
    public partial class Templates : Form
    {
        //The account associated with the staff member who signed in
        Account account;

        /*
         * Creates the form with a fake testing account. Only use this method for testing purposes.
         */
        public Templates()
        {
            InitializeComponent();

            account = Account.TestAccount();
        }

        public Templates(Account account)
        {
            InitializeComponent();

            this.account = account;
        }

        /*
         *  Populates the drop down list with all the names of templates
         */
        private void templates_Load(object sender, EventArgs e)
        {
            //Declare a list for the template names
            List<String> name = new List<String>();

            //Adds a list of all the template names to the combo box drop down            
            name = Database.ManageTemplates.loadTemplateNames();
            int length = name.Count();
            for (int i = 0; i < length; i++)
            {
                templatesComboBox.Items.Add(name[i]);
            }

            //This block upgrades the size of the form font 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        /*
         *  Clears all text fields on the form
         */
        private void clearButton_Click(object sender, EventArgs e)
        {
            subjectTextBox.Text = string.Empty;
            bodyRichTextBox.Text = string.Empty;
            templateNameTextBox.Text = string.Empty;
            templatesComboBox.Text = string.Empty;
        }
        /*
         *  Saves the template name, subject, and body to the database
         */
        private void saveButton_Click(object sender, EventArgs e)
        {
            String body = bodyRichTextBox.Text;
            String subject = subjectTextBox.Text;
            String name = templateNameTextBox.Text;

            if (String.IsNullOrEmpty(subject) || String.IsNullOrEmpty(body) || String.IsNullOrEmpty(name))
            {
                MessageBox.Show("You must have a body, a subject, and a unique name to save a template", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Database.ManageTemplates.saveTemplate(account.getId(), subject, body, name);
                    MessageBox.Show("Template Saved!");
                    templatesComboBox.Items.Add(name);

                }
                catch
                {
                    MessageBox.Show("Template Name already exists.\n Please enter a unique name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /*
         *  Deleted the selected template
         */
        private void deleteButton_Click(object sender, EventArgs e)
        {
            String name = templatesComboBox.Text;
            if (templateNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("No template selected.\nPlease select a template.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Database.ManageTemplates.deleteTemplate(name);
                    templatesComboBox.Items.Remove(name);
                    clearButton_Click(sender, e);
                    MessageBox.Show("Template Deleted!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        /*
         *  Brings up a saved template when the user clicks a different template name in the drop down list
         */
        private void templatesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Changes the template name text to match the selected item from the combo box
                string selectedTemplateName = (string)templatesComboBox.SelectedItem;
                templateNameTextBox.Text = selectedTemplateName;

                //Query for the subject of the template and set the value to the subject text box
                string subject = Database.ManageTemplates.fetchSubject(selectedTemplateName);
                subjectTextBox.Text = subject;

                //Query for the body of the template and set the value to the body text box
                string body = Database.ManageTemplates.fetchMessage(selectedTemplateName);
                bodyRichTextBox.Text = body;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /*
         *  Prevents the user from typing into the combo box
         */
        private void templatesComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        /*
         *  Adds a <tag> string to the body of the message text box when a selection is picked from the combo box
         */ 
        private void tagsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tagsComboBox.SelectedIndex)
            {
                case 0:
                    bodyRichTextBox.Text += ("<Hot Food>");
                    break;
                case 1:
                    bodyRichTextBox.Text += ("<Location>");
                    break;
                case 2:
                    bodyRichTextBox.Text += ("<Drinks>");
                    break;
                case 3:
                    bodyRichTextBox.Text += ("<Clothing>");
                    break;
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
