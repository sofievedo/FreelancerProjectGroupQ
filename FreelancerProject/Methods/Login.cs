using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelancerProject.Methods
{
    public static class Login
    {
        public static int UserId
        {
            get { return int.Parse(HttpContext.Current.Session["BusinessID"].ToString()); }
            set { HttpContext.Current.Session["BusinessID"] = value; }
        }

    }
}