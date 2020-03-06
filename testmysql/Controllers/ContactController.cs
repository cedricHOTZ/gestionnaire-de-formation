using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace testmysql.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        /* limiter l'action uniquement à des requetes post*/
        [HttpPost]
        public ActionResult EnvoyerEmail(string nom, string message, string email)
        {
            formulaire formcontact = new formulaire();
            formcontact.Nom = nom;
            formcontact.Message = message;
            formcontact.Email = email;

            using( var context = new Data.formEntities())
            {
                context.formulaire.Add(formcontact);
                context.SaveChanges();
            }


            try
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
        catch
                {

                return View("ErreurEnvoi");
                }
            return View("EnvoyerEmail");
        }
       
    }
}
