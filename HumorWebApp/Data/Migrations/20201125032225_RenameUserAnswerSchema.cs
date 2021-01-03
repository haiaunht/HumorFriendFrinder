using Microsoft.EntityFrameworkCore.Migrations;

namespace HumorWebApp.Data.Migrations
{
    public partial class RenameUserAnswerSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_EvaluationItem_EvalItemIdId",
                table: "UserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_AspNetUsers_UserIdId",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_EvalItemIdId",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_UserIdId",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "EvalItemIdId",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "UserAnswer");

            migrationBuilder.AddColumn<int>(
                name: "EvalItemId",
                table: "UserAnswer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserAnswer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_EvalItemId",
                table: "UserAnswer",
                column: "EvalItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_UserId",
                table: "UserAnswer",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_EvaluationItem_EvalItemId",
                table: "UserAnswer",
                column: "EvalItemId",
                principalTable: "EvaluationItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_AspNetUsers_UserId",
                table: "UserAnswer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_EvaluationItem_EvalItemId",
                table: "UserAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswer_AspNetUsers_UserId",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_EvalItemId",
                table: "UserAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswer_UserId",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "EvalItemId",
                table: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAnswer");

            migrationBuilder.AddColumn<int>(
                name: "EvalItemIdId",
                table: "UserAnswer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "UserAnswer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_EvalItemIdId",
                table: "UserAnswer",
                column: "EvalItemIdId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_UserIdId",
                table: "UserAnswer",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_EvaluationItem_EvalItemIdId",
                table: "UserAnswer",
                column: "EvalItemIdId",
                principalTable: "EvaluationItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswer_AspNetUsers_UserIdId",
                table: "UserAnswer",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
