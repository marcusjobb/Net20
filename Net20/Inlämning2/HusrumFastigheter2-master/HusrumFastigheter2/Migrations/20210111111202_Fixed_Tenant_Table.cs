using Microsoft.EntityFrameworkCore.Migrations;

namespace HusrumFastigheter2.Migrations
{
    public partial class Fixed_Tenant_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Door",
                table: "Tenants");

            migrationBuilder.AddColumn<long>(
                name: "LocationID",
                table: "Tenants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_LocationID",
                table: "Tenants",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Locations_LocationID",
                table: "Tenants",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Locations_LocationID",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_LocationID",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Tenants");

            migrationBuilder.AddColumn<string>(
                name: "Door",
                table: "Tenants",
                type: "TEXT",
                nullable: true);
        }
    }
}
