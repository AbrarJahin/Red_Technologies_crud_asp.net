using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Enums
{
	public enum EOrderType
    {
        //[Display(Name = "Role-Claim Policy")]
        [Description("Standard Order"), Display(Name = "Standard Order")]
        Standard = 0,
        [Description("Sale Order"), Display(Name = "Sale Order")]
        Sale_Order,
        [Description("Purchase Order"), Display(Name = "Purchase Order")]
        Purchase_Order,
        [Description("Transfer Order"), Display(Name = "Transfer Order")]
        Transfer_Order,
        [Description("Return Order"), Display(Name = "Return Order")]
        Return_Order
    }
}
