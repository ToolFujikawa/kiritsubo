using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Views;
using Target19_Relationship.Services.MasterDatas;

namespace Target19_Relationship.Services.TransactionDatas
{
    public class SaleData
    {
        public List<ReadableSale> GetSpecificWordGroup(string customer, string manufacturer, string keywords, int staff_Id, string helper,
                                            DateTime salesOrderStartDate, DateTime salesOrderEndDate, DateTime salesStartDate,
                                            DateTime salesEndDate)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.SearchKeyWhere<ReadableSale>(db, keywords);
                int openCustomer_Id = BusinessPartnerData.NameToId(db, customer)[0];
                int closeCustomer_Id = BusinessPartnerData.NameToId(db, customer)[1];
                int openManufacturer_Id = ManufacturerData.NameToId(db, manufacturer)[0];
                int closeManufacturer_Id = ManufacturerData.NameToId(db, manufacturer)[1];
                int openStaff_Id = StaffData.GetIdRange(db, staff_Id)[0];
                int closeStaff_Id = StaffData.GetIdRange(db, staff_Id)[1];
                int openHelper_Id = HelperData.NameToId(db, helper)[0];
                int closeHelper_Id = HelperData.NameToId(db, helper)[1];
                List<ReadableSale> readableSales = new List<ReadableSale>();
                if (!String.IsNullOrEmpty(keywords))
                {
                    readableSales = db.Database
                                        .SqlQuery<ReadableSale>(where)
                                        .ToList();
                    return readableSales
                              .Where(rs => rs.Customer_Id >= openCustomer_Id
                                      && rs.Customer_Id <= closeCustomer_Id
                                      && rs.Manufacturer_Id >= openManufacturer_Id
                                      && rs.Manufacturer_Id <= closeManufacturer_Id
                                      && rs.ResponsibleStaff_Id >= openStaff_Id
                                      && rs.ResponsibleStaff_Id <= closeStaff_Id
                                      && rs.Helper_Id >= openHelper_Id
                                      && rs.Helper_Id <= closeHelper_Id
                                      && rs.SalesOrderDate >= salesOrderStartDate
                                      && rs.SalesOrderDate <= salesOrderEndDate
                                      && rs.SalesDate >= salesStartDate
                                      && rs.SalesDate <= salesEndDate)
                              .ToList();
                }
                else
                {
                    readableSales = db.ReadableSales
                                        .Where(rs => rs.Customer_Id >= openCustomer_Id
                                        && rs.Customer_Id <= closeCustomer_Id
                                        && rs.Manufacturer_Id >= openManufacturer_Id
                                        && rs.Manufacturer_Id <= closeManufacturer_Id
                                        && rs.ResponsibleStaff_Id >= openStaff_Id
                                        && rs.ResponsibleStaff_Id <= closeStaff_Id
                                        && rs.Helper_Id >= openHelper_Id
                                        && rs.Helper_Id <= closeHelper_Id
                                        && rs.SalesOrderDate >= salesOrderStartDate
                                        && rs.SalesOrderDate <= salesOrderEndDate
                                        && rs.SalesDate >= salesStartDate
                                        && rs.SalesDate <= salesEndDate)
                                .ToList();

                    return readableSales;
                }
            }
        }
    }
}