using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(Name), IsUnique = true)]
    class Subgroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string PartsUrl { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
