using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreTimesheets.Models;

namespace CoreTimesheets.Migrations
{
    [DbContext(typeof(TimesheetContext))]
    partial class TimesheetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("CoreTimesheets.Models.ApproverCompany", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.Property<long>("CompanyId")
                        .HasColumnName("company_id");

                    b.HasKey("UserId", "CompanyId")
                        .HasName("sqlite_autoindex_approver_company_1");

                    b.HasIndex("CompanyId")
                        .HasName("approver_company_company_id");

                    b.HasIndex("UserId")
                        .HasName("approver_company_user_id");

                    b.ToTable("approver_company");
                });

            modelBuilder.Entity("CoreTimesheets.Models.Break", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("AlternativeCode")
                        .IsRequired()
                        .HasColumnName("alternative_code")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<long>("Minutes")
                        .HasColumnName("minutes");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("AlternativeCode")
                        .IsUnique()
                        .HasName("break_alternative_code");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasName("break_code");

                    b.ToTable("break");
                });

            modelBuilder.Entity("CoreTimesheets.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("code")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.ToTable("company");
                });

            modelBuilder.Entity("CoreTimesheets.Models.Entry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("ApprovedAt")
                        .HasColumnName("approved_at")
                        .HasColumnType("DATETIME");

                    b.Property<long?>("ApproverId")
                        .HasColumnName("approver_id");

                    b.Property<long?>("BreakForId")
                        .HasColumnName("break_for_id");

                    b.Property<string>("Comment")
                        .HasColumnName("comment");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnName("date")
                        .HasColumnType("DATE");

                    b.Property<string>("FinishedAt")
                        .IsRequired()
                        .HasColumnName("finished_at")
                        .HasColumnType("TIME");

                    b.Property<long>("IsApproved")
                        .HasColumnName("is_approved");

                    b.Property<string>("ModifiedAt")
                        .IsRequired()
                        .HasColumnName("modified_at")
                        .HasColumnType("DATETIME");

                    b.Property<string>("StartedAt")
                        .IsRequired()
                        .HasColumnName("started_at")
                        .HasColumnType("TIME");

                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId")
                        .HasName("entry_approver_id");

                    b.HasIndex("BreakForId")
                        .HasName("entry_break_for_id");

                    b.HasIndex("UserId")
                        .HasName("entry_user_id");

                    b.ToTable("entry");
                });

            modelBuilder.Entity("CoreTimesheets.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("role_name");

                    b.ToTable("role");
                });

            modelBuilder.Entity("CoreTimesheets.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("Active")
                        .HasColumnName("active");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<long>("WorkplaceId")
                        .HasColumnName("workplace_id");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasName("user_username");

                    b.HasIndex("WorkplaceId")
                        .HasName("user_workplace_id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("CoreTimesheets.Models.UserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnName("user_id");

                    b.Property<long>("RoleId")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("sqlite_autoindex_user_role_1");

                    b.HasIndex("RoleId")
                        .HasName("user_role_role_id");

                    b.HasIndex("UserId")
                        .HasName("user_role_user_id");

                    b.ToTable("user_role");
                });

            modelBuilder.Entity("CoreTimesheets.Models.ApproverCompany", b =>
                {
                    b.HasOne("CoreTimesheets.Models.Company", "Company")
                        .WithMany("ApproverCompany")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreTimesheets.Models.User", "User")
                        .WithMany("ApproverCompany")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreTimesheets.Models.Entry", b =>
                {
                    b.HasOne("CoreTimesheets.Models.User", "Approver")
                        .WithMany("EntryApprover")
                        .HasForeignKey("ApproverId");

                    b.HasOne("CoreTimesheets.Models.Break", "BreakFor")
                        .WithMany("Entry")
                        .HasForeignKey("BreakForId");

                    b.HasOne("CoreTimesheets.Models.User", "User")
                        .WithMany("EntryUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreTimesheets.Models.User", b =>
                {
                    b.HasOne("CoreTimesheets.Models.Company", "Workplace")
                        .WithMany("User")
                        .HasForeignKey("WorkplaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreTimesheets.Models.UserRole", b =>
                {
                    b.HasOne("CoreTimesheets.Models.Role", "Role")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreTimesheets.Models.User", "User")
                        .WithMany("UserRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
