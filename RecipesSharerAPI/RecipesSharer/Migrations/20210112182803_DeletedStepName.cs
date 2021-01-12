using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipesSharer.Migrations
{
    public partial class DeletedStepName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StepName",
                table: "Steps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StepName",
                table: "Steps",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
