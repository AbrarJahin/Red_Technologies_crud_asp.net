using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData
{
	public class Order : BaseModel
	{
		[Column("OrderType"), Required(ErrorMessage = "Order Type should be chosen"), Display(Name = "Orer Type", Prompt = "Please Choose Order Type")]
		public EOrderType OrderType { get; set; }

        //Customer name is in Customer section and created_date is in MaseModel, so they are not added in here

        #region Customer with Foreign Key
        [ScaffoldColumn(false)]
        [Column("CustomerId"), Display(Name = "Customer Id", Prompt = "Please Choose Customer Id")]
        public Guid? CustomerId { get; set; }
        [ForeignKey("CustomerId"), Display(Name = "Customer", Prompt = "Please Select The Customer Who Made The Order")]
        public virtual User Customer { get; set; }
        #endregion
    }
}
