using Microsoft.AspNetCore.Mvc;
using PFAVersionFinale.Models;
namespace PFAVersionFinale.Controllers
{
    public class VoteController : Controller
    {
        MyContexte db;
        public VoteController(MyContexte db)
        {
            this.db = db;
        }
        public IActionResult IndexVote()
        {
            List<Vote> votes = db.Votes.ToList();
            return View(votes);
        }
        public IActionResult AddVote()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVote(Vote vote)
        {
            if (ModelState.IsValid)
            {
                db.Votes.Add(vote);
                db.SaveChanges();
                return RedirectToAction("IndexVote");
            }
            return View();
        }
        [Route("Vote/EditVotes/{id}")]
        public IActionResult EditVotes(int id)
        {
            Vote vote = db.Votes.Where(vte => vte.VoteId == id).FirstOrDefault();
            if (vote != null)
            {
                return View(vote);
            }
            return View();
        }
        [HttpPost]
        public IActionResult EditVote(Vote model) 
        {
            if (ModelState.IsValid)
            {
                Vote vote = db.Votes.Where(vte => vte.VoteId == model.VoteId).FirstOrDefault();
                if(vote != null)
                {
                    vote.NoteVote = model.NoteVote;
                    db.SaveChanges();
                    return RedirectToAction("IndexVote");
                }
            }
            return View();
        }
        [Route("Vote/DeleteVote/{id}")]
        public IActionResult DeleteVote(int id)
        {
            Vote vote = db.Votes.Where(vte => vte.VoteId == id).FirstOrDefault();
            if(vote != null)
            {
                db.Votes.Remove(vote);
                db.SaveChanges();
            }
            return RedirectToAction("IndexVote");
        }
    }
}