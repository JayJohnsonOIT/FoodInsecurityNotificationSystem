using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit;
using MailKit.Net.Smtp;

namespace SendNotificationLibrary
{
    /*
     * Skyler Drake
     * 11/1/22
     * 
     * A class to handle the sending of email to food notification subscribers.
     */
    public class SendEmail
    {
        /*
         * Sends an email to each recipient from a given List of addresses, using the given subject and message.
         */
        public void sendNotification(List<string> emailList, string emailSubject, string emailMessage)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Food Notification System", "csharplabmail@gmail.com"));
                message.Subject = emailSubject;

                foreach (string emailAddress in emailList)
                {
                    message.Bcc.Add(new MailboxAddress("", emailAddress));
                }

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = emailMessage;

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("csharplabmail", "rncyrcvqqnvfdqmp");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
