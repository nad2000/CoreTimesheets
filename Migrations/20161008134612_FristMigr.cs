using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTimesheets.Migrations
{
    public partial class FristMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "break",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    alternative_code = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    code = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    minutes = table.Column<long>(nullable: false),
                    name = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_break", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    code = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    name = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    description = table.Column<string>(nullable: true),
                    name = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    active = table.Column<long>(nullable: false),
                    email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    first_name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    last_name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    password = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    username = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    workplace_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_company_workplace_id",
                        column: x => x.workplace_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approver_company",
                columns: table => new
                {
                    user_id = table.Column<long>(nullable: false),
                    company_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_approver_company_1", x => new { x.user_id, x.company_id });
                    table.ForeignKey(
                        name: "FK_approver_company_company_company_id",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_approver_company_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entry",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Autoincrement", true),
                    approved_at = table.Column<string>(type: "DATETIME", nullable: true),
                    approver_id = table.Column<long>(nullable: true),
                    break_for_id = table.Column<long>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    date = table.Column<string>(type: "DATE", nullable: false),
                    finished_at = table.Column<string>(type: "TIME", nullable: false),
                    is_approved = table.Column<long>(nullable: false),
                    modified_at = table.Column<string>(type: "DATETIME", nullable: false),
                    started_at = table.Column<string>(type: "TIME", nullable: false),
                    user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entry", x => x.id);
                    table.ForeignKey(
                        name: "FK_entry_user_approver_id",
                        column: x => x.approver_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_entry_break_break_for_id",
                        column: x => x.break_for_id,
                        principalTable: "break",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_entry_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    user_id = table.Column<long>(nullable: false),
                    role_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("sqlite_autoindex_user_role_1", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_user_role_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "approver_company_company_id",
                table: "approver_company",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "approver_company_user_id",
                table: "approver_company",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "break_alternative_code",
                table: "break",
                column: "alternative_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "break_code",
                table: "break",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "entry_approver_id",
                table: "entry",
                column: "approver_id");

            migrationBuilder.CreateIndex(
                name: "entry_break_for_id",
                table: "entry",
                column: "break_for_id");

            migrationBuilder.CreateIndex(
                name: "entry_user_id",
                table: "entry",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "role_name",
                table: "role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_username",
                table: "user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_workplace_id",
                table: "user",
                column: "workplace_id");

            migrationBuilder.CreateIndex(
                name: "user_role_role_id",
                table: "user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "user_role_user_id",
                table: "user_role",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approver_company");

            migrationBuilder.DropTable(
                name: "entry");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "break");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
