using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffteks.Migrations
{
    public partial class initals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectParticipant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectParticipant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAssigns",
                columns: table => new
                {
                    ParticipantID = table.Column<int>(nullable: false),
                    ProjectID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAssigns", x => new { x.ProjectID, x.ParticipantID });
                    table.ForeignKey(
                        name: "FK_ProjectAssigns_ProjectParticipant_ParticipantID",
                        column: x => x.ParticipantID,
                        principalTable: "ProjectParticipant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectAssigns_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssigns_ParticipantID",
                table: "ProjectAssigns",
                column: "ParticipantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectAssigns");

            migrationBuilder.DropTable(
                name: "ProjectParticipant");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
