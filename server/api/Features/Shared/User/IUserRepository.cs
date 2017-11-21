using System.Threading.Tasks;

using api.Features.Auth;
using api.Features.Account;

namespace api.Features.Shared.User
{
	public interface IUserRepository
	{
		Task<AccountModel> Get(AuthModel model);

		Task<bool> Add(AccountModel model);

		Task<bool> Put(AccountModel model);

		Task<bool> Delete(string id);
	}
}
