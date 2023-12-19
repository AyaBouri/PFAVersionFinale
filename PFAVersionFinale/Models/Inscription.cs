using System.ComponentModel.DataAnnotations;
namespace PFAVersionFinale.Models
{
    public class Inscription
    {
        public int InscriptionId { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Le prenom est obligatoire")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "L'email est obligatoire")]
        public string Login { get; set; }
        public string Email { get; set; }
        [MinLength(6, ErrorMessage = "Le password > 6 caractére")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Les 2 passwords doivent etre equi")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
        //public string Role { get;set; }
        public List<Client>? clients { get; set; }
        public List<Ouvrier>? ouvriners { get; set; }
    }
}