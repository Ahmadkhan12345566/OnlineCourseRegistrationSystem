﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationPaper.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Course_reg_DatabaseEntities : DbContext
    {
        public Course_reg_DatabaseEntities()
            : base("name=Course_reg_DatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CourcesTable> CourcesTables { get; set; }
        public virtual DbSet<offerd_courseTable> offerd_courseTable { get; set; }
        public virtual DbSet<registerd_crs_Table> registerd_crs_Table { get; set; }
        public virtual DbSet<studentsTable> studentsTables { get; set; }
    }
}