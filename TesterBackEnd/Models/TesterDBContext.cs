using Microsoft.EntityFrameworkCore;

namespace TesterBackEnd.Models
{
    public partial class TesterDBContext : DbContext
    {

        public TesterDBContext(DbContextOptions<TesterDBContext> options) : base(options) { }

        public virtual DbSet<Project> Projects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(k => k.Id);

            });
            OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
