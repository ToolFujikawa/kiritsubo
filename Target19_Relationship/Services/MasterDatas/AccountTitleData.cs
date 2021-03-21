using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Services.MasterDatas
{
    public class AccountTitleData
    {
        public List<AccountTitle> GetAll()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.AccountTitles
                            .ToList();
            }
        }

        public static List<SelectListItem> GetAllSelectListItem()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.AccountTitles
                                .Select(at => new SelectListItem
                                {
                                    Text = at.AccountName,
                                    Value = at.Id.ToString()
                                })
                                .ToList();
                results.Insert(0, new SelectListItem { Value = "0", Text = "勘定科目選択" });
                return results;
            }
        }

        public static List<SelectListItem> GetGoodsIssueSelectListItem()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.AccountTitles
                                .Where(at => at.Id == 4)
                                .Select(at => new SelectListItem
                                {
                                    Text = at.AccountName,
                                    Value = at.Id.ToString()
                                })
                                .ToList();
                results.Insert(0, new SelectListItem { Value = "0", Text = "出庫理由選択" });

                return results;
            }
        }

        public static int[] GetIdRange(DefaultConnection db, int targetId)
        {
            int[] results = new int[2];
            if (targetId == 0)
            {
                results[0] = 1;
                results[1] = db.AccountTitles
                                .Max(at => at.Id);
                return results;
            }
            else
            {
                results[0] = targetId;
                results[1] = targetId;
                return results;
            }

        }

        public AccountTitle GetUnique(int Id)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.AccountTitles
                            .Single(at => at.Id == Id);
            }
        }

        public static int[] NameToId(DefaultConnection db, string accountTitle)
        {
            int[] ids = new int[2] { 1, 1 };
            if (!String.IsNullOrEmpty(accountTitle))
            {
                var result = db.AccountTitles
                                .Single(at => at.AccountName == accountTitle)
                                .Id;
                ids[0] = result;
                ids[1] = result;
                return ids;
            }
            else
            {
                var result = db.AccountTitles
                                .Max(at => at.Id);
                ids[1] = result;
                return ids;
            }

        }
    }
}