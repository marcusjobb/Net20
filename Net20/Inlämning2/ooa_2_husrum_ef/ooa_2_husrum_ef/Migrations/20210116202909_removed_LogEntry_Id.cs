using Microsoft.EntityFrameworkCore.Migrations;

namespace ooa_2_husrum_ef.Migrations
{
    public partial class removed_LogEntry_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "LogEntries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LogEntries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
