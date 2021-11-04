import React from "react";
import s from './Home.module.css';
import {useSelector} from "react-redux";
import {s_getIsAuth} from "../../redux/auth-selectors";

export const Home: React.FC = () => {
    const isAuth = useSelector(s_getIsAuth);

    return (
        <>
            {isAuth
                ? <div>AUTHED HOME PAGE</div>
                : <div>HOME PAGE</div>
            }
        </>
    );
}