using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Services;
using Target19_Relationship.Services.MasterDatas;
using Target19_Relationship.Services.TransactionDatas;

namespace Target19_Relationship.Controllers
{
    public class TransactionDataController : Controller
    {
        //納品前
        public ActionResult BeforeDeliveryList()
        {
            ViewBag.CustomerSelectOptions = new SelectList(BeforeDeliveryData.GetCustomerSelectListItems(), "Value", "Text");
            ViewBag.ManufacturerSelectOptions = new SelectList(BeforeDeliveryData.GetManufacturerSelectListItems(), "Value", "Text");
            ViewBag.ResponsibleStaffSelectOptions = new SelectList(BeforeDeliveryData.GetStaffSelectListItems(), "Value", "Text");
            ViewBag.HelperSelectOptions = new SelectList(BeforeDeliveryData.GetHelperSelectListItems(), "Value", "Text");
            return View();
        }

        public ActionResult BeforeDeliveryContent(int customer_Id, int manufacturer_Id, string keywords, int responsibleStaff_Id,
                                                    int helper_Id, DateTime startDate, DateTime endDate)
        {
            if (Request.IsAjaxRequest())
            {
                BeforeDeliveryData data = new BeforeDeliveryData();
                var results = data.GetSpecificWordGroup(customer_Id, manufacturer_Id, keywords, responsibleStaff_Id, helper_Id,
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

        //発注前商品
        public ActionResult BeforeIssuingPurchaseOrderList()
        {
            BeforeIssuingPurchaseOrderData data = new BeforeIssuingPurchaseOrderData();
            return View(data.GetAll());
        }

        //入庫前商品
        public ActionResult BeforeWarehousingList()
        {
            ViewBag.SupplierSelectOptions = new SelectList(BeforeWarehousingData.GetSupplierSelectListItems(), "Value", "Text");
            ViewBag.ManufacturerSelectOptions = new SelectList(BeforeWarehousingData.GetManufacturerSelectListItem(), "Value", "Text");
            return View();
        }

        public ActionResult BeforeWarehousingContent(int supplier_Id, int manufacturer_Id, string keywords,
                                                        DateTime startDate, DateTime endDate)
        {
            BeforeWarehousingData data = new BeforeWarehousingData();
            var results = data.GetSpecificWordGroup(supplier_Id, manufacturer_Id, keywords, startDate, endDate);
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
            ViewBag.AccountTitleSelectOptions = new SelectList(AccountTitleData.GetGoodsIssueSelectListItem(), "Value", "Text");
            ViewBag.StaffSelectOptions = new SelectList(StaffData.GetAllSelectListItem(), "Value", "Text");
            return View();
        }

        public ActionResult GoodsIssueContent(string manufacturer, string keywords, int accounttitleid,
                                                int responsiblestaffid, DateTime startdate, DateTime enddate)
        {
            if (Request.IsAjaxRequest())
            {
                GoodsIssueData data = new GoodsIssueData();
                var results = data.GetSpecificWordGroup(manufacturer, keywords, accounttitleid, responsiblestaffid, startdate, enddate);
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
            ViewBag.AccountTitleSelectOptions = new SelectList(AccountTitleData.GetGoodsIssueSelectListItem(), "Value", "Text");
            ViewBag.StaffSelectOptions = new SelectList(StaffData.GetAllSelectListItem(), "Value", "Text");
            return View();
        }

        public ActionResult GoodsReceiptContent(string manufacturer, string keywords, int accounttitleid,
                                                int responsiblestaffid, DateTime startdate, DateTime enddate)
        {
            GoodsReceiptData data = new GoodsReceiptData();
            var results = data.GetSpecificWordGroup(manufacturer, keywords, accounttitleid, responsiblestaffid, startdate, enddate);
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
            return View();
        }

        public ActionResult JournalContent(string businessPartner, string keywords, string debit,
                                            string credit, DateTime startDate, DateTime endDate)
        {
            JournalData data = new JournalData();
            var results = data.GetSpecificWordGroup(businessPartner, keywords, debit, credit, startDate, endDate);
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
            ViewBag.ResponsibleStaffSelectOptions = new SelectList(StaffData.GetAllSelectListItem(), "Value", "Text");
            return View();
        }

        public ActionResult PurchaseContent(string supplier, string manufacturer, string keywords, int staff_Id,
                                            DateTime purchaseStartDate, DateTime purchaseEndDate,
                                            DateTime receiptStartDate, DateTime receiptEndDate)
        {
            if (Request.IsAjaxRequest())
            {
                PurchaseData data = new PurchaseData();
                var results = data.GetSpecificWordGroup(supplier, keywords, staff_Id, purchaseStartDate,
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


        //売掛金発生事由
        public ActionResult SalesList()
        {
            ViewBag.ResponsibleStaffSelectOptions = new SelectList(StaffData.GetAllSelectListItem(), "Value", "Text");
            return View();
        }

        public ActionResult SalesContent(string customer, string manufacturer, string keywords, int staff_Id, string helper, 
                                            DateTime salesOrderStartDate, DateTime salesOrderEndDate, DateTime salesStartDate, 
                                            DateTime salesEndDate)
        {
            if (Request.IsAjaxRequest())
            {
                SaleData data = new SaleData();
                var results = data.GetSpecificWordGroup(customer, manufacturer, keywords, staff_Id, helper, salesOrderStartDate,
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
            ViewBag.ResponsibleStaffSelectOptions = new SelectList(StaffData.GetAllSelectListItem(), "Value", "Text");
            return View();
        }

        public ActionResult QuotationContent(string customer, string manufacturer, string keywords, int staff_Id, string helper,
                                                DateTime startDate, DateTime endDate)
        {
            if (Request.IsAjaxRequest())
            {
                QuotationData data = new QuotationData();
                var results = data.GetSpecificWordGroup(customer, manufacturer, keywords, staff_Id, helper, startDate, endDate);
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