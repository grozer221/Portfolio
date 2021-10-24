import React from "react";
import s from './Login.module.css';
import {Button, Form, Input} from "antd";
import {LockOutlined, UserOutlined} from "@ant-design/icons/lib";
import {useDispatch, useSelector} from "react-redux";
import {login} from "../../redux/auth-reducer";
import {s_getIsAuth} from "../../redux/auth-selectors";
import { Redirect } from "react-router-dom";

export const Login: React.FC = () => {
    const dispatch = useDispatch();
    const isAuth = useSelector(s_getIsAuth);

    const onFinish = (values: {login: string, password: string}) => {
        dispatch(login(values.login, values.password));
    };

    if(isAuth)
        return <Redirect to={'/'}/>

    return (
        <Form
            name="login-form"
            className="login-form"
            onFinish={onFinish}
        >
            <Form.Item
                name="login"
                rules={[{required: true, message: 'Please input your Login!'}]}
            >
                <Input prefix={<UserOutlined className="site-form-item-icon"/>} placeholder="Login"/>
            </Form.Item>
            <Form.Item
                name="password"
                rules={[{required: true, message: 'Please input your Password!'}]}
            >
                <Input
                    prefix={<LockOutlined className="site-form-item-icon"/>}
                    type="password"
                    placeholder="Password"
                />
            </Form.Item>
            <Form.Item>
                <Button type="primary" htmlType="submit" className="login-form-button">
                    Log in
                </Button>
                Or <a href="">register now!</a>
            </Form.Item>
        </Form>
    );
}