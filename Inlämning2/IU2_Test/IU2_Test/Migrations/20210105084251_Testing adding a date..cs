using Microsoft.EntityFrameworkCore.Migrations;

namespace IU2_Test.Migrations
{
    public partial class Testingaddingadate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Relations",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Relations");
        }
    }
}
