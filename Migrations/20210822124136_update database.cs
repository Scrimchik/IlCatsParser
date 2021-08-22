using Microsoft.EntityFrameworkCore.Migrations;

namespace ilcatsParser.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSubmodels_CarModels_CarModelId",
                table: "CarSubmodels");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_ComplectationModels_ComplectationModelId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ComplectationModelId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_CarSubmodels_ModelCode",
                table: "CarSubmodels");

            migrationBuilder.DropColumn(
                name: "ComplectationModelId",
                table: "Groups");

            migrationBuilder.AlterColumn<string>(
                name: "ModelCode",
                table: "CarSubmodels",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CarModelId",
                table: "CarSubmodels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarSubmodels_ModelCode",
                table: "CarSubmodels",
                column: "ModelCode",
                unique: true,
                filter: "[ModelCode] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CarSubmodels_CarModels_CarModelId",
                table: "CarSubmodels",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSubmodels_CarModels_CarModelId",
                table: "CarSubmodels");

            migrationBuilder.DropIndex(
                name: "IX_CarSubmodels_ModelCode",
                table: "CarSubmodels");

            migrationBuilder.AddColumn<int>(
                name: "ComplectationModelId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModelCode",
                table: "CarSubmodels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarModelId",
                table: "CarSubmodels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ComplectationModelId",
                table: "Groups",
                column: "ComplectationModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarSubmodels_ModelCode",
                table: "CarSubmodels",
                column: "ModelCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarSubmodels_CarModels_CarModelId",
                table: "CarSubmodels",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_ComplectationModels_ComplectationModelId",
                table: "Groups",
                column: "ComplectationModelId",
                principalTable: "ComplectationModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
