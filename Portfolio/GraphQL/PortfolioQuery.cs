using GraphQL;
using GraphQL.Types;
using Portfolio.GraphQL.Types;
using Portfolio.Repositories;

namespace Portfolio.GraphQL
{
    public class PortfolioQuery : ObjectGraphType
    {
        public PortfolioQuery(UsersRepository userRep, ProjectsRepository projectRep)
        {
            Name = "Query";

            /* ===Users=== */
            Field<ListGraphType<UserType>>(
                name: "users",
                description: "Returns a list of Users",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "Page Number" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "Page Size" }
                    ),
                resolve: context => userRep.GetUsersIncludedRoleAsync(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize")));

            Field<UserType>("user",
                description: "Returns a Single User",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "User Id" }),
                resolve: context => userRep.GetUserIncludedRoleById(context.GetArgument<int>("id")));
            
            
            /* ===Projects=== */
            Field<ListGraphType<ProjectType>>(
                name: "projects",
                description: "Returns a list of Projects",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "Page Number" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "Page Size" }
                    ),
                resolve: context => projectRep.GetProjectsIncludedUsersTechnologiesLikesCommentsAsync(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize")));

            Field<ProjectType>(
                name: "project",
                description: "Returns a Single Project",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Project Id" }),
                resolve: context => projectRep.GetProjectIncludedUsersTechnologiesLikesCommentsByIdAsync(context.GetArgument<int>("id")));
        }
    }
}
