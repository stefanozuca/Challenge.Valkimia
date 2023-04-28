using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Valkimia.Infrastructure.Migrations.Identity
{
    /// <inheritdoc />
    public partial class AddLastnameProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lastname",
                schema: "Identity",
                table: "Users");
        }
    }
}
