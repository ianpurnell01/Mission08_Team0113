using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission08_Team0113.Migrations
{
    /// <inheritdoc />
    public partial class mission82 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Categories_CategoryId",
                table: "Tables");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tables",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Categories_CategoryId",
                table: "Tables",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Categories_CategoryId",
                table: "Tables");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Tables",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Categories_CategoryId",
                table: "Tables",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
