using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using api.Features.Account;

namespace api.Features.Shared.Token
{
	public class TokenHandler : ITokenHandler
	{
		private TokenSettings tokenSettings;

		public TokenHandler(IOptions<TokenSettings> tokenSettings) => this.tokenSettings = tokenSettings.Value;

		public JwtPaket CreateToken(AccountModel model)
		{
			var handler = new JwtSecurityTokenHandler();

			var token = handler.CreateToken(new SecurityTokenDescriptor
			{
				Issuer = tokenSettings.Issuer,
				Audience = tokenSettings.Audience,
				SigningCredentials = tokenSettings.SigningCredentials,
				Expires = DateTime.Now.Add(tokenSettings.TokenExpirationTime),
				NotBefore = DateTime.Now
			});

			return new JwtPaket
			{
				AccessToken = handler.WriteToken(token),
				Email = model.Email
			};
		}
	}
}
