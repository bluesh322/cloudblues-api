import { configureStore } from '@reduxjs/toolkit'
import counterReducer from './components/Counter/counterSlice'
import setNumberReducer from './components/Counter/setNumberSlice'

export const store = configureStore({
    reducer: {
        counter: counterReducer,
        setNumber: setNumberReducer,
    },
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch