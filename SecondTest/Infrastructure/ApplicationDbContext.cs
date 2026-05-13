namespace SecondTest.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using SecondTest.Entities;
    using SecondTest.Infrastructure.Interfaces;

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet<T> properties here for your aggregate roots / entities, for example:
        public DbSet<Product> Products => Set<Product>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity mappings here, for example:
             modelBuilder.Entity<Product>(b => { b.ToTable("Products"); b.HasKey(x => x.Id); });
        }
    }
}
