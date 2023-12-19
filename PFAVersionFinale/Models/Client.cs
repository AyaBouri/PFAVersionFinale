namespace PFAVersionFinale.Models
{
    public class Client:User
    {

		public int ClientId { get; set; }
        public List<Review>? reviews { get; set; }
        public List<Vote>? votes { get; set; }
        public int VoteId { get; set; }
    }
}