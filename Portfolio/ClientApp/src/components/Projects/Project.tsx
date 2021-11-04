import React from "react";
import s from './Projects.module.css'
import {Link} from "react-router-dom";
import {ProjectType} from "../../types/types";

type PropsType = {
    project: ProjectType
}

export const Project: React.FC<PropsType> = ({project}) => {
    return (
        <div className={s.wrapperProject}>
            <div className={s.wrapperImage}>
                <img className={s.image} src={'/media/projects/' + project.imageURL} alt={project.name + ' image'}/>
            </div>
            <div className={s.info}>
                <div>
                    <h2 className={s.name}>{project.name}</h2>
                    <p className={s.shortDescription}>


                    </p>
                    <h3 className={s.titleTechnologies}>Technologies :</h3>
                    <ul className={s.technologies}>
                        {project.technologies.map(technology => (
                            <li className={s.technology} key={technology.id}>
                                <div className={s.technologyColor}
                                     style={{backgroundColor: technology.color ? technology.color : 'white'}}/>
                                <div>{technology.name}</div>
                            </li>
                        ))}
                    </ul>
                </div>
                <Link to={'/project/' + project.id} className='customButton'>More</Link>
            </div>
        </div>
    );
}