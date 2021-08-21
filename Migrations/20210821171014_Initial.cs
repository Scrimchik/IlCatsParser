using Microsoft.EntityFrameworkCore.Migrations;

namespace ilcatsParser.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATMOrMTMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATMOrMTMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bodies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriversPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearShiftTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearShiftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoOfDoors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoOfDoors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarSubmodels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelCode = table.Column<long>(type: "bigint", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complectations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSubmodels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarSubmodels_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplectationModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Complectation = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngineId = table.Column<int>(type: "int", nullable: true),
                    BodyId = table.Column<int>(type: "int", nullable: true),
                    GradeId = table.Column<int>(type: "int", nullable: true),
                    ATMOrMTMId = table.Column<int>(type: "int", nullable: true),
                    GearShiftTypeId = table.Column<int>(type: "int", nullable: true),
                    DriversPositionId = table.Column<int>(type: "int", nullable: true),
                    NoOfDoorsId = table.Column<int>(type: "int", nullable: true),
                    DestinationId = table.Column<int>(type: "int", nullable: true),
                    CarSubmodelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplectationModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplectationModels_ATMOrMTMs_ATMOrMTMId",
                        column: x => x.ATMOrMTMId,
                        principalTable: "ATMOrMTMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplectationModels_Bodies_BodyId",
                        column: x => x.BodyId,
                        principalTable: "Bodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplectationModels_CarSubmodels_CarSubmodelId",
                        column: x => x.CarSubmodelId,
                        principalTable: "CarSubmodels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplectationModels_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplectationModels_DriversPositions_DriversPositionId",
                        column: x => x.DriversPositionId,
                        principalTable: "DriversPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplectationModels_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplectationModels_GearShiftTypes_GearShiftTypeId",
                        column: x => x.GearShiftTypeId,
                        principalTable: "GearShiftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplectationModels_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplectationModels_NoOfDoors_NoOfDoorsId",
                        column: x => x.NoOfDoorsId,
                        principalTable: "NoOfDoors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ComplectationModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_ComplectationModels_ComplectationModelId",
                        column: x => x.ComplectationModelId,
                        principalTable: "ComplectationModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subgroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subgroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subgroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_Name",
                table: "CarModels",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarSubmodels_CarModelId",
                table: "CarSubmodels",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarSubmodels_ModelCode",
                table: "CarSubmodels",
                column: "ModelCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModels_ATMOrMTMId",
                table: "ComplectationModels",
                column: "ATMOrMTMId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModels_BodyId",
                table: "ComplectationModels",
                column: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModels_CarSubmodelId",
                table: "ComplectationModels",
                column: "CarSubmodelId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModels_Complectation",
                table: "ComplectationModels",
                column: "Complectation",
                unique: true,
                filter: "[Complectation] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModels_DestinationId",
                table: "ComplectationModels",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModels_DriversPositionId",
                table: "ComplectationModels",
                column: "DriversPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModels_EngineId",
                table: "ComplectationModels",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModels_GearShiftTypeId",
                table: "ComplectationModels",
                column: "GearShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModels_GradeId",
                table: "ComplectationModels",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplectationModels_NoOfDoorsId",
                table: "ComplectationModels",
                column: "NoOfDoorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ComplectationModelId",
                table: "Groups",
                column: "ComplectationModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Subgroups_GroupId",
                table: "Subgroups",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subgroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "ComplectationModels");

            migrationBuilder.DropTable(
                name: "ATMOrMTMs");

            migrationBuilder.DropTable(
                name: "Bodies");

            migrationBuilder.DropTable(
                name: "CarSubmodels");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "DriversPositions");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "GearShiftTypes");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "NoOfDoors");

            migrationBuilder.DropTable(
                name: "CarModels");
        }
    }
}
