using Microsoft.EntityFrameworkCore.Migrations;

namespace ilcatsParser.Migrations
{
    public partial class addparttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subgroups_Groups_GroupId",
                table: "Subgroups");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Subgroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubgroupdId = table.Column<int>(type: "int", nullable: false),
                    SubgroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Part_Subgroups_SubgroupId",
                        column: x => x.SubgroupId,
                        principalTable: "Subgroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplectationModelPart",
                columns: table => new
                {
                    ComplectationModelsId = table.Column<int>(type: "int", nullable: false),
                    PartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplectationModelPart", x => new { x.ComplectationModelsId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_ComplectationModelPart_ComplectationModels_ComplectationModelsId",
                        column: x => x.ComplectationModelsId,
                        principalTable: "ComplectationModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplectationModelPart_Part_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Part",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModelPart_PartsId",
                table: "ComplectationModelPart",
                column: "PartsId");

            migrationBuilder.CreateIndex(
                name: "IX_Part_Code",
                table: "Part",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Part_SubgroupId",
                table: "Part",
                column: "SubgroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subgroups_Groups_GroupId",
                table: "Subgroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subgroups_Groups_GroupId",
                table: "Subgroups");

            migrationBuilder.DropTable(
                name: "ComplectationModelPart");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Subgroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Subgroups_Groups_GroupId",
                table: "Subgroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
