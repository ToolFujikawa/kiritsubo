using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Services;
using Target19_Relationship.Services.TransactionDatas;

namespace Target19_Relationship.Controllers
{
    public class TransactionDataController : Controller
    {
        //発注前商品
        public ActionResult BeforeIssuingPurchaseOrderList()
        {
            TransactionListViews listViews = new TransactionListViews();
            var results = listViews.BeforeIssuingPurchaseOrderList();
            return View(results);
        }

        //入庫前商品
        public ActionResult BeforeWarehousingList()
        {
            DropdownDataSources dropdownDataSources = new DropdownDataSources();
            var supplier = new SelectList(dropdownDataSources.GetBusinessPartner("BeforeWarehousing"), "Value", "Text");
            ViewBag.SupplierSelectOptions = supplier;
            var manufacturer = new SelectList(dropdownDataSources.GetManufacturer("BeforeWarehousing"), "Value", "Text");
            ViewBag.ManufacturerSelectOptions = manufacturer;
            return View();
        }

        public ActionResult BeforeWarehousingContent(int supplier_Id, int manufacturer_Id, string keywords,
                                                        DateTime startDate, DateTime endDate)
        {
            TransactionListViews listViews = new TransactionListViews();
            var results = listViews.BeforeWarehousingList(supplier_Id, manufacturer_Id, keywords, startDate, endDate);
            if (Request.IsAjaxRequest())
            {
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_BeforeWarehousingContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        //出庫
        public ActionResult GoodsIssueList()
        {
            DropdownDataSources dropdownDataSources = new DropdownDataSources();
            var accountTitles = new SelectList(dropdownDataSources.GetAccountTitle("GoodsIssue"), "Value", "Text");
            ViewBag.AccountTitleSelectOptions = accountTitles;
            var staffs = new SelectList(dropdownDataSources.GetStaff(true), "Value", "Text");
            ViewBag.StaffSelectOptions = staffs;
            return View();
        }

        public ActionResult GoodsIssueContent(string manufacturer, string keywords, int accounttitleid,
                                                int responsiblestaffid, DateTime startdate, DateTime enddate)
        {
            if (Request.IsAjaxRequest())
            {
                TransactionListViews listViews = new TransactionListViews();
                var results = listViews.GoodsIssueList(manufacturer, keywords, accounttitleid, responsiblestaffid, startdate, enddate);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_GoodsIssueContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }
        //入庫
        public ActionResult GoodsReceiptList()
        {
            DropdownDataSources dropdownDataSources = new DropdownDataSources();
            var accountTitles = new SelectList(dropdownDataSources.GetAccountTitle("GoodsReceipt"), "Value", "Text");
            ViewBag.AccountTitleSelectOptions = accountTitles;
            var staffs = new SelectList(dropdownDataSources.GetStaff(true), "Value", "Text");
            ViewBag.StaffSelectOptions = staffs;
            return View();
        }

        public ActionResult GoodsReceiptContent(string manufacturer, string keywords, int accounttitleid,
                                                int responsiblestaffid, DateTime startdate, DateTime enddate)
        {
            TransactionListViews listViews = new TransactionListViews();
            var results = listViews.GoodsReceiptList(manufacturer, keywords, accounttitleid, responsiblestaffid, startdate, enddate);
            if (Request.IsAjaxRequest())
            {
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_GoodsReceiptContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        //会計
        public ActionResult JournalList()
        {
            DropdownDataSources dropdownDataSources = new DropdownDataSources();
            var debit = new SelectList(dropdownDataSources.GetAccountTitle("Debit"), "Value", "Text");
            ViewBag.DebitSelectOptions = debit;
            var credit = new SelectList(dropdownDataSources.GetAccountTitle("Credit"), "Value", "Text");
            ViewBag.CreditSelectOptions = credit;
            return View();
        }

        public ActionResult JournalContent(string businessPertner, string keywords, int debit_Id,
                                            int credit_Id, DateTime startDate, DateTime endDate)
        {
            TransactionListViews listViews = new TransactionListViews();
            var results = listViews.JournalList(businessPertner, debit_Id, credit_Id, keywords, startDate, endDate);
            if (Request.IsAjaxRequest())
            {
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_JournalContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        //買掛金発生事由
        public ActionResult PurchaseList()
        {
            DropdownDataSources dropdownDataSources = new DropdownDataSources();
            var staff = new SelectList(dropdownDataSources.GetStaff(false), "Value", "Text");
            ViewBag.ResponsibleStaffSelectOptions = staff;
            return View();
        }

        public ActionResult PurchaseContent(string supplier, string keywords, int staff_Id,
                                            DateTime purchaseStartDate, DateTime purchaseEndDate,
                                            DateTime receiptStartDate, DateTime receiptEndDate)
        {
            if (Request.IsAjaxRequest())
            {
                TransactionListViews listViews = new TransactionListViews();
                var results = listViews.PurchaseList(supplier, keywords, staff_Id, purchaseStartDate,
                                                        purchaseEndDate, receiptStartDate, receiptEndDate);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_PurchaseContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        //納品前
        public ActionResult BeforeDeliveryList()
        {
            DropdownDataSources dropdownDataSources = new DropdownDataSources();
            var cuntomer = new SelectList(dropdownDataSources.GetBusinessPartner("BeforeDelivery"), "Value", "Text");
            ViewBag.CustomerSelectOptions = cuntomer;
            var manufacturer = new SelectList(dropdownDataSources.GetManufacturer("BeforeDelivery"), "Value", "Text");
            ViewBag.ManufacturerSelectOptions = manufacturer;
            var staff = new SelectList(dropdownDataSources.GetStaff(false), "Value", "Text");
            ViewBag.ResponsibleStaffSelectOptions = staff;
            var helper = new SelectList(dropdownDataSources.GetHelper("BeforeDelivery"), "Value", "Text");
            ViewBag.HelperSelectOptions = helper;
            return View();
        }

        public ActionResult BeforeDeliveryContent(int customer_Id, int manufacturer_Id, string keywords, int responsibleStaff_Id,
                                                    int helper_Id, DateTime startDate, DateTime endDate)
        {
            if (Request.IsAjaxRequest())
            {
                TransactionListViews listViews = new TransactionListViews();
                var results = listViews.BeforeDeliveryList(customer_Id, manufacturer_Id, keywords, responsibleStaff_Id, helper_Id,
                                                            startDate, endDate);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_BeforeDeliveryContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        //売掛金発生事由
        public ActionResult SalesList()
        {
            DropdownDataSources dropdownDataSources = new DropdownDataSources();
            var staff = new SelectList(dropdownDataSources.GetStaff(false), "Value", "Text");
            ViewBag.ResponsibleStaffSelectOptions = staff;
            return View();
        }

        public ActionResult SalesContent(string customer, string keywords, int staff_Id, string helper, DateTime salesOrderStartDate,
                                            DateTime salesOrderEndDate, DateTime salesStartDate, DateTime salesEndDate)
        {
            if (Request.IsAjaxRequest())
            {
                TransactionListViews listViews = new TransactionListViews();
                var results = listViews.SalesList(customer, keywords, staff_Id, helper, salesOrderStartDate,
                                                    salesOrderEndDate, salesStartDate, salesEndDate);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_ReadableSaleContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        //見積
        public ActionResult QuotationList()
        {
            DropdownDataSources dropdownDataSources = new DropdownDataSources();
            var staff = new SelectList(dropdownDataSources.GetStaff(false), "Value", "Text");
            ViewBag.ResponsibleStaffSelectOptions = staff;
            return View();
        }

        public ActionResult QuotationContent(string customer, string keywords, int staff_Id, string helper,
                                                DateTime startDate, DateTime endDate)
        {
            if (Request.IsAjaxRequest())
            {
                TransactionListViews listViews = new TransactionListViews();
                var results = listViews.QuotationList(customer, keywords, staff_Id, helper, startDate, endDate);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_ReadableQuotationContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }
    }
}