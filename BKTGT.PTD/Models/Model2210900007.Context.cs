﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BKTGT.PTD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PtdK22CNT3Lesson7Entities : DbContext
    {
        public PtdK22CNT3Lesson7Entities()
            : base("name=PtdK22CNT3Lesson7Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PtdKhoa> PtdKhoa { get; set; }
        public virtual DbSet<PtdSV> PtdSV { get; set; }
    }
}
