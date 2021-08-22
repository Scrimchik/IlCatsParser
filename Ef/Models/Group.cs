using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(Name), IsUnique = true)]
    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string SubgroupsUrl { get; set; }

        public List<Subgroup> Subgroups { get; set; }
    }
}
