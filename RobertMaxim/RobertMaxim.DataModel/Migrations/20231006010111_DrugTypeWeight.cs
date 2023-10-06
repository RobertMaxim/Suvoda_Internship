using Microsoft.EntityFrameworkCore.Migrations;

namespace RobertMaxim.DataModel.Migrations
{
    public partial class DrugTypeWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "DrugTypes",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "DrugTypes");
        }
    }
}
