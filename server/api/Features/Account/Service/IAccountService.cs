using api.Features.Shared.Response;

namespace api.Features.Account.Service
{
	public interface IAccountService
	{
		ResponseModel UpdatePassword(string id, string newPassword);
		ResponseModel UpdateAccountInfo(string id, AccountModel model);
		ResponseModel DeleteAccount(string id);
		ResponseModel Logout();		
	}
}
