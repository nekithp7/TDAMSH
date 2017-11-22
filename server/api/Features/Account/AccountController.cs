using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

		// PUT account
		[HttpPut]
		public ActionResult Put([FromBody]AccountModel model)
		{
			var result = accountService.Update(model);

			return StatusCode(result.StatusCode, result.Message);
		}

		// DELETE account
		[HttpDelete]
		public ActionResult Delete([FromBody] string id)
		{
			var result = accountService.Delete(id);

			return StatusCode(result.StatusCode, result.Message);
		}
	}
}
