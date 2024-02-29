import { createSlice } from '@reduxjs/toolkit';

const initialState = {
    number: 0,
};

export const setNumberSlice = createSlice({
    name: 'setNumberSlice',
    initialState,
    reducers: {
        setNumber: (state, action) => {
            const newValue = action.payload.value;
            if (!isNaN(newValue)) {
                state.number = newValue;
            }
        },
    },
});

export const { setNumber } = setNumberSlice.actions;
export default setNumberSlice.reducer;