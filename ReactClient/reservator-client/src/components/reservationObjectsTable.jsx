import React from "react";

const ReservationObjectsTable = props => {
  if (props.reservationObjects.length === 0)
    return <p>Nothing to be displayed here!</p>;

  return (
    <table className="table">
      <thead>
        <tr>
          <th>Id</th>
          <th>Item</th>
          <th>Item description</th>
          <th>Maximum reservaton time (min)</th>
          <th />
        </tr>
      </thead>
      <tbody>
        {props.reservationObjects.map(reservationObject => (
          <tr key={reservationObject.id}>
            <td>{reservationObject.id}</td>
            <td>{reservationObject.name}</td>
            <td>{reservationObject.description}</td>
            <td>{reservationObject.maximumReservationTime}</td>
            <td>
              <button
                className="btn btn-sm btn-danger"
                onClick={() => props.handleDelete(reservationObject)}
              >
                Delete
              </button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default ReservationObjectsTable;
