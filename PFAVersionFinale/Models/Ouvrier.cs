namespace PFAVersionFinale.Models
{
    public class Ouvrier:User
    {
        public int OuvrierId { get; set; }
        public List<Service>? services { get; set; }
        public Vote vote { get; set; }
        public int VoteId { get; set; } 
    }
}