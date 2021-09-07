import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ApiRequest, ApiResponse, AppSetting } from "../types/type";
import { CovidReportDetail } from '../types/covidReportDetail';
import { CovidReportDetailRequest } from '../types/covidReportDetailRequest';
import { CurrentCountry } from '../types/currentCountry';

let appSetting: AppSetting = require('../appSetting.json');

export const GetCurrentCountry = createApi({
    reducerPath: 'GetCurrentCountry',
    baseQuery: fetchBaseQuery({ baseUrl: appSetting.CountryViaIPUrl }),
    endpoints: (builder) => ({
        GetCurrentCountry: builder.query<CurrentCountry, void>({
            query: (payload) => ({
                url: '',
                method: 'get',
                body: payload
            }),
            transformResponse(response: CurrentCountry) {
                return response;
            },
        }),
    })
});

export const { useGetCurrentCountryQuery } = GetCurrentCountry