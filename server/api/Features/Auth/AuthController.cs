using Microsoft.AspNetCore.Mvc;

using api.Features.Account;
using api.Features.Auth.Service;

namespace api.Features.Auth
{
	[Produces("application/json")]
	[Route("[controller]")]
	public class AuthController : Controller
	{
		private readonly IAuthService authService;

		public AuthController(IAuthService authService) => this.authService = authService;

		// POST api/auth/login
		[HttpPost("login")]
		public ActionResult Post([FromBody]AuthModel model)
		{
			var result = authService.Login(model);

			return StatusCode(result.StatusCode, result.Message);
		}

		// POST api/auth/register
		[HttpPost("register")]
		public ActionResult Post([FromBody]AccountModel model)
		{
			var result = authService.Register(model);

			return StatusCode(result.StatusCode, result.Message);
		}
	}
}
