//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string MSSV { get; set; }
        public string Class { get; set; }
        public decimal NumberPhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public Nullable<System.DateTime> DateBegin { get; set; }
        public Nullable<int> ID_Faculity { get; set; }
        public Nullable<int> ID_IndustryofFaculity { get; set; }
        public Nullable<int> ID_Subject { get; set; }
    }
}