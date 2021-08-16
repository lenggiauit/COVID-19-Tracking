
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










