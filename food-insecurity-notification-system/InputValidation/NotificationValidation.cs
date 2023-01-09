using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputValidation
{
    /*
    *  Skyler Drake, Maxwell Robinson
    *  11/14/22
    *
    *  This class supplies a method for the validation of input in the subject and message fields, as well as well as
    *  methods that return appropriate error messages to be used in prompts related to validation.
    */
    public class NotificationValidation
    {
        /*
         * This method returns a boolean value based on whether both the subject and message of a user's input 
         * are of valid lengths.
         */
        public static bool isValidNotification(string subject, string message)
        {
            if (subject.Length <= 0 || message.Length <= 0 || subject.Length > 100 || message.Length > 2000)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /*
         * Returns an appropriate string if the subject field's length is outside the proper range.
         */
        public static string subjectError(string subject)
        {
            string errorMessage = "";

            if (subject.Length <= 0)
            {
                errorMessage = "Subject line is empty.";
            }
            else if (subject.Length > 100)
            {
                errorMessage = "Subject is too long. Maximum: 100 characters.";
            }

            return errorMessage;
        }

        /*
         * Returns an appropriate string if the message field's length is outside the proper range.
         */
        public static string messageError(string message)
        {
            string errorMessage = "";

            if (message.Length <= 0)
            {
                errorMessage = "Message is empty.";
            }
            else if (message.Length > 2000)
            {
                errorMessage = "Message is too long. Maximum: 2000 characters.";
            }

            return errorMessage;
        }
    }
}
