using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.Infrastructure.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class AddEssayText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EssayText",
                table: "ExerciseSubmission",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EssayText",
                table: "ExerciseSubmission");
        }
    }
}
