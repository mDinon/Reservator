import React from "react";
import Joi from "joi-browser";
import Form from "./common/form";
import { getReservationObject } from "../services/reservationObjectService";

class ReservationObjectAddOrEdit extends Form {
  state = {
    data: { name: "", description: "", maximumReservationTime: 0 },
    errors: {}
  };

  schema = {
    id: Joi.number(),
    name: Joi.string()
      .required()
      .label("Name"),
    description: Joi.string()
      .required()
      .label("Description"),
    maximumReservationTime: Joi.number()
      .required()
      .min(1)
      .label("Maximum reservation duration (days)")
  };

  doSubmit = () => {};

  async componentDidMount() {
    const reservationObjectId = this.props.match.params.id;
    console.log({ reservationObjectId });

    if (reservationObjectId === "add") return;

    const { data: reservationObject } = await getReservationObject(
      reservationObjectId
    );
    if (!reservationObject) return this.props.history.replace("/not-found");

    this.setState({ data: this.mapToViewModel(reservationObject) });
  }

  mapToViewModel(reservationObject) {
    return {
      id: reservationObject.id,
      name: reservationObject.name,
      description: reservationObject.description
    };
  }

  render() {
    return (
      <div>
        <h1>Add new or edit</h1>
        <form onSubmit={this.handleSubmit}>
          {this.renderInput("name", "Name")}
          {this.renderInput("description", "Description")}
          {this.renderInput(
            "maximumReservationTime",
            "Maximum reservation duration (days)",
            "number"
          )}
          {this.renderButton("Save")}
        </form>
      </div>
    );
  }
}

export default ReservationObjectAddOrEdit;
