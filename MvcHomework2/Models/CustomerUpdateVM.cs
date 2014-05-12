using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcHomework2.Models
{
    public class CustomerUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string 統一編號 { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        //public System.DateTime DateCreated { get; set; }
        public string Phone { get; set; }
        //public string Fax { get; set; }
        //public bool IsDelete { get; set; }
    }
}