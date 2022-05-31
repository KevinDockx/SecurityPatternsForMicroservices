using Duende.IdentityServer.Models;

namespace GloboTicket.Services.Identity;

public static class Config
{ 
    public static IEnumerable<IdentityResource> IdentityResources =>
           new IdentityResource[]
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
           };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
                new ApiScope("eventcatalog.fullaccess"),
                new ApiScope("eventcatalog.read"),
                new ApiScope("eventcatalog.write"),
                new ApiScope("shoppingbasket.fullaccess"),
                new ApiScope("discount.fullaccess"),
                new ApiScope("globoticketgateway.fullaccess"),
                new ApiScope("ordering.fullaccess")
        };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
                new ApiResource("eventcatalog", "Event catalog API")
                {
                    Scopes = { "eventcatalog.fullaccess" }
                },
                new ApiResource("shoppingbasket", "Shopping basket API")
                {
                    Scopes = { "shoppingbasket.fullaccess" }
                },
                new ApiResource("discount", "Discount API")
                {
                    Scopes = { "discount.fullaccess" }
                },
                new ApiResource("globoticketgateway", "GloboTicket Gateway")
                {
                    Scopes = { "globoticketgateway.fullaccess" }
                },
                new ApiResource("ordering", "Ordering API")
                {
                    Scopes = { "ordering.fullaccess" }
                }
        };


    public static IEnumerable<Client> Clients =>
             new Client[]
             {
                new Client
                {
                    ClientId = "shoppingbaskettodownstreamtokenexchangeclient",
                    ClientName = "Shopping Basket Token Exchange Client",
                    AccessTokenLifetime = 10,
                    AllowedGrantTypes = new[] { "urn:ietf:params:oauth:grant-type:token-exchange" },
                    ClientSecrets = { new Secret("0cdea0bc-779e-4368-b46b-09956f70712c".Sha256()) },
                    AllowedScopes = {
                         "openid", "profile", "discount.fullaccess", "ordering.fullaccess" }
                },
                new Client
                {
                    ClientId = "gatewaytodownstreamtokenexchangeclient",
                    ClientName = "Gateway to Downstream Token Exchange Client",
                    AllowedGrantTypes = new[] { "urn:ietf:params:oauth:grant-type:token-exchange" },
                    RequireConsent = false,
                    ClientSecrets = { new Secret("0cdea0bc-779e-4368-b46b-09956f70712c".Sha256()) },
                    AllowedScopes = {
                         "openid", "profile", "eventcatalog.fullaccess" }
                },
                new Client
                {
                    ClientName = "GloboTicket Machine 2 Machine Client",
                    ClientId = "globoticketm2m",
                    ClientSecrets = { new Secret("eac7008f-1b35-4325-ac8d-4a71932e6088".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "eventcatalog.fullaccess" }
                },
                new Client
                {
                    ClientName = "GloboTicket Interactive Client",
                    ClientId = "globoticketinteractive",
                    ClientSecrets = { new Secret("ce766e16-df99-411d-8d31-0f5bbc6b8eba".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:5000/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5000/signout-callback-oidc" },
                    RequireConsent = false,
                    AllowedScopes = { "openid", "profile", "shoppingbasket.fullaccess" }
                },
                 new Client
                {
                    ClientName = "GloboTicket Client",
                    ClientId = "globoticket",
                    ClientSecrets = { new Secret("ce766e16-df99-411d-8d31-0f5bbc6b8eba".Sha256()) },
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RedirectUris = { "https://localhost:5000/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:5000/signout-callback-oidc" },
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    AccessTokenLifetime = 60,
                    AllowedScopes = { "openid", "profile",
                         "globoticketgateway.fullaccess",
                         "shoppingbasket.fullaccess"  }
                } 
             };
}
