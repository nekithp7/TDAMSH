using api.Features.Account;
using api.Features.Shared.Response;

namespace api.Features.Auth.Service
{
	public interface IAuthService
	{
		ResponseModel Login(AuthModel model);
		ResponseModel Register(AccountModel model);
	}
}
