﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CirohubServicesDataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CirohubDBEntities : DbContext
    {
        public CirohubDBEntities()
            : base("name=CirohubDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileCompany> ProfileCompanies { get; set; }
        public virtual DbSet<ProfileIndustry> ProfileIndustries { get; set; }
        public virtual DbSet<ProfileLogin> ProfileLogins { get; set; }
        public virtual DbSet<ProfileMatch> ProfileMatches { get; set; }
        public virtual DbSet<ProfilePartnerCompany> ProfilePartnerCompanies { get; set; }
        public virtual DbSet<ProfileService> ProfileServices { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<EmployeeCountLookup> EmployeeCountLookups { get; set; }
        public virtual DbSet<MatchColorLookup> MatchColorLookups { get; set; }
        public virtual DbSet<MatchScoreLookup> MatchScoreLookups { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<YearsExperienceLookup> YearsExperienceLookups { get; set; }
    }
}
