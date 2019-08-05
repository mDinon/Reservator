import React, { Component } from "react";
import { toast } from "react-toastify";
import {
  getReservations,
  deleteReservation
} from "../services/reservationService";
import Pagination from "./common/pagination";
import { paginate } from "./../services/utils/paginate";

class Reservations extends Component {
  state = {
    reservations: [],
    currentPage: 1,
    pageSize: 4
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

  handlePageChange = page => {
    this.setState({ currentPage: page });
  };

  handleAddingNew = () => {
    this.props.history.push("/reservations/add");
  };

  render() {
    const { length: count } = this.state.reservations;
    const { currentPage, pageSize, reservations: allReservations } = this.state;
    const reservations = paginate(allReservations, currentPage, pageSize);
    return (
      <React.Fragment>
        <h1 style={{ marginBottom: 50 }}>My reservations</h1>
        <button
          className="btn btn-sm btn-primary"
          style={{ marginBottom: 20 }}
          onClick={this.handleAddingNew}
        >
          Add new
        </button>
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
            {reservations.map(reservation => (
              <tr key={reservation.id}>
                <td>{reservation.id}</td>
                <td>{reservation.reservationObjectName}</td>
                <td>{reservation.reservationObjectDescription}</td>
                <td>{reservation.dateFrom}</td>
                <td>{reservation.dateTo}</td>
                <td>
                  <button
                    className="btn btn-sm btn-danger"
                    onClick={() => this.handleDelete(reservation)}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
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
