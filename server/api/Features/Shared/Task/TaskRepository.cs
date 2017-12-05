using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

using MongoDB.Driver;

using api.Features.Task;

namespace api.Features.Shared.Task
{
	public class TaskRepository : ITaskRepository
	{
		private readonly TaskContext taskContext;

		public TaskRepository(IOptions<DBContext> dbContext) => taskContext = new TaskContext(dbContext);

		public async Task<IEnumerable<TaskModel>> GetAllTasks(string userId)
		{
			var filter = Builders<TaskModel>.Filter.Eq(s => s.UserId, userId);

			var documents = await taskContext.Tasks
				.Find(filter)
				.ToListAsync();			

			return documents;
		}

		public async Task<TaskModel> Get(string userId, string taskId)
		{
			var filter = Builders<TaskModel>.Filter.Eq(s => s.Id, taskId) &
				Builders<TaskModel>.Filter.Eq(s => s.UserId, userId);

			var task = await taskContext.Tasks
				.Find(filter)
				.FirstOrDefaultAsync();

			return task;
		}

		public async Task<bool> Add(string userId, TaskModel model)
		{
			try
			{
				await taskContext.Tasks.InsertOneAsync(model);
				return true;
			}
			catch (System.Exception)
			{
				return false;
				throw;
			}
		}

		public async Task<bool> Update(string userId, TaskModel model)
		{
			if (model.Name != null)
			{
				var updateDef = Builders<TaskModel>.Update
				.Set(s => s.Name, model.Name)
				.Set(s => s.Description, model.Description);

				var filter = Builders<TaskModel>.Filter.Eq(s => s.Id, model.Id) &
					Builders<TaskModel>.Filter.Eq(s => s.UserId, userId);

				var result = await taskContext.Tasks.UpdateOneAsync(filter, updateDef);

				return result.IsAcknowledged;
			}
			return false;
		}

		public async Task<bool> Delete(string userId, string taskId)
		{
			var filter = Builders<TaskModel>.Filter.Eq(s => s.Id, taskId) &
				Builders<TaskModel>.Filter.Eq(s => s.UserId, userId);

			var result = await taskContext.Tasks.DeleteOneAsync(filter);

			return result.IsAcknowledged;
		}
	}
}
