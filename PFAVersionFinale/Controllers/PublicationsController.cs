using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFAVersionFinale.Models;
namespace PFAVersionFinale.Controllers
{
    public class PublicationsController : Controller
    {
        MyContexte db;
        public PublicationsController(MyContexte db)
        {
            this.db = db;
        }
        public IActionResult IndexPublication()
        {
            List<Publication> publications = db.Publications.ToList();
            return View(publications);
        }
        public IActionResult AddPublication()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPublication(Publication publication)
        {
            if(ModelState.IsValid)
            {
                db.Publications.Add(publication);
                db.SaveChanges();
                return RedirectToAction("IndexPublication");
            }
            return View();
        }
        public IActionResult EditPublication(int id)
        {
            Publication publication = db.Publications.Where(pub => pub.PublicationId == id).FirstOrDefault();
            if (publication != null)
            {
                return View(publication);
            }
            return RedirectToAction("IndexPublication");
        }
        [HttpPost]
        public IActionResult EditPublication(Publication model)
        {
            if (ModelState.IsValid)
            {
                Publication publication = db.Publications.Where(pub => pub.PublicationId == model.PublicationId).FirstOrDefault();
                if (publication != null)
                {
                    publication.Libelle = model.Libelle;
                    publication.DatePub = model.DatePub;
                    publication.Description = model.Description;
                    db.SaveChanges();
                    return RedirectToAction("IndexPublication");
                }
            }
            return View(model);
        }
        public IActionResult DeletePublication(int id)
        {
            Publication publication = db.Publications.Where(pub => pub.PublicationId == id).FirstOrDefault();
            if (publication != null)
            {
                db.Publications.Remove(publication);
                db.SaveChanges();
            }
            return RedirectToAction("IndexPublication");
        }
    }
}