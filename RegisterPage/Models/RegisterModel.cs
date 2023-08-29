using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterPage.Models
{
    public class RegisterModel
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string mstatus { get; set; }
        public string email { get; set; }
        public string dob { get; set; }
        public long mnumber { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public int zipcode { get; set; }
    }
}