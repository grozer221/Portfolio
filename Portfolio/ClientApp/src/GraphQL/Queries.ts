import {gql} from '@apollo/client';
import {ProjectType} from '../types/types';

export type LoadProjectData = {
    projects: ProjectType[],
}

export type LoadProjectVars = {
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