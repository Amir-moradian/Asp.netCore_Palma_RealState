using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netCore_Palma_RealState.Migrations
{
    /// <inheritdoc />
    public partial class adtcat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_category",
                table: "T_estate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "T_category",
                columns: table => new
                {
                    ID_category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tittle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_category", x => x.ID_category);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_estate_id_category",
                table: "T_estate",
                column: "id_category");

            migrationBuilder.AddForeignKey(
                name: "FK_T_estate_T_category_id_category",
                table: "T_estate",
                column: "id_category",
                principalTable: "T_category",
                principalColumn: "ID_category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_estate_T_category_id_category",
                table: "T_estate");

            migrationBuilder.DropTable(
                name: "T_category");

            migrationBuilder.DropIndex(
                name: "IX_T_estate_id_category",
                table: "T_estate");

            migrationBuilder.DropColumn(
                name: "id_category",
                table: "T_estate");
        }
    }
}
