import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { decrement, increment, incrementByAmount, decrementByAmount } from './Counter/counterSlice';
import SetNumberInput from './Counter/setNumberInput';
export function Counter() {
    const count = useSelector((state) => state.counter.value);
    const setValue = useSelector((state) => state.setNumber.number)
    const dispatch = useDispatch();

    return (
        <div>
            <h1>Counter</h1>

            <p>This is a simple example of a React component.</p>

            <p aria-live="polite">Current count: <strong>{count}</strong></p>

            <button className="btn btn-primary" onClick={() => dispatch(increment())}>Increment</button>
            <button className="btn btn-secondary mx-1" onClick={() => dispatch(decrement())}>Decrement</button>
            <SetNumberInput label="Enter a number: " name="number" default="0"></SetNumberInput>
            <button className="btn btn-primary" onClick={() => dispatch(incrementByAmount(setValue))}>+</button>
            <button className="btn btn-secondary mx-1" onClick={() => dispatch(decrementByAmount(setValue))}>-</button>
        </div>
    );

}