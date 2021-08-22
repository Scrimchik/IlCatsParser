using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(ModelCode), IsUnique = true)]
    class CarSubmodel
    {
        public int Id { get; set; }
        public string ModelCode { get; set; }
        public string Period { get; set; }
        public string Complectations { get; set; }
        [NotMapped]
        public string ComplentationsUrl { get; set; }

        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        public List<ComplectationModel> ComplectationModels { get; set; }
    }
}
