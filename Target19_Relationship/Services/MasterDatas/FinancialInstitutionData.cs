using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Services.MasterDatas
{
    public class FinancialInstitutionData
    {
        public List<FinancialInstitution> GetAll()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.FinancialInstitutions
                                .ToList();
                return records;
            }
        }

        public int GetRow()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.FinancialInstitutions
                            .Count();
            }
        }

        public List<FinancialInstitution> GetSpecificPage(int page)
        {
            using(DefaultConnection db = new DefaultConnection())
            {
                int skipNo = page == 1 ? 0 : (page - 1) * 8;
                return db.FinancialInstitutions
                            .OrderBy(fi => fi.Furigana)
                            .Skip(skipNo)
                            .Take(8)
                            .ToList();
            }
        }
    }
}