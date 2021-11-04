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


export type RegisterData = {
    register: AuthType,
}
export type RegisterVars = {
    login: string,
    password: string,
    passwordConfirm: string,
}
export const REGISTER = gql`
mutation Register($login: String!, $password: String!, $passwordConfirm: String!){
  register(login: $login, password: $password, passwordConfirm: $passwordConfirm){
    id
    login
    role{
      roleName
    }
    token
  }
}
`
