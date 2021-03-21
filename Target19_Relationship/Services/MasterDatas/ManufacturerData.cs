using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Services.MasterDatas
{
    public class ManufacturerData
    {
        public static int[] GetIdRange(DefaultConnection db, int targetId)
        {
            int[] results = new int[2];
            if (targetId == 0)
            {
                results[0] = 1;
                results[1] = db.Manufacturers
                                .Max(m => m.Id);
                return results;
            }
            else
            {
                results[0] = targetId;
                results[1] = targetId;
                return results;
            }
        }

        public List<Manufacturer> GetSpecificInitialGroup(string initial)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.Manufacturers
                                .Where(m => m.Furigana.StartsWith(initial))
                                .ToList();
                return records;
            }
        }

        public static int[] NameToId(DefaultConnection db, string commonName)
        {
            int[] ids = new int[2] { 1, 1 };
            if (!String.IsNullOrEmpty(commonName))
            {
                ids[0] = db.Manufacturers
                            .Single(m => m.CommonName == commonName)
                            .Id;

                ids[1] = db.Manufacturers
                            .Single(m => m.CommonName == commonName)
                            .Id;
                return ids;
            }
            else
            {
                ids[1] = db.Manufacturers.Max(m => m.Id);
                return ids;
            }
        }
    }
}