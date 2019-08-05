import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/reservationObject";

export function getReservationObjects() {
  return http.get(apiEndpoint);
}

export function getReservationObject(id) {
  return http.get(`${apiEndpoint}/${id}`);
}

export function saveReservationObject(reservationObject) {}

export function deleteReservationObject(id) {
  return http.delete(`${apiEndpoint}/${id}`);
}
