using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleCRM.Data.Migrations
{
    public partial class UserIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "cst_user_id",
                table: "customer",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "10005, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cst_user_id",
                table: "customer");
        }
    }
}
