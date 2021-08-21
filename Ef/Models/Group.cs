﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ilcatsParser.Ef.Models
{
    [Index(nameof(Name), IsUnique = true)]
    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Subgroup> Subgroups { get; set; }
    }
}
