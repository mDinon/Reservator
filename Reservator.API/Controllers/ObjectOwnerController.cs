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
			return Ok(await objectOwnerService.GetObjectOwnersAync());
		}

		// GET: api/ObjectOwner/5
		[HttpGet("{id}", Name = "Get")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await objectOwnerService.GetAsync(id));
		}

		// POST: api/ObjectOwner
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ObjectOwnerDto owner)
		{
			if (owner == null)
				return BadRequest();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await objectOwnerService.Insert(owner);
			return Ok();
		}

		// PUT: api/ObjectOwner/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] ObjectOwnerDto owner)
		{
			if (owner == null || owner.ID != id)
				return BadRequest();

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

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
