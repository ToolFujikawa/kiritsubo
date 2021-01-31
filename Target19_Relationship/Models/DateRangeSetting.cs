using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models
{
    public class DateRangeSetting
    {
        public DateTime[] GetRange(DateTime start, DateTime end)
        {
            DateTime[] results = new DateTime[2];

            if (start == DateTime.Parse("9999-12-31"))
            {
                results[0] = DateTime.Parse("1000-01-01");
            }
            else
            {
                results[0] = start;
            }

            results[1] = end;

            return results;
        } 
    }
}