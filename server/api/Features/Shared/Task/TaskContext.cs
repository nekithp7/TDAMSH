using Microsoft.Extensions.Options;

using MongoDB.Driver;

using api.Features.Task;

namespace api.Features.Shared.Task
{
	public class TaskContext
	{
		private IMongoDatabase database;

		public TaskContext(IOptions<DBContext> dbContext) => database = dbContext.Value.Database;

		public IMongoCollection<TaskModel> Tasks => database.GetCollection<TaskModel>("tasks");
	}
}
