using api.Features.Shared.Task;
using api.Features.Shared.Response;

namespace api.Features.Task.Service
{
	public class TaskService : ITaskService
	{
		private ITaskRepository taskRepository;

		public TaskService(ITaskRepository taskRepository) => this.taskRepository = taskRepository;

		public ResponseModel GetAllTasks(string userId)
		{
			throw new System.NotImplementedException();
		}

		public ResponseModel GetTask(string userId, string taskId)
		{
			throw new System.NotImplementedException();
		}

		public ResponseModel AddTask(string userId, TaskModel model)
		{
			throw new System.NotImplementedException();
		}

		public ResponseModel UpdateTask(string userId, string taskId, TaskModel model)
		{
			throw new System.NotImplementedException();
		}

		public ResponseModel DeleteTask(string userId, string taskId)
		{
			throw new System.NotImplementedException();
		}
	}
}
