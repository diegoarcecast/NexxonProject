using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Nexxon.Models.Security;

namespace Nexxon.ViewModels.Security
{
    public class PasswordRecoveryViewModel
    {
        public void RecoverPassword(ref PasswordRecoveryModel passwordRecoveryModel)
        {
            MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            //mail.To = "user@hotmail.com"; // <-- this one
            //mail.From = "you@yourcompany.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            client.Send(mail);
        }
    }
}
