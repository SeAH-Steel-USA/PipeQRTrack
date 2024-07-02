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

        public DbSet<PipeDetailP1TLC2> PipeDetailP1TLC2 { get; set; }
        public DbSet<PipeDetailP1TLC1> PipeDetailP1TLC1 { get; set; }
        public DbSet<PipeDetailComplete> PipeDetailComplete { get; set; }


    }

    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options)
            : base(options)
        {
        }

        public DbSet<FloatTableP1TLC2> FloatTableP1TLC2 { get; set; }
        public DbSet<FloatTableP1TLC1> FloatTableP1TLC1 { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FloatTableP1TLC2>()
                .ToTable("FloatTableP1TLC2")
                .HasNoKey();

            modelBuilder.Entity<FloatTableP1TLC1>()
                .ToTable("FloatTableP1TLC1")
                .HasNoKey();
        }



    }

}
