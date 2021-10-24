import React, {useState} from "react";
import {Menu} from 'antd';
import {AppstoreOutlined} from '@ant-design/icons';
import s from './NavBar.module.css'
import {useDispatch, useSelector} from "react-redux";
import {s_getCurrentUser, s_getIsAuth} from "../../redux/auth-selectors";
import {logout} from "../../redux/auth-reducer";
import {Link} from "react-router-dom";
import {UserOutlined} from "@ant-design/icons/lib";

const {SubMenu} = Menu;

export const NavBar: React.FC = () => {
    const [current, setCurrent] = useState<string>('logo');
    const isAuth = useSelector(s_getIsAuth);
    const currentUser = useSelector(s_getCurrentUser);
    const dispatch = useDispatch();

    const handleClick = (e: any) => {
        setCurrent(e.key)
    };

    return (
        <Menu onClick={handleClick} selectedKeys={[current]} mode="horizontal">
            <Menu.Item key="logo">
                <Link to={'/'}>LOGO</Link>
            </Menu.Item>
            <Menu.Item key="projects" icon={<AppstoreOutlined/>}>
                <Link to={'/projects'}>Projects</Link>
            </Menu.Item>
            {isAuth
                ? <SubMenu key="user" icon={<UserOutlined/>} title={currentUser.login}>
                    <Menu.ItemGroup>
                        <Menu.Item key="user:adminpanel">
                            <a href={'/admin'}>AdminPanel</a>
                        </Menu.Item>
                        <Menu.Item key="user:logout" onClick={() => dispatch(logout())}>Logout</Menu.Item>
                    </Menu.ItemGroup>
                </SubMenu>
                : <Menu.Item key="login">
                    <Link to={'/login'}>Login</Link>
                </Menu.Item>
            }

        </Menu>
    );
}

