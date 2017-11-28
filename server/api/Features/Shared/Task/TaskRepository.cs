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

		public Task<IEnumerable<TaskModel>> GetAllTasks(string userId)
		{
			throw new System.NotImplementedException();
		}

		public Task<TaskModel> Get(string userId, string taskId)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> Add(string userId)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> Update(string userId, string taskId, TaskModel model)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> Delete(string userId, string taskId)
		{
			throw new System.NotImplementedException();
		}
	}
}
