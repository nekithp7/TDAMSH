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

		public UserRepository(IOptions<DBContext> dbContext) => userContext = new UserContext(dbContext);

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

		public async Task<bool> Update(string id, AccountModel model)
		{
			if (model.Email != null)
			{
				var isEmailAvailable = CheckEmailAvailability(id, model.Email);
				if (!isEmailAvailable)
				{
					return false;
				}
			}

			var updateDef = Builders<AccountModel>.Update
				.Set(s => s.Email, model.Email)
				.Set(s => s.FirstName, model.FirstName)
				.Set(s => s.LastName, model.LastName);

			return await Update(id, updateDef);
		}

		public async Task<bool> UpdatePassword(string id, string newPassword)
		{
			var updateDef = Builders<AccountModel>.Update
				.Set(s => s.Password, newPassword);

			return await Update(id, updateDef);
		}

		public async Task<bool> Delete(string id)
		{
			var filter = Builders<AccountModel>.Filter.Eq(s => s.Id, id);

			var result = await userContext.Users.DeleteOneAsync(filter);

			return result.IsAcknowledged;
		}

		private async Task<bool> Update(string id, UpdateDefinition<AccountModel> update)
		{
			var filter = Builders<AccountModel>.Filter.Eq(s => s.Id, id);
			var result = await userContext.Users.UpdateOneAsync(filter, update);

			return result.IsAcknowledged;
		}

		private bool CheckEmailAvailability(string id, string email)
		{
			var filter = Builders<AccountModel>.Filter.Eq(s => s.Email, email);
			var user = userContext.Users
				.Find(filter)
				.FirstOrDefault();

			if (user != null && user.Id != id)
			{
				return false;
			}
			return true;
		}
	}
}
