using Microsoft.AspNetCore.Mvc;
using PFAVersionFinale.Models;
using System.Net.Mail;
using System.Net;
namespace PFAVersionFinale.Controllers
{
    public class UsersController : Controller
    {
        MyContexte db;
        public UsersController(MyContexte db)
        {
            this.db = db;
        }
        public IActionResult IndexUsers()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            string msg = "";
            if (ModelState.IsValid)
            {
                WebMaster wm = db.WebMasters.FirstOrDefault(wb => wb.email == user.email && wb.password == user.password);
                if (wm != null)
                {
                    HttpContext.Session.SetString("Name", user.nom + " " + user.prenom);
                    HttpContext.Session.SetString("Role", "Web MAster");
                    HttpContext.Session.SetString("Id", user.UserId.ToString());
                    return RedirectToAction("../User/WebMaster/Index");
                }
                Client clt = db.Clients.FirstOrDefault(u => u.email == user.email && u.password == user.password);
                if (clt != null)
                {
                    HttpContext.Session.SetString("Name", user.nom + " " + user.prenom);
                    HttpContext.Session.SetString("Role", "Web MAster");
                    HttpContext.Session.SetString("Id", user.UserId.ToString());
                    return RedirectToAction("../User/Client/Index");
                }
                else
                {
                    Ouvrier o = db.Ouvners.FirstOrDefault(s => s.email == user.email && s.password == user.password);
                    if (o != null)
                    {
                        HttpContext.Session.SetString("Name", user.nom + " " + user.prenom);
                        HttpContext.Session.SetString("Role", "Web MAster");
                        HttpContext.Session.SetString("Id", user.UserId.ToString());
                        return RedirectToAction("../User/Ouvrier/Index");
                    }
                }
            }
            msg = "Login/password Incorrecte";
            ViewBag.msg = msg;
            return View();
        }
        public IActionResult Inscription()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Inscription(Inscription inscription)
        {
            if (ModelState.IsValid)
            {
                int count = db.Inscriptions.Where(us => us.Email == inscription.Email).Count();
                //int count = db.users.Where(us => us.Login == inscription.Email).Count();
                if (count == 0)
                {
                    //User user1 = new User(user);
                    db.Inscriptions.Add(inscription);
                    db.SaveChanges();
                    HttpContext.Session.SetString("Nom", inscription.FirstName);
                    HttpContext.Session.SetString("Prenom", inscription.LastName);
                    HttpContext.Session.SetString("Email", inscription.Email);
                    return RedirectToAction("Index", "Inscription");
                }
                ModelState.AddModelError("Login", "Login déja exists!");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        private static string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var password = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }
        public IActionResult forgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult forgotPassword(User user)
        {
            if (ModelState.IsValid)
            {
                int count = db.Users.Where(us => us.email == user.email).Count();
                if (count == 0)
                {
                    //User user = new User(model);
                    user.password = GenerateRandomPassword();
                    db.Users.Add(user);
                    db.Update(user.password);
                    db.SaveChanges();
                    HttpContext.Session.SetString("Nom", user.nom);
                    HttpContext.Session.SetString("Prenom", user.prenom);
                    HttpContext.Session.SetString("Role", user.role);
                    return RedirectToAction("Index", "Inscription");
                }
                ModelState.AddModelError("Login", "Login déja exists!");
            }
            var email = new MailMessage();
            email.From = new MailAddress("votreadresseemail@votredomaine.com");
            email.To.Add(new MailAddress(user.email));
            email.Subject = "Confirmation d'inscription";
            email.Body = "Bonjour " + user.nom + user.prenom + ",<br/><br/>" +
                     "Merci de vous être inscrit sur notre site web. " +
                     "Pour confirmer votre inscription, veuillez cliquer sur le lien suivant :<br/><br/>" +
                     "<a href='" + Url.Action("ConfirmerInscription", "Inscription", new { code = user.InscriptionId }, "http") + "'>Confirmer votre inscription</a><br/><br/>" +
                     "Si vous n'êtes pas à l'origine de cette inscription, ignorez simplement ce message.<br/><br/>" +
                     "Cordialement,<br/>L'équipe de notre site web.";
            var smptClient = new SmtpClient();
            smptClient.Host = "localhost";
            smptClient.Port = 7008;
            smptClient.UseDefaultCredentials = false;
            smptClient.Credentials = new NetworkCredential("votreadresseemail@votredomaine.com", "votre_mot_de_passe");
            smptClient.EnableSsl = true;
            smptClient.Send(email);
            return View("Login", user);
        }
    }
}