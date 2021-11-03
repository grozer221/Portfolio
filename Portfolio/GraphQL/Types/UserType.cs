using GraphQL;
using GraphQL.Types;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.GraphQL.Types
{
    public class UserType : ObjectGraphType<UserModel>
    {
        public UserType(RolesRepository rolesRep)
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
        }
    }
}
