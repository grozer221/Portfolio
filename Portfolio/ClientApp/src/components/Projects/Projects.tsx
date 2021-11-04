import React from "react";
import s from './Projects.module.css';
import {useQuery} from "@apollo/client";
import {
    LOAD_PROJECTS,
    LoadProjectsData,
    LoadProjectsVars,
} from "../../GraphQL/Queries";
import {Project} from "./Project";

export const Projects: React.FC = () => {
    const {loading, error, data} = useQuery<LoadProjectsData, LoadProjectsVars>(
        LOAD_PROJECTS,
        {variables: {pageNumber: 1, pageSize: 6}}
    );

    return (
        <div className={s.projects}>
            {data?.projects?.map((project) => (
                <Project project={project} key={project.id}/>
            ))}
        </div>
    );
}