using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;

namespace Target19_Relationship.Services
{
    public class NameToId
    {
        //戻り値が配列なのは条件を与えられない検索に対応するため
        public static int[] AccountTitle(DefaultConnection db, string accountTitle)
        {
            try
            {
                var result = db.AccountTitles
                               .Single(at => at.AccountName == accountTitle)
                               .Id;
                int[] ids = new int[2] { result, result };
                return ids;
            }
            catch (Exception)
            {
                var result = db.AccountTitles
                                .Max(at => at.Id);
                int[] ids = new int[2] { 1, result };
                return ids;
                throw;
            }
        }

        public static int[] Manufacturer(DefaultConnection db, string commonName)
        {
            try
            {
                int[] ids = new int[2] { 1, 1 };
                if (String.IsNullOrEmpty(commonName))
                {
                    ids[1] = db.Manufacturers.Max(m => m.Id);
                    return ids;
                }
                else
                {
                    ids[0] = db.Manufacturers
                                .Single(m => m.CommonName == commonName)
                                .Id;

                    ids[1] = db.Manufacturers
                                .Single(m => m.CommonName == commonName)
                                .Id;
                    return ids;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int[] Staff(DefaultConnection db, string fullName)
        {
            try
            {
                var result = db.Staffs
                                .Single(s => s.LastName + s.FirstName == fullName)
                                .Id;
                int[] ids = new int[2] { result, result };
                return ids;

            }
            catch (Exception)
            {
                var result = db.Staffs
                                .Max(s => s.Id);
                int[] ids = new int[2] { 1, result };
                return ids;
                throw;
            }
        }

        public static int[] Helper(DefaultConnection db, string fullName)
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

        public static int[] BusinessPartner(DefaultConnection db, string commonName)
        {
            try
            {
                var result = db.BusinessPartners
                                .Single(m => m.CommonName == commonName)
                                .Id;
                int[] ids = new int[2] { result, result };
                return ids;
            }
            catch (Exception)
            {
                var result = db.BusinessPartners
                                .Max(m => m.Id);
                int[] ids = new int[2] { 1, result };
                return ids;
                throw;
            }
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