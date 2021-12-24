using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace SpaceTask.Model.Database
{
    public class MovieContext : DbContext
    {
        public IConfiguration Configuration { get; set; }
        public  DbSet<Movies> Movies { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Watchlists> Watchlists { get; set; }
        public MovieContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:ConStr"].ToString());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
