import { Covid19DataByDayRegion } from "./covid19DataByDayRegion";
import { Covid19DataByRegion } from "./covid19DataByRegion";
import { VaccineData } from "./vaccineData";

export type CovidReportDetail = {
    covidReport: Covid19DataByRegion,
    vaccineReport: VaccineData,
    covidReportByDayRegion: Covid19DataByDayRegion[],
};
