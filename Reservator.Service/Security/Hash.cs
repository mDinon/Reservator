using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Text;

namespace Reservator.Service.Security
{
	public class Hash
	{
		public static HashSalt Create(string value, string salt)
		{
			byte[] valueBytes = KeyDerivation.Pbkdf2(
								password: value,
								salt: Encoding.UTF8.GetBytes(salt),
								prf: KeyDerivationPrf.HMACSHA512,
								iterationCount: 10000,
								numBytesRequested: 256 / 8);

			return new HashSalt()
			{
				Hash = Convert.ToBase64String(valueBytes),
				Salt = salt
			};
		}

		public static bool Validate(string value, string salt, string hash)
		{
			return Create(value, salt).Hash == hash;
		}
	}
}
