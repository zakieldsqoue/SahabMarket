using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using BL.Util;
namespace SL.Util
{
    public class SendMail
    {
        public Task SendAsync(Message message)
        {
            // Plug in your email service here to send an email.

            var Mmessage = new MailMessage() { From = new MailAddress("market.sahab@gmail.com") };
            Mmessage.To.Add(message.Destination);
            Mmessage.Body = message.MessageContent;
            Mmessage.Subject = message.Subject;
            Mmessage.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = true;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("market.sahab@gmail.com", "M@rket@2018");
            smtp.Timeout = 20000;
            smtp.Send(Mmessage);
            return Task.FromResult(0);
        }
    }
}