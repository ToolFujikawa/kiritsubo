using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Views
{
    public partial class ReadableSale : CreationRecord
    {
        public int Id { get; set; }

        public int SalesOrder_Id { get; set; }
        [DisplayName("中止")]
        public bool IsCancel { get; set; }
        [DisplayName("専用納品書")]
        public bool IsExclusiveDeliveryNote { get; set; }
        [DisplayName("受注明細")]
        public string SalesOrderDetail { get; set; }
        [DisplayName("受注者Id")]
        public int ResponsibleStaff_Id { get; set; }
        [DisplayName("受注者")]
        public string ResponsibleStaff { get; set; }
        [DisplayName("販売先担当者Id")]
        public int Helper_Id { get; set; }
        [DisplayName("販売先担当者")]
        public string Helper { get; set; }
        [DisplayName("販売先Id")]
        public int Customer_Id { get; set; }
        [DisplayName("販売先")]
        public string Customer { get; set; }
        [DisplayName("納品場所Id")]
        public int DeliveryPlace_Id { get; set; }
        [DisplayName("納品場所")]
        public string DeliveryPlace { get; set; }
        [DisplayName("商品Id")]
        public int Product_Id { get; set; }
        [DisplayName("メーカーId")]
        public int Manufacturer_Id { get; set; }
        [DisplayName("商品")]
        public string Product { get; set; }
        [DisplayName("受注数")]
        public string SalesOrderQuantity { get; set; }
        [DisplayName("単位")]
        public string Unit { get; set; }
        [DisplayName("受注日")]
        public DateTime SalesOrderDate { get; set; }
        [DisplayName("注文主番号")]
        public string OrderMainNo { get; set; }
        [DisplayName("注文枝番号")]
        public string OrderBranchNo { get; set; }
        [DisplayName("発注済")]
        public bool IsParchase { get; set; }
        [DisplayName("分納可")]
        public bool IsSeparateDelivery { get; set; }
        [DisplayName("想定売上")]
        public decimal EstimatedSale { get; set; }
        [DisplayName("受注備考")]
        public string SalesOrderNote { get; set; }
        [DisplayName("納品書発行遅延")]
        public bool IsLater { get; set; }
        [DisplayName("数量")]
        public string Quantity { get; set; }
        [DisplayName("単価")]
        public decimal UnitPrice { get; set; }
        [DisplayName("税率")]
        public string TaxRate { get; set; }
        [DisplayName("売上日")]
        public DateTime SalesDate { get; set; }
        [DisplayName("売上詳細")]
        public string SalesDetail { get; set; }
        [DisplayName("伝票種別")]
        [EnumDataType(typeof(DocumentTypes))]
        public DocumentTypes DocumentType_Id { get; set; }
        [DisplayName("納品書番号")]
        public string DeliveryNoteNo { get; set; }
        [DisplayName("納品状態")]
        [EnumDataType(typeof(DeliveryStatus))]
        public DeliveryStatus DeliveryStatus_Id { get; set; }
        [DisplayName("請求書番号")]
        public int InvoiceNo { get; set; }
        [DisplayName("請求日")]
        public DateTime BilledDate { get; set; }
        [DisplayName("売上備考")]
        public string SalesNote { get; set; }
        
        public string SearchKey { get; set; }
    }
}