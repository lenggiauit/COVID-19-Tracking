import { Covid19Data } from "./covid19Data";

export type Covid19DataByCountry = Covid19Data & { countryCode: string }

export type DetailByCountryRequest = {
    countryCode: any,
    startDate?: any,
    endDate?: any,
};