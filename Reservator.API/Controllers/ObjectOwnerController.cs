using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservator.Service.Dto;
using Reservator.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Reservator.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ObjectOwnerController : ControllerBase
	{
		private readonly IObjectOwnerService objectOwnerService;

		public ObjectOwnerController(IObjectOwnerService objectOwnerService)
		{
			this.objectOwnerService = objectOwnerService;
		}
		// GET: api/ObjectOwner
		[HttpGet]
		public async Task<IActionResult> GetObjectOwners()
		{
			return Ok(await objectOwnerService.GetObjectOwnersAsync());
		}

		// GET: api/ObjectOwner/5
		[HttpGet("{id}", Name = "Get")]
		public async Task<IActionResult> Get(int id)
		{
			ObjectOwnerDto objectOwner = await objectOwnerService.GetAsync(id);

			if(objectOwner == null)
			{
				return NotFound();
			}

			return Ok(objectOwner);
		}

		// POST: api/ObjectOwner
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ObjectOwnerDto owner)
		{
			if (owner == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await objectOwnerService.Insert(owner);
			return Ok();
		}

		// PUT: api/ObjectOwner/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] ObjectOwnerDto owner)
		{
			if (owner == null || owner.ID != id)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await objectOwnerService.Update(id, owner);
			return NoContent();
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await objectOwnerService.Delete(id);
			return NoContent();
		}
	}
}
