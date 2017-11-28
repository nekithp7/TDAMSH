using api.Features.Shared.Response;

namespace api.Features.Task.Service
{
	public interface ITaskService
	{
		ResponseModel GetAllTasks(string userId);

		ResponseModel GetTask(string userId, string taskId);

		ResponseModel AddTask(string userId, TaskModel model);

		ResponseModel UpdateTask(string userId, TaskModel model);

		ResponseModel DeleteTask(string userId, string taskId);
	}
}
