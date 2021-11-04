import {gql} from '@apollo/client';
import {AuthType} from "../types/types";

export type AuthenticationData = {
    authentication: AuthType,
}

export type AuthenticationVars = {
    login: string,
    password: string,
}

export const AUTHENTICATION = gql`
mutation Authentication($login: String!, $password: String!){
    authentication(login: $login, password: $password){
    id
    login
    role{
      roleName
    }
    token
  }
}
`
