import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/reservation";

function reservationUrl(id) {
  return `${apiEndpoint}/${id}`;
}

export function getReservations() {
  return http.get(apiEndpoint);
}

export function getReservation(id) {
  return http.get(reservationUrl(id));
}

export function saveReservation(reservation) {
  if (reservation.id && reservation.id !== undefined) {
    return http.put(reservationUrl(reservation.id), reservation);
  }

  return http.post(apiEndpoint, reservation);
}

export function deleteReservation(id) {
  return http.delete(reservationUrl(id));
}
