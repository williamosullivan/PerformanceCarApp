﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PerformanceCarApp.Models
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }
        public int UserID { get; set; }

        public virtual ICollection<User> User { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Generation { get; set; }
        public string Drivetrain { get; set; }
        public string BodyStyle { get; set; }
        public int BaseHorsepower { get; set; }
        public string EngineSize { get; set; }
        public string Trim { get; set; }

        public virtual ICollection<Brakes> Brakes { get; set; }
        public virtual ICollection<EnginePart> EngineParts { get; set; }
        public virtual ICollection<Exhaust> Exhausts { get; set; }
        public virtual ICollection<Intake> Intakes { get; set; }
        public virtual ICollection<Suspension> Suspension { get; set; }
    }
}