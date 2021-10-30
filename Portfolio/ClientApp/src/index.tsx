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
    uri: window.location.protocol + '//' + window.location.host + '/graphql',
    cache: new InMemoryCache()
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