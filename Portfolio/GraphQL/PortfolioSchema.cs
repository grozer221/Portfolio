using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Portfolio.GraphQL
{
    public class PortfolioSchema : Schema
    {
        public PortfolioSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<PortfolioQuery>();
            Mutation = provider.GetRequiredService<PortfolioMutation>();
        }
    }
}
