import React, { Component } from "react";
import Table from "./common/table";
import { Link } from "react-router-dom";

class ReservationObjecsTable extends Component {
  columns = [
    //{ path: "id", label: "Id" },
    {
      path: "name",
      label: "Item",
      content: reservationObject => (
        <Link to={`/items/edit/${reservationObject.id}`}>
          {reservationObject.name}
        </Link>
      )
    },
    { path: "description", label: "Item description" },
    { path: "maximumReservationTime", label: "Maximum reservaton time (days)" },
    {
      key: "delete",
      content: reservationObject => (
        <button
          className="btn btn-sm btn-danger"
          onClick={() => this.props.onDelete(reservationObject)}
        >
          <i className="fa fa-trash m-1" />
          Delete
        </button>
      )
    }
  ];
  render() {
    const { reservationObjects, onSort, sortColumn } = this.props;

    if (reservationObjects.length === 0)
      return <p>Nothing to be displayed here!</p>;

    return (
      <Table
        columns={this.columns}
        data={reservationObjects}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}

export default ReservationObjecsTable;
