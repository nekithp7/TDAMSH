using api.Features.Shared.User;
using api.Features.Shared.Hash;
using api.Features.Shared.Response;

namespace api.Features.Account.Service
{
	public class AccountService : IAccountService
	{
		private IHashService hashService;
		private IUserRepository userRepository;

		public AccountService(IUserRepository userRepository, IHashService hashService)
		{
			this.userRepository = userRepository;
			this.hashService = hashService;
		}

		public ResponseModel Update(AccountModel model)
		{
			if (model.Password != null && model.Password != string.Empty)
			{
				model.Password = hashService.CreateHash(model.Password);
			}

			var result = userRepository.Put(model).Result;

			if (result)
			{
				return new ResponseModel(200, "");
			}
			else
			{
				return new ResponseModel(404, "");
			}
		}

		public ResponseModel Delete(string id)
		{
			var result = userRepository.Delete(id).Result;

			if (result)
			{
				return new ResponseModel(200, "");
			}
			else
			{
				return new ResponseModel(404, "");
			}
		}

		public ResponseModel Logout()
		{
			return null;
		}
	}
}
