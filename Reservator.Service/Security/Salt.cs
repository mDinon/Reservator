using System;
using System.Security.Cryptography;

namespace Reservator.Service.Security
{
	public class Salt
	{
		public static string Create()
		{
			byte[] randomBytes = new byte[128 / 8];
			using (RandomNumberGenerator generator = RandomNumberGenerator.Create())
			{
				generator.GetBytes(randomBytes);
				return Convert.ToBase64String(randomBytes);
			}
		}
	}
}
