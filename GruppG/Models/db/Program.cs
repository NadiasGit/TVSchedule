//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Program
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public Nullable<int> Chanel { get; set; }
        public Nullable<int> Category { get; set; }
        public Nullable<System.DateTime> Starttime { get; set; }
        public Nullable<System.DateTime> Endtime { get; set; }
        public Nullable<int> Puff { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Programstart { get; set; }
    
        public virtual Category Category1 { get; set; }
        public virtual Chanel Chanel1 { get; set; }
    }
}
