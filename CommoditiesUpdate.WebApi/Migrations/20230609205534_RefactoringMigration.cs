using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommoditiesUpdate.WebApi.Migrations
{
    public partial class RefactoringMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Commodities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Commodities");
        }
    }
}
