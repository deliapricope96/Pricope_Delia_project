using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pricope_Delia_project.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriereProdus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descriere",
                table: "Produs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriere",
                table: "Produs");
        }
    }
}
