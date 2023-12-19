namespace PFAVersionFinale.Models
{
    public class WebMaster:User
    {
        public int WebMasterId { get; set; }
        public List<Publication>? publications { get; set; }
        public int PublicationId { get; set; }
    }
}