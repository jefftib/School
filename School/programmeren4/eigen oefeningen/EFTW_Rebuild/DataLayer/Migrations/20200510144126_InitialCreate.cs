using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "forestlogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForestId = table.Column<int>(nullable: false),
                    TreeId = table.Column<int>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forestlogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monkeylogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonkeyId = table.Column<int>(nullable: false),
                    MonkeyName = table.Column<string>(nullable: true),
                    ForestId = table.Column<int>(nullable: false),
                    SequenceNumber = table.Column<int>(nullable: false),
                    TreeId = table.Column<int>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monkeylogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "txtLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForestId = table.Column<int>(nullable: false),
                    MonkeyId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_txtLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "forestlogs");

            migrationBuilder.DropTable(
                name: "Monkeylogs");

            migrationBuilder.DropTable(
                name: "txtLogs");
        }
    }
}
