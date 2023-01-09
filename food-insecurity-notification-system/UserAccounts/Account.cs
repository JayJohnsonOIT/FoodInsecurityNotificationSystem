using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccounts
{
    /*
     * Maxwell Robinson
     * 11/14/22
     * 
     * A class representing an entry in the users table and its associated values
     */
    public class Account
    {
        //The values contained within the class
        private int id;
        private string username, email, name, role;
        private DateTime creationDate;

        public Account(int id, string username, string email, string name, string role, DateTime creationDate)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.name = name;
            this.role = role;
            this.creationDate = creationDate;
        }

        public int getId()
        {
            return id;
        }

        public string getUsername()
        {
            return username;
        }

        public string getEmail()
        {
            return email;
        }

        public string getName()
        {
            return name;
        }

        public string getRole()
        {
            return role;
        }

        public DateTime GetCreationDate()
        {
            return creationDate;
        }

        /*
         * Returns an account associated with the admin account used for testing individual features of the program
         */
        public static Account TestAccount()
        {
            Account testAccount = new Account(5, "admin", "testing@test.com", "Admin", "staff", DateTime.Now);
            return testAccount;
        }
    }
}
