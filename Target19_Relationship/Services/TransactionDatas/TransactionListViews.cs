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
        public List<ReadableGoodsIssue> GoodsIssueList(string manufacturer, string keywords, int accountTitle_Id
                                                        , int responsibleStaff_Id, DateTime startDate, DateTime endDate)
        {
            List<ReadableGoodsIssue> readableGoodsIssues = new List<ReadableGoodsIssue>();
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.AssembleProductWhere(db, keywords, "goodsissues");
                int[] manufacturer_Ids = NameToId.Manufacturer(db, manufacturer);
                if (where == "Empty")
                {
                    var results = db.GoodsIssues
                                        .Where(gi => gi.AccountTitle_Id >= accountTitle_Id
                                                    && gi.AccountTitle_Id <= accountTitle_Id
                                                    && gi.FluctuatingDate >= startDate
                                                    && gi.FluctuatingDate <= endDate
                                                    && gi.Product.Manufacturer_Id >= manufacturer_Ids[0]
                                                    && gi.Product.Manufacturer_Id <= manufacturer_Ids[1]
                                                    && gi.ResponsibleStaff_Id >= responsibleStaff_Id
                                                    && gi.ResponsibleStaff_Id <= responsibleStaff_Id);
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
                                         .Where(r => r.AccountTitle_Id >= accountTitle_Id
                                                    && r.AccountTitle_Id <= accountTitle_Id
                                                    && r.FluctuatingDate >= startDate
                                                    && r.FluctuatingDate <= endDate
                                                    && r.Product.Manufacturer_Id >= manufacturer_Ids[0]
                                                    && r.Product.Manufacturer_Id <= manufacturer_Ids[1]
                                                    && r.ResponsibleStaff_Id >= responsibleStaff_Id
                                                    && r.ResponsibleStaff_Id <= responsibleStaff_Id);
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

        public List<ReadableGoodsReceipt> GoodsReceiptList(string manufacturer, string keywords, int accountTitle_Id
                                                        , int responsibleStaff_Id, DateTime startDate, DateTime endDate)
        {
            List<ReadableGoodsReceipt> readableGoodsReceipts = new List<ReadableGoodsReceipt>();
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.AssembleProductWhere(db, keywords, "goodsreceipts");
                int[] manufacturer_Ids = NameToId.Manufacturer(db, manufacturer);
                if (where == "Empty")
                {
                    var results = db.GoodsReceipts
                                        .Where(gi => gi.AccountTitle_Id >= accountTitle_Id
                                                    && gi.AccountTitle_Id <= accountTitle_Id
                                                    && gi.FluctuatingDate >= startDate
                                                    && gi.FluctuatingDate <= endDate
                                                    && gi.Product.Manufacturer_Id >= manufacturer_Ids[0]
                                                    && gi.Product.Manufacturer_Id <= manufacturer_Ids[1]
                                                    && gi.ResponsibleStaff_Id >= responsibleStaff_Id
                                                    && gi.ResponsibleStaff_Id <= responsibleStaff_Id);
                    readableGoodsReceipts = results
                                            .Select(r => new ReadableGoodsReceipt
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
                    return readableGoodsReceipts;
                }
                else
                {
                    var extractions = db.Database
                                    .SqlQuery<GoodsReceipt>(where);
                    var results = extractions
                                         .Where(r => r.AccountTitle_Id >= accountTitle_Id
                                                    && r.AccountTitle_Id <= accountTitle_Id
                                                    && r.FluctuatingDate >= startDate
                                                    && r.FluctuatingDate <= endDate
                                                    && r.Product.Manufacturer_Id >= manufacturer_Ids[0]
                                                    && r.Product.Manufacturer_Id <= manufacturer_Ids[1]
                                                    && r.ResponsibleStaff_Id >= responsibleStaff_Id
                                                    && r.ResponsibleStaff_Id <= responsibleStaff_Id);
                    readableGoodsReceipts = results
                                            .Select(r => new ReadableGoodsReceipt
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
                    return readableGoodsReceipts;
                }
            }
        }
    }
}