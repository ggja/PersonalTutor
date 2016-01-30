using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using PersonalTutor.Preferences;


namespace PersonalTutor.Helpers
{
    /// <summary>
    /// Helper for sending emails.
    /// </summary>
    /// <date>17:01 12/01/2015</date>
    /// <author>Anton Liakhovich</author>
    public static class MailHelper
    {
      
        /// <summary>
        /// Send <see cref="MailMessage"/> composed from <paramref name="from"/>, <paramref name="to"/>, 
        /// <paramref name="subject"/> and <paramref name="body"/>.
        /// </summary>
        /// <param name="from"><see cref="string"/> that contains the address of the sender of the e-mail message.</param>
        /// <param name="to"><see cref="string"/> that contains the address of the recipient of the e-mail message.</param>
        /// <param name="subject"><see cref="string"/> that contains the subject text.</param>
        /// <param name="body"><see cref="string"/> that contains the message body.</param>
        /// <param name="prefs"> that  is Smtp server preferences </param>
        /// <exception cref="ArgumentNullException"><paramref name="from"/> is null.-or-<paramref name="to"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="from"/> is <see cref="string.Empty"/> ("").-or-<paramref name="to"/> is <see cref="String.Empty"/> ("").</exception>
        /// <exception cref="FormatException"><paramref name="from"/> or <paramref name="to"/> is malformed.</exception>
        public static void Send(string from, string to, string subject, string body, PreferencesSmtp prefs)
        {
            var message = new MailMessage(from, to, subject, body);
            Send(message, prefs.SmtpServer, prefs.SmtpPort, prefs.SmtpUserName, prefs.SmtpPassword);
        }

        /// <summary>
        /// Send <paramref name="message"/>.
        /// </summary>
        /// <param name="message"><see cref="MailMessage"/> to send.</param>
        /// <param name="smtpServer">address of Smtp Server.</param>
        /// <param name="smtpPort">port of Smtp Server.</param>
        /// <param name="smtpUserName"> login for connect to smtp server</param>
        /// <param name="smtpPassword"> password for connect to smtp server</param>
        /// <exception cref="ArgumentNullException"><paramref name="message" /> is null.</exception>
        /// <exception cref="InvalidOperationException"><see cref="MailMessage.From" /> is null.-or-
        /// There are no recipients specified in <see cref="MailMessage.To" />, <see cref="MailMessage.CC" />, and <see cref="MailMessage.Bcc" /> properties.</exception>
        /// <exception cref="ObjectDisposedException">this object has been disposed.</exception>
        /// <exception cref="SmtpException">the connection to the SMTP server failed.-or- Authentication failed.-or-T he operation timed out.</exception>
        /// <exception cref="SmtpFailedRecipientsException">the <paramref name="message" /> could not be delivered to one or more of the recipients in <see cref="MailMessage.To" />, <see cref="MailMessage.CC" />, or <see cref="MailMessage.Bcc" />.</exception>
        public static void Send(MailMessage message, string smtpServer, int smtpPort, string smtpUserName, string smtpPassword)
        {
            using (var smtp = new SmtpClient(smtpServer, smtpPort))
            {
                if (string.IsNullOrWhiteSpace(smtpUserName))
                {
                    smtp.UseDefaultCredentials = true;
                }
                else
                {
                    smtp.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
                }

                smtp.Send(message);
            }
        }
    }
}
