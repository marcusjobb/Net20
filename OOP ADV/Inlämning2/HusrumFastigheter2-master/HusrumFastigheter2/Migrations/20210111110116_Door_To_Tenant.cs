using Microsoft.EntityFrameworkCore.Migrations;

namespace HusrumFastigheter2.Migrations
{
    public partial class Door_To_Tenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Door",
                table: "Tenants",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Door",
                table: "Tenants");
        }
    }
}
