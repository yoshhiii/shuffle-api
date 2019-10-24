using Microsoft.EntityFrameworkCore.Migrations;

namespace Shuffle.Data.Migrations
{
    public partial class added_color_to_team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Team",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Team");
        }
    }
}
