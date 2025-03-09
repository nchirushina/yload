using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyYTLoader.DAL.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class addStateToVideoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Videos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Videos");
        }
    }
}
