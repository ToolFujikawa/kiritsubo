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
            if (results.Count() == 0)
            {
                return PartialView("_NoResult");
            }
            else
            {
                return PartialView("_GoodsReceiptContent", results);
            }
        }
    }
}