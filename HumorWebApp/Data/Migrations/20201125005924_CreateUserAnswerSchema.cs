using Microsoft.EntityFrameworkCore.Migrations;

namespace HumorWebApp.Data.Migrations
{
    public partial class CreateUserAnswerSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdId = table.Column<string>(nullable: true),
                    EvalItemIdId = table.Column<int>(nullable: true),
                    Answer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswer_EvaluationItem_EvalItemIdId",
                        column: x => x.EvalItemIdId,
                        principalTable: "EvaluationItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAnswer_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_EvalItemIdId",
                table: "UserAnswer",
                column: "EvalItemIdId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_UserIdId",
                table: "UserAnswer",
                column: "UserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnswer");
        }
    }
}
