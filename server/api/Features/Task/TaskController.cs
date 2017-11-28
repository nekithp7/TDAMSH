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
	}
}
