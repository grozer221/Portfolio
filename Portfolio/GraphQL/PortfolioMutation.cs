using GraphQL;
using GraphQL.Types;
using Portfolio.GraphQL.Types;
using Portfolio.Repositories;
using Portfolio.Services;

namespace Portfolio.GraphQL
{
    public class PortfolioMutation : ObjectGraphType
    {
        public PortfolioMutation(UsersRepository usersRep, IdentityService identityService)
        {
            Name = "Mutation";

            Field<UserType>(
                  "authentication",
                  arguments: new QueryArguments(
                      new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "login", Description = "User login." },
                      new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password", Description = "User password." }
                  ),
                  resolve: context =>
                  {
                      string login = context.GetArgument<string>("login");
                      string password = context.GetArgument<string>("password");
                      return usersRep.Get(login, password);
                  },
                  description: "Returns authorized user with token."
              );
        }
    }
}
