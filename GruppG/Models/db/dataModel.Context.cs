﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GruppG.Models.db
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class U4Entities : DbContext
    {
        public U4Entities()
            : base("name=U4Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Chanel> Chanel { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<FavoriteChannel> FavoriteChannel { get; set; }
        public virtual DbSet<Role> Role { get; set; }
    }
}
