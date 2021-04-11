using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Views
{
    public partial class BeforeSubmittingQuotation
    {
        public int Id { get; set; }

        [DisplayName("責任者")]
        public string ResponsibleStaff { get; set; }

        [DisplayName("販売先")]
        public string Customer { get; set; }

        [DisplayName("担当者")]
        public string Helper { get; set; }

        [DisplayName("商品")]
        public string Product { get; set; }

        [DisplayName("原価")]
        public Decimal Cost { get; set; }

        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("単位")]
        public string Unit { get; set; }

        [DisplayName("単価")]
        public decimal UnitPrice { get; set; }

        [DisplayName("納期")]
        public string Arrival { get; set; }

        [DisplayName("明細")]
        public string Detail { get; set; }

        [DisplayName("有効期間")]
        [EnumDataType(typeof(ValidityPeriods))]
        public ValidityPeriods ValidityPeriod { get; set; }

        [DisplayName("支払い条件")]
        [EnumDataType(typeof(PaymentTerms))]
        public PaymentTerms PaymentTerm { get; set; }
    }
}