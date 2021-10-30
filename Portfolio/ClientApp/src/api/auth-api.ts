import {instance, ResponseCodes} from "./api";
import {UserType} from "../types/types";

export const authAPI = {
    isAuth() {
        return instance.get<ResponseType>('account/isauth')
            .then(res => res.data);
    },
    login(login: string, password: string) {
        return instance.post<ResponseType>('account/login', {'login': login, 'password': password})
            .then(res => res.data);
    },
    register(login: string, password: string, confirmPassword: string) {
        return instance.post<ResponseType>('account/register', {'login': login, 'password': password, 'confirmPassword': confirmPassword})
            .then(res => res.data);
    },
    logout() {
        return instance.delete<LogoutType>('account/logout')
            .then(res => res.data);
    }
};

type ResponseType = {
    resultCode: ResponseCodes,
    messages: Array<string>,
    data: UserType,
}

type LogoutType = {
    resultCode: ResponseCodes,
    messages: Array<string>,
}