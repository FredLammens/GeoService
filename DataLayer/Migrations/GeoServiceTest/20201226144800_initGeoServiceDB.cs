using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.GeoServiceTest
{
    public partial class initGeoServiceDB : Migration
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
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DCountry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false),
                    Surface = table.Column<float>(type: "real", nullable: false),
                    DContinentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCountry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DCountry_Continents_DContinentId",
                        column: x => x.DContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DCity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false),
                    DCountryId = table.Column<long>(type: "bigint", nullable: true),
                    DCountryId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DCity_DCountry_DCountryId",
                        column: x => x.DCountryId,
                        principalTable: "DCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DCity_DCountry_DCountryId1",
                        column: x => x.DCountryId1,
                        principalTable: "DCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DCountryDRiver",
                columns: table => new
                {
                    CountriesId = table.Column<long>(type: "bigint", nullable: false),
                    RiversId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCountryDRiver", x => new { x.CountriesId, x.RiversId });
                    table.ForeignKey(
                        name: "FK_DCountryDRiver_DCountry_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "DCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DCountryDRiver_Rivers_RiversId",
                        column: x => x.RiversId,
                        principalTable: "Rivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DCity_DCountryId",
                table: "DCity",
                column: "DCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DCity_DCountryId1",
                table: "DCity",
                column: "DCountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_DCountry_DContinentId",
                table: "DCountry",
                column: "DContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_DCountryDRiver_RiversId",
                table: "DCountryDRiver",
                column: "RiversId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DCity");

            migrationBuilder.DropTable(
                name: "DCountryDRiver");

            migrationBuilder.DropTable(
                name: "DCountry");

            migrationBuilder.DropTable(
                name: "Rivers");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
