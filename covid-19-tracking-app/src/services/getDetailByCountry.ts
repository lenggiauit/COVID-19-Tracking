import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ApiRequest, ApiResponse, AppSetting } from "../types/type";
import { Covid19DataByRegion } from '../types/covid19DataByRegion';
import { CovidReportDetail } from '../types/covidReportDetail';
import { CovidReportDetailRequest } from '../types/covidReportDetailRequest';
import { DetailByCountryRequest } from '../types/covid19DataByCountry';

let appSetting: AppSetting = require('../appSetting.json');

export const GetDetailByCountry = createApi({
    reducerPath: 'GetDetailByCountry',
    baseQuery: fetchBaseQuery({ baseUrl: appSetting.BaseUrl }),
    endpoints: (builder) => ({
        GetDetailByCountry: builder.query<ApiResponse<CovidReportDetail>, ApiRequest<DetailByCountryRequest>>({
            query: (payload) => ({
                url: 'GetDetailByCountry',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<CovidReportDetail>) {
                return response;
            },
        }),
    })
});

export const { useGetDetailByCountryQuery } = GetDetailByCountry
