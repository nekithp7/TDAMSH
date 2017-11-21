using MongoDB.Bson.Serialization.Attributes;

namespace api.Features.Account
{
	public class AccountModel
	{
		[BsonId]
		public string Id;
		public string FirstName;
		public string LastName;
		public string Email;		
		public string Password;
	}
}
