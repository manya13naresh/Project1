using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.Migrations
{
    public partial class SixthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BillDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_UserId",
                table: "BillDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_Users_UserId",
                table: "BillDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_Users_UserId",
                table: "BillDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetails_UserId",
                table: "BillDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BillDetails");
        }
    }
}
