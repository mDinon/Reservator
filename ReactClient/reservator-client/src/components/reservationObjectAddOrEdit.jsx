import React from "react";
import Joi from "joi-browser";
import Form from "./common/form";
import {
  getReservationObject,
  saveReservationObject
} from "../services/reservationObjectService";

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

  doSubmit = async () => {
    await saveReservationObject(this.state.data);

    this.props.history.push("/items");
  };

  async populateReservationObject() {
    try {
      const reservationObjectId = this.props.match.params.id;
      if (reservationObjectId === undefined) return;

      const { data: reservationObject } = await getReservationObject(
        reservationObjectId
      );
      this.setState({ data: this.mapToViewModel(reservationObject) });
    } catch (ex) {
      if (ex.response && ex.response.status === 404)
        this.props.history.replace("/not-found");
    }
  }

  async componentDidMount() {
    await this.populateReservationObject();
  }

  mapToViewModel(reservationObject) {
    return {
      id: reservationObject.id,
      name: reservationObject.name,
      description: reservationObject.description,
      maximumReservationTime: reservationObject.maximumReservationTime
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
