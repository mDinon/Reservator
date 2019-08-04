import React, { Component } from "react";
import axios from "axios";
import ReservationsTable from "./reservationsTable";

class Reservations extends Component {
  state = {
    reservations: []
  };

  async componentDidMount() {
    const { data: res } = await axios.get(
      "https://localhost:44381/api/Reservation"
    );
    this.setState({ reservations: res });
  }

  handleDelete = async reservation => {
    const result = this.state.reservations.filter(r => r.id !== reservation.id);
    await axios.delete(
      "https://localhost:44381/api/Reservation/" + reservation.id
    );
    this.setState({ reservations: result });
  };

  handleAddingNew = () => {
    this.props.history.push("/reservations/add");
  };

  render() {
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
        <ReservationsTable
          handleDelete={this.handleDelete}
          reservations={this.state.reservations}
        />
      </React.Fragment>
    );
  }
}

export default Reservations;
