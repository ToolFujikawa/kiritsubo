using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using Target19_Relationship.Models.Tables;
using Target19_Relationship.Models.Views;

namespace Target19_Relationship.Services.MasterDatas
{
    public class ProductData
    {
        public List<ReadableProduct> GetSpecificWordGroup(string manufacturer, string keywords)
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                SQLWhereString whereString = new SQLWhereString();
                string where = whereString.SearchKeyWhere<ReadableProduct>(db, keywords);
                int openManufacturer_Id = ManufacturerData.NameToId(db, manufacturer)[0];
                int closeManufacturer_Id = ManufacturerData.NameToId(db, manufacturer)[1];
                if (!String.IsNullOrEmpty(keywords))
                {
                    var anonymous = db.Database
                                        .SqlQuery<ReadableProduct>(where)
                                        .ToList();
                    return anonymous
                            .Where(a => a.Manufacturer_Id >= openManufacturer_Id
                                        && a.Manufacturer_Id <= closeManufacturer_Id)
                            .ToList();
                }
                else
                {
                    return db.ReadableProducts
                                .Where(rp => rp.Manufacturer_Id >= openManufacturer_Id
                                            && rp.Manufacturer_Id <= closeManufacturer_Id)
                                .ToList();
                }
            }
        }
    }
}