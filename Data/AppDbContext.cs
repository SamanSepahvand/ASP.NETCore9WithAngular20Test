using CoreAngular1.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAngular1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users"); // اتصال به جدول SQL
            base.OnModelCreating(modelBuilder);
        }
    }
}
