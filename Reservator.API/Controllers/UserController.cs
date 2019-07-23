using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservator.Service.DTO;
using Reservator.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Reservator.API.Controllers
{
	[Authorize]
	[Produces("application/json")]
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public ActionResult Authenticate([FromBody]UserDto userDto)
		{
			Task<UserDto> user = userService.Authenticate(userDto.Username, userDto.Password);

			return Ok(user);
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public IActionResult Register([FromBody]UserDto userDto)
		{
			Task<UserDto> user = userService.Register(userDto);

			return Ok(user);
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(new UserDto());
		}
	}
}
