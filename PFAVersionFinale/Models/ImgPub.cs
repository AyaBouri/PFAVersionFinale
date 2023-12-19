namespace PFAVersionFinale.Models
{
    public class ImgPub
    {
        public int ImgPubId { get; set; }
        public string Chemin { get; set; }
        public List<Publication>? publications { get; set; }
    }
}