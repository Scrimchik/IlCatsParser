using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(ModelCode), IsUnique = true)]
    class CarSubmodel
    {
        public int Id { get; set; }
        public long ModelCode { get; set; }
        public string Period { get; set; }
        public string Complectations { get; set; }

        public CarModel CarModel { get; set; }
        public List<ComplectationModel> ComplectationModels { get; set; }
    }
}
