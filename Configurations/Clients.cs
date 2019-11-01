
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using static IdentityServer4.IdentityServerConstants;

namespace WebAppIdentity.Configurations
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                ///////////////////////////////////////////
                // Console Client Credentials Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "sshpoc_api_s", "sshpoc_api_e.read_only", LocalApi.ScopeName }
                },

                ///////////////////////////////////////////
                // X509 mTLS Client
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mtls",
                    ClientSecrets = {
                        new Secret(@"CN=mtls.test, OU=ROO\ballen@roo, O=mkcert development certificate", "mtls.test")
                        {
                            Type = SecretTypes.X509CertificateName
                        },
                        //new Secret("bca0d040847f843c5ee0fa6eb494837470155868", "mtls.test")
                        //{
                        //    Type = SecretTypes.X509CertificateThumbprint
                        //},
                    },

                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "sshpoc_api_s", "sshpoc_api_e.read_only" }
                },

                ///////////////////////////////////////////
                // Console Client Credentials Flow with client JWT assertion
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "client.jwt",
                    ClientSecrets =
                    {
                        new Secret
                        {
                            Type = IdentityServerConstants.SecretTypes.X509CertificateBase64,
                            Value = "MIIDATCCAe2gAwIBAgIQoHUYAquk9rBJcq8W+F0FAzAJBgUrDgMCHQUAMBIxEDAOBgNVBAMTB0RldlJvb3QwHhcNMTAwMTIwMjMwMDAwWhcNMjAwMTIwMjMwMDAwWjARMQ8wDQYDVQQDEwZDbGllbnQwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDSaY4x1eXqjHF1iXQcF3pbFrIbmNw19w/IdOQxbavmuPbhY7jX0IORu/GQiHjmhqWt8F4G7KGLhXLC1j7rXdDmxXRyVJBZBTEaSYukuX7zGeUXscdpgODLQVay/0hUGz54aDZPAhtBHaYbog+yH10sCXgV1Mxtzx3dGelA6pPwiAmXwFxjJ1HGsS/hdbt+vgXhdlzud3ZSfyI/TJAnFeKxsmbJUyqMfoBl1zFKG4MOvgHhBjekp+r8gYNGknMYu9JDFr1ue0wylaw9UwG8ZXAkYmYbn2wN/CpJl3gJgX42/9g87uLvtVAmz5L+rZQTlS1ibv54ScR2lcRpGQiQav/LAgMBAAGjXDBaMBMGA1UdJQQMMAoGCCsGAQUFBwMCMEMGA1UdAQQ8MDqAENIWANpX5DZ3bX3WvoDfy0GhFDASMRAwDgYDVQQDEwdEZXZSb290ghAsWTt7E82DjU1E1p427Qj2MAkGBSsOAwIdBQADggEBADLje0qbqGVPaZHINLn+WSM2czZk0b5NG80btp7arjgDYoWBIe2TSOkkApTRhLPfmZTsaiI3Ro/64q+Dk3z3Kt7w+grHqu5nYhsn7xQFAQUf3y2KcJnRdIEk0jrLM4vgIzYdXsoC6YO+9QnlkNqcN36Y8IpSVSTda6gRKvGXiAhu42e2Qey/WNMFOL+YzMXGt/nDHL/qRKsuXBOarIb++43DV3YnxGTx22llhOnPpuZ9/gnNY7KLjODaiEciKhaKqt/b57mTEz4jTF4kIg6BP03MUfDXeVlM1Qf1jB43G2QQ19n5lUiqTpmQkcfLfyci2uBZ8BkOhXr3Vk9HIk/xBXQ="
                        }
                    },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "sshpoc_api_s", "sshpoc_api_e.read_only" }
                },

                ///////////////////////////////////////////
                // Custom Grant Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "client.custom",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = { "custom", "custom.nosubject" },
                    AllowedScopes = { "sshpoc_api_s", "sshpoc_api_e.read_only" }
                },

                ///////////////////////////////////////////
                // Console Resource Owner Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "sshpocadmin",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowOfflineAccess = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "custom.profile",
                        "sshpoc_api_s", "sshpoc_api_e.read_only"
                    }
                },

                ///////////////////////////////////////////
                // Console Public Resource Owner Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "sshpoc.public",
                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowOfflineAccess = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        "sshpoc_api_s", "sshpoc_api_e.read_only"
                    }
                },

                ///////////////////////////////////////////
                // Console with PKCE Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "console.pkce",
                    ClientName = "Console with PKCE Sample",
                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    RedirectUris = { "http://127.0.0.1", "sample-windows-client://callback" },

                    AllowOfflineAccess = true,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "sshpoc_api_s", "sshpoc_api_e.read_only"
                    }
                },

                ///////////////////////////////////////////
                // Introspection Client Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "sshpoc.reference",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = { "sshpoc_api_s", "sshpoc_api_e.read_only" },

                    AccessTokenType = AccessTokenType.Reference
                },

                ///////////////////////////////////////////
                // MVC Implicit Flow Samples
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.implicit",
                    ClientName = "MVC Implicit",
                    ClientUri = "http://identityserver.io",

                    // if request JWT is used
                    ClientSecrets =
                    {
                        new Secret
                        {
                            Type = IdentityServerConstants.SecretTypes.X509CertificateBase64,
                            Value = "MIIDATCCAe2gAwIBAgIQoHUYAquk9rBJcq8W+F0FAzAJBgUrDgMCHQUAMBIxEDAOBgNVBAMTB0RldlJvb3QwHhcNMTAwMTIwMjMwMDAwWhcNMjAwMTIwMjMwMDAwWjARMQ8wDQYDVQQDEwZDbGllbnQwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDSaY4x1eXqjHF1iXQcF3pbFrIbmNw19w/IdOQxbavmuPbhY7jX0IORu/GQiHjmhqWt8F4G7KGLhXLC1j7rXdDmxXRyVJBZBTEaSYukuX7zGeUXscdpgODLQVay/0hUGz54aDZPAhtBHaYbog+yH10sCXgV1Mxtzx3dGelA6pPwiAmXwFxjJ1HGsS/hdbt+vgXhdlzud3ZSfyI/TJAnFeKxsmbJUyqMfoBl1zFKG4MOvgHhBjekp+r8gYNGknMYu9JDFr1ue0wylaw9UwG8ZXAkYmYbn2wN/CpJl3gJgX42/9g87uLvtVAmz5L+rZQTlS1ibv54ScR2lcRpGQiQav/LAgMBAAGjXDBaMBMGA1UdJQQMMAoGCCsGAQUFBwMCMEMGA1UdAQQ8MDqAENIWANpX5DZ3bX3WvoDfy0GhFDASMRAwDgYDVQQDEwdEZXZSb290ghAsWTt7E82DjU1E1p427Qj2MAkGBSsOAwIdBQADggEBADLje0qbqGVPaZHINLn+WSM2czZk0b5NG80btp7arjgDYoWBIe2TSOkkApTRhLPfmZTsaiI3Ro/64q+Dk3z3Kt7w+grHqu5nYhsn7xQFAQUf3y2KcJnRdIEk0jrLM4vgIzYdXsoC6YO+9QnlkNqcN36Y8IpSVSTda6gRKvGXiAhu42e2Qey/WNMFOL+YzMXGt/nDHL/qRKsuXBOarIb++43DV3YnxGTx22llhOnPpuZ9/gnNY7KLjODaiEciKhaKqt/b57mTEz4jTF4kIg6BP03MUfDXeVlM1Qf1jB43G2QQ19n5lUiqTpmQkcfLfyci2uBZ8BkOhXr3Vk9HIk/xBXQ="
                        }
                    },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =  { "http://localhost:44077/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:44077/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:44077/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "sshpoc_api_s", "sshpoc_api_e.read_only"
                    }
                },

                ///////////////////////////////////////////
                // MVC Manual Implicit Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.manual",
                    ClientName = "MVC Manual",
                    ClientUri = "http://identityserver.io",

                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = { "http://localhost:44078/home/callback" },
                    PostLogoutRedirectUris = { "http://localhost:44078/" },
                    FrontChannelLogoutUri = "http://localhost:44078/home/FrontChannelLogout",
                    BackChannelLogoutUri = "http://localhost:44078/home/BackChannelLogout",

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    }
                },

                ///////////////////////////////////////////
                // MVC Hybrid Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.hybrid",
                    ClientName = "MVC Hybrid",
                    ClientUri = "http://identityserver.io",
                    //LogoUri = "https://pbs.twimg.com/profile_images/1612989113/Ki-hanja_400x400.png",

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = false,

                    RedirectUris = { "http://localhost:21402/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:21402/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:21402/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "sshpoc_api_s", "sshpoc_api_e.read_only"
                    }
                },
                ///////////////////////////////////////////
                // MVC Hybrid Flow Sample (Back Channel logout)
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.hybrid.backchannel",
                    ClientName = "MVC Hybrid (with BackChannel logout)",
                    ClientUri = "http://identityserver.io",

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = false,

                    RedirectUris = { "http://localhost:21403/signin-oidc" },
                    BackChannelLogoutUri = "http://localhost:21403/logout",
                    PostLogoutRedirectUris = { "http://localhost:21403/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "sshpoc_api_s", "sshpoc_api_e.read_only"
                    }
                },

                ///////////////////////////////////////////
                // MVC Hybrid Flow Sample (Automatic Refresh)
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "mvc.hybrid.autorefresh",
                    ClientName = "MVC Hybrid (with automatic refresh)",
                    ClientUri = "http://identityserver.io",

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = false,

                    AccessTokenLifetime = 75,

                    RedirectUris = { "http://localhost:21404/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:21404/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:21404/signout-callback-oidc" },

                    AllowOfflineAccess = true,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "sshpoc_api_s", "sshpoc_api_e.read_only"
                    }
                },

                ///////////////////////////////////////////
                // JS OAuth 2.0 Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "js_oauth",
                    ClientName = "JavaScript OAuth 2.0 Client",
                    ClientUri = "http://localhost:7001/",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AlwaysIncludeUserClaimsInIdToken = true,

                    RedirectUris = { "http://localhost:7001/auth/callback" },
                    PostLogoutRedirectUris = { "http://localhost:7001/" },
                    AllowedCorsOrigins = { "http://localhost:7001" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "custom.profile",
                        "sshpoc_api_s", "sshpoc_api_e.read_only"
                    }
                },
                
                ///////////////////////////////////////////
                // JS OIDC Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "js_oidc",
                    ClientName = "JavaScript OIDC Client",
                    ClientUri = "http://localhost:7001",
                    //LogoUri = "https://pbs.twimg.com/profile_images/1612989113/Ki-hanja_400x400.png",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireConsent = false,
                    RequireClientSecret = false,
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenType = AccessTokenType.Jwt,

                    RedirectUris =
                    {
                        "http://localhost:7001/auth/callback"
                    },

                    PostLogoutRedirectUris = { "http://localhost:7001/logout.html" },
                    AllowedCorsOrigins = { "http://localhost:7001" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "custom.profile", "sshpoc_api_s", "sshpoc_api_e.read_only"
                    }
                },

                ///////////////////////////////////////////
                // Device Flow Sample
                //////////////////////////////////////////
                new Client
                {
                    ClientId = "device",
                    ClientName = "Device Flow Client",

                    AllowedGrantTypes = GrantTypes.DeviceFlow,
                    RequireClientSecret = false,

                    AllowOfflineAccess = true,

                    AllowedCorsOrigins = { "http://localhost:5001" }, // JS test client only

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "sshpoc_api_s", "sshpoc_api_e.read_only", "sshpoc_api_e.full_access"
                    }
                }
            };
        }
    }
}