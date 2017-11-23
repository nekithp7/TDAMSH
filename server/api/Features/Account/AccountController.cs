using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using api.Features.Account.Service;

namespace api.Features.Account
{
	[Produces("application/json")]
	[Route("[controller]")]
	[Authorize]
	public class AccountController : Controller
	{
		private readonly IAccountService accountService;

		public AccountController(IAccountService accountService) => this.accountService = accountService;

		// PUT account/update
		[HttpPut("update")]
		public ActionResult Put([FromBody]AccountModel model)
		{
			var id = User.FindFirstValue(ClaimTypes.Sid);

			var result = accountService.UpdateAccountInfo(id, model);

			return StatusCode(result.StatusCode, result.Message);
		}

		// PUT account/password
		[HttpPut("password")]
		public ActionResult PutPassword([FromBody]AccountModel model)
		{
			var id = User.FindFirstValue(ClaimTypes.Sid);

			var result = accountService.UpdatePassword(id, model.Password);

			return StatusCode(result.StatusCode, result.Message);
		}

		// DELETE account
		[HttpDelete]
		public ActionResult Delete()
		{
			var id = User.FindFirstValue(ClaimTypes.Sid);

			var result = accountService.DeleteAccount(id);

			return StatusCode(result.StatusCode, result.Message);
		}
	}
}
