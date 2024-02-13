using Microsoft.EntityFrameworkCore;
using AppUpdatesManager.Infrastructure.Entities;

namespace AppUpdatesManager.Infrastructure.Data
{
    public class AppUpdatesManagerDbContext : DbContext
    {
        public AppUpdatesManagerDbContext(DbContextOptions<AppUpdatesManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUpdateEntity> ApplicationUpdates { get; set; }
        public DbSet<DownloadDetailEntity> DownloadDetails { get; set; }
        public DbSet<SoftwareVersionEntity> SoftwareVersions { get; set; }
        public DbSet<UpdateRequirementEntity> UpdateRequirements { get; set; }
        public DbSet<UpdateStrategyEntity> UpdateStrategies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplicationUpdates
            modelBuilder.Entity<ApplicationUpdateEntity>(entity =>
            {
                entity.HasKey(e => e.ApplicationUpdateId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.PackageName).IsRequired().HasMaxLength(255);
            });

            // DownloadDetails
            modelBuilder.Entity<DownloadDetailEntity>(entity =>
            {
                entity.HasKey(e => e.DownloadDetailId);
                entity.Property(e => e.DownloadUrl).IsRequired();
                entity.HasOne(d => d.CurrentVersion).WithMany().HasForeignKey(d => d.DownloadDetailId);
                entity.HasOne(d => d.RequiredUpdate).WithMany().HasForeignKey(d => d.DownloadDetailId);
            });

            // SoftwareVersions
            modelBuilder.Entity<SoftwareVersionEntity>(entity =>
            {
                entity.HasKey(e => e.SoftwareVersionId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Checksum).IsRequired().HasMaxLength(64);
            });

            // UpdateRequirements
            modelBuilder.Entity<UpdateRequirementEntity>(entity =>
            {
                entity.HasKey(e => e.UpdateRequirementId);
                entity.HasOne(u => u.HardUpdate).WithMany().HasForeignKey(u => u.UpdateRequirementId);
                entity.HasOne(u => u.SoftUpdate).WithMany().HasForeignKey(u => u.UpdateRequirementId);
            });

            // UpdateStrategies
            modelBuilder.Entity<UpdateStrategyEntity>(entity =>
            {
                entity.HasKey(e => e.UpdateStrategyId);
            });
        }
    }
}
