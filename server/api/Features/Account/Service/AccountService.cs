using api.Features.Shared.User;
using api.Features.Shared.Hash;
using api.Features.Shared.Response;

namespace api.Features.Account.Service
{
	public class AccountService : IAccountService //TODO: new token on password change
	{
		private IHashService hashService;
		private IUserRepository userRepository;

		public AccountService(IUserRepository userRepository, IHashService hashService)
		{
			this.userRepository = userRepository;
			this.hashService = hashService;
		}

		public ResponseModel UpdatePassword(string id, string newPassword)
		{
			var hash = hashService.CreateHash(newPassword);

			var result = userRepository.UpdatePassword(id, hash).Result;

			if (result)
			{
				return new ResponseModel(200, "");
			}
			else
			{
				return new ResponseModel(404, "");
			}
		}

		public ResponseModel UpdateAccountInfo(string id, AccountModel model)
		{
			var result = userRepository.Update(id, model).Result;

			if (result)
			{
				return new ResponseModel(200, "");
			}
			else
			{
				return new ResponseModel(409, "Email is not available");
			}
		}

		public ResponseModel DeleteAccount(string id)
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
