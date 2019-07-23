using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Reservator.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Reservator.Service.Security
{
	public class Jwt
	{
		public static void GenerateToken(User user, IOptions<JwtSettings> options)
		{
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			byte[] key = Encoding.ASCII.GetBytes(options.Value.Secret);
			int duration = options.Value.Duration;

			SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.ID.ToString())
				}),
				Expires = DateTime.UtcNow.AddMinutes(duration),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
			user.Token = tokenHandler.WriteToken(token);
		}
	}
}
