using IdentityServer4.Models;
using System.Collections.Generic;

namespace AirJobs.IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("AirJobsApi", "API for MobileApp")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "airJobMobileApp",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("air@Jobs53CR37".Sha256()) },
                    AllowedScopes = { "AirJobsApi" }
                }
            };
        }
    }
}
