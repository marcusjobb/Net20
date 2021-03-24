using Microsoft.EntityFrameworkCore.Migrations;

namespace HusrumFastigheter2.Migrations
{
    public partial class Log_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Person",
                table: "Tenants",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Tenants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    DoorID = table.Column<long>(type: "INTEGER", nullable: true),
                    EventID = table.Column<long>(type: "INTEGER", nullable: true),
                    TenantID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Logs_Doors_DoorID",
                        column: x => x.DoorID,
                        principalTable: "Doors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Logs_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Logs_Tenants_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_DoorID",
                table: "Logs",
                column: "DoorID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_EventID",
                table: "Logs",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_TenantID",
                table: "Logs",
                column: "TenantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Tenants",
                newName: "Person");
        }
    }
}
