using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Simcrm.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    cst_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cst_user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cst_first_name = table.Column<string>(type: "text", nullable: false),
                    cst_middle_name = table.Column<string>(type: "text", nullable: true),
                    cst_last_name = table.Column<string>(type: "text", nullable: false),
                    cst_dob = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    cst_add_user = table.Column<Guid>(type: "uuid", nullable: false),
                    cst_add_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    cst_change_user = table.Column<Guid>(type: "uuid", nullable: true),
                    cst_change_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.cst_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
