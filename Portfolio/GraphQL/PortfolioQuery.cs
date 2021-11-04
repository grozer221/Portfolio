using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Portfolio.GraphQL.Types;
using Portfolio.Repositories;

namespace Portfolio.GraphQL
{
    public class PortfolioQuery : ObjectGraphType
    {
        public PortfolioQuery(IHttpContextAccessor httpContextAccessor, UsersRepository userRep, ProjectsRepository projectRep)
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
                resolve: context => userRep.Get(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize")))
                .AuthorizeWith("Authenticated");

            Field<UserType>("user",
                description: "Returns a Single User",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "User Id" }),
                resolve: context => userRep.Get(context.GetArgument<int>("id")))
                .AuthorizeWith("Authenticated");


            Field<UserType>("currentUser",
                description: "Returns a Cureent User",
                resolve: context => userRep.Get(httpContextAccessor.HttpContext.User.Identity.Name))
                .AuthorizeWith("Authenticated");


            /* ===Projects=== */
            Field<ListGraphType<ProjectType>>(
                name: "projects",
                description: "Returns a list of Projects",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", Description = "Page Number" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", Description = "Page Size" }
                    ),
                resolve: context => projectRep.Get(context.GetArgument<int>("pageNumber"), context.GetArgument<int>("pageSize")));

            Field<ProjectType>(
                name: "project",
                description: "Returns a Single Project",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Project Id" }),
                resolve: context => projectRep.GetById(context.GetArgument<int>("id")));
        }
    }
}
