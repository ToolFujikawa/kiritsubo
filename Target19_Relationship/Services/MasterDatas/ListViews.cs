using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Services.MasterDatas
{
    public class ListViews
    {
        public List<AccountTitle> AccountTitles()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.AccountTitles
                                .ToList();
                return records;
            }
        }

        public List<BusinessPartner> BusinessPartners()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.BusinessPartners
                                .ToList();
                return records;
            }
        }

        public List<BusinessPartnerEMailAddress> BusinessPartnerEMailAddresses()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.BusinessPartnerEMailAddresses
                                .ToList();
                return records;
            }
        }

        public List<DeliveryPlace> DeliveryPlaces()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.DeliveryPlaces
                                .ToList();
                return records;
            }
        }

        public List<FinancialInstitution> FinancialInstitutions()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.FinancialInstitutions
                                .ToList();
                return records;
            }
        }
    }
}