
export type Covid19Data = {
    todayDeaths: any,
    todayConfirmed: any,
    updatedDate: any,
    deaths: any,
    cumulativeDeaths: any,
    deathsLast7Days: any,
    deathsLast7DaysChange: any,
    deathsPerHundredThousand: any,
    confirmed: any,
    cumulativeConfirmed: any,
    casesLast7Days: any,
    casesLast7DaysChange: any,
    casesPerHundredThousand: any,
    wkCasePop: any,
    wkDeathPop: any,
    avg7Case: any,
    avg7Death: any,
    avg7CasePop: any,
    avg7DeathPop: any,
    latestMeasures?: LatestMeasures
};

export type LatestMeasures = {
    MEASURES_IN_PLACE: any,
    MASKS__1: any,
    TRAVEL__1: any,
    GATHERINGS__1: any,
    SCHOOLS__1: any,
    BUSINESSES__1: any,
    MOVEMENTS__1: any
}




