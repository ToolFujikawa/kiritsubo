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
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.SearchKeyWhere<ReadableGoodsReceipt>(db, keywords);
                int openManufacturer_Id = ManufacturerData.NameToId(db, manufacturer)[0];
                int closeManufacturer_Id = ManufacturerData.NameToId(db, manufacturer)[1];
                if (!String.IsNullOrEmpty(keywords))
                {
                    var extractions = db.Database
                                        .SqlQuery<ReadableGoodsReceipt>(where);
                    return extractions
                            .Where(r => r.AccountTitle_Id >= accountTitle_Id
                                        && r.AccountTitle_Id <= accountTitle_Id
                                        && r.FluctuatingDate >= startDate
                                        && r.FluctuatingDate <= endDate
                                        && r.Manufacturer_Id >= openManufacturer_Id
                                        && r.Manufacturer_Id <= closeManufacturer_Id
                                        && r.ResponsibleStaff_Id >= responsibleStaff_Id
                                        && r.ResponsibleStaff_Id <= responsibleStaff_Id)
                             .ToList();
                }
                else
                {
                    return db.ReadableGoodsReceipts
                        .Where(gi => gi.AccountTitle_Id >= accountTitle_Id
                            && gi.AccountTitle_Id <= accountTitle_Id
                            && gi.FluctuatingDate >= startDate
                            && gi.FluctuatingDate <= endDate
                            && gi.Manufacturer_Id >= openManufacturer_Id
                            && gi.Manufacturer_Id <= closeManufacturer_Id
                            && gi.ResponsibleStaff_Id >= responsibleStaff_Id
                            && gi.ResponsibleStaff_Id <= responsibleStaff_Id)
                        .ToList();
                }
            }
        }
    }
}