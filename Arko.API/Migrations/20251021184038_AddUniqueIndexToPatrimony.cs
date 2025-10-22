using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arko.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToPatrimony : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_Patrimony",
                table: "Equipamentos",
                column: "Patrimony",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_Patrimony",
                table: "Equipamentos");
        }
    }
}
