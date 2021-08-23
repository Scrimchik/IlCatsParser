using Microsoft.EntityFrameworkCore.Migrations;

namespace ilcatsParser.Migrations
{
    public partial class addsubparttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subparts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subparts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subparts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplectationModelSubpart",
                columns: table => new
                {
                    ComplectationModelsId = table.Column<int>(type: "int", nullable: false),
                    SubpartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplectationModelSubpart", x => new { x.ComplectationModelsId, x.SubpartsId });
                    table.ForeignKey(
                        name: "FK_ComplectationModelSubpart_ComplectationModels_ComplectationModelsId",
                        column: x => x.ComplectationModelsId,
                        principalTable: "ComplectationModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplectationModelSubpart_Subparts_SubpartsId",
                        column: x => x.SubpartsId,
                        principalTable: "Subparts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModelSubpart_SubpartsId",
                table: "ComplectationModelSubpart",
                column: "SubpartsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subparts_Code",
                table: "Subparts",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Subparts_PartId",
                table: "Subparts",
                column: "PartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplectationModelSubpart");

            migrationBuilder.DropTable(
                name: "Subparts");
        }
    }
}
