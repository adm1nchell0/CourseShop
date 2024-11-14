using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CourseShop.Models;

namespace CourseShop.Data
{
    public class MyAppDbContext(DbContextOptions<MyAppDbContext> options) : DbContext(options)
    {

        // DbSet для каждой модели
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Lesson> Lessons { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Связь между User и Order (один ко многим)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            // Связь между Course и Order (один ко многим)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Orders)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);

            // Связь между Course и Lesson (один ко многим)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);

            // Связь между Course и Review (один ко многим)
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId);

            // Связь между User и Review (один ко многим)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            // Связь между Course и Category (многие к одному)
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Courses)
                .WithOne(cc => cc.Category)
                .HasForeignKey(c => c.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}