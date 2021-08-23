using ilcatsParser.Ef.Models.ComplectationFields;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(Complectation), IsUnique = true)]
    class ComplectationModel
    {
        public int Id { get; set; }
        public string Complectation { get; set; }
        public string Date { get; set; }
        public int? EngineId { get; set; }
        public Engine Engine { get; set; }
        public int? BodyId { get; set; }
        public Body Body { get; set; }
        public int? GradeId { get; set; }
        public Grade Grade { get; set; }
        public int? ATMOrMTMId { get; set; }
        public ATMOrMTM ATMOrMTM { get; set; }
        public int? GearShiftTypeId { get; set; }
        public GearShiftType GearShiftType { get; set; }
        public int? DriversPositionId { get; set; }
        public DriversPosition DriversPosition { get; set; }
        public int? NoOfDoorsId { get; set; }
        public NoOfDoors NoOfDoors { get; set; }
        public int? DestinationId { get; set; }
        public Destination Destination { get; set; }
        [NotMapped]
        public string GroupUrl { get; set; }

        public int CarSubmodelId { get; set; }
        public CarSubmodel CarSubmodel { get; set; }
        public List<Part> Parts { get; set; }
        public List<Subpart> Subparts { get; set; }
    }
}
