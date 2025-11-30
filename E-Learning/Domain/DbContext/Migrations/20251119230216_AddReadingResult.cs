using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.Infrastructure.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class AddReadingResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ExerciseListeningId",
                table: "ExerciseSubmissionDetail",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ExerciseReadingId",
                table: "ExerciseSubmissionDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSubmissionDetail_ExerciseListeningId",
                table: "ExerciseSubmissionDetail",
                column: "ExerciseListeningId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSubmissionDetail_ExerciseReadingId",
                table: "ExerciseSubmissionDetail",
                column: "ExerciseReadingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSubmissionDetail_ExerciseListening_ExerciseListeningId",
                table: "ExerciseSubmissionDetail",
                column: "ExerciseListeningId",
                principalTable: "ExerciseListening",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSubmissionDetail_ExercisesReading_ExerciseReadingId",
                table: "ExerciseSubmissionDetail",
                column: "ExerciseReadingId",
                principalTable: "ExercisesReading",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSubmissionDetail_ExerciseListening_ExerciseListeningId",
                table: "ExerciseSubmissionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSubmissionDetail_ExercisesReading_ExerciseReadingId",
                table: "ExerciseSubmissionDetail");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseSubmissionDetail_ExerciseListeningId",
                table: "ExerciseSubmissionDetail");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseSubmissionDetail_ExerciseReadingId",
                table: "ExerciseSubmissionDetail");

            migrationBuilder.DropColumn(
                name: "ExerciseReadingId",
                table: "ExerciseSubmissionDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExerciseListeningId",
                table: "ExerciseSubmissionDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
