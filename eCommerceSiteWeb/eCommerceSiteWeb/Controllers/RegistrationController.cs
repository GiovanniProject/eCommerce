using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerceSiteWeb.Models;
using System.Net.Mail;
using System.Net;

namespace eCommerceSiteWeb.Controllers
{
    public class RegistrationController : Controller
    {
        public eCommerceDBEntitie _db = new eCommerceDBEntitie();
        //
        // GET: /RegistrationUser/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Registration()
        {
       
            return View();

        }

        [HttpPost]
        public ActionResult Registration(UserClass usr)
        {
            string ResultRegistration = null;
            bool result = true;
            usr = new UserClass();
            TryUpdateModel<UserClass>(usr);

            if (ModelState.IsValid)
            {
                int i = 0;
                foreach (var userPresentDB in _db.Users)
                {
                    if ((userPresentDB.FirstName == usr.FirstName) && (userPresentDB.LastName == usr.LastName) && (userPresentDB.Mail == usr.Mail))
                    {
                        ResultRegistration = "Risulti già registrato";
                        result = false;
                        break;
                    }
                    i++;
                }
                if (result == true)
                {
                    Users addUser = new Users();
                    addUser.FirstName = usr.FirstName;
                    addUser.LastName = usr.LastName;
                    addUser.ID = i.ToString();
                    addUser.Mail = usr.Mail;
                    _db.Users.AddObject(addUser);
                    ResultRegistration = "La Registrazione è avvenuta con successo";
                }
                if (ModelState.IsValid)
                {

                    MailMessage msgeme = new MailMessage("UserRegistration@noreply.it", usr.Mail, "Registrazione", "Ciao, la tua registrazione è avvenuta con successo");
                    SmtpClient stmClient = new SmtpClient("stmp.gmail.com", 587);
                    stmClient.EnableSsl = true;
                    stmClient.Credentials = new NetworkCredential("UserRegistration@noreply.it", usr.Password);
                    stmClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    stmClient.Send(msgeme);
                }

                return View(ResultRegistration);
            }
            else
            {
                return View(usr);
            }
            

        }
    }
}
