using ilcatsParser.Ef.Models;
using ilcatsParser.Ef.Models.ComplectationFields;
using Microsoft.EntityFrameworkCore;

namespace ilcatsParser.Ef
{
    class AppDbContext : DbContext
    {
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarSubmodel> CarSubmodels { get; set; }
        public DbSet<ComplectationModel> ComplectationModels { get; set; }
        public DbSet<ATMOrMTM> ATMOrMTMs { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<DriversPosition> DriversPositions { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<GearShiftType> GearShiftTypes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<NoOfDoors> NoOfDoors { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subgroup> Subgroups { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Subpart> Subparts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
