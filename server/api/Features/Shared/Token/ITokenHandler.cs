using api.Features.Account;

namespace api.Features.Shared.Token
{
	public interface ITokenHandler
	{
		JwtPaket CreateToken(AccountModel model);
	}
}
