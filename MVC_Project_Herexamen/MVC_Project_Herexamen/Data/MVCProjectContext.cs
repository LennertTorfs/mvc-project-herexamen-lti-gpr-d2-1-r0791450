using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Project_Herexamen.Models;

namespace MVC_Project_Herexamen.Data
{
    public class MVCProjectContext : IdentityDbContext<CustomUser>
    {
        #region Constructor
        public MVCProjectContext(DbContextOptions<MVCProjectContext> options) : base(options) { }
        #endregion

        #region DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<FileAttachment> FileAttachments { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Table Configurations
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Purchase>().ToTable("Purchase");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<FileAttachment>().ToTable("FileAttachment");
            #endregion

            #region Relationship Configurations

            // Relatie tussen Purchase en CustomUser
            modelBuilder.Entity<Purchase>()
               .HasOne(p => p.CustomUser)
               .WithMany(u => u.Purchases)
               .HasForeignKey(p => p.CustomUserId)
               .OnDelete(DeleteBehavior.Cascade);

            // Relatie tussen Purchase en Subject
            modelBuilder.Entity<Purchase>()
                .HasOne(p => p.Subject)
                .WithMany(s => s.Purchases)
                .HasForeignKey(p => p.SubjectId)
                .OnDelete(DeleteBehavior.SetNull);

            // Relatie tussen Product en Purchase
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Purchase)
                .WithMany(pr => pr.Products)
                .HasForeignKey(p => p.PurchaseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
              .Property(p => p.Price)
              .HasPrecision(18, 2);

            // Relatie tussen FileAttachment en Purchase
            modelBuilder.Entity<FileAttachment>()
                .HasOne(fa => fa.Purchase)
                .WithMany(p => p.FileAttachments)
                .HasForeignKey(fa => fa.PurchaseId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
        #endregion
    }
}
