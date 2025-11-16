using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.Infrastructure.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class Submit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseSubmission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalScore = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    SubmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseListeningId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SelectedOption = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSubmissionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseSubmissionDetail_ExerciseSubmission_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "ExerciseSubmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSubmission_ExerciseId",
                table: "ExerciseSubmission",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSubmissionDetail_SubmissionId",
                table: "ExerciseSubmissionDetail",
                column: "SubmissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseSubmissionDetail");

            migrationBuilder.DropTable(
                name: "ExerciseSubmission");
        }
    }
}
