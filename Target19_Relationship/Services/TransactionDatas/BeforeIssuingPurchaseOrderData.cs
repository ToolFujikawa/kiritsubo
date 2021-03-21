using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Views;

namespace Target19_Relationship.Services.TransactionDatas
{
    public class BeforeIssuingPurchaseOrderData
    {
        public List<BeforeIssuingPurchaseOrder> GetAll()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.BeforeIssuingPurchaseOrders
                            .ToList();
            }
        }
    }
}