using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentity
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public ApplicationUserRole()
        {
            
        }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }

    }
}
