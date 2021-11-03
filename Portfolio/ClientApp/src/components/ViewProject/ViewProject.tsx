import React from "react";
import {useParams} from "react-router-dom";
import s from './ViewProject.module.css';
import {useQuery} from "@apollo/client";
import {LOAD_PROJECT, LoadProjectData, LoadProjectVars} from "../../GraphQL/Queries";
import {Loading} from "../common/Loading/Loading";


export const ViewProject: React.FC = () => {
    const params = useParams<{ id: string }>();

    const {loading, error, data} = useQuery<LoadProjectData, LoadProjectVars>(
        LOAD_PROJECT,
        {variables: {id: +params.id}}
    );

    if (loading)
        return <Loading/>

    if (error)
        return <div>{error}</div>

    return (
        <div>
            <h1>{data?.project.name}</h1>
            <div className={s.wrapperImage}>
                <img className={s.image} src={"/media/projects/" + data?.project.imageURL} alt=""/>
            </div>
            <p>{data?.project.description}</p>
        </div>
    );
}