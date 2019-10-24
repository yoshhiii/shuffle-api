using Microsoft.EntityFrameworkCore.Migrations;

namespace Shuffle.Data.Migrations
{
    public partial class added_active_to_team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Team",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Team");
        }
    }
}
