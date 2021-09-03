import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ApiRequest, ApiResponse, AppSetting } from "../types/type";
import { Covid19DataByRegion } from '../types/covid19DataByRegion';
import { CovidReportDetail } from '../types/covidReportDetail';
import { CovidReportDetailRequest } from '../types/covidReportDetailRequest';

let appSetting: AppSetting = require('../appSetting.json');

export const GetDetailByRegion = createApi({
    reducerPath: 'GetDetailByRegion',
    baseQuery: fetchBaseQuery({ baseUrl: appSetting.BaseUrl }),
    endpoints: (builder) => ({
        GetDetailByRegion: builder.query<ApiResponse<CovidReportDetail>, ApiRequest<CovidReportDetailRequest>>({
            query: (payload) => ({
                url: 'GetDetailByRegion',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<CovidReportDetail>) {
                return response;
            },
        }),
    })
});

export const { useGetDetailByRegionQuery, useLazyGetDetailByRegionQuery } = GetDetailByRegion
