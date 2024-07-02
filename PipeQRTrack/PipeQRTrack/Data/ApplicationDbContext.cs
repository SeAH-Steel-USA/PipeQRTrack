using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PipeQRTrack.Data
{
    public class AzureDbContext : IdentityDbContext<ApplicationUser>
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options)
            : base(options)
        {
        }

        public DbSet<PipeDetail> PipeDetails { get; set; }


    }

    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options)
            : base(options)
        {
        }

        public DbSet<FloatTableP1TLC2> FloatTableP1TLC2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FloatTableP1TLC2>()
                .ToTable("FloatTableP1TLC2")
                .HasNoKey();
        }


    }

}
