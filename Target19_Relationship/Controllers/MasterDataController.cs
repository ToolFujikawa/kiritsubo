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
            ListViews listViews = new ListViews();
            return View(listViews.AccountTitles());
        }

        public ActionResult BusinessPartnerList()
        {
            ListViews listViews = new ListViews();
            return View(listViews.BusinessPartners());
        }

        public ActionResult BusinessPartnerEMailAddressList()
        {
            ListViews listViews = new ListViews();
            return View(listViews.BusinessPartnerEMailAddresses());
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
    }
}