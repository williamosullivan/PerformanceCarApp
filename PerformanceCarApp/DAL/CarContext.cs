﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GCFinalProject.Models;

namespace GCFinalProject.DAL
{
    public class CarContext : DbContext
    {
        public CarContext() : base("CarContext")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Exhaust> Exhausts { get; set; }
        public DbSet<Brakes> Brakes { get; set; }
        public DbSet<EnginePart> EngineParts { get; set; }
        public DbSet<Intake> Intakes { get; set; }
        public DbSet<Suspension> Suspensions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}