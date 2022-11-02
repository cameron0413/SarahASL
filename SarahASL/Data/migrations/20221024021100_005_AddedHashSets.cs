using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SarahASL.data.migrations
{
    public partial class _005_AddedHashSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ASLUserId",
                table: "Tag",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ASLUserId",
                table: "ASLTerm",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_ASLUserId",
                table: "Tag",
                column: "ASLUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ASLTerm_ASLUserId",
                table: "ASLTerm",
                column: "ASLUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ASLTerm_AspNetUsers_ASLUserId",
                table: "ASLTerm",
                column: "ASLUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_AspNetUsers_ASLUserId",
                table: "Tag",
                column: "ASLUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ASLTerm_AspNetUsers_ASLUserId",
                table: "ASLTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_AspNetUsers_ASLUserId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_ASLUserId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_ASLTerm_ASLUserId",
                table: "ASLTerm");

            migrationBuilder.DropColumn(
                name: "ASLUserId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "ASLUserId",
                table: "ASLTerm");
        }
    }
}
