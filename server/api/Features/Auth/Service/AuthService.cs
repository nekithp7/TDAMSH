using System;

using api.Features.Shared.Hash;
using api.Features.Shared.User;
using api.Features.Shared.Token;
using api.Features.Shared.Response;
using api.Features.Account;

namespace api.Features.Auth.Service
{
	public class AuthService : IAuthService
	{
		private IHashService hashService;
		private IUserRepository userRepository;
		private ITokenService tokenService;

		public AuthService(IUserRepository userRepository, IHashService hashService, ITokenService tokenService)
		{
			this.userRepository = userRepository;
			this.hashService = hashService;
			this.tokenService = tokenService;
		}

		public ResponseModel Login(AuthModel model)
		{
			var user = userRepository.Get(model).Result;

			if (user != null)
			{
				var result = hashService.VerifyPassword(model.Password, user.Password);

				if (result)
				{					
					var msg = tokenService.CreateToken(user);
					return new ResponseModel(200, msg);
				}
			}
			return new ResponseModel(401, "Incorrect Email or password.");
		}

		public ResponseModel Register(AccountModel model)
		{
			model.Id = Guid.NewGuid().ToString();
			model.Password = hashService.CreateHash(model.Password);

			var result = userRepository.Add(model).Result;
			if (result)
			{				
				var msg = tokenService.CreateToken(model);
				return new ResponseModel(201, msg);
			}
			else
			{
				return new ResponseModel(409, Messages.ErrEmail409);
			}
		}
	}
}
