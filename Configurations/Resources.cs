
using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants;

namespace WebAppIdentity.Configurations
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                // some standard scopes from the OIDC spec
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),

                // custom identity resource with some consolidated claims
                new IdentityResource(
                    "custom.profile", 
                    new[]
                    {
                        JwtClaimTypes.Id,
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.EmailVerified,
                        JwtClaimTypes.PhoneNumber,
                        JwtClaimTypes.PhoneNumberVerified,
                        JwtClaimTypes.BirthDate,
                        JwtClaimTypes.Picture,
                        JwtClaimTypes.NickName,
                        "location"
                    }
                )
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                // local API
                new ApiResource(LocalApi.ScopeName),

                // simple version with ctor
                new ApiResource("sshpoc_api_s", "SSHPoc API")
                {
                    // this is needed for introspection when using reference tokens
                    ApiSecrets = { new Secret("secret".Sha256()) }
                },
                
                // expanded version if more control is needed
                new ApiResource
                {
                    Name = "sshpoc_api_e",

                    ApiSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    UserClaims =
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                    },

                    Scopes =
                    {
                        new Scope
                        {
                            Name = "sshpoc_api_e.full_access",
                            DisplayName = "Full access to SSHPoc Apis"
                        },
                        new Scope
                        {
                            Name = "sshpoc_api_e.read_only",
                            DisplayName = "Read only access to SSHPoc Apis"
                        },
                        new Scope
                        {
                            Name = "sshpoc_api_e.internal",
                            ShowInDiscoveryDocument = false,
                            UserClaims =
                            {
                                "internal_id"
                            }
                        }
                    }
                }
            };
        }
    }
}