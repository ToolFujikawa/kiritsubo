using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Details
{
    public class ReadablePurchase
    {
        public int Id { get; set; }

        [DisplayName("仕入先Id")]
        public int Supplier_Id { get; set; }

        [DisplayName("仕入先")]
        public string Supplier { get; set; }

        [DisplayName("メーカーId")]
        public int Product_Id { get; set; }

        [DisplayName("メーカー")]
        public string Product { get; set; }

        [DisplayName("発注数")]
        public int PurchaseOrderQuantity { get; set; }

        [DisplayName("発注詳細")]
        public string Detail { get; set; }

        [DisplayName("発注責任者Id")]
        public int ResponsibleStaff_Id { get; set; }

        [DisplayName("発注責任者")]
        public string ResponsibleStaff { get; set; }

        [DisplayName("発注日")]
        public DateTime PurchaseDate { get; set; }

        [DisplayName("発注手段")]
        [EnumDataType(typeof(PurchaseMethods))]
        public PurchaseMethods PurchaseMethod_Id { get; set; }

        [DisplayName("納期")]
        public DateTime DeliveryDate { get; set; }

        [DisplayName("納期述語")]
        [EnumDataType(typeof(DeliveryDateInstructions))]
        public DeliveryDateInstructions DeliveryDateInstruction_Id { get; set; }

        [DisplayName("希望価格")]
        public decimal AskingPrice { get; set; }

        [DisplayName("発注備考")]
        public string PurchaseOrderNote { get; set; }

        [DisplayName("受注Id")]
        public int SalesOrder_Id { get; set; }

        [DisplayName("受注詳細")]
        public string SalesOrderDetail { get; set; }

        [DisplayName("中止")]
        public bool IsCancel { get; set; }

        [DisplayName("記録者Id")]
        public int PurchaseOrderRecorder_Id { get; set; }

        [DisplayName("更新者Id")]
        public int PurchaseOrderChanger_Id { get; set; }

        public int PurchaseOrderFIMS_Id { get; set; }

        public int PurchaseOrder_Id { get; set; }

        [DisplayName("入庫日")]
        public DateTime ReceiptDate { get; set; }
        
        [DisplayName("被請求日")]
        public DateTime BilledDate { get; set; }

        [DisplayName("入庫数")]
        public int PurchaseQuantity { get; set; }

        [DisplayName("単価")]
        public decimal UnitPrice { get; set; }

        [DisplayName("税率")]
        public int TaxRate { get; set; }

        [DisplayName("仕入備考")]
        public string PurchaseNote { get; set; }

        public int PurchaseFIMS_Id { get; set; }
    }
}