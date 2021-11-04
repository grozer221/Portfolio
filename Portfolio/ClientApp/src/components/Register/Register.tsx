import React from "react";
import s from './Register.module.css';
import {Button, Form, Input} from "antd";
import {LockOutlined, UserOutlined} from "@ant-design/icons/lib";
import {Link, Redirect} from "react-router-dom";
import {useDispatch, useSelector} from "react-redux";
import {s_getIsAuth} from "../../redux/auth-selectors";
import {useMutation} from "@apollo/client";
import {REGISTER, RegisterData, RegisterVars} from "../../GraphQL/Mutations";
import {actions} from "../../redux/auth-reducer";

export const Register: React.FC = () => {
    const dispatch = useDispatch();
    const isAuth = useSelector(s_getIsAuth);
    const [register, {data, loading, error}] = useMutation<RegisterData, RegisterVars>(REGISTER);

    const onFinish = async (values: { login: string, password: string, passwordConfirm: string }) => {
        const response = await register({
            variables: {
                login: values.login,
                password: values.password,
                passwordConfirm: values.passwordConfirm
            }
        });
        if (response.data) {
            localStorage.setItem('token', response.data?.register.token)
            dispatch(actions.setAuthData(response.data.register, true));
        } else
            console.log('error:', error)
    };

    if (isAuth)
        return <Redirect to={'/'}/>

    return (
        <div className={s.wrapperRegisterForm}>
            <Form
                name="register-form"
                className="login-form"
                onFinish={onFinish}
            >
                <Form.Item
                    name="login"
                    rules={[{required: true, message: 'Please input your Login!'}]}
                >
                    <Input prefix={<UserOutlined className="site-form-item-icon"/>}
                           placeholder="Login"
                           className={s.formInput}
                    />
                </Form.Item>
                <Form.Item
                    name="password"
                    rules={[{required: true, message: 'Please input your Password!'}]}
                >
                    <Input
                        prefix={<LockOutlined className="site-form-item-icon"/>}
                        type="password"
                        placeholder="Password"
                        className={s.formInput}
                    />
                </Form.Item>
                <Form.Item
                    name="passwordConfirm"
                    rules={[{required: true, message: 'Please input your Password Confirm!'}]}
                >
                    <Input
                        prefix={<LockOutlined className="site-form-item-icon"/>}
                        type="password"
                        placeholder="Password Confirm"
                        className={s.formInput}
                    />
                </Form.Item>
                <Form.Item>
                    <div>
                        Or <Link to={'/login'}>login now!</Link>
                    </div>
                    <div className={s.wrapperButton}>
                        <Button loading={loading} type="primary" htmlType="submit" className='login-form-button'>
                            Register
                        </Button>
                    </div>
                </Form.Item>
            </Form>
        </div>
    );
}