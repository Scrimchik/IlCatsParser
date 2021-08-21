using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(Name), IsUnique = true)]
    class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CarSubmodel> CarSubmodels { get; set; }
    }
}
