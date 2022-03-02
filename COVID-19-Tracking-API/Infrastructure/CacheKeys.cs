using System;
using System.ComponentModel;

namespace C19Tracking.API.Infrastructure
{
    public enum CacheRawKeys 
    {
        ByDayRaw,
        ByDayCumulativeRaw,
        DayGroupsRaw,
        CountriesDailyChangeRaw,
        ByCountryRaw,
        CountryGroupsRaw,
        TopCountryGroupsRaw,
        ByRegionRaw,
        RegionGroupsRaw,
        TodayRaw,
        YesterdayRaw,
        StartDateRaw,
        EndDateRaw,
        LastUpdateRaw,
        LastDayPerCountryRaw,
        Last7DaysPerCountryRaw,
        TotalsRaw,
        CreatedTimeRaw,
        CountriesCurrentRaw,
        VaccineDataRaw,
        VaccineMetaDataRaw
    }
    public enum CacheKeys 
    { 
        ByDay,
        ByDayCumulative,
        DayGroups,
        CountriesDailyChange,
        ByCountry,
        [Description("data.regionsWeeklyIndexed.data")]
        RegionWeekly,
        CountryGroups,
        [Description("data.countryMapData.data")]
        CountryMapData,
        [Description("data.allByCountry.nodes")]
        AllByCountry,
        [Description("result.data.today")]
        Today,
        [Description("data.deathsDESC.nodes")]
        TopDeathsCountry,
        [Description("data.casesDESC.nodes")]
        TopCasesCountry,
        [Description("data.byRegionTotals.data")]
        ByRegion,
        RegionGroups, 
        Yesterday,
        StartDate,
        EndDate,
        [Description("data.lastUpdate.date")]
        LastUpdate,
        LastDayPerCountry,
        Last7DaysPerCountry,
        [Description("result.data.totals")]
        Totals,
        CreatedTime,
        CountriesCurrent,
        VaccineData,
        VaccineMetaData
    }

    public static class ConvertCacheKey
    { 
        public static CacheRawKeys GetRawKey(CacheKeys cacheKeys)
        {
            switch (cacheKeys)
            {
                case CacheKeys.ByDay:
                    return CacheRawKeys.ByDayRaw;
                case CacheKeys.ByDayCumulative:
                    return CacheRawKeys.ByDayCumulativeRaw;
                case CacheKeys.DayGroups:
                    return CacheRawKeys.DayGroupsRaw;
                case CacheKeys.CountriesDailyChange:
                    return CacheRawKeys.CountriesDailyChangeRaw;
                case CacheKeys.ByCountry:
                    return CacheRawKeys.ByCountryRaw;
                case CacheKeys.CountryGroups:
                    return CacheRawKeys.CountryGroupsRaw;
                //case CacheKeys.TopCountryGroups:
                //    return CacheRawKeys.TopCountryGroupsRaw;
                case CacheKeys.ByRegion:
                    return CacheRawKeys.ByRegionRaw;
                case CacheKeys.RegionGroups:
                    return CacheRawKeys.RegionGroupsRaw;
                case CacheKeys.Today:
                    return CacheRawKeys.TodayRaw;
                case CacheKeys.Yesterday:
                    return CacheRawKeys.YesterdayRaw;
                case CacheKeys.StartDate:
                    return CacheRawKeys.StartDateRaw;
                case CacheKeys.EndDate:
                    return CacheRawKeys.EndDateRaw;
                case CacheKeys.LastUpdate:
                    return CacheRawKeys.LastUpdateRaw;
                case CacheKeys.LastDayPerCountry:
                    return CacheRawKeys.LastDayPerCountryRaw;
                case CacheKeys.Last7DaysPerCountry:
                    return CacheRawKeys.Last7DaysPerCountryRaw;
                case CacheKeys.Totals:
                    return CacheRawKeys.TotalsRaw;
                case CacheKeys.CreatedTime:
                    return CacheRawKeys.CreatedTimeRaw;
                case CacheKeys.CountriesCurrent:
                    return CacheRawKeys.CountriesCurrentRaw;
                case CacheKeys.VaccineData:
                    return CacheRawKeys.VaccineDataRaw;
                case CacheKeys.VaccineMetaData:
                    return CacheRawKeys.VaccineMetaDataRaw; 
                default:
                    return CacheRawKeys.ByDayRaw;
            }
            
        }
    }



}