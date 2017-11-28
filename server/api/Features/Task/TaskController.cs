using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using api.Features.Task.Service;

namespace api.Features.Task
{
	[Produces("application/json")]
	[Route("[controller]")]
	[Authorize]
	public class TaskController : Controller
	{
		private readonly ITaskService taskService;

		public TaskController(ITaskService taskService) => this.taskService = taskService;

		string Id => User?.FindFirstValue(ClaimTypes.Sid);

		[HttpGet("all")]
		public ActionResult GetAllTasks()
		{
			var result = taskService.GetAllTasks(Id);

			return StatusCode(result.StatusCode, result.Message);
		}

		[HttpGet]
		public ActionResult GetTask([FromQuery]string taskId)
		{
			var result = taskService.GetTask(Id, taskId);

			return StatusCode(result.StatusCode, result.Message);
		}

		[HttpPost]
		public ActionResult AddTask([FromBody]TaskModel model)
		{
			var result = taskService.AddTask(Id, model);

			return StatusCode(result.StatusCode, result.Message);
		}

		[HttpPut]
		public ActionResult UpdateTask([FromBody]TaskModel model)
		{
			var result = taskService.UpdateTask(Id, model);

			return StatusCode(result.StatusCode, result.Message);
		}

		[HttpDelete]
		public ActionResult DeleteTask([FromQuery]string taskId)
		{
			var result = taskService.DeleteTask(Id, taskId);

			return StatusCode(result.StatusCode, result.Message);
		}
	}
}
