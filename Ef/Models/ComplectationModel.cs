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
        public Engine Engine { get; set; }
        public Body Body { get; set; }
        public Grade Grade { get; set; }
        public ATMOrMTM ATMOrMTM { get; set; }
        public GearShiftType GearShiftType { get; set; }
        public DriversPosition DriversPosition { get; set; }
        public NoOfDoors NoOfDoors { get; set; }
        public Destination Destination { get; set; }
        [NotMapped]
        public string GroupUrl { get; set; }

        public CarSubmodel CarSubmodel { get; set; }
        public List<Group> Groups { get; set; }
    }
}
