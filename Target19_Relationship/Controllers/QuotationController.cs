using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;
using Target19_Relationship.Models.Views;
using Target19_Relationship.Services;
using Target19_Relationship.Services.MasterDatas;
using Target19_Relationship.Services.Quotations;

namespace Target19_Relationship.Controllers
{
    public class QuotationController : Controller
    {
        //見積入力画面の表示。取引先、担当者等共通部分。
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string customer, string helper, string staff, string[] products_Ids)
        {
            QuoteOperation quoteOperation = new QuoteOperation();
            quoteOperation.Create(customer, helper, staff, products_Ids);
            return View();
        }

        [HttpPost]
        public ActionResult CreateWithNewProduct(string customer, string helper, string staff, string manufacturer, string productName,
                                                    string material, string model)
        {
            ProductData data = new ProductData();
            string[] newProduct_Id = { data.Create(manufacturer, productName, material, model, staff).ToString() };
            QuoteOperation quoteOperation = new QuoteOperation();
            quoteOperation.Create(customer, helper, staff, newProduct_Id);
            return View();
        }

        //数量、単価入力
        public ActionResult UnitPriceSetting()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnitPriceSetting(List<BeforeSubmittingQuotation> setQuotations)
        {
            QuoteOperation quoteOperation = new QuoteOperation();
            quoteOperation.SetUnitPrice(setQuotations);
            return RedirectToAction("Create");
        }

        public ActionResult UnitPriceSettingContent(string staffEmailAddress)
        {
            ReadableQuotationData data = new ReadableQuotationData();
            return PartialView("_UnitPriceSettingContent", data.UnitPriceSetting(staffEmailAddress));
        }

        public ActionResult PublishQuotation(List<BeforeSubmittingQuotation> setQuotations)
        {
            QuoteOperation quoteOperation = new QuoteOperation();
            quoteOperation.Publish(setQuotations);
            return Redirect("~/WebForms/Quotation.aspx");
        }
    }
}