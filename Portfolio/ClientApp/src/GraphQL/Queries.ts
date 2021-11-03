import {gql} from '@apollo/client';
import {ProjectType, UserType} from '../types/types';

export type LoadProjectsData = {
    projects: ProjectType[],
}
export type LoadProjectsVars = {
    pageNumber: number,
    pageSize: number,
}
export const LOAD_PROJECTS = gql`
    query GetProjects($pageNumber: Int!, $pageSize: Int!){
        projects(pageNumber: $pageNumber, pageSize: $pageSize){
            id
            name
            description
            imageURL
            technologies{
              name
              color
            }
        }
    }
`


export type LoadProjectData = {
    project: ProjectType,
}
export type LoadProjectVars = {
    id: number
}
export const LOAD_PROJECT = gql`
    query GetProject($id: Int!){
        project(id: $id){
            id
            name
            description
            imageURL
            technologies{
              name
              color
            }
        }
    }
`


export type GetCurrentUserData = {
    currentUser: UserType,
}
export type GetCurrentUserVars = {}
export const GET_CURRENT_USER = gql`
    query {
      currentUser {
        id
        login
        role {
          roleName
        }
      }
    }
`



