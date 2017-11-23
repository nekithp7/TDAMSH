using Microsoft.Extensions.Options;

using MongoDB.Driver;

using api.Features.Account;

namespace api.Features.Shared.User
{
	public class UserContext
	{
		private IMongoDatabase database;

		public UserContext(IOptions<DBContext> dbContext) => database = dbContext.Value.Database;

		public IMongoCollection<AccountModel> Users => database.GetCollection<AccountModel>("users");
	}
}
