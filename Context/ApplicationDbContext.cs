using Microsoft.EntityFrameworkCore;
using StarWars.Entity;

namespace StarWars.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //definitions of tables (table name)
        public DbSet<Pages> Pages { get; set; }
        public DbSet<TopContent> TopContent { get; set; }
        public DbSet<Contacts> Contact { get; set; }
        public DbSet<BottomContent> BottomContent { get; set; }
        public DbSet<Footer> Footer { get; set; }
        public DbSet<AboutContent> AboutContent { get; set; }

    }
}
