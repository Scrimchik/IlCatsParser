using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(Code), IsUnique = true)]
    class Subpart
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Count { get; set; }
        public string Date { get; set; }
        public string Info { get; set; }

        public int PartId { get; set; }
        public Part Part { get; set; }
        public List<ComplectationModel> ComplectationModels { get; set; } = new List<ComplectationModel>();
    }
}
