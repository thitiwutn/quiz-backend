using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quiz_api.Entities.Migrations
{
    public partial class add_question_choice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    point = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    ChoiceId = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => new { x.QuizId, x.QuestionId, x.ChoiceId });
                    table.ForeignKey(
                        name: "FK_Answers_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreateDate", "GroupId", "Inactive", "QuestionText", "UpdateDate", "order" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "สัตว์น้ำชนิดใดที่มีขนาดใหญ่ที่สุดในโลก", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "สัตว์น้ำชนิดใดที่อาศัยอยู่ในน้ำจืด", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "สัตว์น้ำชนิดใดที่กินเนื้อเป็นอาหาร", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "สัตว์น้ำชนิดใดที่อาศัยอยู่ในทะเลลึก", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "สัตว์น้ำชนิดใดที่กินปลาวาฬเป็นอาหาร", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "สัตว์บกชนิดใดที่มีความสามารถในการบินได้", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "สัตว์บกชนิดใดที่ใหญ่ที่สุดในโลก", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "สัตว์บกชนิดใดที่กินพืชเป็นอาหาร", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "สัตว์บกชนิดใดที่ออกลูกเป็นตัว", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 10, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "สัตว์บกชนิดใดที่อาศัยอยู่ในทะเลทราย", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 11, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "สัตว์ปีกที่บินไม่ได้คืออะไร?", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "สัตว์ปีกที่ออกลูกเป็นไข่คืออะไร?", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "สัตว์ปีกที่อาศัยอยู่ในน้ำคืออะไร?", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "สัตว์ปีกที่กินพืชเป็นอาหารคืออะไร?", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 15, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "สัตว์ปีกที่มีความสำคัญต่อมนุษย์คืออะไร?", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "ChoiceText", "CreateDate", "Inactive", "QuestionId", "UpdateDate", "point" },
                values: new object[,]
                {
                    { 1, "วาฬสีน้ำเงิน", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, "ปลาวาฬสเปิร์ม", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, "ปลาฉลามวาฬ", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, "ปลาฉลามขาว", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, "ปลาดาว", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, "ปลาทอง", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 7, "กุ้งก้ามกราม", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, "เต่า", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, "ปลาฉลาม", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 10, "ปลาโลมา", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 11, "ปลาหมึกยักษ์", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, "ปลากระเบน", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, "ปลาฉลาม", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 14, "ปลาโลมา", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, "ปลาหมึกยักษ์", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 16, "วาฬสเปิร์ม", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, "ปลาฉลามวาฬ", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 18, "ปลาโลมา", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 19, "ปลาหมึกยักษ์", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, "แมงมุมน้ำ", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 21, "นก", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 22, "ค้างคาว", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 23, "กบ", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 24, "สุนัข", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 25, "ช้างแอฟริกัน", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 26, "วัวกระทิง", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 27, "สิงโต", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 28, "ลิงอุรังอุตัง", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 29, "วัว", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 30, "ช้าง", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 31, "ม้า", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 32, "แมว", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 33, "ช้าง", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 34, "วัว", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 35, "ม้า", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 36, "แมว", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 37, "อูฐ", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 38, "ยีราฟ", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 39, "ม้าลาย", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 40, "สิงโต", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 41, "นกกระจอกเทศ", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 11, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 42, "นกแก้ว", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 11, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "ChoiceText", "CreateDate", "Inactive", "QuestionId", "UpdateDate", "point" },
                values: new object[,]
                {
                    { 43, "นกเป็ด", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 11, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 44, "นกยูง", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 11, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 45, "นก", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 46, "ค้างคาว", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 47, "เต่า", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 48, "ปลา", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 49, "นกเป็ดน้ำ", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 13, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 50, "นกกระจอกเทศ", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 13, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 51, "นกแก้ว", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 13, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 52, "นกยูง", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 13, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 53, "นกกระจอกเทศ", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 14, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 54, "นกแก้ว", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 14, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 55, "นกเป็ด", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 14, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 56, "นกยูง", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 14, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 57, "ไก่", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 15, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 58, "นกกระจอกเทศ", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 15, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 59, "นกแก้ว", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 15, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 60, "นกยูง", new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 15, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GroupId",
                table: "Questions",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
