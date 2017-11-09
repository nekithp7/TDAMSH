using Microsoft.AspNetCore.Mvc;

namespace api.Features.Test
{
	[Route("api/[controller]")]
	public class TestController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("{value}")]
		public string Get(int value)
		{
			return $"value: {value}";
		}
	}
}