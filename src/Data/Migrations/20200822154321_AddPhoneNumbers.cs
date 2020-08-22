using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleCRM.Data.Migrations
{
    public partial class AddPhoneNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "eml_address",
                table: "email",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cst_last_name",
                table: "customer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cst_first_name",
                table: "customer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "cst_dob",
                table: "customer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "phone_type",
                columns: table => new
                {
                    pht_id = table.Column<Guid>(nullable: false),
                    pht_type = table.Column<string>(nullable: false),
                    pht_add_user = table.Column<Guid>(nullable: false),
                    pht_add_date = table.Column<DateTime>(nullable: false),
                    pht_change_user = table.Column<Guid>(nullable: true),
                    pht_change_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone_type", x => x.pht_id);
                });

            migrationBuilder.CreateTable(
                name: "phone",
                columns: table => new
                {
                    phn_id = table.Column<Guid>(nullable: false),
                    phn_cst_id = table.Column<Guid>(nullable: false),
                    phn_number = table.Column<string>(nullable: false),
                    phn_ext = table.Column<string>(nullable: true),
                    phn_pht_id = table.Column<Guid>(nullable: false),
                    phn_add_user = table.Column<Guid>(nullable: false),
                    phn_add_date = table.Column<DateTime>(nullable: false),
                    phn_change_user = table.Column<Guid>(nullable: true),
                    phn_change_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone", x => x.phn_id);
                    table.ForeignKey(
                        name: "FK_phone_customer_phn_cst_id",
                        column: x => x.phn_cst_id,
                        principalTable: "customer",
                        principalColumn: "cst_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phone_phone_type_phn_pht_id",
                        column: x => x.phn_pht_id,
                        principalTable: "phone_type",
                        principalColumn: "pht_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_phone_phn_cst_id",
                table: "phone",
                column: "phn_cst_id");

            migrationBuilder.CreateIndex(
                name: "IX_phone_phn_pht_id",
                table: "phone",
                column: "phn_pht_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "phone");

            migrationBuilder.DropTable(
                name: "phone_type");

            migrationBuilder.DropColumn(
                name: "cst_dob",
                table: "customer");

            migrationBuilder.AlterColumn<string>(
                name: "eml_address",
                table: "email",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "cst_last_name",
                table: "customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "cst_first_name",
                table: "customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
