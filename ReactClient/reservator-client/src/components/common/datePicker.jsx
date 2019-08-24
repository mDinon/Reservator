import React from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const DatePickerWrapper = ({ name, label, error, value, ...rest }) => {
  return (
    <div className="form-group">
      <label htmlFor={name}>{label}</label>
      <div>
        <DatePicker
          selected={value}
          onChange={date => this.handleDatePickerChange({ name }, date)}
          showTimeSelect
          timeFormat="HH:mm"
          timeIntervals={15}
          dateFormat="dd.MM.yyyy. HH:mm"
          timeCaption="time"
          todayButton={"Today"}
          name={name}
          {...rest}
          className="form-control"
        />
      </div>
      {error && <div className="alert alert-danger">{error}</div>}
    </div>
  );
};

export default DatePickerWrapper;
