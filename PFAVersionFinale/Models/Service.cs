namespace PFAVersionFinale.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Libelle { get; set; }
        public List<User>? users { get; set; }
    }
}