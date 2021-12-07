using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentity
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public ApplicationUserLogin()
        {
            
        }

        public virtual ApplicationUser User { get; set; }

    }
}
