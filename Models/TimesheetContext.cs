using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Timesheets.Models
{
    public partial class TimesheetContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlite(@"Filename=./timesheets.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApproverCompany>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CompanyId })
                    .HasName("sqlite_autoindex_approver_company_1");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("approver_company_company_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("approver_company_user_id");
            });

            modelBuilder.Entity<Break>(entity =>
            {
                entity.HasIndex(e => e.AlternativeCode)
                    .HasName("break_alternative_code")
                    .IsUnique();

                entity.HasIndex(e => e.Code)
                    .HasName("break_code")
                    .IsUnique();
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.HasIndex(e => e.ApproverId)
                    .HasName("entry_approver_id");

                entity.HasIndex(e => e.BreakForId)
                    .HasName("entry_break_for_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("entry_user_id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("role_name")
                    .IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("user_username")
                    .IsUnique();

                entity.HasIndex(e => e.WorkplaceId)
                    .HasName("user_workplace_id");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("sqlite_autoindex_user_role_1");

                entity.HasIndex(e => e.RoleId)
                    .HasName("user_role_role_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_role_user_id");
            });
        }

        public virtual DbSet<ApproverCompany> ApproverCompanies { get; set; }
        public virtual DbSet<Break> Breaks { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}