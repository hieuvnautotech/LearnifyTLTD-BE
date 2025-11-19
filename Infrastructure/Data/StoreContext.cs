using Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>()
            .HasMany(c => c.Courses)
            .WithOne(c => c.Category!)
            .HasForeignKey(c => c.CategoryId);
    }
}
