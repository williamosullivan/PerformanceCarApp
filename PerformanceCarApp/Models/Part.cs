using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PerformanceCarApp.Models
{
    public class Part
    {
        [Key, Column(Order = 1)]
        public int CarID { get; set;}
        [Key, Column(Order = 2)]
        public int PartID { get; set; }
        public string PartType { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual Exhaust Exhaust { get; set; }
        public virtual Intake Intake { get; set; }
        public virtual EnginePart EnginePart { get; set; }
        public virtual Suspension Suspension { get; set; }
        public virtual Brakes Brakes { get; set; }
    }
}
