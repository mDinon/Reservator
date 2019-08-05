using Microsoft.AspNetCore.Mvc;
using Reservator.Service.DTO;
using Reservator.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Reservator.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationObjectController : ControllerBase
	{
		private readonly IReservationObjectService reservationObjectService;

		public ReservationObjectController(IReservationObjectService reservationObjectService)
		{
			this.reservationObjectService = reservationObjectService;
		}
		// GET: api/ReservationObject
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await reservationObjectService.GetAsync());
		}

		// GET: api/ReservationObject/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			ReservationObjectDto reservationObject = await reservationObjectService.GetAsync(id);

			if (reservationObject == null)
			{
				return NotFound();
			}

			return Ok(reservationObject);
		}

		// POST: api/ReservationObject
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ReservationObjectDto reservationObject)
		{
			if (reservationObject == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await reservationObjectService.Insert(reservationObject);
			return Ok();
		}

		// PUT: api/ReservationObject/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] ReservationObjectDto reservationObject)
		{
			if (reservationObject == null || reservationObject.ID != id)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await reservationObjectService.Update(id, reservationObject);
			return NoContent();
		}

		// DELETE: api/ReservationObject/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await reservationObjectService.Delete(id);
			return NoContent();
		}
	}
}
