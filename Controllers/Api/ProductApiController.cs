using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using StartupProject_Asp.NetCore_PostGRE.Data.Repository.Wrapper;
using StartupProject_Asp.NetCore_PostGRE.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StartupProject_Asp.NetCore_PostGRE.Controllers.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductApiController : ControllerBase
	{
		private readonly UserManager<User> _userManager;
        private readonly IRepositoryWrapper _repository;

        public ProductApiController(IRepositoryWrapper repository, UserManager<User> userManager)
		{
			_userManager = userManager;
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

                IQueryable<Product> productData = _repository.Product.FindAll();//.OrderBy(c => c.CreateTime).Where(d=> d.Name.Length>2);
                int recordsTotal = await productData.CountAsync();

                if (pageSize == -1)
                {
                    pageSize = recordsTotal;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    string nameString = StringHelper.GetDisplayNameString(typeof(Product), "Name");
                    string unitPriceString = StringHelper.GetDisplayNameString(typeof(Product), "UnitPrice");
                    nameString = (nameString == null) ? "Name" : nameString;
                    unitPriceString = (unitPriceString == null) ? "Unit Price" : unitPriceString;

                    if (nameString.Equals(sortColumn))
                    {
                        if (String.Equals(sortColumnDirection, "asc"))
                        {
                            productData = productData.OrderBy(c => c.Name);
                        }
                        else
                        {
                            productData = productData.OrderByDescending(c => c.Name);
                        }
                    }
                    else if (unitPriceString.Equals(sortColumn))
                    {
                        if (String.Equals(sortColumnDirection, "asc"))
                        {
                            productData = productData.OrderBy(c => c.UnitPrice);
                        }
                        else
                        {
                            productData = productData.OrderByDescending(c => c.UnitPrice);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    productData = productData.Where(p =>
                                                        p.Name.Contains(searchValue)
                                                        //||
                                                        //p.UnitPrice.ToString().Contains(searchValue)
                                                    );
                }
                int recordsFiltered = await productData.CountAsync();
                var data = await productData
                                    .Select(product => new {
                                        product.Id,
                                        Name = product.Name,
                                        //LeaveType = ((ELeaveType)product.LeaveType).DesplayName(),
                                        UnitPrice = product.UnitPrice.ToString("C2")
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
