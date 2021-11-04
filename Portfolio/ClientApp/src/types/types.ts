export type CommentType = {
    id: number,
    text: string,
    DateCreate: Date,
    user: UserType,
}

export type LikeType = {
    id: number,
    dateCreate: Date,
    user: UserType,
}

export type ProjectType = {
    id: number,
    name: string,
    imageURL: string,
    description: string | null,
    siteLink: string | null,
    desktopAppLink: string | null,
    androidAppLink: string | null,
    iOSAppLink: string | null,
    createdByUser: UserType,
    technologies: TechnologyType[],
    comments: CommentType[],
    likes: LikeType[],
}

export type RoleType = {
    id: number,
    roleName: string,
    users: UserType
}

export type TechnologyType = {
    id: number,
    name: string,
    color: string | null,
}

export type UserType = {
    id: number,
    login: string,
    role: RoleType,
}



export type AuthType = UserType & {
    token: string,
}
