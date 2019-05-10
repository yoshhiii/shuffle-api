using Microsoft.EntityFrameworkCore.Migrations;

namespace Shuffle.Data.Migrations
{
    public partial class addedFcmTokenToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FcmToken",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FcmToken",
                table: "User");
        }
    }
}
