using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;

namespace Target19_Relationship.Services
{
    public class IdRange
    {
        public static int[] AccountTitle(DefaultConnection db, int targetId)
        {
            int[] results = new int[2];
            if (targetId == 0)
            {
                results[0] = 1;
                results[1] = db.AccountTitles.Max(at => at.Id);
                return results;
            }
            else
            {
                results[0] = targetId;
                results[1] = targetId;
                return results;
            }
        }
        public int[] Manufacturer(string commonName)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return NameToId.Manufacturer(db, commonName);
            }
        }
    }
}