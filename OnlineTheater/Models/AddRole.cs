using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTheater.Models
{
    public class AddRole
    {
        public IEnumerable<string> RoleNames { get; set; }
        public string UserName { get; set; }
        public string selectedRole { get; set; }
        public List<string> AllRoles { get; set; }

        public AddRole()
        {
            AllRoles = new List<string>();
        }
    }
}