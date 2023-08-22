using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreiBrindusan.DataModel.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depot",
                columns: table => new
                {
                    DepotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepotName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depot", x => x.DepotId);
                });

            migrationBuilder.CreateTable(
                name: "DrugType",
                columns: table => new
                {
                    DrugTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DrugTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugType", x => x.DrugTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    SiteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.SiteId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepotId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Country_Depot_DepotId",
                        column: x => x.DepotId,
                        principalTable: "Depot",
                        principalColumn: "DepotId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrugUnit",
                columns: table => new
                {
                    DrugUnitId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PickNumber = table.Column<int>(type: "int", nullable: false),
                    DrugUnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepotId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugTypeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugUnit", x => x.DrugUnitId);
                    table.ForeignKey(
                        name: "FK_DrugUnit_DrugType_DrugTypeId",
                        column: x => x.DrugTypeId,
                        principalTable: "DrugType",
                        principalColumn: "DrugTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_DepotId",
                table: "Country",
                column: "DepotId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugUnit_DrugTypeId",
                table: "DrugUnit",
                column: "DrugTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "DrugUnit");

            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "Depot");

            migrationBuilder.DropTable(
                name: "DrugType");
        }
    }
}
