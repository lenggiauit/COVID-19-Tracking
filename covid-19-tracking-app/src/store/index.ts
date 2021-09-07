import { Action, configureStore, ThunkAction } from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/query'
import { GetTotalsCase } from '../services/getTotalsCase';
import { GetListCaseByRegion } from '../services/getListCaseByRegion';
import { GetDetailByRegion } from '../services/getDetailByRegion';
import { GetTopByCountry } from '../services/getTopByCountry';
import { GetCurrentCountry } from '../services/getCurrentCountry';
import { GetByCountry } from '../services/getByCountry';
import selectedCountryReducer from '../components/byCountry/selectedCountrySlice';

export const store = configureStore({
    reducer: {
        // Add the generated reducer as a specific top-level slice
        [GetTotalsCase.reducerPath]: GetTotalsCase.reducer,
        [GetListCaseByRegion.reducerPath]: GetListCaseByRegion.reducer,
        [GetDetailByRegion.reducerPath]: GetDetailByRegion.reducer,
        [GetTopByCountry.reducerPath]: GetTopByCountry.reducer,
        [GetCurrentCountry.reducerPath]: GetCurrentCountry.reducer,
        [GetByCountry.reducerPath]: GetByCountry.reducer,
        selectedCountry: selectedCountryReducer,

    },
    // Adding the api middleware enables caching, invalidation, polling,
    // and other useful features of `rtk-query`.
    middleware: (getDefaultMiddleware) => {
        return getDefaultMiddleware({ serializableCheck: false })
            .concat(GetTotalsCase.middleware)
            .concat(GetListCaseByRegion.middleware)
            .concat(GetDetailByRegion.middleware)
            .concat(GetTopByCountry.middleware)
            .concat(GetCurrentCountry.middleware)
            .concat(GetByCountry.middleware);
    }

});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
    ReturnType,
    RootState,
    unknown,
    Action<string>
>;
setupListeners(store.dispatch)
