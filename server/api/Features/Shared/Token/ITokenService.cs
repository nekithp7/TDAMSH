using api.Features.Account;

namespace api.Features.Shared.Token
{
	public interface ITokenService
	{
		string CreateToken(AccountModel model);
	}
}
