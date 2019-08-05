using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservator.Service.Dto;
using Reservator.Service.Services.Interfaces;

namespace Reservator.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationController : ControllerBase
	{
		private readonly IReservationService reservationService;

		public ReservationController(IReservationService reservationService)
		{
			this.reservationService = reservationService;
		}
		// GET: api/Reservation
		[HttpGet]
		public async Task<IActionResult> GetReservations()
		{
			return Ok(await reservationService.GetAsync());
		}

		// GET: api/Reservation/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			ReservationDto reservation = await reservationService.GetAsync(id);
			if(reservation == null)
			{
				return NotFound();
			}

			return Ok(reservation);
		}

		// POST: api/Reservation
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ReservationDto reservation)
		{
			if (reservation == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await reservationService.Insert(reservation);
			return Ok();
		}

		// PUT: api/Reservation/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] ReservationDto reservation)
		{
			if (reservation == null || reservation.ID != id)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await reservationService.Update(id, reservation);
			return NoContent();
		}

		// DELETE: api/Reservation/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await reservationService.Delete(id);
			return NoContent();
		}
	}
}
