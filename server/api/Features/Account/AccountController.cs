using Microsoft.AspNetCore.Mvc;

using api.Features.Account.Service;

namespace api.Features.Account
{
	[Produces("application/json")]
	[Route("[controller]")]	
	public class AccountController : Controller
	{
		private readonly AccountService accountService;

		public AccountController(AccountService accountService) => this.accountService = accountService;

		// PUT api/account
		[HttpPut]
		public ActionResult Put([FromBody]AccountModel model)
		{
			var result = accountService.Update(model);

			return StatusCode(result.StatusCode, result.Message);
		}

		// DELETE api/account
		[HttpDelete]
		public ActionResult Delete([FromBody] string id)
		{
			var result = accountService.Delete(id);

			return StatusCode(result.StatusCode, result.Message);
		}
	}
}
