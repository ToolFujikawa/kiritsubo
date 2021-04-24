using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Services.MasterDatas
{
    public class StaffData
    {
        public static int EmailToId(DefaultConnection db, string email)
        {
            return db.Staffs
                        .Single(s => s.LentEmailAddress == email)
                        .Id;
        }

        public List<Staff> GetAll()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.Staffs
                          .ToList();
            }
        }

        public static List<SelectListItem> GetAllSelectListItem()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.Staffs
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

        public static string EmailToFullName(DefaultConnection db, string lentEmail)
        {
            var anonymous = db.Staffs
                                .Where(s => s.LentEmailAddress == lentEmail)
                                .Select(s => new
                                {
                                    FullName = s.LastName + s.FirstName
                                })
                                .ToList();
            string result = anonymous
                            .Select(a => a.FullName)
                            .First()
                            .ToString();
            return result;
        }

        public static int[] GetIdRange(DefaultConnection db, int targetId)
        {
            int[] results = new int[2];
            if (targetId == 0)
            {
                results[0] = 1;
                results[1] = db.Staffs
                                .Max(s => s.Id);
                return results;
            }
            else
            {
                results[0] = targetId;
                results[1] = targetId;
                return results;
            }
        }

        public static List<SelectListItem> GetIsActiveSelectListItems()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var results = db.Staffs
                                .Where(s => s.IsActive == true)
                                .OrderBy(s => s.LastName + s.FirstName)
                                .Select(s => new SelectListItem
                                {
                                    Text = s.LastName + s.FirstName,
                                    Value = s.Id.ToString()
                                })
                                .ToList();

                return results;

            }
        }

        public List<string> GetNames(string staffName)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.Staffs.Where(s => s.LastName.StartsWith(staffName))
                                .Select(s => s.LastName + s.FirstName).ToList();
            }
        }
    }
}