using Microsoft.EntityFrameworkCore.Migrations;

namespace HusrumProject.Migrations
{
    public partial class Husrum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoorEvents",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorEvents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DoorLocations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorLocations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DoorNames",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorNames", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenantTag = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    LocationID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tenants_DoorLocations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "DoorLocations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<string>(type: "TEXT", nullable: true),
                    DoorNameID = table.Column<long>(type: "INTEGER", nullable: true),
                    DoorEventID = table.Column<long>(type: "INTEGER", nullable: true),
                    TenantID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventLogs_DoorEvents_DoorEventID",
                        column: x => x.DoorEventID,
                        principalTable: "DoorEvents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventLogs_DoorNames_DoorNameID",
                        column: x => x.DoorNameID,
                        principalTable: "DoorNames",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventLogs_Tenants_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_DoorEventID",
                table: "EventLogs",
                column: "DoorEventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_DoorNameID",
                table: "EventLogs",
                column: "DoorNameID");

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_TenantID",
                table: "EventLogs",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_LocationID",
                table: "Tenants",
                column: "LocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "DoorEvents");

            migrationBuilder.DropTable(
                name: "DoorNames");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "DoorLocations");
        }
    }
}
