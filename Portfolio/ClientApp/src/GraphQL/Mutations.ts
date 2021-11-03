import {gql} from '@apollo/client';

export type AuthenticationData = {
    authentication: string,
}

export type AuthenticationVars = {
    login: string,
    password: string,
}

export const AUTHENTICATION = gql`
    mutation Authentication($login: String!, $password: String!){
        authentication(login: $login, password: $password)
    }
`
