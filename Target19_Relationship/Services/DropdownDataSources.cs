using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models;

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