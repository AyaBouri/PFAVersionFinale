using Microsoft.AspNetCore.Mvc;
using PFAVersionFinale.Models;
namespace PFAVersionFinale.Controllers
{
    public class ImgPubController : Controller
    {
        MyContexte db;
        public ImgPubController(MyContexte db)
        {
            this.db = db;
        }
        public IActionResult IndexImgPub()
        {
            List<ImgPub> imgPubs = db.ImgPubs.ToList();
            return View(imgPubs);
        }
        public IActionResult AddImg()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImg(ImgPub imgPub,IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if(image.FileName.EndsWith(".jpeg")||image.FileName.EndsWith(".jpg")||image.FileName.EndsWith(".png") && image.Length< 100000)
                {
                    imgPub.Chemin = image.FileName;
                    //Copier l'image dans le serveur
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image", image.FileName);
                    var file = new FileStream(path, FileMode.Create);
                    //cette methode est capable de copier l'image vers le serveur
                    image.CopyTo(file);
                    db.ImgPubs.Add(imgPub);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            ImgPub imgPub = db.ImgPubs.Where(imgpub => imgpub.ImgPubId == id).FirstOrDefault();
            if (imgPub != null)
            {
                return View(imgPub);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(ImgPub model)
        {
            if (ModelState.IsValid)
            {
                ImgPub imgPub = db.ImgPubs.Where(imgpub => imgpub.ImgPubId == model.ImgPubId).FirstOrDefault();
                if (imgPub != null) 
                {
                    imgPub.Chemin = model.Chemin;
                    imgPub.publications = model.publications;
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            ImgPub imgPub = db.ImgPubs.Where(img => img.ImgPubId == id).FirstOrDefault();
            if(imgPub != null)
            {
                db.ImgPubs.Remove(imgPub);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}