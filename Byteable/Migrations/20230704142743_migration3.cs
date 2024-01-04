using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Byteable.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CometiitonType",
                table: "RegisterCompetitions",
                newName: "CompetitionType");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PaymentReceipt",
                table: "RegisterCompetitions",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompetitionType",
                table: "RegisterCompetitions",
                newName: "CometiitonType");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PaymentReceipt",
                table: "RegisterCompetitions",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }
    }
}
