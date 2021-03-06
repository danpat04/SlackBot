﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace SlackBot.SlackAuthentication
{
    public static class Extensions
    {
        public static void AddSlackAuthorization(this IServiceCollection services)
        {
            services.AddAuthorizationCore(options =>
                options.AddPolicy("Slack",
                policy => policy.RequireClaim(SlackAuthenticationHandler.WorkspaceClaimType)));

            // configure slack authentication 
            services.AddAuthentication("SlackAuthentication")
                .AddScheme<AuthenticationSchemeOptions, SlackAuthenticationHandler>("SlackAuthentication", null);
        }

        public static string SlackWorkspaceName(this HttpContext context)
        {
            var claim = context.User.Claims.FirstOrDefault(c => c.Type == SlackAuthenticationHandler.WorkspaceClaimType);
            return claim?.Value;
        }
    }
}
