using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GCFinalProject.Models
{
    public class Suspension
    {
        [Key]
        public int SuspensionID { get; set; }
        public int PartID { get; set; }
        public int SuspensionDrop { get; set; }
        public int SuspensionWeightSave { get; set; }
        public string SuspensionName { get; set; }

        public virtual ICollection<Part> Part { get; set; }
    }
}
