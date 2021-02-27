using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Target19_Relationship.Models;

namespace Target19_Relationship.Services
{
    public class SQLWhereString
    {
        public string ProductWhere(DefaultConnection db, string keywords)
        {
            StringBuilder sb = new StringBuilder();
            string[] keywordArray = keywords.Split(new[] { ' ', '　' });

            for (int i = 0; i < keywordArray.Count(); i++)
            {
                if (i == 0)
                {
                    sb.Append(" pr0.SearchKey like '%" + keywordArray[i] + "%'");
                }
                else
                {
                    sb.Append(" and pr0.SearchKey like '%" + keywordArray[i] + "%'");
                }
            }

            sb.Insert(0, "select * from products as pr0 left outer join manufacturers as ma0 on pr0.Manufacturer_Id = ma0.Id where");
            return sb.ToString();
        }

        public string ProductAttributeWhere(DefaultConnection db, string keywords)
        {
            StringBuilder sb = new StringBuilder();
            string[] keywordArray = keywords.Split(new[] { ' ', '　' });

            for (int i = 0; i < keywordArray.Count(); i++)
            {
                if (i == 0)
                {
                    sb.Append(" ra0.SearchKey like '%" + keywordArray[i] + "%'");
                }
                else
                {
                    sb.Append(" and ra0.SearchKey like '%" + keywordArray[i] + "%'");
                }
            }

            sb.Insert(0, "select * from readableproductattributes as ra0 where");
            return sb.ToString();
        }
    }
}