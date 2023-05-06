// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Collections.Generic;
using HackTest.IdentityServer.Data;
using HackTest.IdentityServer.Models;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace HackTest.IdentityServer
{
    public class SeedData
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog")     {Scopes={"catalog_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.Email(),
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource(){ Name="roles", DisplayName="Roles", Description="User Roles", UserClaims=new []{ "role" } }
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("catalog_fullpermission","Catalog API full access"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
        new Client
        {
            ClientName="Asp.Net Core MVC",
            ClientId="WebMvcClient",
            ClientSecrets= {new Secret("secret".Sha256())},
            AllowedGrantTypes= GrantTypes.ClientCredentials,
            AllowedScopes=
            {
                "catalog_fullpermission",
                IdentityServerConstants.LocalApi.ScopeName
            }
        },
        new Client
        {
            ClientName="Asp.Net Core MVC",
            ClientId="WebMvcClientForUser",
            AllowOfflineAccess= true,
            ClientSecrets= {new Secret("secret".Sha256())},
            AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
            AllowedScopes=
            {
                "catalog_fullpermission",
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.LocalApi.ScopeName,
                "roles"
            },
            AccessTokenLifetime=1*60*60,
            RefreshTokenExpiration=TokenExpiration.Absolute,
            AbsoluteRefreshTokenLifetime= (int) (DateTime.Now.AddDays(60)- DateTime.Now).TotalSeconds,
            RefreshTokenUsage= TokenUsage.ReUse
        },
        new Client
        {
            ClientName="Token Exchange",
            ClientId="TokenExchange",
            ClientSecrets= {new Secret("secret".Sha256())},
            AllowedGrantTypes= { OidcConstants.GrantTypes.TokenExchange },
            AllowedScopes=
            {
                "discount_fullpermission",
                "payment_fullpermission",
                IdentityServerConstants.StandardScopes.OpenId,
            }
        },
        };
    }
}
