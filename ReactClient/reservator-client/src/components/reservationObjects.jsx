import React, { Component } from "react";
import axios from "axios";
import ReservationObjectsTable from "./reservationObjectsTable";

class ReservationObjects extends Component {
  state = {
    reservationObjects: []
  };

  async componentDidMount() {
    const { data: result } = await axios.get(
      "https://localhost:44381/api/ReservationObject"
    );
    this.setState({ reservationObjects: result });
  }

  handleDelete = async reservationObject => {
    const result = this.state.reservationObjects.filter(
      r => r.id !== reservationObject.id
    );
    await axios.delete(
      "https://localhost:44381/api/ReservationObject/" + reservationObject.id
    );
    this.setState({ reservationObjects: result });
  };

  handleAddingNew = () => {
    this.props.history.push("/items/add");
  };

  render() {
    return (
      <React.Fragment>
        <h1 style={{ marginBottom: 50 }}>Items</h1>
        <button
          className="btn btn-sm btn-primary"
          style={{ marginBottom: 20 }}
          onClick={this.handleAddingNew}
        >
          Add new
        </button>
        <ReservationObjectsTable
          handleDelete={this.handleDelete}
          reservationObjects={this.state.reservationObjects}
        />
      </React.Fragment>
    );
  }
}

export default ReservationObjects;
