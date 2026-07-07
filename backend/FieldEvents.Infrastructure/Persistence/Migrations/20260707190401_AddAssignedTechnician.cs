using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FieldEvents.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAssignedTechnician : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedTechnician",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedTechnician",
                table: "Events");
        }
    }
}
