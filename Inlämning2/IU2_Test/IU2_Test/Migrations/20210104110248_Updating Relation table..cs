namespace IU2_Test.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdatingRelationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_DoorTypes_doorTypeIDID",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Events_eventIDID",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Tenants_tenantIDID",
                table: "Relations");

            migrationBuilder.RenameColumn(
                name: "tenantIDID",
                table: "Relations",
                newName: "tenantID");

            migrationBuilder.RenameColumn(
                name: "eventIDID",
                table: "Relations",
                newName: "eventTypeID");

            migrationBuilder.RenameColumn(
                name: "doorTypeIDID",
                table: "Relations",
                newName: "doorTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_tenantIDID",
                table: "Relations",
                newName: "IX_Relations_tenantID");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_eventIDID",
                table: "Relations",
                newName: "IX_Relations_eventTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_doorTypeIDID",
                table: "Relations",
                newName: "IX_Relations_doorTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_DoorTypes_doorTypeID",
                table: "Relations",
                column: "doorTypeID",
                principalTable: "DoorTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Events_eventTypeID",
                table: "Relations",
                column: "eventTypeID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Tenants_tenantID",
                table: "Relations",
                column: "tenantID",
                principalTable: "Tenants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_DoorTypes_doorTypeID",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Events_eventTypeID",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Tenants_tenantID",
                table: "Relations");

            migrationBuilder.RenameColumn(
                name: "tenantID",
                table: "Relations",
                newName: "tenantIDID");

            migrationBuilder.RenameColumn(
                name: "eventTypeID",
                table: "Relations",
                newName: "eventIDID");

            migrationBuilder.RenameColumn(
                name: "doorTypeID",
                table: "Relations",
                newName: "doorTypeIDID");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_tenantID",
                table: "Relations",
                newName: "IX_Relations_tenantIDID");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_eventTypeID",
                table: "Relations",
                newName: "IX_Relations_eventIDID");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_doorTypeID",
                table: "Relations",
                newName: "IX_Relations_doorTypeIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_DoorTypes_doorTypeIDID",
                table: "Relations",
                column: "doorTypeIDID",
                principalTable: "DoorTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Events_eventIDID",
                table: "Relations",
                column: "eventIDID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Tenants_tenantIDID",
                table: "Relations",
                column: "tenantIDID",
                principalTable: "Tenants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
