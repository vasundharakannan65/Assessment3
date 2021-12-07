using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentity
{
    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
        public ApplicationUserClaim()
        {
            
        }

        public virtual ApplicationUser User { get; set; }

    }
}
