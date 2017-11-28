using System.Threading.Tasks;
using System.Collections.Generic;

using api.Features.Task;

namespace api.Features.Shared.Task
{
	public interface ITaskRepository
	{
		Task<IEnumerable<TaskModel>> GetAllTasks(string userId);

		Task<TaskModel> Get(string userId, string taskId);

		Task<bool> Add(string userId, TaskModel model);

		Task<bool> Update(string userId, TaskModel model);

		Task<bool> Delete(string userId, string taskId);
	}
}
