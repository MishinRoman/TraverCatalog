using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using webapi.Data.Models;

namespace webapi.Data
{
    public class PostgresDbContext : IdentityDbContext<User>
    {

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        DbSet<TravelModel> Traverls { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Media> Medias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.ProviderKey);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => x.RoleId);
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => x.Value);
        }
        

    }
}
