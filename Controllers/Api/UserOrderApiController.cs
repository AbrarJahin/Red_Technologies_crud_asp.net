using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.Wrapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StartupProject_Asp.NetCore_PostGRE.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UserOrderApiController : ControllerBase
	{

		private readonly UserManager<User> _userManager;
		private readonly IRepositoryWrapper _repository;

		public UserOrderApiController(IRepositoryWrapper repository, UserManager<User> userManager)
		{
			_userManager = userManager;
			_repository = repository;
		}
		// POST api/<UserOrderApiController>
		[HttpPost]
		public async Task<IActionResult> PlaceOrderAsync([FromForm] List<Guid?> id, [FromForm] List<int> count)
		{
			try
			{
				User loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
				await _repository.Order.PlaceOrder(id, count, loggedInUser);
				await _repository.SaveAsync();
				return Ok("Order Placed Successfully");
			}
			catch (Exception ex) {
				Console.WriteLine(ex);
				return BadRequest("Order Failed");
			}
		}
	}
}
