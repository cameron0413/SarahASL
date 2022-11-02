using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SarahASL.data.migrations
{
    public partial class _007_ASLTermModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ASLTerm_AspNetUsers_AslUserId",
                table: "ASLTerm");

            migrationBuilder.AlterColumn<string>(
                name: "AslUserId",
                table: "ASLTerm",
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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ASLTerm_AspNetUsers_AslUserId",
                table: "ASLTerm");

            migrationBuilder.AlterColumn<string>(
                name: "AslUserId",
                table: "ASLTerm",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_ASLTerm_AspNetUsers_AslUserId",
                table: "ASLTerm",
                column: "AslUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
