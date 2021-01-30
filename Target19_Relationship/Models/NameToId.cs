using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;

namespace Target19_Relationship.Models
{
    public class NameToId
    {
        public static int Manufacturer(DefaultConnection db, string commonName)
        {
            try
            {
                var result = db.Manufacturers
                                .Single(m => m.CommonName == commonName)
                                .Id;
                return result;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }

        public static int Staff(DefaultConnection db, string fullName)
        {
            var result = db.Staffs
                            .Single(s => s.LastName + s.FirstName == fullName)
                            .Id;
            return result;
        }

        public static int Helper(DefaultConnection db, string fullName)
        {
            if (fullName == null)
            {
                return 1;
            }
            var result = db.Helpers
                            .Single(s => s.LastName + s.FirstName == fullName)
                            .Id;
            return result;
        }

        public static int BusinessPartner(DefaultConnection db, string commonName)
        {
            int result = db.BusinessPartners
                            .Single(bp => bp.CommonName == commonName)
                            .Id;
            return result;
        }

        public static int ProductPseudonym(DefaultConnection db, string pseudonym)
        {
            if (pseudonym == null)//三項演算で使用して必ず評価されるための分岐
            {
                return 1;
            }
            else
            {
                int result = db.Products
                                .Single(p => p.Pseudonym == pseudonym)
                                .Id;
                return result;

            }
        }
    }
}