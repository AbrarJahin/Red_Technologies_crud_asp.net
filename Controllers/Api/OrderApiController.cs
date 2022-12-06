using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.AuthorizationRequirement;
using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.Wrapper;
using StartupProject_Asp.NetCore_PostGRE.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StartupProject_Asp.NetCore_PostGRE.Controllers.Api
{
	[AuthorizePolicy(EClaim.SuperAdmin_All)]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderApiController : ControllerBase
	{
		private readonly IRepositoryWrapper _repository;

		public OrderApiController(IRepositoryWrapper repository)
		{
			_repository = repository;
		}

        [Route("Datatable-Ajax")]
        [HttpPost]
        public async Task<IActionResult> DatatableAjaxAsync()
        {
            try
            {
                string draw = Request.Form["draw"].FirstOrDefault();
                string start = Request.Form["start"].FirstOrDefault();
                string length = Request.Form["length"].FirstOrDefault();
                string sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                string sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                string searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;

                IQueryable<Order> orderData = _repository.Order.FindAll();//.OrderBy(c => c.CreateTime).Where(d=> d.Name.Length>2);
                int recordsTotal = await orderData.CountAsync();

                if (pageSize == -1)
                {
                    pageSize = recordsTotal;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    //customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                    switch (sortColumn)
                    {
                        case "Customer":
                            if (String.Equals(sortColumnDirection, "asc"))
                            {
                                orderData = orderData.OrderBy(c => c.Customer.FirstName).ThenBy(c => c.Customer.LastName);
                            }
                            else
                            {
                                orderData = orderData.OrderByDescending(c => c.Customer.FirstName).ThenBy(c => c.Customer.LastName);
                            }
                            break;
                        case "Order Type":
                            if (String.Equals(sortColumnDirection, "asc"))
                            {
                                orderData = orderData.OrderBy(c => c.OrderType);
                            }
                            else
                            {
                                orderData = orderData.OrderByDescending(c => c.OrderType);
                            }
                            break;
                        case "Total Order Value":
                            if (String.Equals(sortColumnDirection, "asc"))
                            {
                                orderData = orderData.OrderBy(c => c.OrderTotal);
                            }
                            else
                            {
                                orderData = orderData.OrderByDescending(c => c.OrderTotal);
                            }
                            break;
                        case "Order Approval Status":
                            if (String.Equals(sortColumnDirection, "asc"))
                            {
                                orderData = orderData.OrderBy(c => c.IsApproved);
                            }
                            else
                            {
                                orderData = orderData.OrderByDescending(c => c.IsApproved);
                            }
                            break;
                        case "Payment Status":
                            if (String.Equals(sortColumnDirection, "asc"))
                            {
                                orderData = orderData.OrderBy(c => c.IsPaid);
                            }
                            else
                            {
                                orderData = orderData.OrderByDescending(c => c.IsPaid);
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    orderData = orderData.Where(p =>
                                                        p.Customer.FullName.Contains(searchValue)
                                                        ||
                                                        p.OrderType.ToString().Contains(searchValue)
                                                    );
                }
                int recordsFiltered = await orderData.CountAsync();
                var data = await orderData
                                    .Select(product => new {
                                        product.Id,
                                        Customer = product.Customer.FullName,
                                        OrderType = product.OrderType,
                                        IsApproved = product.IsApproved,
                                        IsPaid = product.IsPaid,
                                        OrderTotal = product.OrderTotal.ToString("C2")
                                    })
                                    .Skip(skip)
                                    .Take(pageSize)
                                    .ToListAsync();
                var jsonData = new
                {
                    draw = draw,
                    recordsFiltered = recordsFiltered,
                    recordsTotal = recordsTotal,
                    data = data
                };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
