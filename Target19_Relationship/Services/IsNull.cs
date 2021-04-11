using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Services
{
    //Nullを変換するメソッド
    public class IsNull
    {
        public static decimal ToDecimal(object value)
        {
            if (value == null)
            {
                return 0;
            }
            return Convert.ToDecimal(value);
        }

        public static int ToInt(object value)
        {
            if (value == null)
            {
                return 1;
            }
            return Convert.ToInt32(value);
        }

        public static string ToString(object value)
        {
            if (value == null)
            {
                return "";
            }
            return value.ToString();
        }

        public static DateTime ToDate(object value)
        {
            if (value == null)
            {
                return DateTime.Parse("9999-12-31");
            }
            return (DateTime)value;
        }
    }
}