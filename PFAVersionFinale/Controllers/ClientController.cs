using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFAVersionFinale.Models;
namespace PFAVersionFinale.Controllers
{
    public class ClientController : Controller
    {
        MyContexte db;
        public ClientController(MyContexte db)
        {
            this.db = db;
        }
        public IActionResult IndexClient()
        {
            List<Client> clients = db.Clients.ToList();
            return View(clients);
        }
        public IActionResult AddClient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClient(Client client,IFormFile photo)
        {
            if(ModelState.IsValid)
            {
                if (photo.FileName.EndsWith(".jpeg") || photo.FileName.EndsWith(".png") || photo.FileName.EndsWith(".jpg"))
                {
                    client.photo = photo.FileName;
                    //copier l'image vers le serveur
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image", photo.FileName);
                    var file = new FileStream(path, FileMode.Create);
                    photo.CopyTo(file);
                    db.Clients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("IndexClient");
                }
            }
            return View();
        }
        public IActionResult EditClient(int id)
        {
            Client client = db.Clients.Where(clt => clt.ClientId == id).FirstOrDefault();
            if (client != null)
            {
                return View(client);
            }
            return RedirectToAction("IndexClient");
        }
        [HttpPost]
        public IActionResult EditClient(Client model)
        {
            if (ModelState.IsValid)
            {
                Client client = db.Clients.Where(clt => clt.ClientId == model.ClientId).FirstOrDefault();
                if (client != null)
                {
                    client.nom = model.nom;
                    client.prenom = model.prenom;
                    client.telephone = model.telephone;
                    client.email = model.email;
                    client.ville = model.ville;
                    client.photo = model.photo;
                    db.SaveChanges();
                    return RedirectToAction("IndexClient");
                }
            }
            return View();
        }
        public IActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Where(clt => clt.ClientId == id).FirstOrDefault();
            if(client != null)
            {
                db.Clients.Remove(client);
                db.SaveChanges();
            }
            return RedirectToAction("IndexClient");
        }
    }
}