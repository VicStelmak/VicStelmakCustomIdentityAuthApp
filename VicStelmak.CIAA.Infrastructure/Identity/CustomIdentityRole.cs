using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace VicStelmak.CIAA.Infrastructure.Identity
{
    /// <summary>
    /// Custom implementation of IdentityRole.
    /// </summary>
    public class CustomIdentityRole : IdentityRole
    {
        public CustomIdentityRole() { }

        public CustomIdentityRole(string roleName) : base(roleName) { }

        public virtual ICollection<IdentityRoleClaim<string>>? Claims { get; set; }
    }
}
