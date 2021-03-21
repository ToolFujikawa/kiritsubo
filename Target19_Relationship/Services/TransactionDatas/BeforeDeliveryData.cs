using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Views;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Services.TransactionDatas
{
    public class BeforeDeliveryData
    {
        public static List<SelectListItem> GetCustomerSelectListItems()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.BeforeDeliveries
                                   .Select(bd => new SelectListItem
                                   {
                                       Text = bd.Customer,
                                       Value = bd.Customer_Id.ToString()
                                   })
                                   .Distinct()
                                   .ToList();
                results.Insert(0, new SelectListItem { Value = "0", Text = "販売先選択" });
                return results;

            }
        }

        public static List<SelectListItem> GetHelperSelectListItems()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.BeforeDeliveries
                                .Join(
                                    db.Helpers,
                                    bd => bd.Helper_Id,
                                    h => h.Id,
                                    (bd, h) => new
                                    {
                                        h.Id,
                                        Name = h.LastName + h.FirstName,
                                        Furigana = h.LastNameFurigana + h.FirstNameFurigana
                                    })
                                    .OrderBy(jointable => jointable.Furigana)
                                    .Select(jointable => new SelectListItem
                                    {
                                        Text = jointable.Name,
                                        Value = jointable.Id.ToString()
                                    })
                                    .Distinct()
                                    .ToList();
                results.Insert(0, new SelectListItem { Value = "0", Text = "発注者選択" });
                return results;
            }
        }

        public static List<SelectListItem> GetManufacturerSelectListItems()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.BeforeDeliveries
                                    .Join(
                                        db.Products,
                                        bd => bd.Product_Id,
                                        p => p.Id,
                                        (bd, p) => new
                                        {
                                            p.Manufacturer_Id,
                                            p.Manufacturer.CommonName,
                                            p.Manufacturer.Furigana
                                        })
                                    .OrderBy(jointable => jointable.Furigana)
                                    .Select(jointable => new SelectListItem
                                    {
                                        Text = jointable.CommonName,
                                        Value = jointable.Manufacturer_Id.ToString()
                                    })
                                    .Distinct()
                                    .ToList();
                results.Insert(0, new SelectListItem { Value = "0", Text = "メーカー選択" });
                return results;
            }
        }

        public List<BeforeDelivery> GetSpecificWordGroup(int customer_Id, int manufacturer_Id, string keywords, int responsibleStaff_Id,
                                                            int helper_Id, DateTime startDate, DateTime endDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                int openCustomer_Id = BusinessPartnerData.GetIdRange(db, customer_Id)[0];
                int closeCustomer_Id = BusinessPartnerData.GetIdRange(db, customer_Id)[1];
                int openManufacturer_Id = ManufacturerData.GetIdRange(db, manufacturer_Id)[0];
                int closeManufacturer_Id = ManufacturerData.GetIdRange(db, manufacturer_Id)[1];
                int openStaff_Id = IdRange.Staff(db, responsibleStaff_Id)[0];
                int closeStaff_Id = IdRange.Staff(db, responsibleStaff_Id)[1];
                int openHelper_Id = IdRange.Helper(db, helper_Id)[0];
                int closeHelper_Id = IdRange.Helper(db, helper_Id)[1];
                List<BeforeDelivery> beforeDeliveries = new List<BeforeDelivery>();

                if (!String.IsNullOrEmpty(keywords))
                {
                    SQLWhereString whereString = new SQLWhereString();
                    string where = whereString.SearchKeyWhere<BeforeDelivery>(db, keywords);
                    string[] keywordArray = keywords.Split(new[] { ' ', '　' });
                    beforeDeliveries = db.Database
                                            .SqlQuery<BeforeDelivery>(where)
                                            .ToList();
                    return beforeDeliveries
                                        .Where(so => so.Customer_Id >= openCustomer_Id
                                            && so.Customer_Id <= closeCustomer_Id
                                            && so.Manufacturer_Id >= openManufacturer_Id
                                            && so.Manufacturer_Id <= closeManufacturer_Id
                                            && so.ResponsibleStaff_Id >= openStaff_Id
                                            && so.ResponsibleStaff_Id <= closeStaff_Id
                                            && so.Helper_Id >= openHelper_Id
                                            && so.Helper_Id <= closeHelper_Id
                                            && so.SalesOrderDate >= startDate
                                            && so.SalesOrderDate <= endDate)
                                        .ToList();
                }
                else
                {
                    return db.BeforeDeliveries
                                        .Where(so => so.Customer_Id >= openCustomer_Id
                                            && so.Customer_Id <= closeCustomer_Id
                                            && so.Manufacturer_Id >= openManufacturer_Id
                                            && so.Manufacturer_Id <= closeManufacturer_Id
                                            && so.ResponsibleStaff_Id >= openStaff_Id
                                            && so.ResponsibleStaff_Id <= closeStaff_Id
                                            && so.Helper_Id >= openHelper_Id
                                            && so.Helper_Id <= closeHelper_Id
                                            && so.SalesOrderDate >= startDate
                                            && so.SalesOrderDate <= endDate)
                                        .ToList();
                }
            }
        }

        public static List<SelectListItem> GetStaffSelectListItems()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.BeforeDeliveries
                                .Join(
                                    db.Staffs,
                                    bd => bd.ResponsibleStaff_Id,
                                    s => s.Id,
                                    (bd, s) => new
                                    {
                                        s.Id,
                                        Name = s.LastName + s.FirstName,
                                        Furigana = s.LastNameFurigana + s.FirstNameFurigana
                                    })
                                 .OrderBy(jointable => jointable.Furigana)
                                 .Select(jointable => new SelectListItem
                                 {
                                     Text = jointable.Name,
                                     Value = jointable.Id.ToString()
                                 })
                                 .Distinct()
                                 .ToList();
                results.Insert(0, new SelectListItem { Value = "0", Text = "責任者選択" });
                return results;
            }
        }
    }
}