using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPADemo.CoreEntity.Models
{
    public partial class AngularASPCoreDemoContext : DbContext
    {
        public virtual DbSet<BankAcessorries> BankAcessorries { get; set; }
        public virtual DbSet<BankCategory> BankCategory { get; set; }
        public virtual DbSet<Bike> Bike { get; set; }
        public virtual DbSet<BikeType> BikeType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=ADMIN-PC;Initial Catalog=AngularASPCoreDemo;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAcessorries>(entity =>
            {
                entity.Property(e => e.ProductDescription).IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductCategoryNavigation)
                    .WithMany(p => p.BankAcessorries)
                    .HasForeignKey(d => d.ProductCategory)
                    .HasConstraintName("FK_BankAcessorries_BankCategory");
            });

            modelBuilder.Entity<BankCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bike>(entity =>
            {
                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Bike)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_Bike_BikeType");
            });

            modelBuilder.Entity<BikeType>(entity =>
            {
                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
