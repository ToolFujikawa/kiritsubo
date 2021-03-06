using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Views;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Services.Quotations
{
    public class ReadableQuotationData
    {
        public List<BeforeSubmittingQuotation> UnitPriceSetting(string staffEmailAddress)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                string fullName = StaffData.EmailToFullName(db, staffEmailAddress);
                return db.BeforeSubmittingQuotations
                            .Where(sq => sq.ResponsibleStaff == fullName)
                            .ToList();
            }
        }

        public static List<SelectListItem> GetCustomerSelectListItem()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.ReadableQuotations
                                .Where(rq => rq.QuotationNo == 0)
                                .Select(rq => new SelectListItem
                                {
                                    Text = rq.Customer,
                                    Value = rq.Customer_Id.ToString()
                                })
                                .Distinct()
                                .ToList();
                
                results.Insert(0, new SelectListItem { Value = "0", Text = "販売先選択" });
                return results;
            }
        }

        public static List<SelectListItem> GetStaffSelectListItems()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.ReadableQuotations
                                .Where(rq => rq.QuotationNo == 0)
                                .Select(rq => new SelectListItem
                                {
                                    Text = rq.ResponsibleStaff,
                                    Value = rq.ResponsibleStaff_Id.ToString()
                                })
                                .Distinct()
                                .ToList();
                
                results.Insert(0, new SelectListItem { Value = "0", Text = "責任者選択" });
                return results;
            }
        }
    }
}