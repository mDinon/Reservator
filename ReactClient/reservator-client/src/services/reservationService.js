import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/reservation";

export function getReservations() {
  return http.get(apiEndpoint);
}

export function getReservation(id) {
  return http.get(`${apiEndpoint}/${id}`);
}

export function saveResevation(reservation) {}

export function deleteReservation(id) {
  return http.delete(`${apiEndpoint}/${id}`);
}
