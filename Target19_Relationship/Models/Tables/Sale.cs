using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Tables
{
    public partial class Sale : CreationRecord
    {
        public int Id { get; set; }

        [DisplayName("受注Id")]
        public int SalesOrder_Id { get; set; }

        [DisplayName("納品書発行遅延")]
        public bool IsLater { get; set; }

        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("単価")]
        public decimal UnitPrice { get; set; }

        [DisplayName("税率")]
        public int TaxRate { get; set; }

        [DisplayName("売上日")]
        public DateTime SalesDate { get; set; }
        
        [DisplayName("詳細")]
        public string Detail { get; set; }
        
        [DisplayName("伝票種別")]
        [EnumDataType(typeof(DocumentTypes))]
        public DocumentTypes DocumentType_Id { get; set; }

        [DisplayName("納品書番号")]
        public int DeliveryNoteNo { get; set; }

        [DisplayName("納品状態")]
        [EnumDataType(typeof(DeliveryStatus))]
        public DeliveryStatus DeliveryStatus_Id { get; set; }

        [DisplayName("請求書番号")]
        public int InvoiceNo { get; set; }

        [DisplayName("請求日")]
        public DateTime BilledDate { get; set; }

        [DisplayName("備考")]
        public string Note { get; set; }

        //ナビゲーションプロパティ
        [ForeignKey("SalesOrder_Id")]
        public virtual SalesOrder SalesOrder { get; set; }
    }
}