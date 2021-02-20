using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Services
{
    public class DropdownDataSources
    {
        public List<SelectListItem> GetAccountTitle(string use)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                switch (use)
                {
                    case "GoodsIssue":
                        var results0 = db.AccountTitles
                                            .Where(at => at.Id == 4)
                                            .OrderBy(at => at.Id)
                                            .Select(at => new SelectListItem
                                            {
                                                Text = at.AccountName,
                                                Value = at.Id.ToString()
                                            })
                                            .ToList();
                        results0.Insert(0, new SelectListItem { Value = "0", Text = "出庫理由選択" });
                        return results0;

                    case "GoodsReceipt":
                        var results2 = db.AccountTitles
                                            .Where(at => at.Id == 4)
                                            .OrderBy(at => at.Id)
                                            .Select(at => new SelectListItem
                                            {
                                                Text = at.AccountName,
                                                Value = at.Id.ToString()
                                            })
                                            .ToList();
                        results2.Insert(0, new SelectListItem { Value = "0", Text = "入庫理由選択" });
                        return results2;

                    case "Debit":
                        var results3 = db.AccountTitles
                                            .OrderBy(at => at.Id)
                                            .Select(at => new SelectListItem
                                            {
                                                Text = at.AccountName,
                                                Value = at.Id.ToString()
                                            })
                                            .ToList();
                        results3.Insert(0, new SelectListItem { Value = "0", Text = "借方科目選択" });
                        return results3;

                    case "Credit":
                        var results4 = db.AccountTitles
                                            .OrderBy(at => at.Id)
                                            .Select(at => new SelectListItem
                                            {
                                                Text = at.AccountName,
                                                Value = at.Id.ToString()
                                            })
                                            .ToList();
                        results4.Insert(0, new SelectListItem { Value = "0", Text = "貸方科目選択" });
                        return results4;

                    default:
                        var results1 = db.AccountTitles
                                            .Select(at => new SelectListItem
                                            {
                                                Text = at.AccountName,
                                                Value = at.Id.ToString()
                                            })
                                            .ToList();           
                        results1.Insert(0, new SelectListItem { Value = "0", Text = "勘定科目選択" });
                        return results1;
                }

            }
        }

        public List<SelectListItem> GetBusinessPartner(string dataSouce)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                switch (dataSouce)
                {
                    case "BeforeDelivery":
                        var results2 = db.BeforeDeliveries
                                            .Select(bd => new SelectListItem
                                            {
                                                Text = bd.Customer,
                                                Value = bd.Customer_Id.ToString()
                                            })
                                            .Distinct()
                                            .ToList();
                        results2.Insert(0, new SelectListItem { Value = "0", Text = "販売先" });
                        return results2;

                    case "BeforeWarehousing":
                        var results0 = db.BeforeWarehousings
                                            .Select(bw => new SelectListItem
                                            {
                                                Text = bw.Supplier,
                                                Value = bw.Supplier_Id.ToString()
                                            })
                                            .Distinct()
                                            .ToList();
                        results0.Insert(0, new SelectListItem { Value = "0", Text = "仕入先" });
                        return results0;

                    default:
                        var results1 = db.BusinessPartners
                                            .Select(bp => new SelectListItem
                                            {
                                                Text = bp.CommonName,
                                                Value = bp.Id.ToString()
                                            })
                                            .ToList();
                        results1.Insert(0, new SelectListItem { Value = "0", Text = "取引先" });
                        return results1;
                }
            }
        }

        public List<SelectListItem> GetHelper(string dataSource)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                switch (dataSource)
                {
                    default:
                        var results0 = db.BeforeDeliveries
                                            .Select(bd => new SelectListItem
                                            {
                                                Text = bd.Helper,
                                                Value = bd.Helper_Id.ToString()
                                            })
                                            .Distinct()
                                            .ToList();
                        results0.Insert(0, new SelectListItem { Value = "0", Text = "販売先担当者" });
                        return results0;
                }
            }
        }

        public List<SelectListItem> GetManufacturer(string dataSource)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                switch (dataSource)
                {
                    case "BeforeDelivery":
                        var results2 = db.BeforeDeliveries
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
                        results2.Insert(0, new SelectListItem { Value = "0", Text = "メーカー選択" });
                        return results2;

                    case "BeforeWarehousing":
                        var results0 = db.BeforeWarehousings
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
                        results0.Insert(0, new SelectListItem { Value = "0", Text = "メーカー選択" });
                        return results0;

                    default:
                        var results1 = db.Manufacturers
                                            .OrderBy(m => m.Furigana)
                                            .Select(m => new SelectListItem
                                            {
                                                Text = m.CommonName,
                                                Value = m.Id.ToString()
                                            })
                                            .ToList();
                        results1.Insert(0, new SelectListItem { Value = "0", Text = "メーカー選択" });
                        return results1;
                }
            }
        }

        public List<SelectListItem> GetStaff(bool active)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.Staffs
                                .Where(s => s.IsActive == active)
                                .OrderBy(s => s.LastNameFurigana + s.FirstNameFurigana)
                                .Select(s => new SelectListItem
                                {
                                    Text = s.LastName + s.FirstName,
                                    Value = s.Id.ToString()
                                })
                                .ToList();
                results.Insert(0, new SelectListItem { Value = "0", Text = "責任者選択" });
                return results;
            }
        }
    }
}