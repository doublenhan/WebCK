using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Areas.Admin.Models
{
    public class sysdiagram
    {
        public string name { get; set; }
        public int principal_id { get; set; }
        public int diagram_id { get; set; }
        public Nullable<int> version { get; set; }
        public byte[] definition { get; set; }
    }
}