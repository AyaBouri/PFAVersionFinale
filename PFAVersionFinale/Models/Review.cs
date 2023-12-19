namespace PFAVersionFinale.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Rating { get; set; }
        public Client client { get; set; }
        public int ClientId { get; set; }
    }
}