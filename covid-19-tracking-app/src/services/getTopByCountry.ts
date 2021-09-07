import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ApiResponse, AppSetting } from "../types/type";
import { Covid19DataByCountry } from '../types/covid19DataByCountry';

let appSetting: AppSetting = require('../appSetting.json');

export const GetTopByCountry = createApi({
    reducerPath: 'GetTopByCountry',
    baseQuery: fetchBaseQuery({ baseUrl: appSetting.BaseUrl }),
    endpoints: (builder) => ({
        getTopByCountry: builder.query<ApiResponse<Covid19DataByCountry[]>, void>({
            query: () => ({
                url: 'GetTopByCountry',
                method: 'get'
            }),
            transformResponse(response: ApiResponse<Covid19DataByCountry[]>) {
                return response;
            },
        }),
    })
});

export const { useGetTopByCountryQuery } = GetTopByCountry;
