﻿using GraphQL.Types;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.GraphQL.Types
{
    public class ProjectType : ObjectGraphType<ProjectModel>
    {
        public ProjectType(UsersRepository usersRep, TechnologiesRepository technologiesRep, CommentsRepository commentsRep, LikesRepository likesRep)
        {
            Field(u => u.Id, 
                type: typeof(IdGraphType))
                .Description("Project Id");

            Field(u => u.Name,
                type: typeof(StringGraphType))
                .Description("Project Name");

            Field(u => u.ImageURL, 
                nullable: true, type: typeof(StringGraphType))
                .Description("Project ImageUrl");

            Field(u => u.Description,
                nullable: true, type: typeof(StringGraphType))
                .Description("Project Description");

            Field(u => u.SiteLink,
                nullable: true, type: typeof(StringGraphType))
                .Description("Project SiteLink");

            Field(u => u.DesktopAppLink, 
                nullable: true, type: typeof(StringGraphType))
                .Description("Project DesktopAppLink");

            Field(u => u.AndroidAppLink, 
                nullable: true, type: typeof(StringGraphType))
                .Description("Project AndroidAppLink");

            Field(u => u.IOSAppLink, 
                nullable: true, type: typeof(StringGraphType))
                .Description("Project IOSAppLink");

            Field<UserType>(
                name: nameof(ProjectModel.User),
                description: "User who create Project",
                resolve: context => usersRep.Get(context.Source.UserId));

            Field<ListGraphType<TechnologyType>>(
                name: nameof(ProjectModel.Technologies),
                description: "List of Technologies",
                resolve: context => technologiesRep.GetByProjectId(context.Source.Id));
            
            Field<ListGraphType<CommentType>>(
                name: nameof(ProjectModel.Comments),
                description: "List of Comments",
                resolve: context => commentsRep.GetByProjectId(context.Source.Id));
            
            Field<ListGraphType<LikeType>>(
                name: nameof(ProjectModel.Likes),
                description: "List of Likes",
                resolve: context => likesRep.GetByProjectId(context.Source.Id));
        }
    }
}
