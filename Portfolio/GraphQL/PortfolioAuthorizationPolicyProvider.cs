using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.GraphQL
{
    public class PortfolioAuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        private DefaultAuthorizationPolicyProvider BackupPolicyProvider { get; }

        public PortfolioAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            // ASP.NET Core only uses one authorization policy provider, so if the custom implementation
            // doesn't handle all policies it should fall back to an alternate provider.
            BackupPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        public async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            return await BackupPolicyProvider.GetPolicyAsync(policyName);
        }

        public async Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return await Task.FromResult(new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());
        }

        public async Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            return await GetDefaultPolicyAsync();
        }
    }
}
