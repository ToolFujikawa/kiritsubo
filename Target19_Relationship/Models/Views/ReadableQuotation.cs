using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Target19_Relationship.Models.Tables;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Views
{
    public partial class ReadableQuotation : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("中止")]
        public bool IsCancel { get; set; }

        [DisplayName("入力日")]
        public DateTime InputDate { get; set; }

        [DisplayName("問合せ発信日")]
        public DateTime ContactOutgoingDate { get; set; }

        [DisplayName("見積番号")]
        public int EstimateNo { get; set; }

        [DisplayName("見積詳細")]
        public string Detail { get; set; }

        [DisplayName("責任者Id")]
        public int ResponsibleStaff_Id { get; set; }

        [DisplayName("依頼者Id")]
        public int Helper_Id { get; set; }

        [DisplayName("受注先Id")]
        public int Customer_Id { get; set; }

        [DisplayName("有効期間")]
        [EnumDataType(typeof(ValidityPeriods))]
        public ValidityPeriods ValidityPeriod { get; set; }

        [DisplayName("支払い条件")]
        [EnumDataType(typeof(PaymentTerms))]
        public PaymentTerms PaymentTerm { get; set; }

        [DisplayName("提出日")]
        public DateTime SubmissionDate { get; set; }

        [DisplayName("商品Id")]
        public int Product_Id { get; set; }

        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("単価")]
        public decimal UnitPrice { get; set; }

        [DisplayName("納期")]
        public string Arrival { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        public int Manufacturer_Id { get; set; }

        [DisplayName("責任者")]
        public string ResponsibleStaff { get; set; }

        [DisplayName("責任者")]
        public string Helper { get; set; }

        [DisplayName("販売先")]
        public string Customer { get; set; }

        [DisplayName("商品")]
        public string Product { get; set; }

        [DisplayName("取引単位")]
        public string Unit { get; set; }

        public string SearchKey { get; set; }
    }
}