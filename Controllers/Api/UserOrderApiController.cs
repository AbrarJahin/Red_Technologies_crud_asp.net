using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StartupProject_Asp.NetCore_PostGRE.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserOrderApiController : ControllerBase
	{
		//// GET: api/<UserOrderApiController>
		//[HttpGet]
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		//// GET api/<UserOrderApiController>/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//	return "value";
		//}

		// POST api/<UserOrderApiController>
		[HttpPost]
		public List<Guid?> GetProductUnitPrice([FromBody] List<Guid?> idList)
		{
			return idList;
		}

		//// PUT api/<UserOrderApiController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/<UserOrderApiController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
