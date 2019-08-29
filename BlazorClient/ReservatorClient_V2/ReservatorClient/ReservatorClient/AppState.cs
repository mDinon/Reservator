using Microsoft.AspNetCore.Components;
using ReservatorClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReservatorClient
{
	public class AppState
	{
		private readonly string apiUrl = "https://localhost:44381/api";
		public List<Reservation> Reservations { get; set; }
		public List<ReservationObject> ReservationObjects { get; set; }
		public Reservation Reservation { get; set; }
		public ReservationObject ReservationObject { get; set; }

		public event Action OnChange;

		private readonly HttpClient http;
		public AppState(HttpClient httpInstance)
		{
			http = httpInstance;
			if(Reservation == null)
			{
				Reservation = new Reservation();
			}
			if (ReservationObject == null)
			{
				ReservationObject = new ReservationObject();
			}
		}

		#region Reservation

		public async Task GetReservations()
		{
			Console.WriteLine(apiUrl);
			Reservations = await http.GetJsonAsync<List<Reservation>>($"{apiUrl}/reservation");
			NotifyStateChanged();
		}

		public async Task DeleteReservation(int id)
		{
			await http.DeleteAsync($"{apiUrl}/reservation/{id}");
			NotifyStateChanged();
		}

		public async Task SaveReservation(int? id)
		{
			if (id.GetValueOrDefault() > 0)
			{
				await http.SendJsonAsync(HttpMethod.Put, $"{apiUrl}/reservation/{id.Value}", Reservation);
			}
			else
			{
				await http.SendJsonAsync(HttpMethod.Post, $"{apiUrl}/reservation", Reservation);
			}

			NotifyStateChanged();
		}

		#endregion

		#region ReservationObject

		public async Task GetReservationObjects()
		{
			ReservationObjects = await http.GetJsonAsync<List<ReservationObject>>($"{apiUrl}/reservationObject");
			NotifyStateChanged();
		}

		public async Task GetReservationObject(int Id)
		{
			ReservationObject = await http.GetJsonAsync<ReservationObject>($"{apiUrl}/reservationObject/{Id}");
			NotifyStateChanged();
		}

		public async Task SaveReservationObject(int? id)
		{
			if (id.GetValueOrDefault() > 0)
			{
				await http.SendJsonAsync(HttpMethod.Put, $"{apiUrl}/reservationObject/{id.Value}", ReservationObject);
			}
			else
			{
				await http.SendJsonAsync(HttpMethod.Post, $"{apiUrl}/reservationObject", ReservationObject);
			}

			NotifyStateChanged();
		}

		public async Task DeleteReservationObject(int id)
		{
			await http.DeleteAsync($"{apiUrl}/reservationObject/{id}");
			NotifyStateChanged();
		}

		#endregion

		private void NotifyStateChanged() => OnChange?.Invoke();
	}
}
