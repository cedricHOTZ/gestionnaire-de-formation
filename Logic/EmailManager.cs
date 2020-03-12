using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public  class EmailManager
    {
        public void SendEmail(string titre, string message,string email)
        {
           

                //envoyer un email
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress("developpeurweb@cedric-hotz.fr"));
                msg.Subject = "Nouveau message AvisFormations";
                msg.Body = message;
                var client = new SmtpClient
                {
                    Host = "ssl0.ovh.net",
                    Port = 587,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Timeout = 30 * 1000,
                    Credentials = new System.Net.NetworkCredential("developpeurweb@cedric-hotz.fr", "cedric-68")

                };
                client.Send(msg);


            }   
    }
}
