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
        public List<BeforeDelivery> BeforeDeliveryList(int customer_Id, int manufacturer_Id, string keywords, int responsibleStaff_Id,
                                                        int helper_Id, DateTime startDate, DateTime endDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                int openCustomer_Id = IdRange.BusinessPartner(db, customer_Id)[0];
                int closeCustomer_Id = IdRange.BusinessPartner(db, customer_Id)[1];
                int openManufacturer_Id = IdRange.Manufacturer(db, manufacturer_Id)[0];
                int closeManufacturer_Id = IdRange.Manufacturer(db, manufacturer_Id)[1];
                int openStaff_Id = IdRange.Staff(db, responsibleStaff_Id)[0];
                int closeStaff_Id = IdRange.Staff(db, responsibleStaff_Id)[1];
                int openHelper_Id = IdRange.Helper(db, helper_Id)[0];
                int closeHelper_Id = IdRange.Helper(db, helper_Id)[1];
                List<BeforeDelivery> beforeDeliveries = new List<BeforeDelivery>();

                if (!String.IsNullOrEmpty(keywords))
                {
                    SQLWhereString whereString = new SQLWhereString();
                    string where = whereString.SearchKeyWhere<BeforeDelivery>(db, keywords);
                    string[] keywordArray = keywords.Split(new[] { ' ', '　' });
                    beforeDeliveries = db.Database
                                            .SqlQuery<BeforeDelivery>(where)
                                            .ToList();
                    beforeDeliveries = beforeDeliveries
                                        .Where(so => so.Customer_Id >= openCustomer_Id
                                            && so.Customer_Id <= closeCustomer_Id
                                            && so.Manufacturer_Id >= openManufacturer_Id
                                            && so.Manufacturer_Id <= closeManufacturer_Id
                                            && so.ResponsibleStaff_Id >= openStaff_Id
                                            && so.ResponsibleStaff_Id <= closeStaff_Id
                                            && so.Helper_Id >= openHelper_Id
                                            && so.Helper_Id <= closeHelper_Id
                                            && so.SalesOrderDate >= startDate
                                            && so.SalesOrderDate <= endDate)
                                        .ToList();
                    return beforeDeliveries;
                }
                else
                {
                    beforeDeliveries = db.BeforeDeliveries
                                        .Where(so => so.Customer_Id >= openCustomer_Id
                                            && so.Customer_Id <= closeCustomer_Id
                                            && so.Manufacturer_Id >= openManufacturer_Id
                                            && so.Manufacturer_Id <= closeManufacturer_Id
                                            && so.ResponsibleStaff_Id >= openStaff_Id
                                            && so.ResponsibleStaff_Id <= closeStaff_Id
                                            && so.Helper_Id >= openHelper_Id
                                            && so.Helper_Id <= closeHelper_Id
                                            && so.SalesOrderDate >= startDate
                                            && so.SalesOrderDate <= endDate)
                                        .ToList();
                    return beforeDeliveries;
                }
            }
        }

        public List<BeforeIssuingPurchaseOrder> BeforeIssuingPurchaseOrderList()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.BeforeIssuingPurchaseOrders
                            .ToList();
            }
        }

        public List<BeforeWarehousing> BeforeWarehousingList(int supplier_Id, int manufacturer_Id, string keywords,
                                                        DateTime startDate, DateTime endDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                int openManufacturer_Id = IdRange.Manufacturer(db, manufacturer_Id)[0];
                int closeManufacturer_Id = IdRange.Manufacturer(db, manufacturer_Id)[1];
                int openSupplier_Id = IdRange.BusinessPartner(db, supplier_Id)[0];
                int closeSupplier_Id = IdRange.BusinessPartner(db, supplier_Id)[1];
                List<BeforeWarehousing> beforeWarehousings = new List<BeforeWarehousing>();

                if (!String.IsNullOrEmpty(keywords))
                {
                    SQLWhereString whereString = new SQLWhereString();
                    string where = whereString.SearchKeyWhere<BeforeWarehousing>(db, keywords);
                    beforeWarehousings = db.Database
                                            .SqlQuery<BeforeWarehousing>(where)
                                            .ToList();
                    beforeWarehousings = beforeWarehousings
                                            .Where(bw => bw.Supplier_Id >= openSupplier_Id
                                            && bw.Supplier_Id <= closeSupplier_Id
                                            && bw.Manufacturer_Id >= openManufacturer_Id
                                            && bw.Manufacturer_Id <= closeManufacturer_Id
                                            && bw.PurchaseDate >= startDate
                                            && bw.PurchaseDate <= endDate)
                                    .ToList();
                    return beforeWarehousings;
                }
                else
                {
                    beforeWarehousings = db.BeforeWarehousings
                                            .Where(bw => bw.Supplier_Id >= openSupplier_Id
                                            && bw.Supplier_Id <= closeSupplier_Id
                                            && bw.Manufacturer_Id >= openManufacturer_Id
                                            && bw.Manufacturer_Id <= closeManufacturer_Id
                                            && bw.PurchaseDate >= startDate
                                            && bw.PurchaseDate <= endDate)
                                    .ToList();
                    return beforeWarehousings;
                }
            }
        }

        public List<ReadableGoodsIssue> GoodsIssueList(string manufacturer, string keywords, int accountTitle_Id
                                                        , int responsibleStaff_Id, DateTime startDate, DateTime endDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.SearchKeyWhere<ReadableGoodsIssue>(db, keywords);
                int openManufacturer_Id = NameToId.Manufacturer(db, manufacturer)[0];
                int closeManufacturer_Id = NameToId.Manufacturer(db, manufacturer)[1];
                List<ReadableGoodsIssue> readableGoodsIssues = new List<ReadableGoodsIssue>();
                if (!String.IsNullOrEmpty(keywords))
                {
                    readableGoodsIssues = db.Database
                                            .SqlQuery<ReadableGoodsIssue>(where)
                                            .ToList();

                    readableGoodsIssues = readableGoodsIssues
                                            .Where(gi => gi.AccountTitle_Id >= accountTitle_Id
                                                    && gi.AccountTitle_Id <= accountTitle_Id
                                                    && gi.FluctuatingDate >= startDate
                                                    && gi.FluctuatingDate <= endDate
                                                    && gi.Manufacturer_Id >= openManufacturer_Id
                                                    && gi.Manufacturer_Id <= closeManufacturer_Id
                                                    && gi.ResponsibleStaff_Id >= responsibleStaff_Id
                                                    && gi.ResponsibleStaff_Id <= responsibleStaff_Id)
                                            .ToList();
                    return readableGoodsIssues;
                }
                else
                {
                    readableGoodsIssues = db.ReadableGoodsIssues
                                         .Where(r => r.AccountTitle_Id >= accountTitle_Id
                                                    && r.AccountTitle_Id <= accountTitle_Id
                                                    && r.FluctuatingDate >= startDate
                                                    && r.FluctuatingDate <= endDate
                                                    && r.Manufacturer_Id >= openManufacturer_Id
                                                    && r.Manufacturer_Id <= closeManufacturer_Id
                                                    && r.ResponsibleStaff_Id >= responsibleStaff_Id
                                                    && r.ResponsibleStaff_Id <= responsibleStaff_Id)
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
                string where = whereString.SearchKeyWhere<ReadableGoodsIssue>(db, keywords);
                int openManufacturer_Id = NameToId.Manufacturer(db, manufacturer)[0];
                int closeManufacturer_Id = NameToId.Manufacturer(db, manufacturer)[1];
                if (where == "Empty")
                {
                    var results = db.GoodsReceipts
                                        .Where(gi => gi.AccountTitle_Id >= accountTitle_Id
                                                    && gi.AccountTitle_Id <= accountTitle_Id
                                                    && gi.FluctuatingDate >= startDate
                                                    && gi.FluctuatingDate <= endDate
                                                    && gi.Product.Manufacturer_Id >= openManufacturer_Id
                                                    && gi.Product.Manufacturer_Id <= closeManufacturer_Id
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
                                                    && r.Product.Manufacturer_Id >= openManufacturer_Id
                                                    && r.Product.Manufacturer_Id <= closeManufacturer_Id
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
                int openBusinessPartner_Id = NameToId.BusinessPartner(db, businessPartner)[0];
                int closeBusinessPartner_Id = NameToId.BusinessPartner(db, businessPartner)[1];
                int openDebit_Id = IdRange.AccountTitle(db, debit_Id)[0];
                int closeDebit_Id = IdRange.AccountTitle(db, debit_Id)[1];
                int openCredit_Id = IdRange.AccountTitle(db, credit_Id)[0];
                int closeCredit_Id = IdRange.AccountTitle(db, credit_Id)[1];
                var anonymous = db.Journals
                                    .Where(j => j.BusinessPartner_Id >= openBusinessPartner_Id
                                                && j.BusinessPartner_Id <= closeBusinessPartner_Id
                                                && j.Debit_Id >= openDebit_Id
                                                && j.Debit_Id <= closeDebit_Id
                                                && j.Credit_Id >= openCredit_Id
                                                && j.Credit_Id <= closeCredit_Id
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

        public List<ReadablePurchase> PurchaseList(string supplier, string keywords, int staff_Id,
                                                    DateTime purchaseStartDate, DateTime purchaseEndDate,
                                                    DateTime receiptStartDate, DateTime receiptEndDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.SearchKeyWhere<ReadablePurchase>(db, keywords);
                int openSupplier_Id = NameToId.BusinessPartner(db, supplier)[0];
                int closeSupplier_Id = NameToId.BusinessPartner(db, supplier)[1];
                int openStaff_Id = IdRange.Staff(db, staff_Id)[0];
                int closeStaff_Id = IdRange.Staff(db, staff_Id)[1];
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


        public List<ReadableSale> SalesList(string customer, string manufacturer, string keywords, int staff_Id, string helper,
                                            DateTime salesOrderStartDate, DateTime salesOrderEndDate, DateTime salesStartDate,
                                            DateTime salesEndDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.SearchKeyWhere<ReadableSale>(db, keywords);
                int openCustomer_Id = NameToId.BusinessPartner(db, customer)[0];
                int closeCustomer_Id = NameToId.BusinessPartner(db, customer)[1];
                int openManufacturer_Id = NameToId.Manufacturer(db, manufacturer)[0];
                int closeManufacturer_Id = NameToId.Manufacturer(db, manufacturer)[1];
                int openStaff_Id = IdRange.Staff(db, staff_Id)[0];
                int closeStaff_Id = IdRange.Staff(db, staff_Id)[1];
                int openHelper_Id = NameToId.Helper(db, helper)[0];
                int closeHelper_Id = NameToId.Helper(db, helper)[1];
                List<ReadableSale> readableSales = new List<ReadableSale>();
                if (!String.IsNullOrEmpty(keywords))
                {
                    readableSales = db.Database
                                        .SqlQuery<ReadableSale>(where)
                                        .ToList();
                    return readableSales
                              .Where(rs => rs.Customer_Id >= openCustomer_Id
                                      && rs.Customer_Id <= closeCustomer_Id
                                      && rs.Manufacturer_Id >= openManufacturer_Id
                                      && rs.Manufacturer_Id <= closeManufacturer_Id
                                      && rs.ResponsibleStaff_Id >= openStaff_Id
                                      && rs.ResponsibleStaff_Id <= closeStaff_Id
                                      && rs.Helper_Id >= openHelper_Id
                                      && rs.Helper_Id <= closeHelper_Id
                                      && rs.SalesOrderDate >= salesOrderStartDate
                                      && rs.SalesOrderDate <= salesOrderEndDate
                                      && rs.SalesDate >= salesStartDate
                                      && rs.SalesDate <= salesEndDate)
                              .ToList();
                }
                else
                {
                    readableSales = db.ReadableSales
                                        .Where(rs => rs.Customer_Id >= openCustomer_Id
                                        && rs.Customer_Id <= closeCustomer_Id
                                        && rs.Manufacturer_Id >= openManufacturer_Id
                                        && rs.Manufacturer_Id <= closeManufacturer_Id
                                        && rs.ResponsibleStaff_Id >= openStaff_Id
                                        && rs.ResponsibleStaff_Id <= closeStaff_Id
                                        && rs.Helper_Id >= openHelper_Id
                                        && rs.Helper_Id <= closeHelper_Id
                                        && rs.SalesOrderDate >= salesOrderStartDate
                                        && rs.SalesOrderDate <= salesOrderEndDate
                                        && rs.SalesDate >= salesStartDate
                                        && rs.SalesDate <= salesEndDate)
                                .ToList();

                    return readableSales;
                }
            }
        }

        public List<ReadableQuotation> QuotationList(string customer, string manufacturer, string keywords, int staff_Id, string helper,
                                                        DateTime startDate, DateTime endDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.SearchKeyWhere<ReadableQuotation>(db, keywords);
                int openCustomer_Id = NameToId.BusinessPartner(db, customer)[0];
                int closeCustomer_Id = NameToId.BusinessPartner(db, customer)[1];
                int openManufacturer_Id = NameToId.Manufacturer(db, manufacturer)[0];
                int closeManufacturer_Id = NameToId.Manufacturer(db, manufacturer)[1];
                int openStaff_Id = IdRange.Staff(db, staff_Id)[0];
                int closeStaff_Id = IdRange.Staff(db, staff_Id)[1];
                int openHelper_Id = NameToId.Helper(db, helper)[0];
                int closeHelper_Id = NameToId.Helper(db, helper)[1];
                List<ReadableQuotation> readableQuotations = new List<ReadableQuotation>();
                if (!String.IsNullOrEmpty(keywords))
                {
                    readableQuotations = db.Database
                                            .SqlQuery<ReadableQuotation>(where)
                                            .ToList();
                    return readableQuotations
                            .Where(rq => rq.Customer_Id >= openCustomer_Id
                                        && rq.Customer_Id <= closeCustomer_Id
                                        && rq.Manufacturer_Id >= openManufacturer_Id
                                        && rq.Manufacturer_Id <= closeManufacturer_Id
                                        && rq.Helper_Id >= openHelper_Id
                                        && rq.Helper_Id <= closeHelper_Id
                                        && rq.ResponsibleStaff_Id >= openStaff_Id
                                        && rq.ResponsibleStaff_Id <= closeStaff_Id
                                        && rq.SubmissionDate >= startDate
                                        && rq.SubmissionDate <= endDate)
                            .ToList();
                }
                else
                {
                    readableQuotations = db.ReadableQuotations
                                            .Where(rq => rq.Customer_Id >= openCustomer_Id
                                                        && rq.Customer_Id <= closeCustomer_Id
                                                        && rq.Manufacturer_Id >= openManufacturer_Id
                                                        && rq.Manufacturer_Id <= closeManufacturer_Id
                                                        && rq.Helper_Id >= openHelper_Id
                                                        && rq.Helper_Id <= closeHelper_Id
                                                        && rq.ResponsibleStaff_Id >= openStaff_Id
                                                        && rq.ResponsibleStaff_Id <= closeStaff_Id
                                                        && rq.SubmissionDate >= startDate
                                                        && rq.SubmissionDate <= endDate)
                                            .ToList();
                    return readableQuotations;
                }
            }
        }
    }
}