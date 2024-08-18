using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.netCore_Palma_RealState.Migrations
{
    /// <inheritdoc />
    public partial class ad_t_fav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_favourite",
                columns: table => new
                {
                    ID_favourite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_estate = table.Column<int>(type: "int", nullable: true),
                    id_user = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_favourite", x => x.ID_favourite);
                    table.ForeignKey(
                        name: "FK_T_favourite_AspNetUsers_id_user",
                        column: x => x.id_user,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_T_favourite_T_estate_id_estate",
                        column: x => x.id_estate,
                        principalTable: "T_estate",
                        principalColumn: "ID_estate");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_favourite_id_estate",
                table: "T_favourite",
                column: "id_estate");

            migrationBuilder.CreateIndex(
                name: "IX_T_favourite_id_user",
                table: "T_favourite",
                column: "id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_favourite");
        }
    }
}
