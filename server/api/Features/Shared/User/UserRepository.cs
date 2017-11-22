using System.Threading.Tasks;
using Microsoft.Extensions.Options;

using MongoDB.Driver;

using api.Features.Auth;
using api.Features.Account;

namespace api.Features.Shared.User
{
	public class UserRepository : IUserRepository
	{
		private readonly UserContext userContext;

		public UserRepository(IOptions<DBContext> db) => userContext = new UserContext(db);

		public async Task<AccountModel> Get(AuthModel model)
		{
			var filter = Builders<AccountModel>.Filter.Eq(s => s.Email, model.Email);

			var user = await userContext.Users
			 .Find(filter)
			 .FirstOrDefaultAsync();

			return user;
		}

		public async Task<bool> Add(AccountModel model)
		{
			var filter = Builders<AccountModel>.Filter.Eq(s => s.Email, model.Email);
			try
			{
				await userContext.Users.InsertOneAsync(model);
				return true;
			}
			catch (MongoWriteException exp)
			{
				if (exp.WriteError.Category == ServerErrorCategory.DuplicateKey)
				{
					return false;
				}
				throw exp;
			}
		}

		public async Task<bool> Put(AccountModel model)
		{
			var filter = Builders<AccountModel>.Filter.Eq(s => s.Email, model.Email);

			var current = await userContext.Users
				.Find(filter)
				.FirstOrDefaultAsync();

			var update = Builders<AccountModel>.Update
				.Set(s => s.FirstName, model.FirstName ?? current.FirstName)
				.Set(s => s.LastName, model.LastName ?? current.LastName)
				.Set(s => s.Email, model.Email ?? current.Email)
				.Set(s => s.Password, model.Password ?? current.Password);

			var result = await userContext.Users.UpdateOneAsync(filter, update);

			return result.IsAcknowledged
					&& (result.MatchedCount == 1 || result.ModifiedCount == 1);
		}

		public async Task<bool> Delete(string id)
		{
			var filter = Builders<AccountModel>.Filter.Eq(s => s.Id, id);

			var result = await userContext.Users.DeleteOneAsync(filter);

			return result.IsAcknowledged && result.DeletedCount == 1;
		}
	}
}
