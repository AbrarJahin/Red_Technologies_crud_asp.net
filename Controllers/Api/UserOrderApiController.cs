using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StartupProject_Asp.NetCore_PostGRE.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UserOrderApiController : ControllerBase
	{

		// POST api/<UserOrderApiController>
		[HttpPost]
		public List<Guid?> PlaceOrder([FromForm] List<Guid?> id, [FromForm] List<int> count)
		{
			return id;
		}
	}
}
