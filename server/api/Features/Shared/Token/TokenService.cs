using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using api.Features.Account;

namespace api.Features.Shared.Token
{
	public class TokenService : ITokenService
	{
		private TokenSettings tokenSettings;

		public TokenService(IOptions<TokenSettings> tokenSettings) => this.tokenSettings = tokenSettings.Value;

		public string CreateToken(AccountModel model)
		{
			var handler = new JwtSecurityTokenHandler();

			var identity = new ClaimsIdentity();
			identity.AddClaim(new Claim(ClaimTypes.Email, model.Email));
			identity.AddClaim(new Claim(ClaimTypes.Name, model.GetFullName()));
			identity.AddClaim(new Claim(ClaimTypes.Sid, model.Id));

			var token = handler.CreateToken(new SecurityTokenDescriptor
			{
				Issuer = tokenSettings.Issuer,
				Audience = tokenSettings.Audience,
				Subject = identity,
				SigningCredentials = tokenSettings.SigningCredentials,
				Expires = DateTime.Now.Add(tokenSettings.TokenExpirationTime),
				NotBefore = DateTime.Now
			});

			return handler.WriteToken(token);
		}
	}
}
