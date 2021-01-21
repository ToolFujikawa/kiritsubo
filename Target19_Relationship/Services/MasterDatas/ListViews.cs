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

        public List<BusinessPartner> BusinessPartners(string initial)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var anonymous = db.BusinessPartners
                                    .Where(bp => bp.Furigana.StartsWith(initial))
                                    .Select(bp => new
                                    {
                                        bp.Id,
                                        bp.IsHalted,
                                        bp.IsExport,
                                        bp.FormalName,
                                        bp.CommonName,
                                        bp.IntegratedName,
                                        bp.Furigana,
                                        bp.PhoneNo,
                                        bp.FAXNo,
                                        bp.ZIPCode,
                                        bp.Prefecture,
                                        bp.City,
                                        bp.Address,
                                        bp.StreetAddress,
                                        bp.AccountsPayable,
                                        bp.AccountsPayableClosingDay,
                                        bp.AccountsReceivable,
                                        bp.AccountsReceivableClosingDay,
                                        bp.PaymentSite,
                                        bp.ReceivingSite,
                                        bp.PaymentMethod,
                                        bp.ReceivingMethod,
                                        bp.PaymentDate,
                                        bp.CollectionDate,
                                        bp.IsExclusiveDeliveryNote,
                                        bp.Note,
                                        bp.Recorder_Id,
                                        bp.Changer_Id,
                                        bp.RecordingDate,
                                        bp.RecordingTime,
                                        bp.UpdateDate,
                                        bp.UpdateTime,
                                        bp.AccessRoute,
                                        bp.FIMS_Id
                                    })
                                    .ToList();

                var records = anonymous
                                .Select(a => new BusinessPartner
                                {
                                    Id = a.Id,
                                    IsHalted = a.IsHalted,
                                    IsExport = a.IsExport,
                                    FormalName = a.FormalName,
                                    CommonName = a.CommonName,
                                    IntegratedName = a.IntegratedName,
                                    Furigana = a.Furigana,
                                    PhoneNo = a.PhoneNo,
                                    FAXNo = a.FAXNo,
                                    ZIPCode = a.ZIPCode,
                                    Prefecture = a.Prefecture,
                                    City = a.City,
                                    Address = a.Address,
                                    StreetAddress = a.StreetAddress,
                                    AccountsPayable = a.AccountsPayable,
                                    AccountsPayableClosingDay = a.AccountsPayableClosingDay,
                                    AccountsReceivable = a.AccountsReceivable,
                                    AccountsReceivableClosingDay = a.AccountsReceivableClosingDay,
                                    PaymentSite = a.PaymentSite,
                                    ReceivingSite = a.ReceivingSite,
                                    PaymentMethod = a.PaymentMethod,
                                    ReceivingMethod = a.ReceivingMethod,
                                    PaymentDate = a.PaymentDate,
                                    CollectionDate = a.CollectionDate,
                                    IsExclusiveDeliveryNote = a.IsExclusiveDeliveryNote,
                                    Note = a.Note,
                                    Recorder_Id = a.Recorder_Id,
                                    Changer_Id = a.Changer_Id,
                                    RecordingDate = a.RecordingDate,
                                    RecordingTime = a.RecordingTime,
                                    UpdateDate = a.UpdateDate,
                                    UpdateTime = a.UpdateTime,
                                    AccessRoute = a.AccessRoute,
                                    FIMS_Id = a.FIMS_Id
                                })
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