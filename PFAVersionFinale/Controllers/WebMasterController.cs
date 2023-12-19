using Microsoft.AspNetCore.Mvc;
using PFAVersionFinale.Models;

namespace PFAVersionFinale.Controllers
{
    public class WebMasterController : Controller
    {
        MyContexte db;
        public WebMasterController(MyContexte db)
        {
            this.db = db;
        }
        public IActionResult IndexWebMaster()
        {
            List<WebMaster> webMasters = db.WebMasters.ToList();
            return View(webMasters);
        }
        public IActionResult AddWebMaster()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWebMaster(WebMaster webMaster)
        {
            if(ModelState.IsValid)
            {
                db.WebMasters.Add(webMaster);
                db.SaveChanges();
                return RedirectToAction("IndexWebMaster");
            }
           return View();
        }
        public IActionResult EditWebMaster(int id)
        {
            WebMaster webMaster = db.WebMasters.Where(web => web.WebMasterId == id).FirstOrDefault();
            if (webMaster != null)
            {
                return View(webMaster);
            }
            return RedirectToAction("IndexWebMaster");
        }
        [HttpPost]
        public IActionResult EditWebMaster(WebMaster model)
        {
            if (ModelState.IsValid)
            {
                WebMaster webMaster = db.WebMasters.Where(web => web.WebMasterId == model.WebMasterId).FirstOrDefault();
                if(webMaster != null)
                {
                    webMaster.nom = model.nom;
                    webMaster.prenom = model.prenom;
                    webMaster.telephone = model.telephone;
                    webMaster.email = model.email;
                    webMaster.ville = model.ville;
                    webMaster.PublicationId = model.PublicationId;
                    db.SaveChanges();
                    return RedirectToAction("IndexWebMaster");
                }
            }
            return View();
        }
        public IActionResult DeleteWebMaster(int id)
        {
            WebMaster web = db.WebMasters.Where(web => web.WebMasterId == id).FirstOrDefault();
            if (web != null)
            {
                db.WebMasters.Remove(web);
                db.SaveChanges();
            }
            return RedirectToAction("IndexWeb");
        }
    }
}