using CoreAngular1.Models;
using Microsoft.EntityFrameworkCore;
using YourApp.Models;

namespace CoreAngular1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CachedUsers> CachedUsers { get; set; }
        public DbSet<CachedUserRoles> CachedUserRoles { get; set; }
        public DbSet<CachedRoles> CachedRoles { get; set; }
        public DbSet<CachedUserDependencies> CachedUserDependencies { get; set; }
        public DbSet<CachedWarehouses> CachedWarehouses { get; set; }




        public DbSet<Departments> Departments { get; set; }

        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<TicketMessages> TicketMessages { get; set; }
        public DbSet<TicketTransfers> TicketTransfers { get; set; }
        public DbSet<TicketAttachments> TicketAttachments { get; set; }
        public DbSet<TicketAccess> TicketAccess { get; set; }


        public DbSet<SystemLogs> SystemLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CachedUsers>().ToTable("CachedUsers");
            modelBuilder.Entity<CachedUserDependencies>().ToTable("CachedUserDependencies");
            modelBuilder.Entity<CachedWarehouses>().ToTable("CachedWarehouses");
            modelBuilder.Entity<CachedUserRoles>().ToTable("CachedUserRoles");
            // تعریف جدول CachedUserRoles
            modelBuilder.Entity<CachedUserRoles>()
                .HasKey(c => new { c.UserId, c.RoleId }); // <-- این مهم است


            modelBuilder.Entity<CachedRoles>().ToTable("CachedRoles");

            modelBuilder.Entity<Departments>().ToTable("Departments");

            modelBuilder.Entity<Tickets>().ToTable("Tickets");
            modelBuilder.Entity<Tickets>()
                        .HasOne(t => t.Creator)
                        .WithMany()
                        .HasForeignKey(t => t.CreatedBy)
                        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TicketMessages>().ToTable("TicketMessages");
            modelBuilder.Entity<TicketTransfers>().ToTable("TicketTransfers");
            modelBuilder.Entity<TicketAttachments>().ToTable("TicketAttachments");
            modelBuilder.Entity<TicketAccess>().ToTable("TicketAccess");


            modelBuilder.Entity<SystemLogs>().ToTable("SystemLogs");


            base.OnModelCreating(modelBuilder);
        }

   
    }
}
