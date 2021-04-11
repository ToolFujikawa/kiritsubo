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

        [DisplayName("")]
        public DateTime InputDate { get; set; }

        [DisplayName("")]
        public DateTime ContactOutgoingDate { get; set; }

        [DisplayName("")]
        public int QuotationNo { get; set; }

        [DisplayName("")]
        public int InqueryNo { get; set; }

        [DisplayName("")]
        public string Detail { get; set; }

        [DisplayName("")]
        public int ResponsibleStaff_Id { get; set; }

        [DisplayName("")]
        public string ResponsibleStaff { get; set; }

        [DisplayName("")]
        public int Helper_Id { get; set; }

        [DisplayName("")]
        public string Helper { get; set; }

        [DisplayName("")]
        public int Customer_Id { get; set; }

        [DisplayName("")]
        public string Customer { get; set; }

        [DisplayName("有効期間")]
        [EnumDataType(typeof(ValidityPeriods))]
        public ValidityPeriods ValidityPeriod { get; set; }

        [DisplayName("支払い条件")]
        [EnumDataType(typeof(PaymentTerms))]
        public PaymentTerms PaymentTerm { get; set; }

        [DisplayName("")]
        public DateTime SubmissionDate { get; set; }

        [DisplayName("")]
        public int Product_Id { get; set; }

        [DisplayName("")]
        public int Manufacturer_Id { get; set; }

        [DisplayName("")]
        public string Product { get; set; }

        [DisplayName("")]
        public int Quantity { get; set; }

        [DisplayName("")]
        public string Unit { get; set; }

        [DisplayName("")]
        public decimal UnitPrice { get; set; }

        [DisplayName("")]
        public string Arrival { get; set; }

        [DisplayName("")]
        public string Note { get; set; }

        public string SearchKey { get; set; }
    }
}