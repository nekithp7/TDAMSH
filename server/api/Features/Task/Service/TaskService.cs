using System;

using Newtonsoft.Json;

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
			var tasks = taskRepository.GetAllTasks(userId).Result;

			var json = JsonConvert.SerializeObject(tasks);

			return new ResponseModel(200, json);
		}

		public ResponseModel GetTask(string userId, string taskId)
		{
			if (taskId != null && taskId != string.Empty)
			{
				var task = taskRepository.Get(userId, taskId).Result;

				if (task != null)
				{
					return new ResponseModel(200, task);
				}
				return new ResponseModel(404, "");
			}
			return new ResponseModel(400, "taskId");
		}

		public ResponseModel AddTask(string userId, TaskModel model)
		{
			if (model != null)
			{
				model.Id = Guid.NewGuid().ToString();
				model.UserId = userId;

				var result = taskRepository.Add(userId, model).Result;

				if (result)
				{
					return new ResponseModel(200, "");
				}
				return new ResponseModel(500, "");
			}
			return new ResponseModel(400, "model");
		}

		public ResponseModel UpdateTask(string userId, TaskModel model)
		{
			if (model != null)
			{
				var task = taskRepository.Update(userId, model).Result;

				if (task)
				{
					return new ResponseModel(200, "");
				}
				return new ResponseModel(500, "");
			}
			return new ResponseModel(400, "model");
		}

		public ResponseModel DeleteTask(string userId, string taskId)
		{
			if (taskId != null && taskId != string.Empty)
			{
				var result = taskRepository.Delete(userId, taskId).Result;

				if (result)
				{
					return new ResponseModel(200, "");
				}
				return new ResponseModel(500, "");
			}
			return new ResponseModel(400, "model");
		}
	}
}
