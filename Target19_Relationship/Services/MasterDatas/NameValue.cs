using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Views;

namespace Target19_Relationship.Services.MasterDatas
{
    public class NameValue
    {
        public List<string> BusinessPartner(string businessPartnerName)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.BusinessPartners.Where(bp => bp.CommonName.StartsWith(businessPartnerName))
                                .Select(s => s.CommonName).ToList();
            }
        }

        public List<string> Manufacturer(string term)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.Manufacturers
                            .Where(m => m.CommonName.StartsWith(term))
                            .OrderBy(m => m.Furigana)
                            .Select(m => m.CommonName)
                            .ToList();
            }
        }

        public List<string> Staff(string staffName)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.Staffs.Where(s => s.LastName.StartsWith(staffName))
                                .Select(s => s.LastName + s.FirstName).ToList();
            }
        }
    }
}