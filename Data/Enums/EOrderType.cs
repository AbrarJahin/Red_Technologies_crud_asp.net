using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Enums
{
    public enum EOrderType
    {
        //[Display(Name = "Role-Claim Policy")]
        [Description("Standard Order")]
        Standard = 0,
        [Description("Sale Order")]
        Sale_Order,
        [Description("Purchase Order")]
        Purchase_Order,
        [Description("Transfer Order")]
        Transfer_Order,
        [Description("Return Order")]
        Return_Order
    }
}
