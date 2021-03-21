using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Services.MasterDatas
{
    public class HelperData
    {
        public List<Helper> GetAll()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.Helpers
                                .ToList();
                return records;
            }
        }

        public static int[] GetIdRange(DefaultConnection db, int targetId)
        {
            int[] results = new int[2];
            if (targetId == 0)
            {
                results[0] = 1;
                results[1] = db.Helpers
                                .Max(h => h.Id);
                return results;
            }
            else
            {
                results[0] = targetId;
                results[1] = targetId;
                return results;
            }
        }

        public static int[] NameToId(DefaultConnection db, string fullName)
        {
            if (String.IsNullOrEmpty(fullName))
            {
                var result = db.Helpers
                                .Max(h => h.Id);
                int[] ids = new int[2] { 1, result };
                return ids;
            }
            else
            {
                var result = db.Helpers
                                .Single(h => h.LastName + h.FirstName == fullName)
                                .Id;
                int[] ids = new int[2] { result, result };
                return ids;
            }
        }
    }
}