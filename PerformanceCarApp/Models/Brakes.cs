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
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
        public int BrakeWeightSave { get; set; }
        public string BrakeName { get; set; }
    }
}
