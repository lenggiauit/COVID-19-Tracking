import { configureStore } from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/query'
import { GetTotalsCase } from '../services/getTotalsCase';
import { GetListCaseByRegion } from '../services/getListCaseByRegion';

export const store = configureStore({
    reducer: {
        // Add the generated reducer as a specific top-level slice
        [GetTotalsCase.reducerPath]: GetTotalsCase.reducer,
        [GetListCaseByRegion.reducerPath]: GetListCaseByRegion.reducer,

    },
    // Adding the api middleware enables caching, invalidation, polling,
    // and other useful features of `rtk-query`.
    middleware: (getDefaultMiddleware) => {
        return getDefaultMiddleware()
            .concat(GetTotalsCase.middleware)
            .concat(GetListCaseByRegion.middleware);
    }

});

setupListeners(store.dispatch)
