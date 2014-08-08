using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PerformanceCarApp.Models
{
    public class Intake
    {
        [Key]
        public int IntakeID { get; set; }
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
        public int IntakeHPGain { get; set; }
        public string IntakeName { get; set; }
    }
}
