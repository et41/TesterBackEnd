using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;


namespace TesterBackEnd.Models
{
    public partial class TesterDBContext : DbContext
    {
        public TesterDBContext(DbContextOptions<TesterDBContext> options) : base(options) { }

        public virtual DbSet<Project> Project { get; set; }

        public virtual DbSet<Transformer> Transformer { get; set; }

        public virtual DbSet<ActiveTestReport> ActiveTestReport { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Project entity
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.HasMany(p => p.Transformers)
                      .WithOne(t => t.Project)
                      .HasForeignKey(t => t.ProjectId);
            });

            // Configure the Transformer entity
            modelBuilder.Entity<Transformer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(t => t.Project)
                      .WithMany(p => p.Transformers)
                      .HasForeignKey(t => t.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(t => t.ActiveTestReports).WithOne(a => a.Transformer).HasForeignKey(a => a.TransformerId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ActiveTestReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(a => a.Transformer)
                      .WithMany(t => t.ActiveTestReports)
                      .HasForeignKey(a => a.TransformerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            /*
            //modelBuilder.Entity<HvResistance>()
             .HasOne(hr => hr.ActiveTestReport)
             .WithMany(atr => atr.HvResistances)
            .HasForeignKey(hr => hr.ActiveTestReportId)
               .OnDelete(DeleteBehavior.Cascade);
            */


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
