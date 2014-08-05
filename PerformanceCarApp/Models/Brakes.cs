using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PerformanceCarApp.Models
{
    public class Brakes
    {
        [Key]
        public int BrakeID { get; set; }
        public int PartID { get; set; }
        [ForeignKey("PartID")]
        public virtual ICollection<Part> Parts { get; set; }
        public int BrakeWeightSave { get; set; }
        public string BrakeName { get; set; }
    }
}
