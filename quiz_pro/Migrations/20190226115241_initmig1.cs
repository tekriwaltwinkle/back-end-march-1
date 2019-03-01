using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace quiz_pro.Migrations
{
    public partial class initmig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    aID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.aID);
                });

            migrationBuilder.CreateTable(
                name: "quizs",
                columns: table => new
                {
                    qID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    aID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizs", x => x.qID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    uID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phonenumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.uID);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    quID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    CorrectAnswer = table.Column<string>(nullable: true),
                    Answer1 = table.Column<string>(nullable: true),
                    Answer2 = table.Column<string>(nullable: true),
                    Answer3 = table.Column<string>(nullable: true),
                    qID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.quID);
                    table.ForeignKey(
                        name: "FK_questions_quizs_qID",
                        column: x => x.qID,
                        principalTable: "quizs",
                        principalColumn: "qID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scores",
                columns: table => new
                {
                    scoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    marks = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    uID = table.Column<int>(nullable: false),
                    qID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scores", x => x.scoreId);
                    table.ForeignKey(
                        name: "FK_scores_quizs_qID",
                        column: x => x.qID,
                        principalTable: "quizs",
                        principalColumn: "qID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_scores_users_uID",
                        column: x => x.uID,
                        principalTable: "users",
                        principalColumn: "uID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_qID",
                table: "questions",
                column: "qID");

            migrationBuilder.CreateIndex(
                name: "IX_scores_qID",
                table: "scores",
                column: "qID");

            migrationBuilder.CreateIndex(
                name: "IX_scores_uID",
                table: "scores",
                column: "uID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "scores");

            migrationBuilder.DropTable(
                name: "quizs");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
