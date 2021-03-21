using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Views;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Services.TransactionDatas
{
    public class QuotationData
    {
        public List<ReadableQuotation> GetSpecificWordGroup(string customer, string manufacturer, string keywords, 
                                                            int staff_Id, string helper, DateTime startDate, DateTime endDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.SearchKeyWhere<ReadableQuotation>(db, keywords);
                int openCustomer_Id = BusinessPartnerData.NameToId(db, customer)[0];
                int closeCustomer_Id = BusinessPartnerData.NameToId(db, customer)[1];
                int openManufacturer_Id = ManufacturerData.NameToId(db, manufacturer)[0];
                int closeManufacturer_Id = ManufacturerData.NameToId(db, manufacturer)[1];
                int openStaff_Id = StaffData.GetIdRange(db, staff_Id)[0];
                int closeStaff_Id = StaffData.GetIdRange(db, staff_Id)[1];
                int openHelper_Id = HelperData.NameToId(db, helper)[0];
                int closeHelper_Id = HelperData.NameToId(db, helper)[1];
                List<ReadableQuotation> readableQuotations = new List<ReadableQuotation>();
                if (!String.IsNullOrEmpty(keywords))
                {
                    readableQuotations = db.Database
                                            .SqlQuery<ReadableQuotation>(where)
                                            .ToList();
                    return readableQuotations
                            .Where(rq => rq.Customer_Id >= openCustomer_Id
                                        && rq.Customer_Id <= closeCustomer_Id
                                        && rq.Manufacturer_Id >= openManufacturer_Id
                                        && rq.Manufacturer_Id <= closeManufacturer_Id
                                        && rq.Helper_Id >= openHelper_Id
                                        && rq.Helper_Id <= closeHelper_Id
                                        && rq.ResponsibleStaff_Id >= openStaff_Id
                                        && rq.ResponsibleStaff_Id <= closeStaff_Id
                                        && rq.SubmissionDate >= startDate
                                        && rq.SubmissionDate <= endDate)
                            .ToList();
                }
                else
                {
                    readableQuotations = db.ReadableQuotations
                                            .Where(rq => rq.Customer_Id >= openCustomer_Id
                                                        && rq.Customer_Id <= closeCustomer_Id
                                                        && rq.Manufacturer_Id >= openManufacturer_Id
                                                        && rq.Manufacturer_Id <= closeManufacturer_Id
                                                        && rq.Helper_Id >= openHelper_Id
                                                        && rq.Helper_Id <= closeHelper_Id
                                                        && rq.ResponsibleStaff_Id >= openStaff_Id
                                                        && rq.ResponsibleStaff_Id <= closeStaff_Id
                                                        && rq.SubmissionDate >= startDate
                                                        && rq.SubmissionDate <= endDate)
                                            .ToList();
                    return readableQuotations;
                }
            }
        }
    }
}