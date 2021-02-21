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
                int[] manufacturer_Ids = IdRange.Manufacturer(db, manufacturer_Id);
                int[] supplier_Ids = IdRange.BusinessPartner(db, supplier_Id);
                var anonymous = db.BeforeWarehousings
                                    .Where(bw => bw.Supplier_Id >= supplier_Ids[0]
                                            && bw.Supplier_Id <= supplier_Ids[1]
                                            && bw.Manufacturer_Id >= manufacturer_Ids[0]
                                            && bw.Manufacturer_Id <= manufacturer_Ids[1]
                                            && bw.PurchaseDate >= startDate
                                            && bw.PurchaseDate <= endDate);

                //データベースビューでデータが絞り込まれているので、このメソッドを使います。
                string[] keywordArray = keywords.Split(new[] { ' ', '　' });
                foreach (var item in keywordArray)
                {
                    anonymous = anonymous
                                .Where(a => a.SearchKey.Contains(item));
                }

                var results = anonymous
                                .Select(a => new BeforeWarehousing
                                {
                                    Id = a.Id,
                                    Supplier_Id = a.Supplier_Id,
                                    Supplier = a.Supplier,
                                    Manufacturer_Id = a.Manufacturer_Id,
                                    Product_Id = a.Product_Id,
                                    Product = a.Product,
                                    Quantity = a.Quantity,
                                    Unit = a.Unit,
                                    Detail = a.Detail,
                                    ResponsibleStaff_Id = a.ResponsibleStaff_Id,
                                    ResponsibleStaff = a.ResponsibleStaff,
                                    PurchaseDate = a.PurchaseDate,
                                    PurchaseMethod_Id = a.PurchaseMethod_Id,
                                    DeliveryDate = a.DeliveryDate,
                                    DeliveryDateInstruction_Id = a.DeliveryDateInstruction_Id,
                                    AskingPrice = a.AskingPrice,
                                    Note = a.Note,
                                    SalesOrder_Id = a.SalesOrder_Id,
                                    SalesOrderDetail = a.SalesOrderDetail,
                                    IsCancel = a.IsCancel,
                                    Recorder_Id = a.Recorder_Id,
                                    Changer_Id = a.Changer_Id,
                                    SearchKey = a.SearchKey
                                })
                                .ToList();
                return results;
            }
        }

        public List<ReadablePurchase> PurchaseList(string supplier, string keywords, int staff_Id,
                                                    DateTime purchaseStartDate, DateTime purchaseEndDate,
                                                    DateTime receiptStartDate, DateTime receiptEndDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.AssembleProductWhere(db, keywords, "purchaseorders");
                int[] supplier_Ids = new int[2] { NameToId.BusinessPartner(db, supplier)[0], NameToId.BusinessPartner(db, supplier)[1] };
                int[] staff_Ids = new int[2] { IdRange.Staff(db, staff_Id)[0], IdRange.Staff(db, staff_Id)[1] };
                List<ReadablePurchase> readablePurchases = new List<ReadablePurchase>();
                if (where == "Empty")//商品データ数が多数に上るため商品抽出をSQLで実行
                {
                    var anonymous = db.Purchases
                                        .Where(p => p.PurchaseOrder.Supplier_Id >= supplier_Ids[0]
                                                    && p.PurchaseOrder.Supplier_Id <= supplier_Ids[1]
                                                    && p.PurchaseOrder.ResponsibleStaff_Id >= staff_Ids[0]
                                                    && p.PurchaseOrder.ResponsibleStaff_Id <= staff_Ids[1]
                                                    && p.PurchaseOrder.PurchaseDate >= purchaseStartDate
                                                    && p.PurchaseOrder.PurchaseDate <= purchaseEndDate
                                                    && p.ReceiptDate >= receiptStartDate
                                                    && p.ReceiptDate <= receiptEndDate);
                    readablePurchases = anonymous
                                        .Select(a => new ReadablePurchase
                                        {
                                            Id = a.Id,//Purchase
                                            Supplier_Id = a.PurchaseOrder.Supplier_Id,
                                            Supplier = a.PurchaseOrder.BusinessPartner.CommonName,
                                            Product_Id = a.PurchaseOrder.Product_Id,
                                            Product = a.PurchaseOrder.Product.Manufacturer.CommonName + " "
                                                        + a.PurchaseOrder.Product.ProductName + " "
                                                        + a.PurchaseOrder.Product.Material + " "
                                                        + a.PurchaseOrder.Product.Model,
                                            PurchaseOrderQuantity = a.PurchaseOrder.Quantity,
                                            Detail = a.PurchaseOrder.Detail,
                                            ResponsibleStaff_Id = a.PurchaseOrder.ResponsibleStaff_Id,
                                            ResponsibleStaff = a.PurchaseOrder.ResponsibleStaff.LastName +
                                                                a.PurchaseOrder.ResponsibleStaff.FirstName,
                                            PurchaseDate = a.PurchaseOrder.PurchaseDate,
                                            PurchaseMethod_Id = a.PurchaseOrder.PurchaseMethod_Id,
                                            DeliveryDate = a.PurchaseOrder.DeliveryDate,
                                            DeliveryDateInstruction_Id = a.PurchaseOrder.DeliveryDateInstruction_Id,
                                            AskingPrice = a.PurchaseOrder.AskingPrice,
                                            PurchaseOrderNote = a.PurchaseOrder.Note,
                                            SalesOrder_Id = a.PurchaseOrder.SalesOrder_Id,
                                            SalesOrderDetail = a.PurchaseOrder.SalesOrderDetail,
                                            IsCancel = a.PurchaseOrder.IsCancel,
                                            PurchaseOrderRecorder_Id = a.PurchaseOrder.Recorder_Id,
                                            PurchaseOrderChanger_Id = a.PurchaseOrder.Changer_Id,
                                            PurchaseOrderFIMS_Id = a.PurchaseOrder.FIMS_Id,
                                            PurchaseOrder_Id = a.PurchaseOrder_Id,
                                            ReceiptDate = a.ReceiptDate,
                                            BilledDate = a.BilledDate,
                                            PurchaseQuantity = a.Quantity,
                                            UnitPrice = a.UnitPrice,
                                            TaxRate = a.TaxRate,
                                            PurchaseNote = a.Note,
                                            PurchaseFIMS_Id = a.FIMS_Id
                                        })
                                        .ToList();
                    return readablePurchases;
                }
                else
                {
                    var anonymous = db.Database
                                        .SqlQuery<Purchase>(where);

                    readablePurchases = anonymous
                                        .Where(a => a.PurchaseOrder.Supplier_Id >= supplier_Ids[0]
                                                    && a.PurchaseOrder.Supplier_Id <= supplier_Ids[1]
                                                    && a.PurchaseOrder.ResponsibleStaff_Id >= staff_Ids[0]
                                                    && a.PurchaseOrder.ResponsibleStaff_Id <= staff_Ids[1]
                                                    && a.PurchaseOrder.PurchaseDate >= purchaseStartDate
                                                    && a.PurchaseOrder.PurchaseDate <= purchaseEndDate
                                                    && a.ReceiptDate >= receiptStartDate
                                                    && a.ReceiptDate <= receiptEndDate)
                                        .Select(a => new ReadablePurchase
                                        {
                                            Id = a.Id,//Purchase
                                            Supplier_Id = a.PurchaseOrder.Supplier_Id,
                                            Supplier = a.PurchaseOrder.BusinessPartner.CommonName,
                                            Product_Id = a.PurchaseOrder.Product_Id,
                                            Product = a.PurchaseOrder.Product.Manufacturer.CommonName + " "
                                                        + a.PurchaseOrder.Product.ProductName + " "
                                                        + a.PurchaseOrder.Product.Material + " "
                                                        + a.PurchaseOrder.Product.Model,
                                            PurchaseOrderQuantity = a.PurchaseOrder.Quantity,
                                            Detail = a.PurchaseOrder.Detail,
                                            ResponsibleStaff_Id = a.PurchaseOrder.ResponsibleStaff_Id,
                                            ResponsibleStaff = a.PurchaseOrder.ResponsibleStaff.LastName +
                                                                a.PurchaseOrder.ResponsibleStaff.FirstName,
                                            PurchaseDate = a.PurchaseOrder.PurchaseDate,
                                            PurchaseMethod_Id = a.PurchaseOrder.PurchaseMethod_Id,
                                            DeliveryDate = a.PurchaseOrder.DeliveryDate,
                                            DeliveryDateInstruction_Id = a.PurchaseOrder.DeliveryDateInstruction_Id,
                                            AskingPrice = a.PurchaseOrder.AskingPrice,
                                            PurchaseOrderNote = a.PurchaseOrder.Note,
                                            SalesOrder_Id = a.PurchaseOrder.SalesOrder_Id,
                                            SalesOrderDetail = a.PurchaseOrder.SalesOrderDetail,
                                            IsCancel = a.PurchaseOrder.IsCancel,
                                            PurchaseOrderRecorder_Id = a.PurchaseOrder.Recorder_Id,
                                            PurchaseOrderChanger_Id = a.PurchaseOrder.Changer_Id,
                                            PurchaseOrderFIMS_Id = a.PurchaseOrder.FIMS_Id,
                                            PurchaseOrder_Id = a.PurchaseOrder_Id,
                                            ReceiptDate = a.ReceiptDate,
                                            BilledDate = a.BilledDate,
                                            PurchaseQuantity = a.Quantity,
                                            UnitPrice = a.UnitPrice,
                                            TaxRate = a.TaxRate,
                                            PurchaseNote = a.Note,
                                            PurchaseFIMS_Id = a.FIMS_Id
                                        })
                                        .ToList();
                    return readablePurchases;
                }
            }
        }

        public List<BeforeDelivery> BeforeDeliveryList(int customer_Id, int manufacturer_Id, string keywords, int responsibleStaff_Id,
                                                        int helper_Id, DateTime startDate, DateTime endDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                int[] customer_Ids = IdRange.BusinessPartner(db, customer_Id);
                int[] manufacturer_Ids = IdRange.Manufacturer(db, manufacturer_Id);
                int[] staff_Ids = IdRange.Staff(db, responsibleStaff_Id);
                int[] helper_Ids = IdRange.Helper(db, helper_Id);

                var anonymous = db.SalesOrders
                                    .Where(so => so.Customer_Id >= customer_Ids[0]
                                            && so.Customer_Id <= customer_Ids[1]
                                            && so.Product.Manufacturer_Id >= manufacturer_Ids[0]
                                            && so.Product.Manufacturer_Id <= manufacturer_Ids[1]
                                            && so.ResponsibleStaff_Id >= staff_Ids[0]
                                            && so.ResponsibleStaff_Id <= staff_Ids[1]
                                            && so.Helper_Id >= helper_Ids[0]
                                            && so.Helper_Id <= helper_Ids[1]
                                            && so.SalesOrderDate >= startDate
                                            && so.SalesOrderDate <= endDate);

                string[] keywordArray = keywords.Split(new[] { ' ', '　' });
                foreach (var item in keywordArray)
                {
                    anonymous = anonymous
                                .Where(a => a.Product.SearchKey.Contains(item));
                }

                var results = anonymous
                                .Select(a => new BeforeDelivery
                                {
                                    Id = a.Id,
                                    IsCancel = a.IsCancel,
                                    IsExclusiveDeliveryNote = a.IsExclusiveDeliveryNote,
                                    Detail = a.Detail,
                                    ResponsibleStaff_Id = a.ResponsibleStaff_Id,
                                    ResponsibleStaff = a.ResponsibleStaff.LastName + a.ResponsibleStaff.FirstName,
                                    Helper_Id = a.Helper_Id,
                                    Helper = a.Helper.LastName + a.Helper.FirstName,
                                    Customer_Id = a.Customer_Id,
                                    Customer = a.BusinessPartner.CommonName,
                                    DeliveryPlace_Id = a.DeliveryPlace_Id,
                                    DeliveryPlace = a.DeliveryPlace.Location,
                                    Product_Id = a.Product_Id,
                                    Product = a.Product.Manufacturer.CommonName + " " + a.Product.ProductName + " " + a.Product.Material + " " + a.Product.Model,
                                    Quantity = a.Quantity,
                                    Unit = a.Product.TransactionUnit.Unit,
                                    SalesOrderDate = a.SalesOrderDate,
                                    OrderMainNo = a.OrderMainNo,
                                    OrderBranchNo = a.OrderBranchNo,
                                    IsParchase = a.IsParchase,
                                    IsSeparateDelivery = a.IsSeparateDelivery,
                                    EstimatedSale = a.EstimatedSale,
                                    Note = a.Note
                                })
                                .ToList();
                return results;
            }
        }

        public List<ReadableSale> SalesList(string customer, string keywords, int staff_Id, string helper, DateTime salesOrderStartDate,
                                            DateTime salesOrderEndDate, DateTime salesStartDate, DateTime salesEndDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.AssembleProductWhere(db, keywords, "salesorders");
                int[] customer_Ids = new int[2] { NameToId.BusinessPartner(db, customer)[0], NameToId.BusinessPartner(db, customer)[1] };
                int[] staff_Ids = new int[2] { IdRange.Staff(db, staff_Id)[0], IdRange.Staff(db, staff_Id)[1] };
                int[] helper_Ids = new int[2] { NameToId.Helper(db, helper)[0], NameToId.Helper(db, helper)[1] };
                List<ReadableSale> readableSales = new List<ReadableSale>();
                if (where == "Empty")
                {
                    var anonymous = db.Sales
                                        .Where(s => s.SalesOrder.Customer_Id >= customer_Ids[0]
                                                    && s.SalesOrder.Customer_Id <= customer_Ids[1]
                                                    && s.SalesOrder.ResponsibleStaff_Id >= staff_Ids[0]
                                                    && s.SalesOrder.ResponsibleStaff_Id <= staff_Ids[1]
                                                    && s.SalesOrder.Helper_Id >= helper_Ids[0]
                                                    && s.SalesOrder.Helper_Id <= helper_Ids[1]
                                                    && s.SalesOrder.SalesOrderDate >= salesOrderStartDate
                                                    && s.SalesOrder.SalesOrderDate <= salesOrderEndDate
                                                    && s.SalesDate >= salesStartDate
                                                    && s.SalesDate <= salesEndDate);

                    readableSales = anonymous
                                    .Select(a => new ReadableSale
                                    {
                                        Id = a.Id,
                                        SalesOrder_Id = a.SalesOrder_Id,
                                        IsCancel = a.SalesOrder.IsCancel,
                                        IsExclusiveDeliveryNote = a.SalesOrder.IsExclusiveDeliveryNote,
                                        SalesOrderDetail = a.SalesOrder.Detail,
                                        SalesOrderResponsibleStaff_Id = a.SalesOrder.ResponsibleStaff_Id,
                                        SalesOrderResponsibleStaff = a.SalesOrder.ResponsibleStaff.LastName + a.SalesOrder.ResponsibleStaff.FirstName,
                                        Helper_Id = a.SalesOrder.Helper_Id,
                                        Helper = a.SalesOrder.Helper.LastName + a.SalesOrder.Helper.FirstName,
                                        Customer_Id = a.SalesOrder.Customer_Id,
                                        Customer = a.SalesOrder.BusinessPartner.CommonName,
                                        DeliveryPlace_Id = a.SalesOrder.DeliveryPlace_Id,
                                        DeliveryPlace = a.SalesOrder.DeliveryPlace.Location,
                                        Product_Id = a.SalesOrder.Product_Id,
                                        Product = a.SalesOrder.Product.Manufacturer.CommonName + " "
                                                        + a.SalesOrder.Product.ProductName + " "
                                                        + a.SalesOrder.Product.Material + " "
                                                        + a.SalesOrder.Product.Model,
                                        SalesOrderQuantity = a.SalesOrder.Quantity,
                                        SalesOrderUnit = a.SalesOrder.Product.TransactionUnit.Unit,
                                        SalesOrderDate = a.SalesOrder.SalesOrderDate,
                                        OrderMainNo = a.SalesOrder.OrderMainNo,
                                        OrderBranchNo = a.SalesOrder.OrderBranchNo,
                                        IsParchase = a.SalesOrder.IsParchase,
                                        IsSeparateDelivery = a.SalesOrder.IsSeparateDelivery,
                                        EstimatedSale = a.SalesOrder.EstimatedSale,
                                        SaleOrderNote = a.SalesOrder.Note,
                                        SalesOrderRecorder_Id = a.SalesOrder.Recorder_Id,
                                        SalesChanger_Id = a.SalesOrder.Changer_Id,
                                        IsLater = a.IsLater,
                                        SalesQuantity = a.Quantity,
                                        SalesUnit = a.SalesOrder.Product.TransactionUnit.Unit,
                                        UnitPrice = a.UnitPrice,
                                        TaxRate = a.TaxRate,
                                        SalesDate = a.SalesDate,
                                        SalesDetail = a.Detail,
                                        DocumentType_Id = a.DocumentType_Id,
                                        DeliveryNoteNo = a.DeliveryNoteNo,
                                        DeliveryStatus_Id = a.DeliveryStatus_Id,
                                        InvoiceNo = a.InvoiceNo,
                                        BilledDate = a.BilledDate,
                                        SalesNote = a.Note,
                                        SalesRecorder_Id = a.Recorder_Id,
                                        SalesOrderChanger_Id = a.Changer_Id
                                    })
                                    .ToList();
                    return readableSales;
                }
                else
                {
                    var anonymous = db.Database
                                        .SqlQuery<Sale>(where);

                    readableSales = anonymous
                                    .Select(a => new ReadableSale
                                    {
                                        Id = a.Id,
                                        SalesOrder_Id = a.SalesOrder_Id,
                                        IsCancel = a.SalesOrder.IsCancel,
                                        IsExclusiveDeliveryNote = a.SalesOrder.IsExclusiveDeliveryNote,
                                        SalesOrderDetail = a.SalesOrder.Detail,
                                        SalesOrderResponsibleStaff_Id = a.SalesOrder.ResponsibleStaff_Id,
                                        SalesOrderResponsibleStaff = a.SalesOrder.ResponsibleStaff.LastName + a.SalesOrder.ResponsibleStaff.FirstName,
                                        Helper_Id = a.SalesOrder.Helper_Id,
                                        Helper = a.SalesOrder.Helper.LastName + a.SalesOrder.Helper.FirstName,
                                        Customer_Id = a.SalesOrder.Customer_Id,
                                        Customer = a.SalesOrder.BusinessPartner.CommonName,
                                        DeliveryPlace_Id = a.SalesOrder.DeliveryPlace_Id,
                                        DeliveryPlace = a.SalesOrder.DeliveryPlace.Location,
                                        Product_Id = a.SalesOrder.Product_Id,
                                        Product = a.SalesOrder.Product.Manufacturer.CommonName + " "
                                                        + a.SalesOrder.Product.ProductName + " "
                                                        + a.SalesOrder.Product.Material + " "
                                                        + a.SalesOrder.Product.Model,
                                        SalesOrderQuantity = a.SalesOrder.Quantity,
                                        SalesOrderUnit = a.SalesOrder.Product.TransactionUnit.Unit,
                                        SalesOrderDate = a.SalesOrder.SalesOrderDate,
                                        OrderMainNo = a.SalesOrder.OrderMainNo,
                                        OrderBranchNo = a.SalesOrder.OrderBranchNo,
                                        IsParchase = a.SalesOrder.IsParchase,
                                        IsSeparateDelivery = a.SalesOrder.IsSeparateDelivery,
                                        EstimatedSale = a.SalesOrder.EstimatedSale,
                                        SaleOrderNote = a.SalesOrder.Note,
                                        SalesOrderRecorder_Id = a.SalesOrder.Recorder_Id,
                                        SalesChanger_Id = a.SalesOrder.Changer_Id,
                                        IsLater = a.IsLater,
                                        SalesQuantity = a.Quantity,
                                        SalesUnit = a.SalesOrder.Product.TransactionUnit.Unit,
                                        UnitPrice = a.UnitPrice,
                                        TaxRate = a.TaxRate,
                                        SalesDate = a.SalesDate,
                                        SalesDetail = a.Detail,
                                        DocumentType_Id = a.DocumentType_Id,
                                        DeliveryNoteNo = a.DeliveryNoteNo,
                                        DeliveryStatus_Id = a.DeliveryStatus_Id,
                                        InvoiceNo = a.InvoiceNo,
                                        BilledDate = a.BilledDate,
                                        SalesNote = a.Note,
                                        SalesRecorder_Id = a.Recorder_Id,
                                        SalesOrderChanger_Id = a.Changer_Id
                                    })
                                    .ToList();
                    return readableSales;
                }
            }
        }
    }
}