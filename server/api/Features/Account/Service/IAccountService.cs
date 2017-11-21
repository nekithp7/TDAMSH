using api.Features.Shared.Response;

namespace api.Features.Account.Service
{
	public interface IAccountService
	{
		ResponseModel Delete(string id);
		ResponseModel Logout();
		ResponseModel Update(AccountModel model);
	}
}
