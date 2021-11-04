import React from "react";
import s from './NavBar.module.css'
import {useDispatch, useSelector} from "react-redux";
import {s_getAuthData, s_getIsAuth} from "../../redux/auth-selectors";
import {Link} from "react-router-dom";
import {actions} from "../../redux/auth-reducer";
import {Button, Dropdown, Menu, message} from "antd";
import {DownOutlined, UserOutlined} from "@ant-design/icons/lib";

export const NavBar: React.FC = () => {
    const isAuth = useSelector(s_getIsAuth);
    const currentUser = useSelector(s_getAuthData);
    const dispatch = useDispatch();

    const logoutHandler = () => {
        localStorage.removeItem('token');
        dispatch(actions.setAuthData(null, false));
    }

    const menu = (
        <Menu className={s.dropdownItems}>
            {currentUser?.role.roleName === 'admin'
            && <Menu.Item key="1" className={s.dropdownItem}>
                <a href="/admin/account/login">AdminPanel</a>
            </Menu.Item>}
            <Menu.Item key="2" className={s.dropdownItem} onClick={logoutHandler}>
                Logout
            </Menu.Item>
        </Menu>
    );

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
                    ? <Dropdown overlay={menu} className={s.dropdown}>
                        <Button>
                            {currentUser?.login} <DownOutlined/>
                        </Button>
                    </Dropdown>
                    : <Link to={'/login'} className={s.navItem}>Login</Link>}
            </div>
        </div>
    );
}

