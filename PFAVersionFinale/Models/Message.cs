namespace PFAVersionFinale.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Contenu { get; set; }
        public DateTime DateEnvoie { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
    }
}