import React, {useEffect} from 'react';
import './App.css';
import 'antd/dist/antd.css';
import {NavBar} from "./components/Nav/NavBar";
import {Home} from "./components/Home/Home";
import {useDispatch} from "react-redux";
import {Route, Switch, useHistory} from 'react-router-dom';
import {Loading} from "./components/common/Loading/Loading";
import {Button, Result} from "antd";
import {Login} from "./components/Login/Login";
import {Projects} from "./components/Projects/Projects";
import {Profile} from "./components/Profile/Profile";
import {ViewProject} from "./components/ViewProject/ViewProject";
import {actions} from "./redux/auth-reducer";
import {useQuery} from "@apollo/client";
import {GET_CURRENT_USER, GetCurrentUserData,} from "./GraphQL/Queries";

export const App: React.FC = () => {
    const history = useHistory();
    const dispatch = useDispatch();
    const {data, error, loading} = useQuery<GetCurrentUserData>(GET_CURRENT_USER);

    useEffect(() => {
        if (data && !error) {
            dispatch(actions.setAuthData(data.currentUser, true))
        }
    }, [data, error]);

    if (loading)
        return <Loading/>

    return (
        <div className='container'>
            <div className="wrapperProfile">
                <Profile/>
            </div>
            <div className="wrapperNav">
                <NavBar/>
            </div>
            <div className="wrapperContent">
                <Switch>
                    <Route exact path="/" render={() => <Home/>}/>
                    <Route exact path="/projects" render={() => <Projects/>}/>
                    <Route exact path="/project/:id?" render={() => <ViewProject/>}/>
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

