using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Views;

namespace Target19_Relationship.Services.MasterDatas
{
    public class ProductAttributeData
    {
        public List<ReadableProductAttribute> GetSpecificWordGroup(string businessPartner, string manufacturer, string keywords)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.SearchKeyWhere<ReadableProductAttribute>(db, keywords);
                int openManufacturer_Id = ManufacturerData.NameToId(db, manufacturer)[0];
                int closeManufacturer_Id = ManufacturerData.NameToId(db, manufacturer)[1];
                int openBusinessPertner_Id = BusinessPartnerData.NameToId(db, businessPartner)[0];
                int closeBusinessPertner_Id = BusinessPartnerData.NameToId(db, businessPartner)[1];
                if (!String.IsNullOrEmpty(keywords))
                {
                    var anonymous = db.Database
                                        .SqlQuery<ReadableProductAttribute>(where)
                                        .ToList();

                    return anonymous
                                    .Where(a => a.Manufacturer_Id >= openManufacturer_Id
                                            && a.Manufacturer_Id <= closeManufacturer_Id
                                            && a.BusinessPartner_Id >= openBusinessPertner_Id
                                            && a.BusinessPartner_Id <= closeBusinessPertner_Id)
                                    .ToList();
                }
                else
                {
                    return db.ReadableProductAttributes
                                .Where(ra => ra.Manufacturer_Id >= openManufacturer_Id 
                                            && ra.Manufacturer_Id <= closeManufacturer_Id
                                            && ra.BusinessPartner_Id >= openBusinessPertner_Id
                                            && ra.BusinessPartner_Id <= closeBusinessPertner_Id)
                                .ToList();
                }
            }
        }
    }
}