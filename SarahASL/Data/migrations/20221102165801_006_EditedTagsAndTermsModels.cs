using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SarahASL.data.migrations
{
    public partial class _006_EditedTagsAndTermsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ASLTerm_AspNetUsers_ASLUserId",
                table: "ASLTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_AspNetUsers_ASLUserId",
                table: "Tag");

            migrationBuilder.RenameColumn(
                name: "ASLUserId",
                table: "Tag",
                newName: "AslUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_ASLUserId",
                table: "Tag",
                newName: "IX_Tag_AslUserId");

            migrationBuilder.RenameColumn(
                name: "ASLUserId",
                table: "ASLTerm",
                newName: "AslUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ASLTerm_ASLUserId",
                table: "ASLTerm",
                newName: "IX_ASLTerm_AslUserId");

            migrationBuilder.AlterColumn<string>(
                name: "AslUserId",
                table: "Tag",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ASLTerm_AspNetUsers_AslUserId",
                table: "ASLTerm",
                column: "AslUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_AspNetUsers_AslUserId",
                table: "Tag",
                column: "AslUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ASLTerm_AspNetUsers_AslUserId",
                table: "ASLTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_AspNetUsers_AslUserId",
                table: "Tag");

            migrationBuilder.RenameColumn(
                name: "AslUserId",
                table: "Tag",
                newName: "ASLUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_AslUserId",
                table: "Tag",
                newName: "IX_Tag_ASLUserId");

            migrationBuilder.RenameColumn(
                name: "AslUserId",
                table: "ASLTerm",
                newName: "ASLUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ASLTerm_AslUserId",
                table: "ASLTerm",
                newName: "IX_ASLTerm_ASLUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ASLUserId",
                table: "Tag",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
    }
}
