﻿using System;
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
            ListViews listViews = new ListViews();
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
                ListViews listViews = new ListViews();
                var results = listViews.BusinessPartners(initial);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_BusinessPartnerContent");
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
                ListViews listViews = new ListViews();
                var results = listViews.BusinessPartnerEmailAddresses(initial);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_BusinessPartnerEmailAddressContent");
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        public ActionResult DeliveryPlaceList()
        {
            ListViews listViews = new ListViews();
            return View(listViews.DeliveryPlaces());
        }

        public ActionResult FinancialInstitutionList()
        {
            ListViews listViews = new ListViews();
            return View(listViews.FinancialInstitutions());
        }

        public ActionResult FinancialInstitutionBranchList()
        {
            ListViews listViews = new ListViews();
            return View(listViews.FinancialInstitutionBranches());
        }

        public ActionResult HelperList()
        {
            ListViews listViews = new ListViews();
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
                ListViews listViews = new ListViews();
                var results = listViews.Manufacturers(initial);
                if (results.Count() == 0)
                {
                    return PartialView("_NoResult");
                }
                else
                {
                    return PartialView("_ManufacturerContent");
                }
            }
            return Content("Ajax通信以外のアクセスはできません");
        }

        public ActionResult StaffList()
        {
            ListViews listViews = new ListViews();
            return View(listViews.Staffs());
        }
    }
}