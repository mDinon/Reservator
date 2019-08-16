import React, { Component } from "react";
import Table from "./common/table";
import Moment from "react-moment";

class ReservationsTable extends Component {
  columns = [
    //{ path: "id", label: "Id" },
    { path: "reservationObjectName", label: "Item" },
    { path: "reservationObjectDescription", label: "Item escription" },
    {
      path: "dateFrom",
      label: "Date from",
      content: reservation => (
        <Moment format="DD.MM.YYYY. hh:mm">{reservation.dateFrom}</Moment>
      )
    },
    {
      path: "dateTo",
      label: "Date to",
      content: reservation => (
        <Moment format="DD.MM.YYYY. hh:mm">{reservation.dateTo}</Moment>
      )
    },
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
