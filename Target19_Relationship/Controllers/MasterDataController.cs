using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models.Tables;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Controllers
{
    public class MasterDataController : Controller
    {
        public ActionResult AccountTitelContent(int page)
        {
            if (Request.IsAjaxRequest())
            {
                AccountTitleData data = new AccountTitleData();
                var results = data.GetSpecificPage(0);
                return PartialView("_AccountTitleContent");
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        public ActionResult AccountTitleEdit(int Id)
        {
            AccountTitleData data = new AccountTitleData();
            return View(data.GetUnique(Id));
        }

        public ActionResult AccountTitleList()
        {
            AccountTitleData data = new AccountTitleData();
            return View(data.GetAll());
        }

        public ActionResult AccountTitleRowCount()
        {
            AccountTitleData data = new AccountTitleData();
            string jsonData = "{\"status\":" + data.GetRow() + "}";
            return Content(jsonData, "application/json");
        }

        public ActionResult BusinessPartnerList()
        {
            return View();
        }

        public ActionResult BusinessPartnerContent(string initial)
        {
            if (Request.IsAjaxRequest())
            {
                BusinessPartnerData data = new BusinessPartnerData();
                var results = data.GetAll(initial);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_BusinessPartnerContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        public ActionResult BusinessPartnerName(string term)
        {
            BusinessPartnerData data = new BusinessPartnerData();
            return Json(data.GetNames(term), JsonRequestBehavior.AllowGet);
        }

        public ActionResult BusinessPartnerEmailAddressList()
        {
            return View();
        }

        public ActionResult BusinessPartnerEmailAddressContent(string initial)
        {
            if (Request.IsAjaxRequest())
            {
                BusinessPartnerEmailAddressData data = new BusinessPartnerEmailAddressData();
                var results = data.GetSpecificInitialGroup(initial);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_BusinessPartnerEmailAddressContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        public ActionResult DeliveryPlaceList()
        {
            DeliveryPlaceData data = new DeliveryPlaceData();
            return View(data.GetAll());
        }

        public ActionResult FinancialInstitutionContent(int page)
        {
            FinancialInstitutionData data = new FinancialInstitutionData();
            var results = data.GetSpecificPage(page);
            return PartialView("_FinancialInstitutionContent", results);
        }

        public ActionResult FinancialInstitutionList()
        {
            FinancialInstitutionData data = new FinancialInstitutionData();
            return View(data.GetAll());
        }

        public ActionResult FinancialInstitutionRowCount()
        {
            FinancialInstitutionData data = new FinancialInstitutionData();
            string jsonData = "{\"status\":" + data.GetRow() + "}";
            return Content(jsonData, "application/json");
        }

        public ActionResult FinancialInstitutionBranchList()
        {
            FinancialInstitutionBranchData data = new FinancialInstitutionBranchData();
            return View(data.GetAll());
        }

        public ActionResult HelperList()
        {
            HelperData data = new HelperData();
            return View(data.GetAll());
        }

        public ActionResult HelperName(string term)
        {
            HelperData data = new HelperData();
            return Json(data.GetNames(term), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ManufacturerCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManufacturerCreate([Bind(Include = "FormalName")] Manufacturer manufacturer)
        {
            return View();
        }

        public ActionResult ManufacturerList()
        {
            return View();
        }

        public ActionResult ManufacturerContent(string initial)
        {
            if (Request.IsAjaxRequest())
            {
                ManufacturerData data = new ManufacturerData();
                var results = data.GetSpecificInitialGroup(initial);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_ManufacturerContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        public ActionResult ManufacturerName(string term)
        {
            ManufacturerData data = new ManufacturerData();
            return Json(data.GetNames(term), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductAttributeList()
        {
            return View();
        }

        public ActionResult ProductAttributeContent(string businessPartner, string manufacturer, string keywords)
        {
            if (Request.IsAjaxRequest())
            {
                ProductAttributeData data = new ProductAttributeData();
                var results = data.GetSpecificWordGroup(businessPartner, manufacturer, keywords);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                    ;
                }
                else
                {
                    return PartialView("_ProductAttributeContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        public ActionResult ProductCreate(string type)
        {
            if (type == "minimum")
            {
                return PartialView("_ProductCreateMinimum");
            }
            else
            {
                return PartialView();
            }
        }

        public ActionResult ProductList()
        {
            return View();
        }

        public ActionResult ProductContent(string manufacturer, string keywords, int page, string viewName)
        {
            if (Request.IsAjaxRequest())
            {
                ProductData data = new ProductData();
                int skipNo = page == 1 ? 0 : (page - 1) * 8;//1ページ目はスキップ0
                var results = data.GetSpecificWordGroup(manufacturer, keywords)
                                    .Skip(skipNo)
                                    .Take(8);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    switch (viewName)
                    {
                        case "_ProductSelecterContent":
                            return PartialView("_ProductSelecterContent", results);
                        default:
                            return PartialView("_ProductContent", results);
                    }
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        public ActionResult ProductRowCount(string manufacturer, string keywords)
        {
            ProductData data = new ProductData();
            string jsonData = "{\"status\":" + data.GetSpecificWordRow(manufacturer, keywords) + "}";
            return Content(jsonData, "application/json");
        }

        public ActionResult StaffList()
        {
            StaffData data = new StaffData();
            return View(data.GetAll());
        }
    }
}