using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TugasMinggu1.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elemens",
                columns: table => new
                {
                    ElemenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elemens", x => x.ElemenId);
                });

            migrationBuilder.CreateTable(
                name: "Samurais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samurais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Swords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SamuraiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Swords_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElemenSword",
                columns: table => new
                {
                    ElemensElemenId = table.Column<int>(type: "int", nullable: false),
                    SwordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElemenSword", x => new { x.ElemensElemenId, x.SwordsId });
                    table.ForeignKey(
                        name: "FK_ElemenSword_Elemens_ElemensElemenId",
                        column: x => x.ElemensElemenId,
                        principalTable: "Elemens",
                        principalColumn: "ElemenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElemenSword_Swords_SwordsId",
                        column: x => x.SwordsId,
                        principalTable: "Swords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tipes_Swords_SwordId",
                        column: x => x.SwordId,
                        principalTable: "Swords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElemenSword_SwordsId",
                table: "ElemenSword",
                column: "SwordsId");

            migrationBuilder.CreateIndex(
                name: "IX_Swords_SamuraiId",
                table: "Swords",
                column: "SamuraiId");

            migrationBuilder.CreateIndex(
                name: "IX_Tipes_SwordId",
                table: "Tipes",
                column: "SwordId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElemenSword");

            migrationBuilder.DropTable(
                name: "Tipes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Elemens");

            migrationBuilder.DropTable(
                name: "Swords");

            migrationBuilder.DropTable(
                name: "Samurais");
        }
    }
}
