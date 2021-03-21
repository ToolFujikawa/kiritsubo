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

        public ActionResult FinancialInstitutionList()
        {
            FinancialInstitutionData data = new FinancialInstitutionData();
            return View(data.GetAll());
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

        public ActionResult ProductList()
        {
            return View();
        }

        public ActionResult ProductContent(string manufacturer, string keywords)
        {
            if (Request.IsAjaxRequest())
            {
                ProductData data = new ProductData();
                var results = data.GetSpecificWordGroup(manufacturer, keywords);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_ProductContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
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
;               }
                else
                {
                    return PartialView("_ProductAttributeContent", results);
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        public ActionResult StaffList()
        {
            StaffData data = new StaffData();
            return View(data.GetAll());
        }
    }
}