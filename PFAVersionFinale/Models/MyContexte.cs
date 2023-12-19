using Microsoft.EntityFrameworkCore;
namespace PFAVersionFinale.Models
{
    public class MyContexte:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<WebMaster> WebMasters { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Ouvrier> Ouvners { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<ImgPub> ImgPubs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public MyContexte(DbContextOptions<MyContexte> options) : base(options) { }
    }
}