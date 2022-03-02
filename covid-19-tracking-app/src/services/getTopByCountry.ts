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
        getTopCasesByCountry: builder.query<ApiResponse<Covid19DataByCountry[]>, void>({
            query: () => ({
                url: 'GetTopCasesByCountry',
                method: 'get'
            }),
            transformResponse(response: ApiResponse<Covid19DataByCountry[]>) {
                return response;
            },
        }),
        GetTopDeathsByCountry: builder.query<ApiResponse<Covid19DataByCountry[]>, void>({
            query: () => ({
                url: 'GetTopDeathsByCountry',
                method: 'get'
            }),
            transformResponse(response: ApiResponse<Covid19DataByCountry[]>) {
                return response;
            },
        }),
    })
});

export const { useGetTopByCountryQuery, useGetTopCasesByCountryQuery, useGetTopDeathsByCountryQuery } = GetTopByCountry;
