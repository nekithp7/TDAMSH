using System;

using api.Features.Account;
using api.Features.Shared.Hash;
using api.Features.Shared.User;
using api.Features.Shared.Response;

namespace api.Features.Auth.Service
{
	public class AuthService : IAuthService
	{
		private IHashService hashService;
		private IUserRepository userRepository;

		public AuthService(IUserRepository userRepository, IHashService hashService)
		{
			this.userRepository = userRepository;
			this.hashService = hashService;
		}

		public ResponseModel Login(AuthModel model)
		{
			var user = userRepository.Get(model).Result;

			var result = hashService.VerifyPassword(model.Password, user.Password);

			if (result)
			{
				user.Password = null;
				return new ResponseModel(200, user);
			}
			else
			{
				return new ResponseModel(401, null);
			}
		}

		public ResponseModel Register(AccountModel model)
		{
			model.Id = Guid.NewGuid().ToString();
			model.Password = hashService.CreateHash(model.Password);

			var result = userRepository.Add(model).Result;
			if (result)
			{
				model.Password = null;
				return new ResponseModel(201, model);
			}
			else
			{
				return new ResponseModel(409, Messages.ErrEmail409);
			}			
		}
	}
}
