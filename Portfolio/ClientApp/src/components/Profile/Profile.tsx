import React from "react";
import s from './Profile.module.css';

export const Profile: React.FC = () => {
    return(
        <div className={s.profile}>
            <div className={s.wrapperImage}>
                <img className={s.image} src="https://img.viva.ua/pictures/content/16/16385.jpg" alt="ProfileImage"/>
            </div>
            <div className={s.info}>
                info
            </div>
            <div className={s.links}>
                links
            </div>
        </div>
    );
}