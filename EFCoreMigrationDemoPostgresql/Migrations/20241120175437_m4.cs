using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMigrationDemoPostgresql.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Waiters",
                newName: "nma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nma",
                table: "Waiters",
                newName: "Name");
        }
    }
}
