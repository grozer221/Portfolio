using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Services;
using Portfolio.Utils;

namespace Portfolio.GraphQL
{
    public class PortfolioMutation : ObjectGraphType
    {
        public PortfolioMutation(UsersRepository usersRep, IdentityService identityService)
        {
            Name = "Mutation";

            Field<StringGraphType>(
                  "authentication",
                  arguments: new QueryArguments(
                      new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "login", Description = "User login." },
                      new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password", Description = "User password." }
                  ),
                  resolve: context =>
                  {
                      string login = context.GetArgument<string>("login");
                      string password = context.GetArgument<string>("password");
                      UserModel user = usersRep.GetUserWithRoleByLogin(login, Hashing.GetHashString(password));
                      if (user == null)
                          return "";
                      return identityService.GenerateAccessToken(user.Id, user.Login, user.Role.RoleName);
                  },
                  description: "Returns JWT."
              );
        }
    }
}
