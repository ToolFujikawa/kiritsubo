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
    public class BeforeWarehousingData
    {
        public static List<SelectListItem> GetManufacturerSelectListItem()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.BeforeWarehousings
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

        public List<BeforeWarehousing> GetSpecificWordGroup(int supplier_Id, int manufacturer_Id, string keywords,
                                                        DateTime startDate, DateTime endDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                int openSupplier_Id = BusinessPartnerData.GetIdRange(db, supplier_Id)[0];
                int closeSupplier_Id = BusinessPartnerData.GetIdRange(db, supplier_Id)[1];
                int openManufacturer_Id = ManufacturerData.GetIdRange(db, manufacturer_Id)[0];
                int closeManufacturer_Id = ManufacturerData.GetIdRange(db, manufacturer_Id)[1];
                List<BeforeWarehousing> beforeWarehousings = new List<BeforeWarehousing>();

                if (!String.IsNullOrEmpty(keywords))
                {
                    SQLWhereString whereString = new SQLWhereString();
                    string where = whereString.SearchKeyWhere<BeforeWarehousing>(db, keywords);
                    beforeWarehousings = db.Database
                                            .SqlQuery<BeforeWarehousing>(where)
                                            .ToList();
                    beforeWarehousings = beforeWarehousings
                                            .Where(bw => bw.Supplier_Id >= openSupplier_Id
                                            && bw.Supplier_Id <= closeSupplier_Id
                                            && bw.Manufacturer_Id >= openManufacturer_Id
                                            && bw.Manufacturer_Id <= closeManufacturer_Id
                                            && bw.PurchaseDate >= startDate
                                            && bw.PurchaseDate <= endDate)
                                    .ToList();
                    return beforeWarehousings;
                }
                else
                {
                    beforeWarehousings = db.BeforeWarehousings
                                            .Where(bw => bw.Supplier_Id >= openSupplier_Id
                                            && bw.Supplier_Id <= closeSupplier_Id
                                            && bw.Manufacturer_Id >= openManufacturer_Id
                                            && bw.Manufacturer_Id <= closeManufacturer_Id
                                            && bw.PurchaseDate >= startDate
                                            && bw.PurchaseDate <= endDate)
                                    .ToList();
                    return beforeWarehousings;
                }
            }
        }

        public static List<SelectListItem> GetSupplierSelectListItems()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.BeforeWarehousings
                                    .Select(bw => new SelectListItem
                                    {
                                        Text = bw.Supplier,
                                        Value = bw.Supplier_Id.ToString()
                                    })
                                    .Distinct()
                                    .ToList();
                results.Insert(0, new SelectListItem { Value = "0", Text = "仕入先" });
                return results;
            }
        }
    }
}