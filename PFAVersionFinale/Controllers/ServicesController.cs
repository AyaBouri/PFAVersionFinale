using Microsoft.AspNetCore.Mvc;
using PFAVersionFinale.Models;
namespace PFAVersionFinale.Controllers
{
    public class ServicesController : Controller
    {
        MyContexte db;
        public ServicesController(MyContexte db)
        {
            this.db = db;
        }
        public IActionResult IndexServices()
        {
            List<Service> services = db.Services.ToList();
            return View(services);
        }
        public IActionResult AddServices()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddServices(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [Route("Services/EditServices/{id}")]
        public IActionResult EditServices(int id)
        {
            Service service = db.Services.Where(srv => srv.ServiceId == id).FirstOrDefault();
            if(service != null)
            {
                return View(service);
            }
            return RedirectToAction("IndexServices");
        }
        [HttpPost]
        public IActionResult EditServices(Service model)
        {
            if(ModelState.IsValid)
            {
                Service service = db.Services.Where(srv => srv.ServiceId == model.ServiceId).FirstOrDefault();
                if(service != null)
                {
                    service.Libelle = model.Libelle;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        public IActionResult DeleteServices(int id)
        {
            Service service = db.Services.Where(srv => srv.ServiceId == id).FirstOrDefault();
            if(service != null)
            {
                db.Services.Remove(service);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}