﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCFinalProject.Models
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Generation { get; set; }
        public string Drivetrain { get; set; }
        public string BodyStyle { get; set; }
        public int BaseHorsepower { get; set; }
        public string EngineSize { get; set; }
        public string Trim { get; set; }

        [Required]
        public virtual ICollection<Part> Parts { get; set; }
    }
}