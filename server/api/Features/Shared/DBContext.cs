using MongoDB.Driver;

namespace api.Features.Shared
{
	public class DBContext
	{
		private IMongoDatabase database;
		public string ConnectionString { get; set; }
		public string DBName { get; set; }

		public IMongoDatabase Database
		{
			get
			{
				if (database == null)
				{
					var client = new MongoClient(ConnectionString);
					database = client?.GetDatabase(DBName);
				}

				return database;
			}
		}
	}
}
