using Microsoft.AspNetCore.Identity;
using System;

namespace AirJobs.IdentityServer
{
    public class ApplicationUser : IdentityUser
    {
        public Guid UserId { get; set; }
    }
}
