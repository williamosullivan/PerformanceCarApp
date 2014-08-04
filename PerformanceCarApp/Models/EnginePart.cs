using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PerformanceCarApp.Models
{
    public class EnginePart
    {
        [Key]
        public int EnginePartID { get; set; }
        public int PartID { get; set; }
        public int EnginePartHPGain { get; set; }
        public string EnginePartName { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
