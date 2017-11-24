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

		/// <summary>
		/// Updates user information
		/// </summary>
		/// <param name="model">New user information</param>
		/// <response code="200">User information updated</response>
		/// <response code="409">If new Email is not available</response>
		[HttpPut("update")]
		public ActionResult Put([FromBody]AccountModel model)
		{
			var id = User.FindFirstValue(ClaimTypes.Sid);

			var result = accountService.UpdateAccountInfo(id, model);

			return StatusCode(result.StatusCode, result.Message);
		}

		/// <summary>
		/// Updates user password
		/// </summary>
		/// <param name="model">New user information</param>
		/// <response code="200">Password updated</response>
		[HttpPut("password")]
		public ActionResult PutPassword([FromBody]AccountModel model)
		{
			var id = User.FindFirstValue(ClaimTypes.Sid);

			var result = accountService.UpdatePassword(id, model.Password);

			return StatusCode(result.StatusCode, result.Message);
		}

		/// <summary>
		/// Deletes user from system
		/// </summary>
		/// <response code="200">User deleted</response>
		[HttpDelete]
		public ActionResult Delete()
		{
			var id = User.FindFirstValue(ClaimTypes.Sid);

			var result = accountService.DeleteAccount(id);

			return StatusCode(result.StatusCode, result.Message);
		}
	}
}
