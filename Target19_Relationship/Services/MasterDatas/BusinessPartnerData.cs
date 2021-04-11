using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Services.MasterDatas
{
    public class BusinessPartnerData
    {
        public List<BusinessPartner> GetAll(string initial)
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
                                        bp.Prefecture_Id,
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
                                    Prefecture_Id = a.Prefecture_Id,
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

        public static int[] GetIdRange(DefaultConnection db, int targetId)
        {
            int[] results = new int[2];
            if (targetId == 0)
            {
                results[0] = 1;
                results[1] = db.BusinessPartners
                                .Max(bp => bp.Id);
                return results;
            }
            else
            {
                results[0] = targetId;
                results[1] = targetId;
                return results;
            }
        }

        public List<string> GetNames(string businessPartnerName)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                return db.BusinessPartners.Where(bp => bp.CommonName.StartsWith(businessPartnerName))
                                .Select(s => s.CommonName).ToList();
            }
        }

        public static int[] NameToId(DefaultConnection db, string businessPartner)
        {
            int[] ids = new int[2] { 1, 1 };
            if (!String.IsNullOrEmpty(businessPartner))
            {
                var result = db.BusinessPartners
                                .Single(m => m.CommonName == businessPartner)
                                .Id;
                ids[0] = result;
                ids[1] = result;
                return ids;
            }
            else
            {
                var result = db.BusinessPartners
                                .Max(m => m.Id);
                ids[1] = result;
                return ids;
            }
        }
    }
}