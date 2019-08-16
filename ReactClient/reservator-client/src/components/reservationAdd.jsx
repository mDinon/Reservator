import React from "react";
import Joi from "joi-browser";
import Form from "./common/form";
import { getReservationObjects } from "../services/reservationObjectService";
import { saveReservation } from "../services/reservationService";

class ReservationAdd extends Form {
  state = {
    data: {
      dateFrom: "",
      dateTo: "",
      reservationObjectId: ""
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

  async populateReservationObjects() {
    const { data: result } = await getReservationObjects();
    this.setState({ reservationObjects: result });
  }

  async componentDidMount() {
    await this.populateReservationObjects();
  }

  mapToViewModel(reservation) {
    return {
      id: reservation.id,
      dateFrom: reservation.dateFrom,
      dateTo: reservation.dateTo,
      reservationObjectId: reservation.reservationObject.Id
    };
  }

  doSubmit = async () => {
    await saveReservation(this.state.data);

    this.props.history.push("/reservations");
  };

  render() {
    return (
      <div>
        <h1 style={{ marginBottom: 50 }}>Add new</h1>
        <form onSubmit={this.handleSubmit}>
          {this.renderSelect(
            "reservationObjectId",
            "Item",
            this.state.reservationObjects
          )}
          {this.renderDatePicker("dateFrom", "Date from")}
          {this.renderDatePicker("dateTo", "Date to")}
          {this.renderButton("Save")}
        </form>
      </div>
    );
  }
}

export default ReservationAdd;
