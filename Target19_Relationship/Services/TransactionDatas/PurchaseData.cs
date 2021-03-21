using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Views;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Services.TransactionDatas
{
    public class PurchaseData
    {
        public List<ReadablePurchase> GetSpecificWordGroup(string supplier, string keywords, int staff_Id,
                                                    DateTime purchaseStartDate, DateTime purchaseEndDate,
                                                    DateTime receiptStartDate, DateTime receiptEndDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.SearchKeyWhere<ReadablePurchase>(db, keywords);
                int openSupplier_Id = BusinessPartnerData.NameToId(db, supplier)[0];
                int closeSupplier_Id = BusinessPartnerData.NameToId(db, supplier)[1];
                int openStaff_Id = StaffData.GetIdRange(db, staff_Id)[0];
                int closeStaff_Id = StaffData.GetIdRange(db, staff_Id)[1];
                List<ReadablePurchase> readablePurchases = new List<ReadablePurchase>();

                if (!String.IsNullOrEmpty(keywords))
                {
                    readablePurchases = db.Database
                                            .SqlQuery<ReadablePurchase>(where)
                                            .ToList();
                    return readablePurchases
                            .Where(p => p.Supplier_Id >= openSupplier_Id
                                        && p.Supplier_Id <= closeSupplier_Id
                                        && p.ResponsibleStaff_Id >= openStaff_Id
                                        && p.ResponsibleStaff_Id <= closeStaff_Id
                                        && p.PurchaseDate >= purchaseStartDate
                                        && p.PurchaseDate <= purchaseEndDate
                                        && p.ReceiptDate >= receiptStartDate
                                        && p.ReceiptDate <= receiptEndDate)
                             .ToList();
                }
                else
                {
                    readablePurchases = db.ReadablePurchases
                                            .Where(p => p.Supplier_Id >= openSupplier_Id
                                                        && p.Supplier_Id <= closeSupplier_Id
                                                        && p.ResponsibleStaff_Id >= openStaff_Id
                                                        && p.ResponsibleStaff_Id <= closeStaff_Id
                                                        && p.PurchaseDate >= purchaseStartDate
                                                        && p.PurchaseDate <= purchaseEndDate
                                                        && p.ReceiptDate >= receiptStartDate)
                                            .ToList();
                    return readablePurchases;
                }
            }

        }
    }
}