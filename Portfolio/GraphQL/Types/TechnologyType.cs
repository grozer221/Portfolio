using GraphQL.Types;
using Portfolio.Models;

namespace Portfolio.GraphQL.Types
{
    public class TechnologyType : ObjectGraphType<TechnologyModel>
    {
        public TechnologyType()
        {
            Field(u => u.Id,
                type: typeof(IdGraphType))
                .Description("Technology Id");

            Field(u => u.Name,
                type: typeof(StringGraphType))
                .Description("Technology Name");

            Field(u => u.Color, 
                nullable: true, type: typeof(StringGraphType))
                .Description("Technology Color");
        }
    }
}
