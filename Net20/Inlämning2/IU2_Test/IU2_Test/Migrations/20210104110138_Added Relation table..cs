using Microsoft.EntityFrameworkCore.Migrations;

namespace IU2_Test.Migrations
{
    public partial class AddedRelationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tenantIDID = table.Column<long>(type: "INTEGER", nullable: true),
                    doorTypeIDID = table.Column<int>(type: "INTEGER", nullable: true),
                    eventIDID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Relations_DoorTypes_doorTypeIDID",
                        column: x => x.doorTypeIDID,
                        principalTable: "DoorTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_Events_eventIDID",
                        column: x => x.eventIDID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_Tenants_tenantIDID",
                        column: x => x.tenantIDID,
                        principalTable: "Tenants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relations_doorTypeIDID",
                table: "Relations",
                column: "doorTypeIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_eventIDID",
                table: "Relations",
                column: "eventIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_tenantIDID",
                table: "Relations",
                column: "tenantIDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relations");
        }
    }
}
