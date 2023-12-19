using Microsoft.AspNetCore.Mvc;
using PFAVersionFinale.Models;
namespace PFAVersionFinale.Controllers
{
    public class MessagesController : Controller
    {
        MyContexte db;
        public MessagesController(MyContexte db)
        {
            this.db = db;
        }
        public IActionResult IndexMessages()
        {
            List<Message> messages = db.Messages.ToList();
            return View(messages);
        }
        public IActionResult AddMessages()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMessages(Message message)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("IndexMessage");
            }
            return View();
        }
        public IActionResult EditMessage(int id)
        {
            Message message = db.Messages.Where(msg => msg.MessageId == id).FirstOrDefault();
            if (message != null)
            {
                return View(message);
            }
            return RedirectToAction("IndexMessage");
        }
        [HttpPost]
        public IActionResult EditMessage(Message model)
        {
            if (ModelState.IsValid)
            {
                Message message = db.Messages.Where(msg => msg.MessageId == model.MessageId).FirstOrDefault();
                if (message != null)
                {
                    message.Contenu = model.Contenu;
                    db.SaveChanges();
                    return RedirectToAction("IndexMessage");
                }
            }
            return View();
        }
        public IActionResult DeleteMessage(int id)
        {
            Message message = db.Messages.Where(msg => msg.MessageId == id).FirstOrDefault();
            if(message != null)
            {
                db.Messages.Remove(message);
                db.SaveChanges();
            }
            return RedirectToAction("IndexMessage");
        }
    }
}