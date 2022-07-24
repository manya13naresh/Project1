using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.Migrations
{
    public partial class FourthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BillDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_Id",
                table: "BillDetails",
                column: "Id");

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

            migrationBuilder.DropIndex(
                name: "IX_BillDetails_Id",
                table: "BillDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BillDetails");
        }
    }
}
