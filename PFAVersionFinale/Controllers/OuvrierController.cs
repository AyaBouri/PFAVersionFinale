using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFAVersionFinale.Models;

namespace PFAVersionFinale.Controllers
{
    public class OuvrierController : Controller
    {
        MyContexte db;
        public OuvrierController(MyContexte db)
        {
            this.db = db;
        }
        public IActionResult IndexOuvriers()
        {
            return View();
        }
        public IActionResult AddOuvriers()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOuvriers(Ouvrier ouvrier,IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                if (photo.FileName.EndsWith(".jpeg") || photo.FileName.EndsWith(".png") || photo.FileName.EndsWith(".jpg"))
                {
                    ouvrier.photo = photo.FileName;
                    //copier l'image vers le serveur
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image", photo.FileName);
                    var file = new FileStream(path, FileMode.Create);
                    photo.CopyTo(file);
                    db.Ouvners.Add(ouvrier);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        public IActionResult EditOuvriers(int id)
        {
            Ouvrier ouv = db.Ouvners.Where(ouv => ouv.OuvrierId == id).FirstOrDefault();
            if(ouv != null)
            {
                return View(ouv);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult EditOuvriers(Ouvrier model)
        {
            if (ModelState.IsValid)
            {
                Ouvrier ouv = db.Ouvners.Where(ouve => ouve.OuvrierId == model.OuvrierId).FirstOrDefault();
                if(ouv != null)
                {
                    ouv.nom = model.nom;
                    ouv.prenom = model.prenom;
                    ouv.telephone = model.telephone;
                    ouv.email = model.email;
                    ouv.ville = model.ville;
                    ouv.photo = model.photo;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        public IActionResult DeleteOuvriers(int id)
        {
            Ouvrier ouvrier = db.Ouvners.Where(ouv => ouv.OuvrierId == id).FirstOrDefault();
            if (ouvrier != null)
            {
                db.Ouvners.Remove(ouvrier);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}