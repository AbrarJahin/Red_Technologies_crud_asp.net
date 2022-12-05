using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData
{
	public class OrderProduct : BaseModel
	{
		[Column("UnitBought"), Required(ErrorMessage = "Product Unit Count required"), Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}."), Display(Name = "Unit of the Product", Prompt = "Please Give Product Unit Count")]
		public int UnitBought { get; set; }

        #region Customer Order Foreign Key
        [ScaffoldColumn(false)]
        [Column("OrderId"), Display(Name = "Order Id", Prompt = "Please Choose Order Id")]
        public Guid? OrderId { get; set; }
        [ForeignKey("OrderId"), Display(Name = "Order", Prompt = "Please Select The Order")]
        public virtual Order Order { get; set; }
        #endregion

        #region Customer Order Foreign Key
        [ScaffoldColumn(false)]
        [Column("ProductId"), Display(Name = "Product Id", Prompt = "Please Choose Product Id")]
        public Guid? ProductId { get; set; }
        [ForeignKey("ProductId"), Display(Name = "Product", Prompt = "Please Select The Product")]
        public virtual Product Product { get; set; }
        #endregion
    }
}
