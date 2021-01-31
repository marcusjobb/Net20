using Microsoft.EntityFrameworkCore.Migrations;

namespace ooa_2_husrum_ef.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tenants_TenantId1",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TenantId1",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TenantId1",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TenantId",
                table: "Tags",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tenants_TenantId",
                table: "Tags",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tenants_TenantId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TenantId",
                table: "Tags");

            migrationBuilder.AlterColumn<string>(
                name: "TenantId",
                table: "Tags",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "TenantId1",
                table: "Tags",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TenantId1",
                table: "Tags",
                column: "TenantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tenants_TenantId1",
                table: "Tags",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
