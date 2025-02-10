using Microsoft.EntityFrameworkCore;

namespace TesterBackEnd.Models
{
    public partial class TesterDBContext : DbContext
    {

        public TesterDBContext(DbContextOptions<TesterDBContext> options) : base(options) { }

        public virtual DbSet<Project> Project { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Transformers)
                      .WithOne(t => t.Project)
                      .HasForeignKey(t => t.ProjectId);
            });

            modelBuilder.Entity<Transformer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Project)
                      .WithMany(p => p.Transformers)
                      .HasForeignKey(e => e.ProjectId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
