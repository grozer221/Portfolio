using GraphQL.Types;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.GraphQL.Types
{
    public class LikeType : ObjectGraphType<LikeModel>
    {
        public LikeType(UsersRepository usersRep)
        {
            Field(u => u.Id,
                type: typeof(IdGraphType))
                .Description("Comment Id");

            Field(u => u.DateCreate,
                type: typeof(DateTimeGraphType))
                .Description("Comment DateCreate");

            Field<UserType>(
                name: nameof(CommentModel.User),
                description: "User who created Like",
                resolve: context => usersRep.GetById(context.Source.UserId));
        }
    }
}
