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
    X_RapidAPI_Key: string;
    X_RapidAPI_Key: string;
    X_Rapidapi_Host: string;
    BaseUrl: string;
    TotalsCase: ApiOptions;
    GetCountries: ApiOptions;
    GetLatestCountryDataByCode: ApiOptions;
    GetLatestCountryDataByName: ApiOptions;
    GetLatestAllCountries: ApiOptions;
    GetDailyReportByCountryCode: ApiOptions;
    GetDailyReportByCountryName: ApiOptions;
    GetDailyReportAllCountries: ApiOptions;
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
    messages: any
    resource: T,
};

export type Paging = {
    index: number;
    size: number;
}

export type MetaData = {
    paging: Paging;
    sortBy: string[];
    orderBy: string[];
}











