using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademy.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoIncrementToDisciplineId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "number_of_lessons",
                table: "Disciplines",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "number_of_lessons",
                table: "Disciplines",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
