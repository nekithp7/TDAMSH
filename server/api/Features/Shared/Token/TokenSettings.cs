using System;
using System.Text;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace api.Features.Shared.Token
{
	public class TokenSettings
	{
		public string TokenSecret;

		public string Issuer => "api";

		public string Audience => "http://localhost:52047/";

		public SecurityKey IssuerSigningKey =>
			new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GetCryptoSecurityKey()));

		public SigningCredentials SigningCredentials =>
				new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256);

		public TimeSpan TokenExpirationTime => TimeSpan.FromDays(30);

		private string GetCryptoSecurityKey()
		{
			using (var algo = SHA256.Create())
			{
				var result = algo.ComputeHash(Encoding.ASCII.GetBytes(TokenSecret));
				return Encoding.ASCII.GetString(result);
			}
		}
	}
}
