﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace ECommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){ Scopes = { "CatalogFullPermission", "CatalogReadPermission" } },
            new ApiResource("ResourceDiscount"){ Scopes = { "DiscountFullPermission" } },
            new ApiResource("ResourceOrder"){ Scopes = { "OrderFullPermission" } },
            new ApiResource("ResourceCargo"){ Scopes = { "CargoFullPermission" } },
            new ApiResource("ResourceBasket"){ Scopes = { "BasketFullPermission" } },
            new ApiResource("ResourceComment"){ Scopes = { "CommentFullPermission" } },
            new ApiResource("ResourcePayment"){Scopes={ "PaymentFullPermission" } },
            new ApiResource("ResourceImage"){Scopes={ "ImageFullPermission" } },
            new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"} },
            new ApiResource("ResourceOcelot"){ Scopes = { "OcelotFullPermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };


        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission", "Read authority for catalog operations"),
            new ApiScope("DiscountFullPermission", "Full authority for discount operations"),
            new ApiScope("OrderFullPermission", "Full authority for order operations"),
            new ApiScope("CargoFullPermission", "Full authority for cargo operations"),
            new ApiScope("BasketFullPermission", "Full authority for basket operations"),
            new ApiScope("CommentFullPermission", "Full authority for comment operations"),
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),
            new ApiScope("ImageFullPermission","Full authority for image operations"),
            new ApiScope("MessageFullPermission","Full authority for message operations"),
            new ApiScope("OcelotFullPermission", "Full authority for ocelot operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "ECommerceVisitorId",
                ClientName = "ECommerce Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("ecommercesecret".Sha256()) },
                AllowedScopes={
                    "CatalogReadPermission",
                    "CatalogFullPermission",
                    "OcelotFullPermission",
                    "CommentFullPermission",
                    "ImageFullPermission",
                    "CommentFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName 
                },
                AllowAccessTokensViaBrowser=true
            },

            //Manager
            new Client
            {
                ClientId = "ECommerceManagerId",
                ClientName = "ECommerce Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("ecommercesecret".Sha256()) },
                AllowedScopes={ 
                    "CatalogReadPermission", 
                    "CatalogFullPermission", 
                    "BasketFullPermission", 
                    "OcelotFullPermission", 
                    "CommentFullPermission", 
                    "PaymentFullPermission", 
                    "ImageFullPermission",
                    "DiscountFullPermission",
                    "OrderFullPermisson",
                    "MessageFullPermission",
                    "CargoFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email
                }
            },

            //Admin
            new Client
            {
                ClientId = "ECommerceAdminId",
                ClientName = "ECommerce Admin User",
                //AllowedGrantTypes = GrantTypes.ClientCredentials, //kullanıcı bilgisi olmadan erişim
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, //kullanıcı bilgisi ile erişim
                ClientSecrets = { new Secret("ecommercesecret".Sha256()) },
                 AllowedScopes={ "CatalogFullPermission", 
                    "CatalogReadPermission", 
                    "DiscountFullPermission", 
                    "OrderFullPermisson",
                    "CargoFullPermission",
                    "BasketFullPermission",
                    "OcelotFullPermission",
                    "CommentFullPermission",
                    "PaymentFullPermission",
                    "ImageFullPermission",
                    "CargoFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email
                },
                AccessTokenLifetime = 600, //10 minutes
            }
        };
    }
}