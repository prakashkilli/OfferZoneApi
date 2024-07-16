using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class sampleContext : DbContext
    {
        public sampleContext()
        {
        }

        public sampleContext(DbContextOptions<sampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Dept> Depts { get; set; } = null!;
        public virtual DbSet<Emp> Emps { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductSize> ProductSizes { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.200.0.18;Database=sample;User Id=sa;Password=welcome1!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandName).HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.ToTable("dept");

                entity.Property(e => e.Deptid)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("deptid");

                entity.Property(e => e.Deptname)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("deptname");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.ToTable("emp");

                entity.Property(e => e.Empid)
                    .ValueGeneratedNever()
                    .HasColumnName("empid");

                entity.Property(e => e.Deptid)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("deptid");

                entity.Property(e => e.Empname)
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .HasColumnName("empname");

                entity.Property(e => e.Salary)
                    .HasColumnType("money")
                    .HasColumnName("salary");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Emps)
                    .HasForeignKey(d => d.Deptid)
                    .HasConstraintName("FK__emp__deptid__25869641");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageUrl).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Products__BrandI__5441852A");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__534D60F1");
            });

            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductSi__Produ__59FA5E80");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK__ProductSi__SizeI__5AEE82B9");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.SizeName).HasMaxLength(10);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Sizes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Sizes__CategoryI__571DF1D5");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Test");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Mobile)
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.UserName, "UQ__users__66DCF95CFC0A73BE")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__users__AB6E6164F2E57D4C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.PassWord)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("passWord");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
