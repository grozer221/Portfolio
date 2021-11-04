using GraphQL;
using GraphQL.Types;
using Portfolio.Models;
using Portfolio.Repositories;
using Portfolio.Services;

namespace Portfolio.GraphQL.Types
{
    public class UserType : ObjectGraphType<UserModel>
    {
        public UserType(IdentityService identityService, RolesRepository rolesRep, UsersRepository usersRep)
        {
            Field(u => u.Id, 
                type: typeof(IdGraphType))
                .Description("User Id");

            Field(u => u.Login,
                type: typeof(StringGraphType))
                .Description("User Login");

            Field<RoleType>(
                name: nameof(UserModel.Role),
                resolve: context => rolesRep.GetByUserIdAsync(context.Source.Id),
                description: "Role of User");

            Field<StringGraphType>(
                name: nameof(UserModel.Token),
                resolve: context =>
                {
                    string login = context.Parent.GetArgument<string>("login");
                    string password = context.Parent.GetArgument<string>("password");
                    UserModel user = usersRep.GetIncludedRole(login, password);
                    if (user == null)
                        return "";
                    return identityService.GenerateAccessToken(user.Id, user.Login, user.Role.RoleName);
                },
                description: "JWT Token");
        }
    }
}
