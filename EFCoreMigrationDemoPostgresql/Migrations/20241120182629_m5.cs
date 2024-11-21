using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMigrationDemoPostgresql.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Waiters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Waiters",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
