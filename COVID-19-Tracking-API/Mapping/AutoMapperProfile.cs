using System;
using AutoMapper;
using C19Tracking.Domain.Models.Entities;
using C19Tracking.Resources;

namespace C19Tracking.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        { 
            CreateMap<Covid19Data, TotalsResource>();
            CreateMap<CovidDataByRegion, CaseByRegionResource>(); 
            CreateMap<CovidDataByRegion, CovidDataByRegionResource>();
            CreateMap<VaccineData, VaccineDataResource>(); 
            CreateMap<VaccineData, TotalVaccineDataResource>();
            CreateMap<CovidReportDetail, CovidReportDetailResource>();
            CreateMap<CovidDataByDayGroup, CovidDataByDayGroupResource>(); 
            CreateMap<CovidDataByDayRegion, CovidDataByDayRegionResource>();
            CreateMap<CovidDataByCountry, CovidDataByCountryResource>();
            CreateMap<TodayData, TodayDataResource>();
            CreateMap<DeathsCountry, DeathsCountryResource>();
            CreateMap<CasesCountry, CasesCountryResource>();
        }
    }
}