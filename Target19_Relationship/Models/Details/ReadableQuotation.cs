using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Target19_Relationship.Models.Tables;

namespace Target19_Relationship.Models.Details
{
    public class ReadableQuotation : Quotation
    {
        [DisplayName("担当者")]//継承元のモデルに同名のナビゲーションプロパティがあり、newキーワードを付加
        public new string ResponsibleStaff { get; set; }

        [DisplayName("販売先担当者")]
        public new string Helper { get; set; }

        [DisplayName("販売先")]
        public string Customer { get; set; }

        [DisplayName("商品")]
        public new string Product { get; set; }

        [DisplayName("単位")]
        public string Unit { get; set; }
    }
}