import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ApiRequest, ApiResponse, AppSetting } from "../types/type";
import { Covid19DataByCountry, DetailByCountryRequest } from '../types/covid19DataByCountry';

let appSetting: AppSetting = require('../appSetting.json');

export const GetTotalCaseByCountry = createApi({
    reducerPath: 'GetTotalCaseByCountry',
    baseQuery: fetchBaseQuery({ baseUrl: appSetting.BaseUrl }),
    endpoints: (builder) => ({
        GetTotalCaseByCountry: builder.query<ApiResponse<Covid19DataByCountry>, ApiRequest<DetailByCountryRequest>>({
            query: (payload) => ({
                url: 'GetTotalCaseByCountry',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<Covid19DataByCountry>) {
                return response;
            },
        }),
    })
});

export const { useGetTotalCaseByCountryQuery } = GetTotalCaseByCountry