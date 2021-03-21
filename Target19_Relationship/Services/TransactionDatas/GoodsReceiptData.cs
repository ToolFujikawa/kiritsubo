using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Views;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Services.TransactionDatas
{
    public class GoodsReceiptData
    {
        public List<ReadableGoodsReceipt> GetSpecificWordGroup(string manufacturer, string keywords, int accountTitle_Id
                                                        , int responsibleStaff_Id, DateTime startDate, DateTime endDate)
        {
            List<ReadableGoodsReceipt> readableGoodsReceipts = new List<ReadableGoodsReceipt>();
            using (DefaultConnection db = new DefaultConnection())
            {
                int[] manufacturer_Ids = ManufacturerData.NameToId(db, manufacturer);
                int openManufacturer_Id = manufacturer_Ids[0];
                int closeManufacturer_Id = manufacturer_Ids[1];
                int[] accountTitle_Ids = AccountTitleData.GetIdRange(db, accountTitle_Id);
                int openAccountTitle_Id = accountTitle_Ids[0];
                int closeAccountTitle_Id = accountTitle_Ids[1];
                int[] staff_Ids = StaffData.GetIdRange(db, responsibleStaff_Id);
                int openResponsibleStaff_Id = staff_Ids[0];
                int closeResponsibleStaff_Id = staff_Ids[1];
                if (!String.IsNullOrEmpty(keywords))
                {
                    SQLWhereString whereString = new SQLWhereString();
                    string where = whereString.SearchKeyWhere<ReadableGoodsReceipt>(db, keywords);
                    var extractions = db.Database
                                        .SqlQuery<ReadableGoodsReceipt>(where);
                    return extractions
                            .Where(r => r.AccountTitle_Id >= openAccountTitle_Id
                                        && r.AccountTitle_Id <= closeAccountTitle_Id
                                        && r.FluctuatingDate >= startDate
                                        && r.FluctuatingDate <= endDate
                                        && r.Manufacturer_Id >= openManufacturer_Id
                                        && r.Manufacturer_Id <= closeManufacturer_Id
                                        && r.ResponsibleStaff_Id >= openResponsibleStaff_Id
                                        && r.ResponsibleStaff_Id <= closeResponsibleStaff_Id)
                             .ToList();
                }
                else
                {
                    return db.ReadableGoodsReceipts
                        .Where(gi => gi.AccountTitle_Id >= openAccountTitle_Id
                            && gi.AccountTitle_Id <= closeAccountTitle_Id
                            && gi.FluctuatingDate >= startDate
                            && gi.FluctuatingDate <= endDate
                            && gi.Manufacturer_Id >= openManufacturer_Id
                            && gi.Manufacturer_Id <= closeManufacturer_Id
                            && gi.ResponsibleStaff_Id >= openResponsibleStaff_Id
                            && gi.ResponsibleStaff_Id <= closeResponsibleStaff_Id)
                        .ToList();
                }
            }
        }
    }
}