using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace api.Features.Shared.Hash
{
	public class HashService : IHashService
	{
		private const int SALT_BYTES = 24;
		private const int HASH_BYTES = 18;
		private const int ITERATIONS = 64000;		

		public string CreateHash(string password)
		{
			byte[] salt = new byte[SALT_BYTES];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}

			byte[] hash = GenerateHash(password, salt);

			return Convert.ToBase64String(salt) + Convert.ToBase64String(hash);
		}

		public bool VerifyPassword(string password, string goodHash)
		{
			byte[] saltedHash = Convert.FromBase64String(goodHash);

			byte[] salt = saltedHash.Take(SALT_BYTES).ToArray();
			byte[] hash = saltedHash.Skip(SALT_BYTES).ToArray();

			if (saltedHash.Length != SALT_BYTES + HASH_BYTES) return false;

			byte[] testHash = GenerateHash(password, salt);
			return IsHashesEquals(hash, testHash);
		}

		private bool IsHashesEquals(byte[] a, byte[] b)
		{
			int diff = a.Length ^ b.Length;
			for (int i = 0; i < a.Length && i < b.Length; i++)
			{
				diff |= a[i] ^ b[i];
			}
			return diff == 0;
		}

		private byte[] GenerateHash(string password, byte[] salt)
		{
			return KeyDerivation.Pbkdf2(
				password,
				salt,
				KeyDerivationPrf.HMACSHA256,
				ITERATIONS,
				HASH_BYTES);
		}
	}
}
