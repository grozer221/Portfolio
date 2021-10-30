using GraphQL.Types;
using Portfolio.Models;

namespace Portfolio.GraphQL.Types
{
    public class UserType : ObjectGraphType<UserModel>
    {
        public UserType()
        {
            Field(u => u.Id, 
                type: typeof(IdGraphType))
                .Description("User Id");

            Field(u => u.Login,
                type: typeof(StringGraphType))
                .Description("User Login");

            Field<RoleType>(
                name: nameof(UserModel.Role),
                resolve: context => context.Source.Role,
                description: "Role of User");
        }
    }
}
