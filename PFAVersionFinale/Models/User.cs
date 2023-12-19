using System.ComponentModel.DataAnnotations.Schema;

namespace PFAVersionFinale.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string telephone { get; set; }
        public string ville { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        [NotMapped]
        public string photo { get; set; }
        public string role { get; set; }
        public DateTime DateDerniereConnection { get; set; }
        public List<Publication>? publications { get; set; }
        public List<Message>? messages { get; set; }
        public Inscription inscription { get; set; }
        public int InscriptionId { get; set; }
    }
}