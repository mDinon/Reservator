import React, { Component } from "react";
import Table from "./common/table";

class ReservationsTable extends Component {
  columns = [
    { path: "id", label: "Id" },
    { path: "reservationObjectName", label: "Item" },
    { path: "reservationObjectDescription", label: "Item Description" },
    { path: "dateFrom", label: "Date from" },
    { path: "dateTo", label: "Date to" },
    {
      key: "delete",
      content: reservation => (
        <button
          className="btn btn-sm btn-danger"
          onClick={() => this.props.onDelete(reservation)}
        >
          <i className="fa fa-trash m-1" />
          Delete
        </button>
      )
    }
  ];

  render() {
    const { reservations, onSort, sortColumn } = this.props;

    if (reservations.length === 0) return <p>Nothing to be displayed here!</p>;

    return (
      <Table
        columns={this.columns}
        data={reservations}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}

export default ReservationsTable;
