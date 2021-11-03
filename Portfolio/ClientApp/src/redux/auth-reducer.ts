import {BaseThunkType, InferActionsTypes} from "./redux-store";
import {UserType} from "../types/types";

let initialState = {
    currentUser: null as null | UserType,
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
    setAuthData: (currentUser: UserType | null, isAuth: boolean) => ({
        type: 'SET_AUTH_DATA',
        payload: {currentUser, isAuth}
    } as const),
}

export default authReducer;

export type InitialStateType = typeof initialState;
type ActionsType = InferActionsTypes<typeof actions>;
type ThunkType = BaseThunkType<ActionsType>;