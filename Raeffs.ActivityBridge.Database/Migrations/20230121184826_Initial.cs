using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Raeffs.ActivityBridge.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Actors",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Actors", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Actors",
            columns: new[] { "Id", "Name" },
            values: new object[] { new Guid("1160a7c1-d2cc-48c4-a823-b6f96973df9d"), "bot" });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Actors");
    }
}
