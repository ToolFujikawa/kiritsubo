using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Controllers
{
    public class MasterDataController : Controller
    {
        public ActionResult AccountTitleList()
        {
            MasterListViews listViews = new MasterListViews();
            return View(listViews.AccountTitles());
        }

        public ActionResult BusinessPartnerList()
        {
            return View();
        }

        public ActionResult BusinessPartnerContent(string initial)
        {
            if (Request.IsAjaxRequest())
            {
                MasterListViews listViews = new MasterListViews();
                var results = listViews.BusinessPartners(initial);
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
                MasterListViews listViews = new MasterListViews();
                var results = listViews.BusinessPartnerEmailAddresses(initial);
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
            MasterListViews listViews = new MasterListViews();
            return View(listViews.DeliveryPlaces());
        }

        public ActionResult FinancialInstitutionList()
        {
            MasterListViews listViews = new MasterListViews();
            return View(listViews.FinancialInstitutions());
        }

        public ActionResult FinancialInstitutionBranchList()
        {
            MasterListViews listViews = new MasterListViews();
            return View(listViews.FinancialInstitutionBranches());
        }

        public ActionResult HelperList()
        {
            MasterListViews listViews = new MasterListViews();
            return View(listViews.Helpers());
        }

        public ActionResult ManufacturerList()
        {
            return View();
        }

        public ActionResult ManufacturerContent(string initial)
        {
            if (Request.IsAjaxRequest())
            {
                MasterListViews listViews = new MasterListViews();
                var results = listViews.Manufacturers(initial);
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
                MasterListViews listViews = new MasterListViews();
                var results = listViews.Products(manufacturer, keywords);
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
                MasterListViews listViews = new MasterListViews();
                var results = listViews.ProductAttributes(businessPartner, manufacturer, keywords);
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
            MasterListViews listViews = new MasterListViews();
            return View(listViews.Staffs());
        }
    }
}