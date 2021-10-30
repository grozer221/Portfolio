import React, {useEffect} from "react";
import s from './Projects.module.css';
import {gql, useQuery} from "@apollo/client";
import {LoadProjectData, LOAD_PROJECTS, LoadProjectVars} from "../../GraphQL/Queries";
import {ProjectType} from "../../types/types";

import { Card } from 'antd';

const { Meta } = Card;


export const Projects: React.FC = () => {
    const {loading, error, data} = useQuery<LoadProjectData, LoadProjectVars>(
        LOAD_PROJECTS,
        {variables: {pageNumber: 1, pageSize: 6}}
    );

    return (
        <div className={s.wrapperProjects}>
            {data?.projects?.map((project) => (
                <div className={s.wrapperProject} key={project.id}>
                    <div className={s.wrapperImage}>
                        <img className={s.image} src={'/media/projects/' + project.imageURL} alt={project.name + ' image'}/>
                    </div>
                    <h2 className={s.name}>{project.name}</h2>
                    <div>{project.description}</div>
                </div>
            ))
            }
        </div>
    );
}