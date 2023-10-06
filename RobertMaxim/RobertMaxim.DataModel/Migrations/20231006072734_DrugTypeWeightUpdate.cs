using Microsoft.EntityFrameworkCore.Migrations;

namespace RobertMaxim.DataModel.Migrations
{
    public partial class DrugTypeWeightUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "DrugTypes",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "DrugTypes",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
