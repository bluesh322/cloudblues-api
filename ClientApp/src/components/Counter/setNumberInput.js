import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setNumber } from './setNumberSlice';

const SetNumberInput = ({ label, name }) => {
    const dispatch = useDispatch();
    const number = useSelector((state) => state.setNumber.number);

    const handleChange = (event) => {
        const newValue = event.target.value;
        dispatch(setNumber({ name, value: newValue }));
    };

    return (
        <div>
            <label htmlFor={name}>{label}</label>
            <input
                type="number"
                id={name}
                name={name}
                value={number}
                onChange={handleChange}
                className="form-control"
            >
            </input>
        </div>
    )
}

export default SetNumberInput;