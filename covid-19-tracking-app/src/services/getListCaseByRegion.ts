import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ApiResponse, AppSetting } from "../types/type";
import { Covid19DataByRegion } from '../types/covid19DataByRegion';

let appSetting: AppSetting = require('../appSetting.json');

export const GetListCaseByRegion = createApi({
    reducerPath: 'allCaseByRegion',
    baseQuery: fetchBaseQuery({ baseUrl: appSetting.BaseUrl }),
    endpoints: (builder) => ({
        GetListCaseByRegion: builder.query<ApiResponse<Covid19DataByRegion[]>, void>({
            query: () => ({
                url: 'GetAllCaseByRegion',
                method: 'get'
            }),
            transformResponse(response: ApiResponse<Covid19DataByRegion[]>) {
                return response;
            },
        }),
    })
});

export const { useGetListCaseByRegionQuery } = GetListCaseByRegion

