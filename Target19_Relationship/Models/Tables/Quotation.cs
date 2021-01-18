using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Target19_Relationship.Models;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Tables
{
    public partial class Quotation : CreationRecord
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

        //ナビゲーションプロパティ
        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }

        [ForeignKey("ResponsibleStaff_Id")]
        public virtual Staff ResponsibleStaff { get; set; }

        [ForeignKey("Customer_Id")]
        public virtual BusinessPartner BusinessPartner { get; set; }

        [ForeignKey("Helper_Id")]
        public virtual Helper Helper { get; set; }

        public virtual ICollection<BusinessPartnerEMailAddress> BusinessPartnerEMailAddresses { get; set; }
    }
}