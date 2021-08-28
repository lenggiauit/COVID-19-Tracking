import { configureStore } from '@reduxjs/toolkit';
import { TotalsCaseAPI } from '../services/totalsCaseAPI';
import { setupListeners } from '@reduxjs/toolkit/query'

export const store = configureStore({
    reducer: {
        // Add the generated reducer as a specific top-level slice
        [TotalsCaseAPI.reducerPath]: TotalsCaseAPI.reducer
    },
    // Adding the api middleware enables caching, invalidation, polling,
    // and other useful features of `rtk-query`.
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(TotalsCaseAPI.middleware)
});

setupListeners(store.dispatch)
