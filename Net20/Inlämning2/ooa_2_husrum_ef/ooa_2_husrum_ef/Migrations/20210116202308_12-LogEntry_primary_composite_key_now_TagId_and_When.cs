using Microsoft.EntityFrameworkCore.Migrations;

namespace ooa_2_husrum_ef.Migrations
{
    public partial class _12LogEntry_primary_composite_key_now_TagId_and_When : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogEntries_Tags_TagId",
                table: "LogEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogEntries",
                table: "LogEntries");

            migrationBuilder.DropIndex(
                name: "IX_LogEntries_TagId",
                table: "LogEntries");

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "LogEntries",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LogEntries",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogEntries",
                table: "LogEntries",
                columns: new[] { "TagId", "When" });

            migrationBuilder.AddForeignKey(
                name: "FK_LogEntries_Tags_TagId",
                table: "LogEntries",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogEntries_Tags_TagId",
                table: "LogEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogEntries",
                table: "LogEntries");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LogEntries",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "LogEntries",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogEntries",
                table: "LogEntries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntries_TagId",
                table: "LogEntries",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogEntries_Tags_TagId",
                table: "LogEntries",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
