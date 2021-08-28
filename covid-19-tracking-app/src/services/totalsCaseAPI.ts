import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ApiResponse, AppSetting } from "../type";
import type { Covid19Data } from '../types/covid19Data';

let appSetting: AppSetting = require('../appSetting.json');

export const TotalsCaseAPI = createApi({
    reducerPath: 'totalsCase',
    baseQuery: fetchBaseQuery({ baseUrl: appSetting.BaseUrl }),
    endpoints: (builder) => ({
        getTotalsCase: builder.query<ApiResponse<Covid19Data>, void>({
            query: () => ({
                url: 'totalsCase',
                method: 'post'
            }),
            transformResponse(response: ApiResponse<Covid19Data>) {
                return response;
            },
        }),
    })
});

export const { useGetTotalsCaseQuery } = TotalsCaseAPI

