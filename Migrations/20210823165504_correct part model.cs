using Microsoft.EntityFrameworkCore.Migrations;

namespace ilcatsParser.Migrations
{
    public partial class correctpartmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplectationModelPart_Part_PartsId",
                table: "ComplectationModelPart");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_Subgroups_SubgroupId",
                table: "Part");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Part",
                table: "Part");

            migrationBuilder.RenameTable(
                name: "Part",
                newName: "Parts");

            migrationBuilder.RenameIndex(
                name: "IX_Part_SubgroupId",
                table: "Parts",
                newName: "IX_Parts_SubgroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Part_Code",
                table: "Parts",
                newName: "IX_Parts_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parts",
                table: "Parts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplectationModelPart_Parts_PartsId",
                table: "ComplectationModelPart",
                column: "PartsId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Subgroups_SubgroupId",
                table: "Parts",
                column: "SubgroupId",
                principalTable: "Subgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplectationModelPart_Parts_PartsId",
                table: "ComplectationModelPart");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Subgroups_SubgroupId",
                table: "Parts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parts",
                table: "Parts");

            migrationBuilder.RenameTable(
                name: "Parts",
                newName: "Part");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_SubgroupId",
                table: "Part",
                newName: "IX_Part_SubgroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_Code",
                table: "Part",
                newName: "IX_Part_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Part",
                table: "Part",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplectationModelPart_Part_PartsId",
                table: "ComplectationModelPart",
                column: "PartsId",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Subgroups_SubgroupId",
                table: "Part",
                column: "SubgroupId",
                principalTable: "Subgroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
