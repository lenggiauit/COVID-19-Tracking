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


            

        }
    }
}