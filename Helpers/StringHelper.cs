using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace StartupProject_Asp.NetCore_PostGRE.Helpers
{
	public class StringHelper
	{
        public static string GetDisplayNameString(Type type, string propertyName)
        {
            try
            {
                //type = typeof(Product);
                MemberInfo property = type.GetProperty(propertyName);
                var attribute1 = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                DisplayNameAttribute attribute = attribute1.Cast<DisplayNameAttribute>().Single();
                string displayName = attribute.DisplayName;
                return displayName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
