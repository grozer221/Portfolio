using GraphQL;
using GraphQL.Types;
using Portfolio.GraphQL.Types;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Services;

namespace Portfolio.GraphQL
{
    public class PortfolioMutation : ObjectGraphType
    {
        public PortfolioMutation(UsersRepository usersRep, IdentityService identityService, RolesRepository rolesRep)
        {
            Name = "Mutation";

            Field<UserType>(
                  "authentication",
                  arguments: new QueryArguments(
                      new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "login", Description = "User login" },
                      new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password", Description = "User password" }
                  ),
                  resolve: context =>
                  {
                      string login = context.GetArgument<string>("login");
                      string password = context.GetArgument<string>("password");
                      return usersRep.Get(login, password);
                  },
                  description: "Returns authorized user with token."
              );
            
            Field<UserType>(
                  "register",
                  arguments: new QueryArguments(
                      new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "login", Description = "User login" },
                      new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password", Description = "User password" },
                      new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "passwordConfirm", Description = "User password confirm" }
                  ),
                  resolve: context =>
                  {
                      string login = context.GetArgument<string>("login");
                      string password = context.GetArgument<string>("password");
                      string passwordConfirm = context.GetArgument<string>("passwordConfirm");
                      if(password != passwordConfirm)
                          throw new ExecutionError("Password do not match");
                      UserModel user = usersRep.GetIncludedRole(login);
                      if(user != null)
                          throw new ExecutionError("User with current login already exists");
                      RoleModel role = rolesRep.GetRoleByName("user");
                      return usersRep.Add(login, password, role);
                  },
                  description: "Register new user"
              );
        }
    }
}
