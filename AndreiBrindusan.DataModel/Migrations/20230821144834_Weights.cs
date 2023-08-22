using Microsoft.EntityFrameworkCore.Migrations;

namespace AndreiBrindusan.DataModel.Migrations
{
    public partial class Weights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "DrugType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "DrugType");
        }
    }
}
