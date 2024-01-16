using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quiz_api.Entities.Migrations
{
    public partial class add_max_score : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Quizzes");

            migrationBuilder.AddColumn<int>(
                name: "MaxScore",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_GroupId",
                table: "Quizzes",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Groups_GroupId",
                table: "Quizzes",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Groups_GroupId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_GroupId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "MaxScore",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
