using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace InputValidation
{
    /*
     * Maxwell Robinson
     * 11/12/22
     * 
     * Contains methods to validate user input based on certain preset requirements
     */
    public class AccountValidation
    {
        //Character range for usernames
        public static readonly int usernameMin = 1;
        public static readonly int usernameMax = 50;

        //Character range for passwords
        public static readonly int passwordMin = 8;
        public static readonly int passwordMax = 50;

        //Character range for emails
        public static readonly int emailMin = 6;
        public static readonly int emailMax = 50;

        //Character range for names
        public static readonly int nameMin = 3;
        public static readonly int nameMax = 100;

        /*
         * Validates a string based on the length requirements passed to it.
         * Returns true if the length of the string is greater than min and less than max.
         */
        private static bool validateLength(string text, int min, int max)
        {
            if(text.Length < min || text.Length > max)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
         * Validates a string based on requirements for a username.
         */
        public static bool validateUsername(string text)
        {
            return (validateLength(text, usernameMin, usernameMax));
        }

        /*
         * Validates a string based on requirements for a password.
         */
        public static bool validatePassword(string text)
        {
            if(validateLength(text, passwordMin, passwordMax))
            {
                //Validates format
                if(Regex.IsMatch(text, @"[0-9]+") && Regex.IsMatch(text, @"\p{Lu}+"))
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * Validates a string based on requirements for an email address.
         */
        public static bool validateEmail(string text)
        {
            if(validateLength(text, emailMin, emailMax))
            {
                //Validates format
                if(Regex.IsMatch(text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * Validates a string based on the requirements for a name.
         */
        public static bool validateName(string text)
        {
            return (validateLength(text, nameMin, nameMax));
        }
    }
}
