using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SprintManager.Data.Migrations
{
    public partial class AlterSprint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Sprints",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Sprints");
        }
    }
}
