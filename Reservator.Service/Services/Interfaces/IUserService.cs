using Reservator.Service.DTO;
using System.Threading.Tasks;

namespace Reservator.Service.Services.Interfaces
{
	public interface IUserService
	{
		Task<UserDto> Authenticate(string username, string password);
		Task<UserDto> Register(UserDto user);
	}
}
