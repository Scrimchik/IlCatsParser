// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ilcatsParser.Ef;

namespace ilcatsParser.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210823165743_correct part model again")]
    partial class correctpartmodelagain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComplectationModelPart", b =>
                {
                    b.Property<int>("ComplectationModelsId")
                        .HasColumnType("int");

                    b.Property<int>("PartsId")
                        .HasColumnType("int");

                    b.HasKey("ComplectationModelsId", "PartsId");

                    b.HasIndex("PartsId");

                    b.ToTable("ComplectationModelPart");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.CarSubmodel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("Complectations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("ModelCode")
                        .IsUnique()
                        .HasFilter("[ModelCode] IS NOT NULL");

                    b.ToTable("CarSubmodels");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.ATMOrMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasFilter("[Value] IS NOT NULL");

                    b.ToTable("ATMOrMTMs");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.Body", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasFilter("[Value] IS NOT NULL");

                    b.ToTable("Bodies");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasFilter("[Value] IS NOT NULL");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.DriversPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasFilter("[Value] IS NOT NULL");

                    b.ToTable("DriversPositions");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasFilter("[Value] IS NOT NULL");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.GearShiftType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasFilter("[Value] IS NOT NULL");

                    b.ToTable("GearShiftTypes");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasFilter("[Value] IS NOT NULL");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.NoOfDoors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Value")
                        .IsUnique()
                        .HasFilter("[Value] IS NOT NULL");

                    b.ToTable("NoOfDoors");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ATMOrMTMId")
                        .HasColumnType("int");

                    b.Property<int?>("BodyId")
                        .HasColumnType("int");

                    b.Property<int>("CarSubmodelId")
                        .HasColumnType("int");

                    b.Property<string>("Complectation")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int?>("DriversPositionId")
                        .HasColumnType("int");

                    b.Property<int?>("EngineId")
                        .HasColumnType("int");

                    b.Property<int?>("GearShiftTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("GradeId")
                        .HasColumnType("int");

                    b.Property<int?>("NoOfDoorsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ATMOrMTMId");

                    b.HasIndex("BodyId");

                    b.HasIndex("CarSubmodelId");

                    b.HasIndex("Complectation")
                        .IsUnique()
                        .HasFilter("[Complectation] IS NOT NULL");

                    b.HasIndex("DestinationId");

                    b.HasIndex("DriversPositionId");

                    b.HasIndex("EngineId");

                    b.HasIndex("GearShiftTypeId");

                    b.HasIndex("GradeId");

                    b.HasIndex("NoOfDoorsId");

                    b.ToTable("ComplectationModels");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubgroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("SubgroupId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.Subgroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Subgroups");
                });

            modelBuilder.Entity("ComplectationModelPart", b =>
                {
                    b.HasOne("ilcatsParser.Ef.Models.ComplectationModel", null)
                        .WithMany()
                        .HasForeignKey("ComplectationModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ilcatsParser.Ef.Models.Part", null)
                        .WithMany()
                        .HasForeignKey("PartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.CarSubmodel", b =>
                {
                    b.HasOne("ilcatsParser.Ef.Models.CarModel", "CarModel")
                        .WithMany("CarSubmodels")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationModel", b =>
                {
                    b.HasOne("ilcatsParser.Ef.Models.ComplectationFields.ATMOrMTM", "ATMOrMTM")
                        .WithMany("Complectations")
                        .HasForeignKey("ATMOrMTMId");

                    b.HasOne("ilcatsParser.Ef.Models.ComplectationFields.Body", "Body")
                        .WithMany("Complectations")
                        .HasForeignKey("BodyId");

                    b.HasOne("ilcatsParser.Ef.Models.CarSubmodel", "CarSubmodel")
                        .WithMany("ComplectationModels")
                        .HasForeignKey("CarSubmodelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ilcatsParser.Ef.Models.ComplectationFields.Destination", "Destination")
                        .WithMany("Complectations")
                        .HasForeignKey("DestinationId");

                    b.HasOne("ilcatsParser.Ef.Models.ComplectationFields.DriversPosition", "DriversPosition")
                        .WithMany("Complectations")
                        .HasForeignKey("DriversPositionId");

                    b.HasOne("ilcatsParser.Ef.Models.ComplectationFields.Engine", "Engine")
                        .WithMany("Complectations")
                        .HasForeignKey("EngineId");

                    b.HasOne("ilcatsParser.Ef.Models.ComplectationFields.GearShiftType", "GearShiftType")
                        .WithMany("Complectations")
                        .HasForeignKey("GearShiftTypeId");

                    b.HasOne("ilcatsParser.Ef.Models.ComplectationFields.Grade", "Grade")
                        .WithMany("Complectations")
                        .HasForeignKey("GradeId");

                    b.HasOne("ilcatsParser.Ef.Models.ComplectationFields.NoOfDoors", "NoOfDoors")
                        .WithMany("Complectations")
                        .HasForeignKey("NoOfDoorsId");

                    b.Navigation("ATMOrMTM");

                    b.Navigation("Body");

                    b.Navigation("CarSubmodel");

                    b.Navigation("Destination");

                    b.Navigation("DriversPosition");

                    b.Navigation("Engine");

                    b.Navigation("GearShiftType");

                    b.Navigation("Grade");

                    b.Navigation("NoOfDoors");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.Part", b =>
                {
                    b.HasOne("ilcatsParser.Ef.Models.Subgroup", "Subgroup")
                        .WithMany()
                        .HasForeignKey("SubgroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subgroup");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.Subgroup", b =>
                {
                    b.HasOne("ilcatsParser.Ef.Models.Group", "Group")
                        .WithMany("Subgroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.CarModel", b =>
                {
                    b.Navigation("CarSubmodels");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.CarSubmodel", b =>
                {
                    b.Navigation("ComplectationModels");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.ATMOrMTM", b =>
                {
                    b.Navigation("Complectations");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.Body", b =>
                {
                    b.Navigation("Complectations");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.Destination", b =>
                {
                    b.Navigation("Complectations");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.DriversPosition", b =>
                {
                    b.Navigation("Complectations");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.Engine", b =>
                {
                    b.Navigation("Complectations");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.GearShiftType", b =>
                {
                    b.Navigation("Complectations");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.Grade", b =>
                {
                    b.Navigation("Complectations");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.ComplectationFields.NoOfDoors", b =>
                {
                    b.Navigation("Complectations");
                });

            modelBuilder.Entity("ilcatsParser.Ef.Models.Group", b =>
                {
                    b.Navigation("Subgroups");
                });
#pragma warning restore 612, 618
        }
    }
}
