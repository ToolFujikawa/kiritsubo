using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Target19_Relationship.Models.Views
{
    public class ReadableSale
    {
        public int Id { get; set; }

        public int SalesOrder_Id { get; set; }

        [DisplayName("中止")]
        public bool IsCancel { get; set; }

        [DisplayName("専用納品書")]
        public bool IsExclusiveDeliveryNote { get; set; }

        [DisplayName("受注詳細")]
        public int SalesOrderDetail { get; set; }

        [DisplayName("受注責任者Id")]
        public int SalesOrderResponsibleStaff_Id { get; set; }

        [DisplayName("受注責任者")]
        public string SalesOrderResponsibleStaff { get; set; }

        [DisplayName("発注者Id")]
        public int Helper_Id { get; set; }

        [DisplayName("発注者")]
        public string Helper { get; set; }

        [DisplayName("受注先Id")]
        public int Customer_Id { get; set; }

        [DisplayName("受注先")]
        public string Customer { get; set; }

        [DisplayName("納品場所Id")]
        public int DeliveryPlace_Id { get; set; }

        [DisplayName("納品場所")]
        public string DeliveryPlace { get; set; }

        [DisplayName("商品Id")]
        public int Product_Id { get; set; }

        [DisplayName("商品")]
        public string Product { get; set; }

        [DisplayName("受注数")]
        public int SalesOrderQuantity { get; set; }

        [DisplayName("受注日")]
        public int SalesOrderDate { get; set; }

        [DisplayName("受注主番号")]
        public int OrderMainNo { get; set; }

        [DisplayName("受注枝番号")]
        public int OrderBranchNo { get; set; }

        [DisplayName("発注済")]
        public bool IsParchase { get; set; }

        [DisplayName("分納可")]
        public bool IsSeparateDelivery { get; set; }

        [DisplayName("想定売上")]
        public int EstimatedSale { get; set; }

        [DisplayName("受注備考")]
        public int SaleOrderNote { get; set; }

        [DisplayName("受注記録者Id")]
        public int SalesOrderRecorder_Id { get; set; }

        [DisplayName("受注更新者Id")]
        public int SalesOrderChanger_Id { get; set; }

        [DisplayName("納品書発行遅延")]
        public string IsLater { get; set; }

        [DisplayName("販売数")]
        public string SalesQuantity { get; set; }

        [DisplayName("単価")]
        public string UnitPrice { get; set; }

        [DisplayName("適用税率")]
        public string TaxRate { get; set; }

        [DisplayName("売上日")]
        public string SalesDate { get; set; }

        [DisplayName("売上詳細")]
        public string SalesDetail { get; set; }

        [DisplayName("伝票種別Id")]
        public int DocumentType_Id { get; set; }

        [DisplayName("納品書番号")]
        public string DeliveryNoteNo { get; set; }

        [DisplayName("納品状態Id")]
        public int DeliveryStatus_Id { get; set; }

        [DisplayName("請求書番号")]
        public string InvoiceNo { get; set; }

        [DisplayName("請求日")]
        public string BilledDate { get; set; }

        [DisplayName("売上備考")]
        public string SalesNote { get; set; }

        [DisplayName("売上記録者Id")]
        public int SalesRecorder_Id { get; set; }

        [DisplayName("売上更新者Id")]
        public int SalesChanger_Id { get; set; }
    }
}