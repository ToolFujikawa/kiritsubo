using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Controllers
{
    public class NameValueController : Controller
    {
        public ActionResult Manufacturer(string term)
        {
            NameValue nameValue = new NameValue();
            return Json(nameValue.Manufacturer(term), JsonRequestBehavior.AllowGet);
        }
    }
}