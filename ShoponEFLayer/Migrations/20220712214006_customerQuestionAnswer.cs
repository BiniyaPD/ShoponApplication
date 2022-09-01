using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoponEFLayer.Migrations
{
    public partial class customerQuestionAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerQueries",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DateOfQuery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false),
                    ProductPid = table.Column<int>(type: "int", nullable: true),
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerQueries", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_CustomerQueries_product_ProductPid",
                        column: x => x.ProductPid,
                        principalTable: "product",
                        principalColumn: "pid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAnswers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerDestription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QuestionForeignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAnswers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_CustomerAnswers_CustomerQueries_QuestionForeignId",
                        column: x => x.QuestionForeignId,
                        principalTable: "CustomerQueries",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAnswers_QuestionForeignId",
                table: "CustomerAnswers",
                column: "QuestionForeignId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerQueries_ProductPid",
                table: "CustomerQueries",
                column: "ProductPid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAnswers");

            migrationBuilder.DropTable(
                name: "CustomerQueries");
        }
    }
}
