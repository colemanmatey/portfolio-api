using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities.Projects;
using Portfolio.Domain.Entities.Technologies;
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

        public DbSet<ProjectVersion> ProjectVersions { get; set; }
        public DbSet<TechnologyVersion> TechnologyVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table names
            modelBuilder.Entity<Project>()
                .ToTable("Project");
            modelBuilder.Entity<Technology>()
                .ToTable("Technology");
            modelBuilder.Entity<ProjectVersion>()
                .ToTable("ProjectVersion");
            modelBuilder.Entity<TechnologyVersion>()
                .ToTable("TechnologyVersion");

            // Relationships
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Technologies)
                .WithMany(t => t.Projects)
                .UsingEntity<Dictionary<string, object>>("ProjectTechnology",
                     pt => pt.HasOne<Technology>().WithMany().HasForeignKey("TechnologyId"),
                     pt => pt.HasOne<Project>().WithMany().HasForeignKey("ProjectId")
                );

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Versions)
                .WithOne(v => v.Project)
                .HasForeignKey(v => v.ProjectId);

            modelBuilder.Entity<Technology>()
                .HasMany(t => t.Versions)
                .WithOne(v => v.Technology)
                .HasForeignKey(v => v.TechnologyId);


            // Owned type definitions
            modelBuilder.Entity<ProjectVersion>()
                .OwnsOne(pv => pv.Version, sa =>
                {
                    sa.Property(v => v.Major);
                    sa.Property(v => v.Minor);
                    sa.Property(v => v.Patch);
                }); ;

            modelBuilder.Entity<TechnologyVersion>()
                .OwnsOne(tv => tv.Version, sa =>
                {
                    sa.Property(v => v.Major);
                    sa.Property(v => v.Minor);
                    sa.Property(v => v.Patch);
                });
        }
    }
}
