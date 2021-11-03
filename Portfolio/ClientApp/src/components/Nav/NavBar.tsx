import React from "react";
import s from './NavBar.module.css'
import {useDispatch, useSelector} from "react-redux";
import {s_getCurrentUser, s_getIsAuth} from "../../redux/auth-selectors";
import {Link} from "react-router-dom";
import Cookies from "js-cookie";
import {actions} from "../../redux/auth-reducer";

export const NavBar: React.FC = () => {
    const isAuth = useSelector(s_getIsAuth);
    const currentUser = useSelector(s_getCurrentUser);
    const dispatch = useDispatch();

    const logoutHandler = () => {
        Cookies.remove('token');
        dispatch(actions.setAuthData(null, false));
    }

    return (
        <div className={s.navBar}>
            <div className={s.links}>
                <Link to={'/'} className={s.navItem}>
                    Home
                </Link>
                <Link to={'/projects'} className={s.navItem}>
                    Projects
                </Link>
                <Link to={'/projects'} className={s.navItem}>
                    Projects
                </Link>
                <Link to={'/projects'} className={s.navItem}>
                    Projects
                </Link>
            </div>
            <div className={s.links}>
                {isAuth
                    ? <div className={s.dropdown}>
                        <div className={s.dropbtn}>{currentUser?.login}</div>
                        <div className={s.dropdownContent}>
                            {currentUser?.role?.roleName === 'admin' && <a href={'/admin'}>AdminPanel</a>}
                            <a onClick={logoutHandler}>Logout</a>
                        </div>
                    </div>
                    : <Link to={'/login'} className={s.navItem}>Login</Link>}

            </div>
        </div>
    );
}

