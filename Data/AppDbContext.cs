using CoreAngular1.Models;
using Microsoft.EntityFrameworkCore;
using YourApp.Models;

namespace CoreAngular1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserDependencies> UserDependencies { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Users>().ToTable("Users"); // اتصال به جدول SQL
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDependencies>().ToTable("UserDependencies"); // اتصال به جدول SQL
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Warehouses>().ToTable("Warehouses"); // اتصال به جدول SQL
            base.OnModelCreating(modelBuilder);

        }
    }
}
