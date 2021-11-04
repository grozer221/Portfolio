import {App} from "./App";
import {BrowserRouter} from "react-router-dom";
import React from "react";
import ReactDOM from "react-dom";
import {Provider} from "react-redux";
import store from "./redux/redux-store";
import {
    ApolloClient,
    InMemoryCache,
    ApolloProvider,
} from "@apollo/client";

const client = new ApolloClient({
    uri: '/graphql',
    credentials: 'include',
    cache: new InMemoryCache(),
    headers: {
        authorization: localStorage.getItem('token') ? `Bearer ${localStorage.getItem('token')}` : "",
    }
});

ReactDOM.render(
    <React.StrictMode>
        <Provider store={store}>
            <BrowserRouter basename={process.env.PUBLIC_URL}>
                <ApolloProvider client={client}>
                    <App/>
                </ApolloProvider>
            </BrowserRouter>
        </Provider>
    </React.StrictMode>,
    document.getElementById('root')
);