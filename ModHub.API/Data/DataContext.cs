using Microsoft.EntityFrameworkCore;
using ModHub.Shared.Entities;
namespace ModHub.API.Data //Carpeta que permite la migracion a la base de datos
{
    
    public class DataContext : DbContext   
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }
        public DbSet<GameCategory> GamesCategories { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Mod> Mods { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Forum> Forums { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Creator> Creators { get; set; }

        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Creator)
                .WithMany(c => c.Reports)
                .HasForeignKey(r => r.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Mod)
                .WithMany(m => m.Reports)
                .HasForeignKey(r => r.ModId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mod>()
                .HasOne(m => m.Creator)
                .WithMany(c => c.Mods)
                .HasForeignKey(m => m.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}
