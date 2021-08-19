
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

export interface ApiOptions {
    Url: string;
    Method: string;

}

export interface AppSetting {
    X_RapidAPI_Key: string;
    X_RapidAPI_Key: string;
    X_Rapidapi_Host: string;
    GetCountries: ApiOptions;
    GetLatestCountryDataByCode: ApiOptions;
    GetLatestCountryDataByName: ApiOptions;
    GetLatestAllCountries: ApiOptions;
    GetDailyReportByCountryCode: ApiOptions;
    GetDailyReportByCountryName: ApiOptions;
    GetDailyReportAllCountries: ApiOptions;
}










