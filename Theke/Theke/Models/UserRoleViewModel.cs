using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Theke.Models
{
    public class UserRoleData
    {
        public IEnumerable<ApplicationUser> UserData { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole> UserRoles { get; set; }
    }
}