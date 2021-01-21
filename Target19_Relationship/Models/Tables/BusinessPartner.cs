using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Tables
{
    public partial class BusinessPartner : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("取引停止")]
        public bool IsHalted { get; set; }

        [DisplayName("輸出")]
        public bool IsExport { get; set; }

        [DisplayName("正式社名")]
        public string FormalName { get; set; }

        [DisplayName("一般社名")]
        public string CommonName { get; set; }

        [DisplayName("手形統合名")]
        public string IntegratedName { get; set; }

        [DisplayName("フリガナ")]
        public string Furigana { get; set; }

        [DisplayName("電話番号")]
        public string PhoneNo { get; set; }

        [DisplayName("ファックス番号")]
        public string FAXNo { get; set; }

        [DisplayName("郵便番号")]
        public string ZIPCode { get; set; }

        [DisplayName("都道府県")]
        public string Prefecture { get; set; }

        [DisplayName("市区町村")]
        public string City { get; set; }

        [DisplayName("番地")]
        public string Address { get; set; }

        [DisplayName("番地以降")]
        public string StreetAddress { get; set; }

        [DisplayName("買掛金残高")]
        public decimal AccountsPayable { get; set; }
        
        [DisplayName("買掛金締日")]
        [EnumDataType(typeof(Days))]
        public Days AccountsPayableClosingDay { get; set; }

        [DisplayName("売掛金残高")]
        public decimal AccountsReceivable { get; set; }

        [DisplayName("売掛金締日")]
        [EnumDataType(typeof(Days))]
        public Days AccountsReceivableClosingDay { get; set; }

        [DisplayName("支払サイト")]
        [EnumDataType(typeof(DeferPeriod))]
        public DeferPeriod PaymentSite { get; set; }

        [DisplayName("受取サイト")]
        [EnumDataType(typeof(DeferPeriod))]
        public DeferPeriod ReceivingSite { get; set; }

        [DisplayName("支払方法")]
        [EnumDataType(typeof(RemittanceMethod))]
        public RemittanceMethod PaymentMethod { get; set; }

        [DisplayName("受取方法")]
        [EnumDataType(typeof(RemittanceMethod))]
        public RemittanceMethod ReceivingMethod { get; set; }

        [DisplayName("支払日")]
        [EnumDataType(typeof(Days))]
        public Days PaymentDate { get; set; }

        [DisplayName("集金日")]
        [EnumDataType(typeof(Days))]
        public Days CollectionDate { get; set; }

        [DisplayName("専用伝票")]
        public int IsExclusiveDeliveryNote { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }
        
        [DisplayName("FIMS_Id")]
        public string FIMS_Id { get; set; }

        //ナビゲーションプロパティ
        public virtual ICollection<Journal> Journals { get; set; }

        public virtual ICollection<Journal> Transferees { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<PurchaseOrder> Suppliers { get; set; }

        public virtual ICollection<SalesOrder> Customers { get; set; }
    }
}