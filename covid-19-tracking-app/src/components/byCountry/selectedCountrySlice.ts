import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState, AppThunk } from '../../store';
import { Covid19DataByCountry } from '../../types/covid19DataByCountry';

export interface SelectedCountryState {
    value?: Covid19DataByCountry;
}

const initialState: SelectedCountryState = {

};

export const selectedCountrySlice = createSlice({
    name: 'SelectedCountry',
    initialState,
    reducers: {
        selectCountry: (state) => {
            state.value = state.value;
        },

    },
});
export const { selectCountry } = selectedCountrySlice.actions;

export const currentCountry = (state: RootState) => state.selectedCountry.value;

export default selectedCountrySlice.reducer;