using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {    
        }

        // Database tables
        public DbSet<Project> Projects { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<SemanticVersion> Versions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table names
            modelBuilder.Entity<Project>()
                .ToTable("Project");
            modelBuilder.Entity<Technology>()
                .ToTable("Technology");
            modelBuilder.Entity<SemanticVersion>()
                .ToTable("Version");

            // Relationships
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Technologies)
                .WithMany(t => t.Projects)
                .UsingEntity<Dictionary<string, object>>("ProjectTechnology",
                     pt => pt.HasOne<Technology>().WithMany().HasForeignKey("TechnologyId"),
                     pt => pt.HasOne<Project>().WithMany().HasForeignKey("ProjectId")
                );

            modelBuilder.Entity<Technology>()
                .HasMany(t => t.Versions)
                .WithOne(sv => sv.Technology)
                .HasForeignKey(sv => sv.TechnologyId);
        }
    }
}
