using AngleSharp.Dom;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(Code), IsUnique = true)]
    class Part
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string PhotoWay { get; set; }
        [NotMapped]
        public IEnumerable<IElement> SubpartElements { get; set; }

        public int SubgroupId { get; set; }
        public Subgroup Subgroup { get; set; }
        public List<Subpart> Subparts { get; set; }
        public List<ComplectationModel> ComplectationModels { get; set; } = new List<ComplectationModel>();
    }
}
