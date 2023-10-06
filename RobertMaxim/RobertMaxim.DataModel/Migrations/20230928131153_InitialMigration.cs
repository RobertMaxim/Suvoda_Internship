using Microsoft.EntityFrameworkCore.Migrations;

namespace RobertMaxim.DataModel.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CountryCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depots",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ProvenienceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    SupplierId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Depots_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Depots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrugUnits",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PickNumber = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    DepotId = table.Column<string>(nullable: false),
                    SiteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugUnits_Depots_DepotId",
                        column: x => x.DepotId,
                        principalTable: "Depots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugUnits_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrugUnits_DrugTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DrugTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SupplierId",
                table: "Countries",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Depots_ProvenienceId",
                table: "Depots",
                column: "ProvenienceId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugUnits_DepotId",
                table: "DrugUnits",
                column: "DepotId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugUnits_SiteId",
                table: "DrugUnits",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugUnits_TypeId",
                table: "DrugUnits",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Depots_Countries_ProvenienceId",
                table: "Depots",
                column: "ProvenienceId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Depots_SupplierId",
                table: "Countries");

            migrationBuilder.DropTable(
                name: "DrugUnits");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "DrugTypes");

            migrationBuilder.DropTable(
                name: "Depots");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
