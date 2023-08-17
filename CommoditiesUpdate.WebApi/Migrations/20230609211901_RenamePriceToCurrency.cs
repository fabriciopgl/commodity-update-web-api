using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommoditiesUpdate.WebApi.Migrations
{
    public partial class RenamePriceToCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Commodities",
                newName: "Currency");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Commodities",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Commodities",
                newName: "Price");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Commodities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
