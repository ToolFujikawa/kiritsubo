using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Details;
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

        public List<ReadableJournal> JournalList(string businessPartner, int debit_Id, int credit_Id, string keywords,
                                                    DateTime startDate, DateTime endDate)
        {
            List<ReadableJournal> readableJournals = new List<ReadableJournal>();
            string[] keywordArray = keywords.Split(new[] { ' ', '　' });
            using (DefaultConnection db = new DefaultConnection())
            {
                int[] businessPartner_Ids = new int[2] { NameToId.BusinessPartner(db, businessPartner)[0],
                                                            NameToId.BusinessPartner(db, businessPartner)[1] };
                int[] debit_Ids = new int[2] { IdRange.AccountTitle(db, debit_Id)[0], IdRange.AccountTitle(db, debit_Id)[1] };
                int[] credit_Ids = new int[2] { IdRange.AccountTitle(db, credit_Id)[0], IdRange.AccountTitle(db, credit_Id)[1] };
                var anonymous = db.Journals
                                    .Where(j => j.BusinessPartner_Id >= businessPartner_Ids[0]
                                                && j.BusinessPartner_Id <= businessPartner_Ids[1]
                                                && j.Debit_Id >= debit_Ids[0]
                                                && j.Debit_Id <= debit_Ids[1]
                                                && j.Credit_Id >= credit_Ids[0]
                                                && j.Credit_Id <= credit_Ids[1]
                                                && j.AccountingDate >= startDate
                                                && j.AccountingDate <= endDate);

                foreach (var item in keywordArray)
                {
                    anonymous = anonymous
                                .Where(a => a.Apply.Contains(item));
                }

                readableJournals = anonymous
                                    .Select(a => new ReadableJournal
                                    {
                                        Id = a.Id,
                                        AccountingDate = a.AccountingDate,
                                        BusinessPartner_Id = a.BusinessPartner_Id,
                                        BusinessPartner = a.BusinessPartner.CommonName,
                                        Credit_Id = a.Credit_Id,
                                        Credit = a.CreditTitle.AccountName,
                                        Debit_Id = a.Debit_Id,
                                        Debit = a.DebitTitle.AccountName,
                                        Amount = a.Amount,
                                        Tax = a.Tax,
                                        Apply = a.Apply,
                                        FinancialInstitution_Id = a.FinancialInstitution_Id,
                                        FinancialInstitution = a.FinancialInstitution.FinancialInstitutionName,
                                        FinancialInstitutionBranch_Id = a.FinancialInstitutionBranch_Id,
                                        FinancialInstitutionBranch = a.FinancialInstitutionBranche.Branch,
                                        BillStatuses = a.BillStatuses,
                                        BillNo = a.BillNo,
                                        PaymentDate = a.PaymentDate,
                                        IssuedFinancialInstitution_Id = a.IssuedFinancialInstitution_Id,
                                        IssuedFinancialInstitution = a.IssuedFinancialInstitution.FinancialInstitutionName,
                                        IssuedFinancialInstitutionBranch_Id = a.IssuedFinancialInstitutionBranch_Id,
                                        IssuedFinancialInstitutionBranch = a.IssuedFinancialInstitutionBranche.Branch,
                                        Transferee_Id = a.Transferee_Id,
                                        Transferee = a.Transferee.CommonName,
                                        EndorsementTransferDate = a.EndorsementTransferDate,
                                        Note = a.Note
                                    })
                                    .ToList();

                return readableJournals;
            }
        }
    }
}