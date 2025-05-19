using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModHub.API.Migrations
{
    /// <inheritdoc />
    public partial class ModsNullableCreatorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mods_Creators_CreatorId",
                table: "Mods");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Mods",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CreatorName",
                table: "Mods",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mods_Creators_CreatorId",
                table: "Mods",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mods_Creators_CreatorId",
                table: "Mods");

            migrationBuilder.DropColumn(
                name: "CreatorName",
                table: "Mods");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Mods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mods_Creators_CreatorId",
                table: "Mods",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
