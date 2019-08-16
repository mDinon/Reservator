import React, { Component } from "react";
import ReservationObjectsTable from "./reservationObjectsTable";
import { toast } from "react-toastify";
import {
  getReservationObjects,
  deleteReservationObject
} from "../services/reservationObjectService";
import Pagination from "./common/pagination";
import { paginate } from "./../services/utils/paginate";
import _ from "lodash";

class ReservationObjects extends Component {
  state = {
    reservationObjects: [],
    currentPage: 1,
    pageSize: 4,
    sortColumn: { path: "id", order: "asc" }
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

  handleSort = sortColumn => {
    this.setState({ sortColumn });
  };

  handlePageChange = page => {
    this.setState({ currentPage: page });
  };

  getPagedData = () => {
    const {
      currentPage,
      pageSize,
      sortColumn,
      reservationObjects: allReservationObjects
    } = this.state;

    const sorted = _.orderBy(
      allReservationObjects,
      [sortColumn.path],
      [sortColumn.order]
    );

    return paginate(sorted, currentPage, pageSize);
  };

  render() {
    const { length: count } = this.state.reservationObjects;
    const { currentPage, pageSize, sortColumn } = this.state;

    const reservationObjects = this.getPagedData();

    return (
      <React.Fragment>
        <h1 style={{ marginBottom: 50 }}>Items</h1>
        <button
          className="btn btn-sm btn-primary"
          style={{ marginBottom: 20 }}
          onClick={this.handleAddingNew}
        >
          <i className="fa fa-plus m-1" />
          Add new
        </button>
        <ReservationObjectsTable
          reservationObjects={reservationObjects}
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

export default ReservationObjects;
