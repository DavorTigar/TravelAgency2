using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency2.Data.Migrations
{
    /// <inheritdoc />
    public partial class TravelAgency2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aerodrom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeAerodroma = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerodrom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Putovanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeZemlje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImeAerodroma = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putovanja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zemlja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeZemlje = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zemlja", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aerodrom");

            migrationBuilder.DropTable(
                name: "Putovanja");

            migrationBuilder.DropTable(
                name: "Zemlja");
        }
    }
}
