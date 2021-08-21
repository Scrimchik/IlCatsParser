using Microsoft.EntityFrameworkCore;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(Name), IsUnique = true)]
    class Subgroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
