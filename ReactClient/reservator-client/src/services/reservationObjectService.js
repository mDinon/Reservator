import http from "./httpService";
import { apiUrl } from "../config.json";

const apiEndpoint = apiUrl + "/reservationObject";

function reservationObjectUrl(id) {
  return `${apiEndpoint}/${id}`;
}

export function getReservationObjects() {
  return http.get(apiEndpoint);
}

export function getReservationObject(id) {
  return http.get(reservationObjectUrl(id));
}

export function saveReservationObject(reservationObject) {
  if (reservationObject.id && reservationObject.id !== undefined) {
    return http.put(
      reservationObjectUrl(reservationObject.id),
      reservationObject
    );
  }

  return http.post(apiEndpoint, reservationObject);
}

export function deleteReservationObject(id) {
  return http.delete(reservationObjectUrl(id));
}
