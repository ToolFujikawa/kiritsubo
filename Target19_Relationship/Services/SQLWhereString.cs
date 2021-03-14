using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Views;

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
            
            sb.Insert(0, "select pr0.Id, ma0.Id as Manufacturer_Id, ma0.CommonName as Manufacturer, pr0.Pseudonym, " + 
                            "pr0.ProductName, pr0.Material, pr0.Model, pr0.Quantity, pr0.LowerLimitQuantity, pr0.OrderQuantity, " +
                            "pr0.TaxRate, tn0.Unit, pr0.Cost, pr0.Valuation, pr0.IsUnmanaged, pr0.Note, pr0.Recorder_Id, pr0.Changer_Id, " +
                            "pr0.RecordingDate, pr0.RecordingTime, pr0.UpdateDate, pr0.UpdateTime, pr0.AccessRoute " +
                            "from products as pr0 left outer join manufacturers as ma0 on pr0.Manufacturer_Id = ma0.Id " +
                            "left outer join transactionunits as tn0 on pr0.TransactionUnit_Id = tn0.Id where");
            return sb.ToString();
        }

        public string SearchKeyWhere<TElement>(DefaultConnection db, string keywords)
        {
            StringBuilder sb = new StringBuilder();
            string[] keywordArray = keywords.Split(new[] { ' ', '　' });

            for (int i = 0; i < keywordArray.Count(); i++)
            {
                if (i == 0)
                {
                    sb.Append(" SearchKey like '%" + keywordArray[i] + "%'");
                }
                else
                {
                    sb.Append(" and SearchKey like '%" + keywordArray[i] + "%'");
                }
            }

            Type t = typeof(TElement);
            string tableName = Pluralize.Plural(t.Name.ToLower());
            string selectStatement = this.Column<TElement>().TrimEnd(',', ' ');
            sb.Insert(0, selectStatement + " from " + tableName + " where");
            return sb.ToString();
        }

        private string Column<TElement>()
        {
            StringBuilder sb = new StringBuilder();
            Type t = typeof(TElement);
            PropertyInfo[] properties = t.GetProperties();
            foreach (var item in properties)
            {
                sb.Append(item.Name + ", ");
            }
            return sb.Insert(0, "select ").ToString();
        }
    }
}