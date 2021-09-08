import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ApiRequest, ApiResponse, AppSetting } from "../types/type";
import { Covid19DataByRegion } from '../types/covid19DataByRegion';
import { CovidReportDetailRequest } from '../types/covidReportDetailRequest';

let appSetting: AppSetting = require('../appSetting.json');

export const GetCountriesByRegion = createApi({
    reducerPath: 'GetCountriesByRegion',
    baseQuery: fetchBaseQuery({ baseUrl: appSetting.BaseUrl }),
    endpoints: (builder) => ({
        GetCountriesByRegion: builder.query<ApiResponse<Covid19DataByRegion[]>, ApiRequest<CovidReportDetailRequest>>({
            query: (payload) => ({
                url: 'GetCountriesByRegion',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<Covid19DataByRegion[]>) {
                return response;
            },
        }),
    })
});

export const { useGetCountriesByRegionQuery } = GetCountriesByRegion;
