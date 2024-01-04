using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Byteable.Migrations
{
    /// <inheritdoc />
    public partial class DTOchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_CompetitionType",
                table: "RegisterCompetitions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_CompetitionType",
                table: "RegisterCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
