import React, {useEffect} from "react";
import {Button, Form, Input} from "antd";
import {LockOutlined, UserOutlined} from "@ant-design/icons/lib";
import {useDispatch, useSelector} from "react-redux";
import {s_getIsAuth} from "../../redux/auth-selectors";
import {Redirect} from "react-router-dom";
import {useMutation} from "@apollo/client";
import {AUTHENTICATION, AuthenticationData, AuthenticationVars} from "../../GraphQL/Mutations";
import Cookies from "js-cookie";
import {actions} from "../../redux/auth-reducer";

export const Login: React.FC = () => {
    const dispatch = useDispatch();
    const isAuth = useSelector(s_getIsAuth);
    const [authentication, {data, loading, error}] = useMutation<AuthenticationData, AuthenticationVars>(AUTHENTICATION);

    useEffect(() => {
        if (data && !error) {
            Cookies.set('token', data?.authentication)
        }
        else
            console.log(error)
    }, [data, error]);


    const onFinish = async (values: { login: string, password: string }) => {
        await authentication({variables: {login: values.login, password: values.password}});
        console.log(data, loading, error)
        authentication({
            variables: {
                login: values.login, password: values.password
            }
        });
    };

    if (isAuth)
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