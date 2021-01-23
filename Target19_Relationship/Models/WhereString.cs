using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Target19_Relationship.Models;

namespace Target19_Relationship.Models
{
    public class WhereString
    {
        public string AssembleProductWhere(DefaultConnection db, string keywords)
        {
            StringBuilder sb = new StringBuilder();
            string[] keywordArray = keywords.Split(new[] { ' ', '　' });

            foreach (var item in keywordArray)
            {
                int manufacturer_Id = NameToId.Manufacturer(db, item);
                if (manufacturer_Id != 0)
                {
                    if (String.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append(" Manufacturer_Id = " + manufacturer_Id + "");
                    }
                    else
                    {
                        sb.Append(" and Manufacturer_Id = " + manufacturer_Id + "");
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(sb.ToString()))
                    {
                        sb.Append(" SearchKey like '%" + item + "%'");
                    }
                    else
                    {
                        sb.Append(" and SearchKey like '%" + item + "%'");
                    }
                }
            }

            if (sb.Length == 0)
            {
                return "Empty";
            }
            else
            {
                sb.Insert(0, "select * from products where");
                return sb.ToString();
            }
        }
    }
}