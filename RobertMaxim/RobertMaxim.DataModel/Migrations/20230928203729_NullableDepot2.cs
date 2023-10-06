using Microsoft.EntityFrameworkCore.Migrations;

namespace RobertMaxim.DataModel.Migrations
{
    public partial class NullableDepot2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugUnits_Depots_DepotId",
                table: "DrugUnits");

            migrationBuilder.AlterColumn<string>(
                name: "DepotId",
                table: "DrugUnits",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_DrugUnits_Depots_DepotId",
                table: "DrugUnits",
                column: "DepotId",
                principalTable: "Depots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrugUnits_Depots_DepotId",
                table: "DrugUnits");

            migrationBuilder.AlterColumn<string>(
                name: "DepotId",
                table: "DrugUnits",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DrugUnits_Depots_DepotId",
                table: "DrugUnits",
                column: "DepotId",
                principalTable: "Depots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
