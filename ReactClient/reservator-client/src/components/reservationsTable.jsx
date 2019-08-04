import React from "react";

const ReservationsTable = props => {
  if (props.reservations.length === 0)
    return <p>Nothing to be displayed here!</p>;

  return (
    <table className="table">
      <thead>
        <tr>
          <th>Id</th>
          <th>Item</th>
          <th>Item description</th>
          <th>Date from</th>
          <th>Date to</th>
          <th />
        </tr>
      </thead>
      <tbody>
        {props.reservations.map(reservation => (
          <tr key={reservation.id}>
            <td>{reservation.id}</td>
            <td>{reservation.reservationObjectName}</td>
            <td>{reservation.reservationObjectDescription}</td>
            <td>{reservation.dateFrom}</td>
            <td>{reservation.dateTo}</td>
            <td>
              <button
                className="btn btn-sm btn-danger"
                onClick={() => props.handleDelete(reservation)}
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

export default ReservationsTable;
