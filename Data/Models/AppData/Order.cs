using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System;
using System.Collections.Generic;
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

        public ICollection<OrderProduct> OrderProducts { get; set; }

        [Column("OrderTotal"), Required(ErrorMessage = "Order Total required"), Range(0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}."), Display(Name = "Total Order Value", Prompt = "Please Give Order Total")]
        public float OrderTotal { get; set; } = 0;

        [Column("IsApproved"), Display(Name = "Order Approval Status", Prompt = "Please Select Approval Status")]
        public bool IsApproved { get; set; } = false;

        [Column("IsPaid"), Display(Name = "Payment Status", Prompt = "Please Select Payment Status")]
        public bool IsPaid { get; set; } = false;
    }
}
