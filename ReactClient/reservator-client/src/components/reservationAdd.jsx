import React from "react";
import Joi from "joi-browser";
import axios from "axios";
import Form from "./common/form";
import { getReservationObjects } from "../services/reservationObjectService";

class ReservationAdd extends Form {
  state = {
    data: {
      dateFrom: "",
      dateTo: "",
      reservationObjectId: "",
      maximumReservationTime: ""
    },
    reservationObjects: [],
    errors: {}
  };

  schema = {
    id: Joi.number(),
    dateFrom: Joi.date()
      .required()
      .label("Date from"),
    dateTo: Joi.date()
      .required()
      .label("DateTo"),
    reservationObjectId: Joi.string()
      .required()
      .label("Item")
  };

  async componentDidMount() {
    const { data: result } = await getReservationObjects();
    this.setState({ reservationObjects: result });

    // const reservationObjectId = this.props.match.params.id;
    // console.log({ reservationObjectId });

    // if (reservationObjectId === "add") return;

    // const { data: reservation } = await axios.get(
    //   `https://localhost:44381/api/Reservation/${reservationObjectId}`
    // );
    // if (!reservation) return this.props.history.replace("/not-found");

    //this.setState({ data: this.mapToViewModel(reservation) });
  }

  mapToViewModel(reservation) {
    return {
      id: reservation.id,
      dateFrom: reservation.dateFrom,
      dateTo: reservation.dateTo,
      reservationObjectId: reservation.reservationObject.Id
    };
  }

  async doSubmit() {
    await axios.post(
      "https://localhost:44381/api/Reservation/",
      this.state.data
    );
    this.props.history.push("/reservations");
  }

  render() {
    return (
      <div>
        <h1>Add new</h1>
        <form onSubmit={this.handleSubmit}>
          {this.renderSelect(
            "reservationObjectId",
            "Item",
            this.state.reservationObjects
          )}
          {this.renderInput("dateFrom", "Date from")}
          {this.renderInput("dateTo", "Date to")}
          {this.renderButton("Save")}
        </form>
      </div>
    );
  }
}

export default ReservationAdd;
