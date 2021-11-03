using GraphQL.Types;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.GraphQL.Types
{
    public class RoleType : ObjectGraphType<RoleModel>
    {
        public RoleType(UsersRepository usersRep)
        {
            Field(r => r.Id, 
                type: typeof(IdGraphType))
                .Description("Role Id");

            Field(r => r.RoleName, 
                type: typeof(StringGraphType))
                .Description("Role Name");

            Field<ListGraphType<UserType>>(
                name: nameof(RoleModel.Users),
                resolve: context => usersRep.GetByRoleId(context.Source.Id),
                description: "Users in Role");
        }
    }
}
