using Microsoft.EntityFrameworkCore.Migrations;

namespace HumorWebApp.Data.Migrations
{
    public partial class AddHumorValuesToEvalItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HumorVariable1",
                table: "EvaluationItem");

            migrationBuilder.DropColumn(
                name: "HumorVariable2",
                table: "EvaluationItem");

            migrationBuilder.AddColumn<float>(
                name: "HumorDark",
                table: "EvaluationItem",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HumorImprovisation",
                table: "EvaluationItem",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HumorObservational",
                table: "EvaluationItem",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HumorPhysical",
                table: "EvaluationItem",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HumorPotty",
                table: "EvaluationItem",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HumorSelfDeprecating",
                table: "EvaluationItem",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HumorSurreal",
                table: "EvaluationItem",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HumorWitty",
                table: "EvaluationItem",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HumorWordplay",
                table: "EvaluationItem",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HumorDark",
                table: "EvaluationItem");

            migrationBuilder.DropColumn(
                name: "HumorImprovisation",
                table: "EvaluationItem");

            migrationBuilder.DropColumn(
                name: "HumorObservational",
                table: "EvaluationItem");

            migrationBuilder.DropColumn(
                name: "HumorPhysical",
                table: "EvaluationItem");

            migrationBuilder.DropColumn(
                name: "HumorPotty",
                table: "EvaluationItem");

            migrationBuilder.DropColumn(
                name: "HumorSelfDeprecating",
                table: "EvaluationItem");

            migrationBuilder.DropColumn(
                name: "HumorSurreal",
                table: "EvaluationItem");

            migrationBuilder.DropColumn(
                name: "HumorWitty",
                table: "EvaluationItem");

            migrationBuilder.DropColumn(
                name: "HumorWordplay",
                table: "EvaluationItem");

            migrationBuilder.AddColumn<float>(
                name: "HumorVariable1",
                table: "EvaluationItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HumorVariable2",
                table: "EvaluationItem",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
