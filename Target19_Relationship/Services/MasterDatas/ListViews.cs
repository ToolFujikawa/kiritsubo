using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Details;
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

        public List<DetailBusinessPartnerEmailAddress> BusinessPartnerEmailAddresses(string initial)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var anonymous = db.BusinessPartnerEMailAddresses
                                    .Where(be => be.BusinessPartner.Furigana.StartsWith(initial))
                                    .Select(be => new
                                    {
                                        be.Id,
                                        be.BusinessPartner.CommonName,
                                        be.EmailAddress,
                                        be.Rank,
                                        be.Note,
                                        be.Recorder_Id,
                                        be.Changer_Id,
                                        be.RecordingDate,
                                        be.RecordingTime,
                                        be.UpdateDate,
                                        be.UpdateTime,
                                        be.AccessRoute
                                    })
                                    .ToList();

                var results = anonymous
                                .Select(a => new DetailBusinessPartnerEmailAddress
                                {
                                    Id = a.Id,
                                    BusinessPartner = a.CommonName,
                                    EmailAddress = a.EmailAddress,
                                    Rank = a.Rank,
                                    Note = a.Note,
                                    Recorder_Id = a.Recorder_Id,
                                    Changer_Id = a.Changer_Id,
                                    RecordingDate = a.RecordingDate,
                                    RecordingTime = a.RecordingTime,
                                    UpdateDate = a.UpdateDate,
                                    UpdateTime = a.UpdateTime,
                                    AccessRoute = a.AccessRoute
                                })
                                .ToList();
                return results;
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

        public List<FinancialInstitutionBranch> FinancialInstitutionBranches()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.FinancialInstitutionBranches
                                .ToList();
                return records;
            }
        }

        public List<Helper> Helpers()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.Helpers
                                .ToList();
                return records;
            }
        }

        public List<Staff> Staffs()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var records = db.Staffs
                                .ToList();
                return records;
            }
        }
    }
}