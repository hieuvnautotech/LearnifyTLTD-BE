using Entity;
using Learnify.Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class LearnifyDbContext : IdentityDbContext<ApplicationUser>
    {
        public LearnifyDbContext(DbContextOptions<LearnifyDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Lecture> Lectures { get; set; } = default!;
        public DbSet<Basket> Baskets { get; set; } = default!;
        public DbSet<BasketItem> BasketItems { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Course - Lecture: 1-n
            builder.Entity<Course>()
                .HasMany(c => c.Lectures)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Basket - BasketItems: 1-n
            builder.Entity<Basket>()
                .HasMany(b => b.Items)
                .WithOne(i => i.Basket)
                .HasForeignKey(i => i.BasketId)
                .OnDelete(DeleteBehavior.Cascade);

            // Order - OrderItems: 1-n
            builder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
