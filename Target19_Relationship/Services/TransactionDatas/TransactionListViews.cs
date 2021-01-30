using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;
using Target19_Relationship.Models.Views;

namespace Target19_Relationship.Services.TransactionDatas
{
    public class TransactionListViews
    {
        public List<ReadableGoodsIssue> GoodsIssueList()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.ReadableGoodsIssues.ToList();
            }
        } 
    }
}