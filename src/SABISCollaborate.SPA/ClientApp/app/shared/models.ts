export enum Gender {
    Male = 1,
    Female = 2
}

export enum MaritalStatus {
    Unspecified = 0,
    Single = 1,
    NotSingle = 2
}

export interface Department {
    id: number;
    title: string;
}

export interface Position {
    id: number;
    title: string;
}

export interface User {
    id: number,
    username: string;
    profile: UserProfile;
}

export interface UserProfile {
    firstName: string;
    lastName: string;
    nickname: string;
}