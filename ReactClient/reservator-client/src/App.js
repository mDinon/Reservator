import React, { Component } from "react";
import { Route, Redirect, Switch } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import Reservations from "./components/reservations";
import ReservationAdd from "./components/reservationAdd";
import ReservationObjects from "./components/reservationObjects";
import NotFound from "./components/notFound";
import NavBar from "./components/navBar";
import ReservationObjectAddOrEdit from "./components/reservationObjectAddOrEdit";
import LoginForm from "./components/loginForm";
import RegisterForm from "./components/registerForm";
import "react-toastify/dist/ReactToastify.css";
import "./App.css";

class App extends Component {
  render() {
    return (
      <React.Fragment>
        <ToastContainer />
        <NavBar />
        <main className="container">
          <Switch>
            <Route path="/login" component={LoginForm} />
            <Route path="/register" component={RegisterForm} />
            <Route path="/reservations/add" component={ReservationAdd} />
            <Route path="/reservations" component={Reservations} />
            <Route path="/items/add" component={ReservationObjectAddOrEdit} />
            <Route path="/items/edit" component={ReservationObjectAddOrEdit} />
            <Route path="/items" component={ReservationObjects} />
            <Route path="/not-found" component={NotFound} />
            <Redirect from="/" exact to="/reservations" />
            <Redirect to="/not-found" />
          </Switch>
        </main>
      </React.Fragment>
    );
  }
}

export default App;
