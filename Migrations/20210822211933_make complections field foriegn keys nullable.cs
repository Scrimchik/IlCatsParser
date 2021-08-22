using Microsoft.EntityFrameworkCore.Migrations;

namespace ilcatsParser.Migrations
{
    public partial class makecomplectionsfieldforiegnkeysnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplectationModels_CarSubmodels_CarSubmodelId",
                table: "ComplectationModels");

            migrationBuilder.AlterColumn<int>(
                name: "CarSubmodelId",
                table: "ComplectationModels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplectationModels_CarSubmodels_CarSubmodelId",
                table: "ComplectationModels",
                column: "CarSubmodelId",
                principalTable: "CarSubmodels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplectationModels_CarSubmodels_CarSubmodelId",
                table: "ComplectationModels");

            migrationBuilder.AlterColumn<int>(
                name: "CarSubmodelId",
                table: "ComplectationModels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplectationModels_CarSubmodels_CarSubmodelId",
                table: "ComplectationModels",
                column: "CarSubmodelId",
                principalTable: "CarSubmodels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
