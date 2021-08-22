using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ilcatsParser.Ef.Models.ComplectationFields
{
    [Index(nameof(Value), IsUnique = true)]
    class DefaultComplectationsField
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<ComplectationModel> Complectations { get; set; }
    }
}
