using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LindegaardProductions.Web.Business.Helpers
{
    public static class MailHelper
    {
        public static string SendMail(string from, string to, string subject, string body, bool isBodyHtml)
        {
            try
            {
                MailMessage mail = new MailMessage(from, to);

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = isBodyHtml;
                client.Send(mail);

                return string.Empty;
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }
    }
}
