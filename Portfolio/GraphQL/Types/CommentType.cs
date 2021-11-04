using GraphQL.Types;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.GraphQL.Types
{
    public class CommentType : ObjectGraphType<CommentModel>
    {
        public CommentType(UsersRepository userRep)
        {
            Field(u => u.Id, 
                type: typeof(IdGraphType))
                .Description("Comment Id");

            Field(u => u.Text,
                type: typeof(StringGraphType))
                .Description("Comment Text");
            
            Field(u => u.DateCreate,
                type: typeof(DateTimeGraphType))
                .Description("Comment DateCreate");

            Field<UserType>(
                name: nameof(CommentModel.User),
                resolve: context => userRep.Get(context.Source.UserId),
                description: "User who created Comment");
        }
    }
}
