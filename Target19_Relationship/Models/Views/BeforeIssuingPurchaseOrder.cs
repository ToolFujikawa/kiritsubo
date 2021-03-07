using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Target19_Relationship.Models.Details;
using static Target19_Relationship.Models.Enums;

namespace Target19_Relationship.Models.Views
{
    public partial class BeforeIssuingPurchaseOrder
    {
        public int Id { get; set; }

        [DisplayName("中止")]
        public bool IsCancel { get; set; }

        [DisplayName("専用納品書")]
        public bool IsExclusiveDeliveryNote { get; set; }

        [DisplayName("受注詳細")]
        public string SalesOrderDetail { get; set; }

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

        public int Manufacturer_id { get; set; }

        [DisplayName("商品")]
        public string Product { get; set; }

        [DisplayName("受注数")]
        public int SalesOrderQuantity { get; set; }

        [DisplayName("単位")]
        public string SalesOrderUnit { get; set; }

        [DisplayName("受注日")]
        public DateTime SalesOrderDate { get; set; }

        [DisplayName("受注主番号")]
        public string OrderMainNo { get; set; }

        [DisplayName("受注枝番号")]
        public string OrderBranchNo { get; set; }

        [DisplayName("発注済")]
        public bool IsParchase { get; set; }

        [DisplayName("分納可")]
        public bool IsSeparateDelivery { get; set; }

        [DisplayName("想定売上")]
        public decimal EstimatedSale { get; set; }

        [DisplayName("受注備考")]
        public string SaleOrderNote { get; set; }

        [DisplayName("受注記録者Id")]
        public int SalesOrderRecorder_Id { get; set; }

        [DisplayName("受注更新者Id")]
        public int SalesOrderChanger_Id { get; set; }

    }
}