import {BaseThunkType, InferActionsTypes} from "./redux-store";
import {AuthType} from "../types/types";

let initialState = {
    authData: null as null | AuthType,
    isAuth: false,
};

const authReducer = (state = initialState, action: ActionsType): InitialStateType => {
    switch (action.type) {
        case 'SET_AUTH_DATA':
            return {
                ...state,
                ...action.payload,
            };
        default:
            return state;
    }
};

export const actions = {
    setAuthData: (authData: AuthType | null, isAuth: boolean) => ({
        type: 'SET_AUTH_DATA',
        payload: {authData, isAuth}
    } as const),
}

export default authReducer;

export type InitialStateType = typeof initialState;
type ActionsType = InferActionsTypes<typeof actions>;
type ThunkType = BaseThunkType<ActionsType>;