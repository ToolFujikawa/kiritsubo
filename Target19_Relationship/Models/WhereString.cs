using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Target19_Relationship.Models;

namespace Target19_Relationship.Models
{
    public class SQLWhereString
    {
        public string AssembleProductWhere(DefaultConnection db, string manufacturer, string keywords)
        {
            StringBuilder sb = new StringBuilder();
            string[] keywordArray = keywords.Split(new[] { ' ', '　' });

            //品名、材質、型式検索条件
            for (int i = 0; i < keywordArray.Count(); i++)
            {
                if (i == 0)
                {
                    sb.Append(" SearchKey like '%" + keywordArray[i] + "%'");
                }
                else
                {
                    sb.Append(" and SearchKey like '%" + keywordArray[i] + "%'");
                }
            }

            //メーカー検索条件
            if (!String.IsNullOrEmpty(manufacturer))
            {
                sb.Append(ManufacturerPartWhere(db, manufacturer, false));
            }

            //戻り値
            if (sb.Length == 0)
            {
                return "Empty";
            }
            else
            {
                sb.Insert(0, "select * from products where");
                return sb.ToString();
            }
        }

        public string AssembleProductAttributeWhere(DefaultConnection db, string businessPartner, string manufacturer, string keywords)
        {
            bool[] elements = new bool[3] { String.IsNullOrEmpty(businessPartner),
                                            String.IsNullOrEmpty(manufacturer),
                                            String.IsNullOrEmpty(keywords) };

            switch (Convert.ToInt32(elements[0]).ToString() + Convert.ToInt32(elements[1]).ToString() + Convert.ToInt32(elements[2]).ToString())
            {
                case "110"://商品検索のみ
                    StringBuilder sb110 = new StringBuilder();
                    sb110.Append(ProductPartWhere(keywords));
                    sb110.Insert(0, "Select * from readableproductattributes where");
                    return sb110.ToString();

                case "101"://メーカー検索のみ
                    StringBuilder sb101 = new StringBuilder();
                    sb101.Append(ManufacturerPartWhere(db, manufacturer, true));
                    sb101.Insert(0, "Select * from readableproductattributes where");
                    return sb101.ToString();

                case "011"://取引先のみ
                    StringBuilder sb011 = new StringBuilder();
                    sb011.Append(BusinessPartnerPartWhere(db, businessPartner, true));
                    return sb011.ToString();

                case "100"://メーカーと商品
                    StringBuilder sb100 = new StringBuilder();
                    sb100.Append(ManufacturerPartWhere(db, manufacturer, true));
                    sb100.Append(ProductPartWhere(keywords));
                    return sb100.ToString();

                case "010"://取引先と商品
                    StringBuilder sb010 = new StringBuilder();
                    sb010.Append(BusinessPartnerPartWhere(db, businessPartner, true));
                    sb010.Append(ProductPartWhere(keywords));
                    return sb010.ToString();

                case "000"://全て
                    StringBuilder sb000 = new StringBuilder();
                    sb000.Append(BusinessPartnerPartWhere(db, businessPartner, true));
                    sb000.Append(ManufacturerPartWhere(db, manufacturer, false));
                    sb000.Append(ProductPartWhere(keywords));
                    return sb000.ToString();

                default:
                    return "Empty";
            }
        }

        private static string BusinessPartnerPartWhere(DefaultConnection db, string businessPartner, bool thisOnly)
        {
            StringBuilder sb = new StringBuilder();
            int businessPartner_Id = NameToId.BusinessPartner(db, businessPartner);
            if (businessPartner_Id != 0)
            {
                if (thisOnly)
                {
                    sb.Append(" BusineePartner_Id = " + businessPartner_Id + "");
                    return sb.ToString();
                }
                else
                {
                    sb.Append(" and BusineePartner_Id = " + businessPartner_Id + "");
                    return sb.ToString();
                }
            }
            else
            {
                return sb.ToString();
            }
        }

        private static string ManufacturerPartWhere(DefaultConnection db, string manufacturer, bool thisOnly)
        {
            StringBuilder sb = new StringBuilder();
            int manufacturer_Id = NameToId.Manufacturer(db, manufacturer);//""(未指定)は0を返す。
            if (manufacturer_Id != 0)
            {
                if (thisOnly)
                {
                    sb.Append(" Manufacturer_Id = " + manufacturer_Id + "");
                    return sb.ToString();
                }
                else
                {
                    sb.Append(" and Manufacturer_Id = " + manufacturer_Id + "");
                    return sb.ToString();
                }
            }
            else
            {
                return sb.ToString();
            }
        }

        private static string ProductPartWhere(string keywords)
        {
            StringBuilder sb = new StringBuilder();
            string[] keywordArray = keywords.Split(new[] { ' ', '　' });
            for (int i = 0; i < keywordArray.Count(); i++)
            {
                if (i == 0)
                {
                    sb.Append(" SearchKey like '%" + keywordArray[i] + "%'");
                }
                else
                {
                    sb.Append(" and SearchKey like '%" + keywordArray[i] + "%'");
                }
            }
            return sb.ToString();
        }
    }
}