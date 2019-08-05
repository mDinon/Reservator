import React, { Component } from "react";
import ReservationObjectsTable from "./reservationObjectsTable";
import { toast } from "react-toastify";
import {
  getReservationObjects,
  deleteReservationObject
} from "../services/reservationObjectService";

class ReservationObjects extends Component {
  state = {
    reservationObjects: []
  };

  async componentDidMount() {
    const { data: reservationObjects } = await getReservationObjects();
    this.setState({ reservationObjects });
  }

  handleDelete = async reservationObject => {
    const originalReservationObjects = this.state.reservationObjects;

    const reservationObjects = originalReservationObjects.filter(
      r => r.id !== reservationObject.id
    );
    this.setState({ reservationObjects });

    try {
      await deleteReservationObject(reservationObject.id);
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        toast.error("Item has already been deleted!");
      this.setState({ reservationObjects: originalReservationObjects });
    }
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
