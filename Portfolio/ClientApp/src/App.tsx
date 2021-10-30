import React, {useEffect} from 'react';
import './App.css';
import 'antd/dist/antd.css';
import {NavBar} from "./components/Nav/NavBar";
import {Home} from "./components/Home/Home";
import {useDispatch, useSelector} from "react-redux";
import {useHistory, Route, Switch} from 'react-router-dom';
import {s_getIsAuth} from "./redux/auth-selectors";
import {s_getInitialised} from "./redux/app-selectors";
import {initialiseApp} from "./redux/app-reducer";
import {Loading} from "./components/common/Loading/Loading";
import {Button, Result} from "antd";
import {Login} from "./components/Login/Login";
import {Projects} from "./components/Projects/Projects";

export const App: React.FC = () => {
    const isAuth = useSelector(s_getIsAuth);
    const initialised = useSelector(s_getInitialised);
    const history = useHistory();
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(initialiseApp());
    }, [isAuth]);

    if (!initialised)
        return <Loading/>

    return (
        <div className='container'>
            <NavBar/>
            <div className='content'>
                <Switch>
                    <Route exact path="/" render={() => <Home/>}/>
                    <Route exact path="/projects" render={() => <Projects/>}/>
                    <Route exact path="/login" render={() => <Login/>}/>
                    <Route path="*" render={() => <Result
                        status="404"
                        title="404"
                        subTitle="Sorry, the page you visited does not exist."
                        extra={<Button type="primary" onClick={() => history.push('/')}>Back Home</Button>}
                    />}/>
                </Switch>
            </div>
        </div>
    );
}

