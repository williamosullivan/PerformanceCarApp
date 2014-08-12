using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PerformanceCarApp.Models
{
    public class Suspension
    {
        [Key]
        public int SuspensionID { get; set; }
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
        public int SuspensionDrop { get; set; }
        public string SuspensionName { get; set; }
    }
}
