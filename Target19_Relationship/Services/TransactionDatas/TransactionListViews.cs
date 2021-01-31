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
        public List<ReadableGoodsIssue> GoodsIssueList(string manufacturer, string keywords, string accountTitle
                                                        , string responsibleStaff, DateTime startDate, DateTime endDate)
        {
            List<ReadableGoodsIssue> readableGoodsIssues = new List<ReadableGoodsIssue>();
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.AssembleProductWhere(db, keywords, "goodsissues");
                int[] accountTitle_Ids = NameToId.AccountTitle(db, accountTitle);
                var dateTimes = new DateRangeSetting();
                int[] manufacturer_Ids = NameToId.Manufacturer(db, manufacturer);
                int[] responsibleStaff_Ids = NameToId.Staff(db, responsibleStaff);
                if (where == "Empty")
                {
                    var results = db.GoodsIssues
                                        .Where(gi => gi.AccountTitle_Id >= accountTitle_Ids[0]
                                                    && gi.AccountTitle_Id <= accountTitle_Ids[1]
                                                    && gi.FluctuatingDate >= dateTimes.GetRange(startDate, endDate)[0]
                                                    && gi.FluctuatingDate <= dateTimes.GetRange(startDate, endDate)[1]
                                                    && gi.Product.Manufacturer_Id >= manufacturer_Ids[0]
                                                    && gi.Product.Manufacturer_Id <= manufacturer_Ids[1]
                                                    && gi.ResponsibleStaff_Id >= responsibleStaff_Ids[0]
                                                    && gi.ResponsibleStaff_Id <= responsibleStaff_Ids[1]);
                    readableGoodsIssues = results
                                            .Select(r => new ReadableGoodsIssue
                                            {
                                                Id = r.Id,
                                                Product_Id = r.Product_Id,
                                                Product = r.Product.Manufacturer.CommonName + " " + r.Product.ProductName + " " + r.Product.Material + " " + r.Product.Model,
                                                Quantity = r.Quantity,
                                                AccountTitle_Id = r.AccountTitle_Id,
                                                AccountTitle = r.AccountTitle.AccountName,
                                                ResponsibleStaff_Id = r.ResponsibleStaff_Id,
                                                ResponsibleStaff = r.ResponsibleStaff.LastName + r.ResponsibleStaff.FirstName,
                                                FluctuatingDate = r.FluctuatingDate,
                                                Note = r.Note
                                            })
                                            .ToList();
                    return readableGoodsIssues;
                }
                else
                {
                    var extractions = db.Database
                                    .SqlQuery<GoodsIssue>(where);
                    var results = extractions
                                         .Where(r => r.AccountTitle_Id >= accountTitle_Ids[0]
                                                    && r.AccountTitle_Id <= accountTitle_Ids[1]
                                                    && r.FluctuatingDate >= dateTimes.GetRange(startDate, endDate)[0]
                                                    && r.FluctuatingDate <= dateTimes.GetRange(startDate, endDate)[1]
                                                    && r.Product.Manufacturer_Id >= manufacturer_Ids[0]
                                                    && r.Product.Manufacturer_Id <= manufacturer_Ids[1]
                                                    && r.ResponsibleStaff_Id >= responsibleStaff_Ids[0]
                                                    && r.ResponsibleStaff_Id <= responsibleStaff_Ids[1]);
                    readableGoodsIssues = results
                                            .Select(r => new ReadableGoodsIssue
                                            {
                                                Id = r.Id,
                                                Product_Id = r.Product_Id,
                                                Product = r.Product.Manufacturer.CommonName + " " + r.Product.ProductName + " " + r.Product.Material + " " + r.Product.Model,
                                                Quantity = r.Quantity,
                                                AccountTitle_Id = r.AccountTitle_Id,
                                                AccountTitle = r.AccountTitle.AccountName,
                                                ResponsibleStaff_Id = r.ResponsibleStaff_Id,
                                                ResponsibleStaff = r.ResponsibleStaff.LastName + r.ResponsibleStaff.FirstName,
                                                FluctuatingDate = r.FluctuatingDate,
                                                Note = r.Note
                                            })
                                            .ToList();
                    return readableGoodsIssues;
                }
            }
        }
    }
}