using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleCRM.Data.Migrations
{
    public partial class AddCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    cst_id = table.Column<Guid>(nullable: false),
                    cst_first_name = table.Column<string>(nullable: true),
                    cst_middle_name = table.Column<string>(nullable: true),
                    cst_last_name = table.Column<string>(nullable: true),
                    cst_add_user = table.Column<string>(nullable: true),
                    cst_add_date = table.Column<DateTime>(nullable: false),
                    cst_change_user = table.Column<string>(nullable: true),
                    cst_change_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.cst_id);
                });

            migrationBuilder.CreateTable(
                name: "email_type",
                columns: table => new
                {
                    emt_id = table.Column<Guid>(nullable: false),
                    emt_type = table.Column<string>(nullable: true),
                    emt_add_user = table.Column<string>(nullable: true),
                    emt_add_date = table.Column<DateTime>(nullable: false),
                    emt_change_user = table.Column<string>(nullable: true),
                    emt_change_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_type", x => x.emt_id);
                });

            migrationBuilder.CreateTable(
                name: "email",
                columns: table => new
                {
                    eml_id = table.Column<Guid>(nullable: false),
                    eml_cst_id = table.Column<Guid>(nullable: false),
                    eml_emt_id = table.Column<Guid>(nullable: false),
                    eml_address = table.Column<string>(nullable: true),
                    eml_add_user = table.Column<string>(nullable: true),
                    eml_add_date = table.Column<DateTime>(nullable: false),
                    eml_change_user = table.Column<string>(nullable: true),
                    eml_change_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email", x => x.eml_id);
                    table.ForeignKey(
                        name: "FK_email_customer_eml_cst_id",
                        column: x => x.eml_cst_id,
                        principalTable: "customer",
                        principalColumn: "cst_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_email_email_type_eml_emt_id",
                        column: x => x.eml_emt_id,
                        principalTable: "email_type",
                        principalColumn: "emt_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_email_eml_cst_id",
                table: "email",
                column: "eml_cst_id");

            migrationBuilder.CreateIndex(
                name: "IX_email_eml_emt_id",
                table: "email",
                column: "eml_emt_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "email");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "email_type");
        }
    }
}
