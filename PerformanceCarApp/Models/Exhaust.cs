using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PerformanceCarApp.Models
{
    public class Exhaust
    {
        [Key]
        public int ExhaustID { get; set; }
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
        public int ExhaustHPGain { get; set; }
        public string ExhaustName { get; set; }
    }
}
