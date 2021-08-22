using AngleSharp.Dom;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(Name), IsUnique = true)]
    class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IElement CarSubmodelsElement { get; set; }

        public List<CarSubmodel> CarSubmodels { get; set; }
    }
}
