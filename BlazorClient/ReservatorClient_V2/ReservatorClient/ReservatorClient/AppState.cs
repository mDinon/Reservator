using Microsoft.AspNetCore.Components;
using ReservatorClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReservatorClient
{
	public class AppState
	{
		public List<Reservation> Reservations { get; set; }

		public event Action OnChange;

		private readonly HttpClient http;
		public AppState(HttpClient httpInstance)
		{
			http = httpInstance;
		}

		public async Task GetReservations()
		{
			Reservations = await http.GetJsonAsync<List<Reservation>>("https://localhost:44381/api/reservation");
			NotifyStateChanged();
		}

		public async Task DeleteReservation(int id)
		{
			await http.DeleteAsync($"https://localhost:44381/api/reservation/{id}");
			NotifyStateChanged();
		}

		private void NotifyStateChanged() => OnChange?.Invoke();
	}
}
