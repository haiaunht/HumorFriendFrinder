using Microsoft.EntityFrameworkCore.Migrations;

namespace HumorWebApp.Data.Migrations
{
    public partial class CreateEvalItemSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaluationItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    TextContent = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    HumorVariable1 = table.Column<float>(nullable: false),
                    HumorVariable2 = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationItem");
        }
    }
}
