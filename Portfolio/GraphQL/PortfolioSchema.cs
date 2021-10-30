using GraphQL.Types;
using Portfolio.Repositories;
using System;

namespace Portfolio.GraphQL
{
    public class PortfolioSchema : Schema
    {
        public PortfolioSchema(UsersRepository usersRep, ProjectsRepository projectRep, IServiceProvider provider) : base(provider)
        {
            Query = new PortfolioQuery(usersRep, projectRep);
        }
    }
}
