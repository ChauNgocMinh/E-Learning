using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.Infrastructure.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseSubmissionDetail");

            migrationBuilder.DropTable(
                name: "ExerciseSubmission");

            migrationBuilder.DropColumn(
                name: "CorrectOption",
                table: "ExercisesReading");

            migrationBuilder.DropColumn(
                name: "OptionA",
                table: "ExercisesReading");

            migrationBuilder.DropColumn(
                name: "OptionB",
                table: "ExercisesReading");

            migrationBuilder.DropColumn(
                name: "OptionC",
                table: "ExercisesReading");

            migrationBuilder.DropColumn(
                name: "OptionD",
                table: "ExercisesReading");

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "ExercisesReading",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OptionsJson",
                table: "ExercisesReading",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "ExercisesReading",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ExerciseSpeaking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    AudioUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Part = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSpeaking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseSpeaking_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseWriting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromptText = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SampleImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ModelAnswer = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    RubricJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseWriting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseWriting_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalScore = table.Column<short>(type: "smallint", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submission_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    UserInput = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmissionDetail_Submission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSpeaking_ExerciseId",
                table: "ExerciseSpeaking",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWriting_ExerciseId",
                table: "ExerciseWriting",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Submission_ExerciseId",
                table: "Submission",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionDetail_SubmissionId",
                table: "SubmissionDetail",
                column: "SubmissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseSpeaking");

            migrationBuilder.DropTable(
                name: "ExerciseWriting");

            migrationBuilder.DropTable(
                name: "SubmissionDetail");

            migrationBuilder.DropTable(
                name: "Submission");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "ExercisesReading");

            migrationBuilder.DropColumn(
                name: "OptionsJson",
                table: "ExercisesReading");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "ExercisesReading");

            migrationBuilder.AddColumn<string>(
                name: "CorrectOption",
                table: "ExercisesReading",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OptionA",
                table: "ExercisesReading",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OptionB",
                table: "ExercisesReading",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OptionC",
                table: "ExercisesReading",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OptionD",
                table: "ExercisesReading",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ExerciseSubmission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TotalScore = table.Column<short>(type: "smallint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseSubmission_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSubmissionDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseListeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExerciseReadingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SelectedOption = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    SubmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSubmissionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseSubmissionDetail_ExerciseListening_ExerciseListeningId",
                        column: x => x.ExerciseListeningId,
                        principalTable: "ExerciseListening",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExerciseSubmissionDetail_ExerciseSubmission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "ExerciseSubmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSubmissionDetail_ExercisesReading_ExerciseReadingId",
                        column: x => x.ExerciseReadingId,
                        principalTable: "ExercisesReading",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSubmission_ExerciseId",
                table: "ExerciseSubmission",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSubmissionDetail_ExerciseListeningId",
                table: "ExerciseSubmissionDetail",
                column: "ExerciseListeningId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSubmissionDetail_ExerciseReadingId",
                table: "ExerciseSubmissionDetail",
                column: "ExerciseReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSubmissionDetail_SubmissionId",
                table: "ExerciseSubmissionDetail",
                column: "SubmissionId");
        }
    }
}
