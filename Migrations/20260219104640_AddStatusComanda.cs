using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pricope_Delia_project.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusComanda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Comanda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Comanda");
        }
    }
}
