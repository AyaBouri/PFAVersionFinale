namespace PFAVersionFinale.Models
{
    public class Publication
    {
        public int PublicationId { get; set; }
        public string Libelle { get; set; }
        public DateTime DatePub { get; set; }
        public string Description { get; set; }
        public string TypePublication { get; set; }
        public List<User>? Users { get; set; }
        public List<WebMaster>? WebMasters { get; set; }
        public List<Ouvrier>? Ouvrier { get; set; }
        public List<Client>? Clients { get; set; }
    }
}