using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.Infrastructure.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submission_Exercise_ExerciseId",
                table: "Submission");

            migrationBuilder.DropTable(
                name: "SubmissionDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Submission",
                table: "Submission");

            migrationBuilder.RenameTable(
                name: "Submission",
                newName: "ExerciseSubmission");

            migrationBuilder.RenameIndex(
                name: "IX_Submission_ExerciseId",
                table: "ExerciseSubmission",
                newName: "IX_ExerciseSubmission_ExerciseId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ExerciseSubmission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ExerciseSubmission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExerciseSubmission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ResultJson",
                table: "ExerciseSubmission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ExerciseSubmission",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ExerciseSubmission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseSubmission",
                table: "ExerciseSubmission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSubmission_Exercise_ExerciseId",
                table: "ExerciseSubmission",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSubmission_Exercise_ExerciseId",
                table: "ExerciseSubmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseSubmission",
                table: "ExerciseSubmission");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ExerciseSubmission");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExerciseSubmission");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExerciseSubmission");

            migrationBuilder.DropColumn(
                name: "ResultJson",
                table: "ExerciseSubmission");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ExerciseSubmission");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ExerciseSubmission");

            migrationBuilder.RenameTable(
                name: "ExerciseSubmission",
                newName: "Submission");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseSubmission_ExerciseId",
                table: "Submission",
                newName: "IX_Submission_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Submission",
                table: "Submission",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SubmissionDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    UserInput = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_SubmissionDetail_SubmissionId",
                table: "SubmissionDetail",
                column: "SubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_Exercise_ExerciseId",
                table: "Submission",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
