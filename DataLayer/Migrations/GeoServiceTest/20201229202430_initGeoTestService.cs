using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.GeoServiceTest
{
    public partial class initGeoTestService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rivers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rivers", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false),
                    Surface = table.Column<float>(type: "real", nullable: false),
                    ContinentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Countries_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false),
                    DCountryName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DCountryName1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_DCountryName",
                        column: x => x.DCountryName,
                        principalTable: "Countries",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_DCountryName1",
                        column: x => x.DCountryName1,
                        principalTable: "Countries",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountryRiver",
                columns: table => new
                {
                    CountryName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RiverName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRiver", x => new { x.CountryName, x.RiverName });
                    table.ForeignKey(
                        name: "FK_CountryRiver_Countries_CountryName",
                        column: x => x.CountryName,
                        principalTable: "Countries",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryRiver_Rivers_RiverName",
                        column: x => x.RiverName,
                        principalTable: "Rivers",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_DCountryName",
                table: "Cities",
                column: "DCountryName");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_DCountryName1",
                table: "Cities",
                column: "DCountryName1");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentId",
                table: "Countries",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryRiver_RiverName",
                table: "CountryRiver",
                column: "RiverName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "CountryRiver");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Rivers");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
