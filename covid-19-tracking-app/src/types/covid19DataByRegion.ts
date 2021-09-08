import { Covid19Data } from "./covid19Data";

export type Covid19DataByRegion = Covid19Data & { regionCode: string } & { countryCode: string }

