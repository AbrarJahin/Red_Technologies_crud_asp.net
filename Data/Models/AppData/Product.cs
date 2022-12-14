using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData
{
	public class Product : BaseModel
	{
		[Column("Name"), Required(ErrorMessage = "Product Name should be given"), MinLength(3), MaxLength(32767), Display(Name = "Product Name", Prompt = "Please Give Product Name")]
		public string Name { get; set; }

		[Column("UnitPrice"), Required(ErrorMessage = "Product Unit Price required"), Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}."), Display(Name = "Unit Price of the Product", Prompt = "Please Give Product Unit Price")]
		public float UnitPrice { get; set; }

		[Column("AvailableUnit"), Required(ErrorMessage = "Available Unit Count required"), Range(0, Int32.MaxValue, ErrorMessage = "The field {0} must be greater than {1}."), Display(Name = "Available Unit", Prompt = "Please Give Product Count")]
		public int AvailableUnit { get; set; } = 1;

		public virtual ICollection<OrderProduct> OrderProducts { get; set; }
	}
}
