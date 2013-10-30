using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MessageBoard.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string to, string from, string subject, string body)
        {
            try
            {
                var msg = new MailMessage(to, from, subject, body);
                var client = new SmtpClient();
                client.Send(msg);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}