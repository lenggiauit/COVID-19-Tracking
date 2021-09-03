// Country Interface 
interface ICountry {
    id: number,
    name: string,
    code: string
}
// Header
interface IHeader {
    key: string,
    value: any
}
// params
interface IParam {
    name: any,
    value: any
}
export interface Dictionary<T> {
    [Key: string]: T;
}

export enum Locale {
    English = 'English',
    VietNam = 'Việt Nam'
}

export enum ToastType {
    Info = 'bg-info',
    Warning = 'bg-warning',
    Danger = 'bg-danger'
}

export interface ApiOptions {
    Url: string;
    Method: string;

}

export interface AppSetting {
    BaseUrl: string;
    ForceHideEnvironment: boolean;
}

export type ApiHeader = {
    key: string;
    value: string;
};

export type KeyValue<T, U> = {
    key: T,
    value: U,
};

export type ApiMethod = "POST" | "GET";

export type ApiResponse<T> = {
    success: boolean,
    errorCode: any,
    messages: any,
    resource: T,
};

export type ApiRequest<T> = {
    metaData?: MetaData,
    payload: T
};

export type Paging = {
    index: number;
    size: number;
}

export type MetaData = {
    paging: Paging,
    sortBy: string[],
    orderBy: string[],
}











