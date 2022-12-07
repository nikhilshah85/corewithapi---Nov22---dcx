using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DI_Demo.Models.EF
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeptInfo> DeptInfos { get; set; } = null!;
        public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:training-server-nikhil.database.windows.net,1433;Initial Catalog=EmployeeDB;Persist Security Info=False;User ID=trainer;Password=Password@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeptInfo>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PK__DeptInfo__D870D66ED3327A4E");

                entity.ToTable("DeptInfo");

                entity.Property(e => e.DId)
                    .ValueGeneratedNever()
                    .HasColumnName("dId");

                entity.Property(e => e.DLocation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dLocation");

                entity.Property(e => e.DName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dName");
            });

            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.HasKey(e => e.EmpNo)
                    .HasName("PK__Employee__AFB335925CB2F52D");

                entity.ToTable("EmployeeInfo");

                entity.Property(e => e.EmpNo)
                    .ValueGeneratedNever()
                    .HasColumnName("empNo");

                entity.Property(e => e.EmpDept).HasColumnName("empDept");

                entity.Property(e => e.EmpDesignation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("empDesignation");

                entity.Property(e => e.EmpIsPermenant).HasColumnName("empIsPermenant");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("empName");

                entity.Property(e => e.EmpSalary).HasColumnName("empSalary");

                entity.HasOne(d => d.EmpDeptNavigation)
                    .WithMany(p => p.EmployeeInfos)
                    .HasForeignKey(d => d.EmpDept)
                    .HasConstraintName("fk_empDept");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
