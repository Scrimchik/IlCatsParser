using System.Collections.Generic;

namespace ilcatsParser.Ef.Models.ComplectationFields
{
    class DefaultComplectationsField
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<ComplectationModel> Complectations { get; set; }
    }
}
