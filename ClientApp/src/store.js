import { configureStore } from '@reduxjs/toolkit'
import counterReducer from './components/Counter/counterSlice'
import setNumberReducer from './components/Counter/setNumberSlice'

export const store = configureStore({
    reducer: {
        counter: counterReducer,
        setNumber: setNumberReducer,
    },
});