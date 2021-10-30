using GraphQL.Types;
using Portfolio.Models;

namespace Portfolio.GraphQL.Types
{
    public class LikeType : ObjectGraphType<LikeModel>
    {
        public LikeType()
        {
            Field(u => u.Id, 
                type: typeof(IdGraphType))
                .Description("Comment Id");

            Field(u => u.DateCreate,
                type: typeof(DateTimeGraphType))
                .Description("Comment DateCreate");

            Field<UserType>(
                name: nameof(CommentModel.User),
                resolve: context => context.Source.User,
                description: "User who create Comment");
        }
    }
}
