using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.Migrations
{
    public partial class EightCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Users_UserId",
                table: "BillDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BillDetails",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_BillDetails_UserId",
                table: "BillDetails",
                newName: "IX_BillDetails_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Users_Id",
                table: "BillDetails",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Users_Id",
                table: "BillDetails");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BillDetails",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BillDetails_Id",
                table: "BillDetails",
                newName: "IX_BillDetails_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Users_UserId",
                table: "BillDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
