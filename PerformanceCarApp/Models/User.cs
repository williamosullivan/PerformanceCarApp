using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PerformanceCarApp.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public DateTime UserBirthday { get; set; }
        public string Gender { get; set; }
        
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car UserCar { get; set; }
    }
}