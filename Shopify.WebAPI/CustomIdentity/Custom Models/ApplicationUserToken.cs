using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentity
{
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
        public ApplicationUserToken()
        {
            
        }

        public virtual ApplicationUser User { get; set; }
    }
}
