import React, { Component } from "react";
import { toast } from "react-toastify";
import {
  getReservations,
  deleteReservation
} from "../services/reservationService";
import Pagination from "./common/pagination";
import { paginate } from "./../services/utils/paginate";
import ReservationsTable from "./reservationsTable";
import _ from "lodash";

class Reservations extends Component {
  state = {
    reservations: [],
    currentPage: 1,
    pageSize: 4,
    sortColumn: { path: "id", order: "asc" }
  };

  async componentDidMount() {
    const { data: reservations } = await getReservations();
    this.setState({ reservations });
  }

  handleDelete = async reservation => {
    const originalReservations = this.state.reservations;

    const reservations = originalReservations.filter(
      r => r.id !== reservation.id
    );
    this.setState({ reservations });

    try {
      await deleteReservation(reservation.id);
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        toast.error("Reservation has already been deleted!");
      this.setState({ reservations: originalReservations });
    }
  };

  handleSort = sortColumn => {
    this.setState({ sortColumn });
  };

  handlePageChange = page => {
    this.setState({ currentPage: page });
  };

  handleAddingNew = () => {
    this.props.history.push("/reservations/add");
  };

  getPagedData = () => {
    const {
      currentPage,
      pageSize,
      sortColumn,
      reservations: allReservations
    } = this.state;

    const sorted = _.orderBy(
      allReservations,
      [sortColumn.path],
      [sortColumn.order]
    );

    return paginate(sorted, currentPage, pageSize);
  };

  render() {
    const { length: count } = this.state.reservations;
    const { currentPage, pageSize, sortColumn } = this.state;

    const reservations = this.getPagedData();

    return (
      <React.Fragment>
        <h1 style={{ marginBottom: 50 }}>My reservations</h1>
        <button
          className="btn btn-sm btn-primary"
          style={{ marginBottom: 20 }}
          onClick={this.handleAddingNew}
        >
          <i className="fa fa-plus m-1" />
          Add new
        </button>
        <ReservationsTable
          reservations={reservations}
          sortColumn={sortColumn}
          onDelete={this.handleDelete}
          onSort={this.handleSort}
        />
        <Pagination
          itemsCount={count}
          pageSize={pageSize}
          currentPage={currentPage}
          onPageChange={this.handlePageChange}
        />
      </React.Fragment>
    );
  }
}

export default Reservations;
